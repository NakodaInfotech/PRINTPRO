<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PaperInwardRegister
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
        Me.GREMARKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSIZE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GINSPECTEDBY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCHKACCEPTED = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCHKNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGRNNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridGrn = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GSRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCHALLANNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCHALLANDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLOTNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGSM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRECQTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GINVITEM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRIDGrnDetails = New DevExpress.XtraGrid.GridControl()
        Me.CMDADD = New System.Windows.Forms.Button()
        Me.CMDOK = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.GBILLNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ToolEXCELSHEET.SuspendLayout()
        CType(Me.GridGrn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDGrnDetails, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'GREMARKS
        '
        Me.GREMARKS.Caption = "Remarks"
        Me.GREMARKS.FieldName = "REMARKS"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.Visible = True
        Me.GREMARKS.VisibleIndex = 15
        Me.GREMARKS.Width = 80
        '
        'GSIZE
        '
        Me.GSIZE.Caption = "Size"
        Me.GSIZE.FieldName = "SIZE"
        Me.GSIZE.Name = "GSIZE"
        Me.GSIZE.Visible = True
        Me.GSIZE.VisibleIndex = 10
        Me.GSIZE.Width = 80
        '
        'GINSPECTEDBY
        '
        Me.GINSPECTEDBY.Caption = "Inspected By"
        Me.GINSPECTEDBY.FieldName = "INSPECTEDBY"
        Me.GINSPECTEDBY.Name = "GINSPECTEDBY"
        Me.GINSPECTEDBY.Visible = True
        Me.GINSPECTEDBY.VisibleIndex = 14
        Me.GINSPECTEDBY.Width = 80
        '
        'GCHKACCEPTED
        '
        Me.GCHKACCEPTED.Caption = "Accepted"
        Me.GCHKACCEPTED.FieldName = "ACCEPTED"
        Me.GCHKACCEPTED.Name = "GCHKACCEPTED"
        Me.GCHKACCEPTED.Visible = True
        Me.GCHKACCEPTED.VisibleIndex = 13
        Me.GCHKACCEPTED.Width = 80
        '
        'GWT
        '
        Me.GWT.Caption = "Wt"
        Me.GWT.DisplayFormat.FormatString = "0.00"
        Me.GWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GWT.FieldName = "WT"
        Me.GWT.Name = "GWT"
        Me.GWT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GWT.Visible = True
        Me.GWT.VisibleIndex = 12
        Me.GWT.Width = 80
        '
        'GTYPE
        '
        Me.GTYPE.Caption = "Type"
        Me.GTYPE.FieldName = "TYPE"
        Me.GTYPE.Name = "GTYPE"
        Me.GTYPE.Visible = True
        Me.GTYPE.VisibleIndex = 18
        Me.GTYPE.Width = 100
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
        'GNAME
        '
        Me.GNAME.Caption = "Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 4
        Me.GNAME.Width = 200
        '
        'GDATE
        '
        Me.GDATE.Caption = "Date"
        Me.GDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDATE.FieldName = "DATE"
        Me.GDATE.Name = "GDATE"
        Me.GDATE.Visible = True
        Me.GDATE.VisibleIndex = 2
        Me.GDATE.Width = 80
        '
        'GCHKNO
        '
        Me.GCHKNO.Caption = "Chk No"
        Me.GCHKNO.FieldName = "CHKNO"
        Me.GCHKNO.Name = "GCHKNO"
        Me.GCHKNO.Visible = True
        Me.GCHKNO.VisibleIndex = 0
        Me.GCHKNO.Width = 60
        '
        'GGRNNO
        '
        Me.GGRNNO.Caption = "GRN No."
        Me.GGRNNO.FieldName = "GRNNO"
        Me.GGRNNO.Name = "GGRNNO"
        Me.GGRNNO.Visible = True
        Me.GGRNNO.VisibleIndex = 3
        Me.GGRNNO.Width = 60
        '
        'GridGrn
        '
        Me.GridGrn.AppearancePrint.Preview.BackColor = System.Drawing.Color.White
        Me.GridGrn.AppearancePrint.Preview.Options.UseBackColor = True
        Me.GridGrn.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCHKNO, Me.GSRNO, Me.GDATE, Me.GGRNNO, Me.GNAME, Me.GCHALLANNO, Me.GCHALLANDATE, Me.GITEMNAME, Me.GLOTNO, Me.GGSM, Me.GSIZE, Me.GRECQTY, Me.GWT, Me.GCHKACCEPTED, Me.GINSPECTEDBY, Me.GREMARKS, Me.GINVITEM, Me.GBILLNO, Me.GTYPE})
        Me.GridGrn.GridControl = Me.GRIDGrnDetails
        Me.GridGrn.Name = "GridGrn"
        Me.GridGrn.OptionsBehavior.Editable = False
        Me.GridGrn.OptionsView.ColumnAutoWidth = False
        Me.GridGrn.OptionsView.ShowAutoFilterRow = True
        Me.GridGrn.OptionsView.ShowFooter = True
        Me.GridGrn.PaintStyleName = "Skin"
        '
        'GSRNO
        '
        Me.GSRNO.Caption = "Sr No."
        Me.GSRNO.FieldName = "SRNO"
        Me.GSRNO.Name = "GSRNO"
        Me.GSRNO.Visible = True
        Me.GSRNO.VisibleIndex = 1
        Me.GSRNO.Width = 80
        '
        'GCHALLANNO
        '
        Me.GCHALLANNO.Caption = "Challan No."
        Me.GCHALLANNO.FieldName = "CHALLANNO"
        Me.GCHALLANNO.Name = "GCHALLANNO"
        Me.GCHALLANNO.Visible = True
        Me.GCHALLANNO.VisibleIndex = 5
        Me.GCHALLANNO.Width = 80
        '
        'GCHALLANDATE
        '
        Me.GCHALLANDATE.Caption = "Challan Date"
        Me.GCHALLANDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GCHALLANDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GCHALLANDATE.FieldName = "CHALLANDATE"
        Me.GCHALLANDATE.Name = "GCHALLANDATE"
        Me.GCHALLANDATE.Visible = True
        Me.GCHALLANDATE.VisibleIndex = 6
        Me.GCHALLANDATE.Width = 80
        '
        'GLOTNO
        '
        Me.GLOTNO.Caption = "Lot No."
        Me.GLOTNO.FieldName = "LOTNO"
        Me.GLOTNO.Name = "GLOTNO"
        Me.GLOTNO.Visible = True
        Me.GLOTNO.VisibleIndex = 8
        Me.GLOTNO.Width = 80
        '
        'GGSM
        '
        Me.GGSM.Caption = "Gsm"
        Me.GGSM.FieldName = "GSM"
        Me.GGSM.Name = "GGSM"
        Me.GGSM.Visible = True
        Me.GGSM.VisibleIndex = 9
        Me.GGSM.Width = 80
        '
        'GRECQTY
        '
        Me.GRECQTY.Caption = "Rec Qty"
        Me.GRECQTY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GRECQTY.FieldName = "RECQTY"
        Me.GRECQTY.Name = "GRECQTY"
        Me.GRECQTY.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GRECQTY.Visible = True
        Me.GRECQTY.VisibleIndex = 11
        Me.GRECQTY.Width = 80
        '
        'GINVITEM
        '
        Me.GINVITEM.Caption = "Inv Item"
        Me.GINVITEM.FieldName = "INVITEM"
        Me.GINVITEM.Name = "GINVITEM"
        Me.GINVITEM.Visible = True
        Me.GINVITEM.VisibleIndex = 16
        '
        'GRIDGrnDetails
        '
        Me.GRIDGrnDetails.Location = New System.Drawing.Point(12, 39)
        Me.GRIDGrnDetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GRIDGrnDetails.MainView = Me.GridGrn
        Me.GRIDGrnDetails.Name = "GRIDGrnDetails"
        Me.GRIDGrnDetails.Size = New System.Drawing.Size(1269, 495)
        Me.GRIDGrnDetails.TabIndex = 1
        Me.GRIDGrnDetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridGrn})
        '
        'CMDADD
        '
        Me.CMDADD.BackColor = System.Drawing.Color.Transparent
        Me.CMDADD.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDADD.FlatAppearance.BorderSize = 0
        Me.CMDADD.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDADD.ForeColor = System.Drawing.Color.Black
        Me.CMDADD.Location = New System.Drawing.Point(491, 540)
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
        Me.CMDOK.Location = New System.Drawing.Point(577, 540)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(80, 28)
        Me.CMDOK.TabIndex = 2
        Me.CMDOK.Text = "&Ok"
        Me.CMDOK.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.Location = New System.Drawing.Point(663, 540)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 3
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = True
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.Color.White)
        Me.BlendPanel1.Controls.Add(Me.CMDADD)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.GRIDGrnDetails)
        Me.BlendPanel1.Controls.Add(Me.ToolEXCELSHEET)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 3
        '
        'GBILLNO
        '
        Me.GBILLNO.Caption = "BILL NO"
        Me.GBILLNO.FieldName = "BILLNO"
        Me.GBILLNO.Name = "GBILLNO"
        Me.GBILLNO.OptionsColumn.AllowEdit = False
        Me.GBILLNO.Visible = True
        Me.GBILLNO.VisibleIndex = 17
        Me.GBILLNO.Width = 80
        '
        'PaperInwardRegister
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "PaperInwardRegister"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Paper Inward Register"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolEXCELSHEET.ResumeLayout(False)
        Me.ToolEXCELSHEET.PerformLayout()
        CType(Me.GridGrn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDGrnDetails, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents GREMARKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSIZE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GINSPECTEDBY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHKACCEPTED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHKNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGRNNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridGrn As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GRIDGrnDetails As DevExpress.XtraGrid.GridControl
    Friend WithEvents CMDADD As Button
    Friend WithEvents CMDOK As Button
    Friend WithEvents cmdexit As Button
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents GCHALLANNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHALLANDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLOTNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGSM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRECQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GINVITEM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBILLNO As DevExpress.XtraGrid.Columns.GridColumn
End Class
