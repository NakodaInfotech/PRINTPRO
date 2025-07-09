<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MultipleProductionClose
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
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GORDERNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GJOBDOCKETNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCLIENTNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALCUTSHEET = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPRODUCTIONSRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CMBREASON = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.RBENTERED = New System.Windows.Forms.RadioButton()
        Me.RBPENDING = New System.Windows.Forms.RadioButton()
        Me.CMDREFRESH = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.PrinToExcel = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.GPRODUCTIONNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CMBREASON, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.RBENTERED)
        Me.BlendPanel1.Controls.Add(Me.RBPENDING)
        Me.BlendPanel1.Controls.Add(Me.CMDREFRESH)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1049, 581)
        Me.BlendPanel1.TabIndex = 9
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(8, 51)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CMBREASON})
        Me.gridbilldetails.Size = New System.Drawing.Size(1029, 487)
        Me.gridbilldetails.TabIndex = 808
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GPRODUCTIONNO, Me.GPRODUCTIONSRNO, Me.GORDERNO, Me.GJOBDOCKETNO, Me.GCLIENTNAME, Me.GITEMNAME, Me.GTOTALCUTSHEET})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsSelection.CheckBoxSelectorColumnWidth = 40
        Me.gridbill.OptionsSelection.MultiSelect = True
        Me.gridbill.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.gridbill.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.[True]
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        Me.gridbill.OptionsView.ShowGroupPanel = False
        '
        'GORDERNO
        '
        Me.GORDERNO.Caption = "Order No"
        Me.GORDERNO.FieldName = "ORDERNO"
        Me.GORDERNO.Name = "GORDERNO"
        Me.GORDERNO.OptionsColumn.AllowEdit = False
        Me.GORDERNO.Visible = True
        Me.GORDERNO.VisibleIndex = 3
        Me.GORDERNO.Width = 100
        '
        'GJOBDOCKETNO
        '
        Me.GJOBDOCKETNO.Caption = "Job Docket No"
        Me.GJOBDOCKETNO.FieldName = "JOBNO"
        Me.GJOBDOCKETNO.Name = "GJOBDOCKETNO"
        Me.GJOBDOCKETNO.OptionsColumn.AllowEdit = False
        Me.GJOBDOCKETNO.Visible = True
        Me.GJOBDOCKETNO.VisibleIndex = 4
        Me.GJOBDOCKETNO.Width = 80
        '
        'GCLIENTNAME
        '
        Me.GCLIENTNAME.Caption = "Client Name"
        Me.GCLIENTNAME.FieldName = "NAME"
        Me.GCLIENTNAME.Name = "GCLIENTNAME"
        Me.GCLIENTNAME.OptionsColumn.AllowEdit = False
        Me.GCLIENTNAME.Visible = True
        Me.GCLIENTNAME.VisibleIndex = 5
        Me.GCLIENTNAME.Width = 250
        '
        'GITEMNAME
        '
        Me.GITEMNAME.Caption = "Product Name"
        Me.GITEMNAME.FieldName = "ITEMNAME"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.OptionsColumn.AllowEdit = False
        Me.GITEMNAME.Visible = True
        Me.GITEMNAME.VisibleIndex = 6
        Me.GITEMNAME.Width = 250
        '
        'GTOTALCUTSHEET
        '
        Me.GTOTALCUTSHEET.Caption = "Total Cut Sheet"
        Me.GTOTALCUTSHEET.FieldName = "QTY"
        Me.GTOTALCUTSHEET.Name = "GTOTALCUTSHEET"
        Me.GTOTALCUTSHEET.OptionsColumn.AllowEdit = False
        Me.GTOTALCUTSHEET.Visible = True
        Me.GTOTALCUTSHEET.VisibleIndex = 7
        Me.GTOTALCUTSHEET.Width = 100
        '
        'GPRODUCTIONSRNO
        '
        Me.GPRODUCTIONSRNO.Caption = "Grid Sr No"
        Me.GPRODUCTIONSRNO.FieldName = "GRIDSRNO"
        Me.GPRODUCTIONSRNO.Name = "GPRODUCTIONSRNO"
        Me.GPRODUCTIONSRNO.OptionsColumn.AllowEdit = False
        Me.GPRODUCTIONSRNO.Visible = True
        Me.GPRODUCTIONSRNO.VisibleIndex = 2
        Me.GPRODUCTIONSRNO.Width = 100
        '
        'CMBREASON
        '
        Me.CMBREASON.AutoHeight = False
        Me.CMBREASON.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CMBREASON.Name = "CMBREASON"
        '
        'RBENTERED
        '
        Me.RBENTERED.AutoSize = True
        Me.RBENTERED.BackColor = System.Drawing.Color.Transparent
        Me.RBENTERED.Location = New System.Drawing.Point(170, 31)
        Me.RBENTERED.Name = "RBENTERED"
        Me.RBENTERED.Size = New System.Drawing.Size(66, 19)
        Me.RBENTERED.TabIndex = 807
        Me.RBENTERED.Text = "Entered"
        Me.RBENTERED.UseVisualStyleBackColor = False
        '
        'RBPENDING
        '
        Me.RBPENDING.AutoSize = True
        Me.RBPENDING.BackColor = System.Drawing.Color.Transparent
        Me.RBPENDING.Checked = True
        Me.RBPENDING.Location = New System.Drawing.Point(95, 31)
        Me.RBPENDING.Name = "RBPENDING"
        Me.RBPENDING.Size = New System.Drawing.Size(69, 19)
        Me.RBPENDING.TabIndex = 806
        Me.RBPENDING.TabStop = True
        Me.RBPENDING.Text = "Pending"
        Me.RBPENDING.UseVisualStyleBackColor = False
        '
        'CMDREFRESH
        '
        Me.CMDREFRESH.BackColor = System.Drawing.Color.Transparent
        Me.CMDREFRESH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDREFRESH.FlatAppearance.BorderSize = 0
        Me.CMDREFRESH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDREFRESH.ForeColor = System.Drawing.Color.Black
        Me.CMDREFRESH.Location = New System.Drawing.Point(448, 544)
        Me.CMDREFRESH.Name = "CMDREFRESH"
        Me.CMDREFRESH.Size = New System.Drawing.Size(80, 28)
        Me.CMDREFRESH.TabIndex = 258
        Me.CMDREFRESH.Text = "&Refresh"
        Me.CMDREFRESH.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(534, 544)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 4
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrinToExcel, Me.toolStripSeparator})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1049, 25)
        Me.ToolStrip1.TabIndex = 255
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'PrinToExcel
        '
        Me.PrinToExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrinToExcel.Image = Global.PrintPro.My.Resources.Resources.Excel_icon
        Me.PrinToExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrinToExcel.Name = "PrinToExcel"
        Me.PrinToExcel.Size = New System.Drawing.Size(23, 22)
        Me.PrinToExcel.Text = "&Print"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(362, 544)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 3
        Me.cmdok.Text = "&Save"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'GPRODUCTIONNO
        '
        Me.GPRODUCTIONNO.Caption = "Production No"
        Me.GPRODUCTIONNO.FieldName = "PRODUCTIONNO"
        Me.GPRODUCTIONNO.Name = "GPRODUCTIONNO"
        Me.GPRODUCTIONNO.OptionsColumn.AllowEdit = False
        Me.GPRODUCTIONNO.Visible = True
        Me.GPRODUCTIONNO.VisibleIndex = 1
        '
        'MultipleProductionClose
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1049, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "MultipleProductionClose"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Multiple Production Close"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CMBREASON, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GORDERNO As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GJOBDOCKETNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCLIENTNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALCUTSHEET As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPRODUCTIONSRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMBREASON As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents RBENTERED As RadioButton
    Friend WithEvents RBPENDING As RadioButton
    Friend WithEvents CMDREFRESH As Button
    Friend WithEvents cmdexit As Button
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents PrinToExcel As ToolStripButton
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents cmdok As Button
    Friend WithEvents GPRODUCTIONNO As DevExpress.XtraGrid.Columns.GridColumn
End Class
