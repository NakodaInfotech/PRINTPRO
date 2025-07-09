<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PendingForApproval
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PendingForApproval))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.GridOrderDetails = New DevExpress.XtraGrid.GridControl()
        Me.GridPending = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GSRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GITEMCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFILENO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCLIENTNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GARTDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPDFSENDDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOKDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSHADECARDSEND = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSHADECARDAPPROVALDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GVALIDTILL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BlendPanel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.GridOrderDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridPending, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.Color.White)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.GridOrderDetails)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1274, 581)
        Me.BlendPanel1.TabIndex = 2
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintToolStripButton, Me.ToolStripSeparator1, Me.ToolStripRefresh, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1274, 25)
        Me.ToolStrip1.TabIndex = 256
        Me.ToolStrip1.Text = "ToolStrip1"
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
        'cmdexit
        '
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.Location = New System.Drawing.Point(596, 546)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 12
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = True
        '
        'GridOrderDetails
        '
        Me.GridOrderDetails.Location = New System.Drawing.Point(8, 31)
        Me.GridOrderDetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GridOrderDetails.MainView = Me.GridPending
        Me.GridOrderDetails.Name = "GridOrderDetails"
        Me.GridOrderDetails.Size = New System.Drawing.Size(1254, 509)
        Me.GridOrderDetails.TabIndex = 1
        Me.GridOrderDetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridPending})
        '
        'GridPending
        '
        Me.GridPending.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridPending.Appearance.HeaderPanel.Options.UseFont = True
        Me.GridPending.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridPending.Appearance.Row.Options.UseFont = True
        Me.GridPending.AppearancePrint.Preview.BackColor = System.Drawing.Color.White
        Me.GridPending.AppearancePrint.Preview.Options.UseBackColor = True
        Me.GridPending.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GSRNO, Me.GITEMCODE, Me.GITEMNAME, Me.GFILENO, Me.GCLIENTNAME, Me.GARTDATE, Me.GPDFSENDDATE, Me.GOKDATE, Me.GSHADECARDSEND, Me.GSHADECARDAPPROVALDATE, Me.GVALIDTILL})
        Me.GridPending.GridControl = Me.GridOrderDetails
        Me.GridPending.Name = "GridPending"
        Me.GridPending.OptionsView.ColumnAutoWidth = False
        Me.GridPending.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GridPending.OptionsView.ShowAutoFilterRow = True
        Me.GridPending.OptionsView.ShowFooter = True
        Me.GridPending.PaintStyleName = "Skin"
        '
        'GSRNO
        '
        Me.GSRNO.Caption = "Sr No"
        Me.GSRNO.FieldName = "SRNO"
        Me.GSRNO.Name = "GSRNO"
        Me.GSRNO.OptionsColumn.AllowEdit = False
        Me.GSRNO.Width = 50
        '
        'GITEMCODE
        '
        Me.GITEMCODE.Caption = "Item Code"
        Me.GITEMCODE.FieldName = "ITEMCODE"
        Me.GITEMCODE.Name = "GITEMCODE"
        Me.GITEMCODE.OptionsColumn.AllowEdit = False
        Me.GITEMCODE.Visible = True
        Me.GITEMCODE.VisibleIndex = 0
        Me.GITEMCODE.Width = 170
        '
        'GITEMNAME
        '
        Me.GITEMNAME.Caption = "Item Name"
        Me.GITEMNAME.FieldName = "ITEMNAME"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.OptionsColumn.AllowEdit = False
        Me.GITEMNAME.Visible = True
        Me.GITEMNAME.VisibleIndex = 1
        Me.GITEMNAME.Width = 200
        '
        'GFILENO
        '
        Me.GFILENO.Caption = "File No"
        Me.GFILENO.FieldName = "FILENO"
        Me.GFILENO.Name = "GFILENO"
        Me.GFILENO.OptionsColumn.AllowEdit = False
        Me.GFILENO.Visible = True
        Me.GFILENO.VisibleIndex = 2
        Me.GFILENO.Width = 80
        '
        'GCLIENTNAME
        '
        Me.GCLIENTNAME.Caption = "Client Name"
        Me.GCLIENTNAME.FieldName = "NAME"
        Me.GCLIENTNAME.Name = "GCLIENTNAME"
        Me.GCLIENTNAME.OptionsColumn.AllowEdit = False
        Me.GCLIENTNAME.Visible = True
        Me.GCLIENTNAME.VisibleIndex = 3
        Me.GCLIENTNAME.Width = 200
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
        Me.GARTDATE.VisibleIndex = 4
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
        Me.GPDFSENDDATE.VisibleIndex = 5
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
        Me.GOKDATE.VisibleIndex = 6
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
        Me.GSHADECARDSEND.VisibleIndex = 7
        Me.GSHADECARDSEND.Width = 100
        '
        'GSHADECARDAPPROVALDATE
        '
        Me.GSHADECARDAPPROVALDATE.Caption = "Approval Date"
        Me.GSHADECARDAPPROVALDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GSHADECARDAPPROVALDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GSHADECARDAPPROVALDATE.FieldName = "SCADATE"
        Me.GSHADECARDAPPROVALDATE.Name = "GSHADECARDAPPROVALDATE"
        Me.GSHADECARDAPPROVALDATE.OptionsColumn.AllowEdit = False
        Me.GSHADECARDAPPROVALDATE.Visible = True
        Me.GSHADECARDAPPROVALDATE.VisibleIndex = 8
        Me.GSHADECARDAPPROVALDATE.Width = 90
        '
        'GVALIDTILL
        '
        Me.GVALIDTILL.Caption = "Valid Till"
        Me.GVALIDTILL.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GVALIDTILL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GVALIDTILL.FieldName = "VALIDTILL"
        Me.GVALIDTILL.Name = "GVALIDTILL"
        Me.GVALIDTILL.OptionsColumn.AllowEdit = False
        Me.GVALIDTILL.Visible = True
        Me.GVALIDTILL.VisibleIndex = 9
        Me.GVALIDTILL.Width = 80
        '
        'PendingForApproval
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1274, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "PendingForApproval"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Pending For Approval"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.GridOrderDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridPending, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents PrintToolStripButton As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripRefresh As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents cmdexit As Button
    Friend WithEvents GridOrderDetails As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridPending As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GSRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFILENO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GITEMCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCLIENTNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GARTDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPDFSENDDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOKDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSHADECARDSEND As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSHADECARDAPPROVALDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GVALIDTILL As DevExpress.XtraGrid.Columns.GridColumn
End Class
