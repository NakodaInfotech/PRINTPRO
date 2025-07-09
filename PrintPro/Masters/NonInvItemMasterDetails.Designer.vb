<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NonInvItemMasterDetails
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
        Me.PBEXCEL = New System.Windows.Forms.PictureBox()
        Me.CMDREFRESH = New System.Windows.Forms.Button()
        Me.gridname = New DevExpress.XtraGrid.GridControl()
        Me.gridledger = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Gitemid = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cmdadd = New System.Windows.Forms.Button()
        Me.cmdedit = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.Details = New System.Windows.Forms.TabPage()
        Me.CMBINVITEMNAME = New System.Windows.Forms.ComboBox()
        Me.level4 = New System.Windows.Forms.Label()
        Me.TXTHSNCODE = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TXTGSM = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXTWIDTH = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXTCATEGORY = New System.Windows.Forms.TextBox()
        Me.TXTLENGTH = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtremarks = New System.Windows.Forms.TextBox()
        Me.lblgroup = New System.Windows.Forms.Label()
        Me.CMBPAPERMILL = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CMBPAPERMATERIAL = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.CMBINVITEMCODE = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.PBEXCEL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridname, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridledger, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.Details.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.PBEXCEL)
        Me.BlendPanel1.Controls.Add(Me.CMDREFRESH)
        Me.BlendPanel1.Controls.Add(Me.gridname)
        Me.BlendPanel1.Controls.Add(Me.cmdadd)
        Me.BlendPanel1.Controls.Add(Me.cmdedit)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.TabControl1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 0
        '
        'PBEXCEL
        '
        Me.PBEXCEL.Image = Global.PrintPro.My.Resources.Resources.Excel_icon
        Me.PBEXCEL.Location = New System.Drawing.Point(897, 20)
        Me.PBEXCEL.Name = "PBEXCEL"
        Me.PBEXCEL.Size = New System.Drawing.Size(25, 25)
        Me.PBEXCEL.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBEXCEL.TabIndex = 355
        Me.PBEXCEL.TabStop = False
        '
        'CMDREFRESH
        '
        Me.CMDREFRESH.BackColor = System.Drawing.SystemColors.Control
        Me.CMDREFRESH.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CMDREFRESH.FlatAppearance.BorderSize = 0
        Me.CMDREFRESH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDREFRESH.ForeColor = System.Drawing.Color.Black
        Me.CMDREFRESH.Location = New System.Drawing.Point(928, 17)
        Me.CMDREFRESH.Name = "CMDREFRESH"
        Me.CMDREFRESH.Size = New System.Drawing.Size(80, 28)
        Me.CMDREFRESH.TabIndex = 354
        Me.CMDREFRESH.Text = "&Refresh"
        Me.CMDREFRESH.UseVisualStyleBackColor = True
        '
        'gridname
        '
        Me.gridname.Location = New System.Drawing.Point(21, 30)
        Me.gridname.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridname.MainView = Me.gridledger
        Me.gridname.Name = "gridname"
        Me.gridname.Size = New System.Drawing.Size(407, 510)
        Me.gridname.TabIndex = 322
        Me.gridname.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridledger})
        '
        'gridledger
        '
        Me.gridledger.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridledger.Appearance.Row.Options.UseFont = True
        Me.gridledger.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Gitemid, Me.GITEMNAME})
        Me.gridledger.GridControl = Me.gridname
        Me.gridledger.Name = "gridledger"
        Me.gridledger.OptionsBehavior.Editable = False
        Me.gridledger.OptionsCustomization.AllowColumnMoving = False
        Me.gridledger.OptionsCustomization.AllowGroup = False
        Me.gridledger.OptionsView.ColumnAutoWidth = False
        Me.gridledger.OptionsView.ShowAutoFilterRow = True
        Me.gridledger.OptionsView.ShowGroupPanel = False
        '
        'Gitemid
        '
        Me.Gitemid.Caption = "Item Id"
        Me.Gitemid.FieldName = "ITEMID"
        Me.Gitemid.Name = "Gitemid"
        '
        'GITEMNAME
        '
        Me.GITEMNAME.Caption = "Item Name"
        Me.GITEMNAME.FieldName = "NAME"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.Visible = True
        Me.GITEMNAME.VisibleIndex = 0
        Me.GITEMNAME.Width = 360
        '
        'cmdadd
        '
        Me.cmdadd.BackColor = System.Drawing.Color.Transparent
        Me.cmdadd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdadd.FlatAppearance.BorderSize = 0
        Me.cmdadd.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdadd.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdadd.Location = New System.Drawing.Point(536, 550)
        Me.cmdadd.Name = "cmdadd"
        Me.cmdadd.Size = New System.Drawing.Size(80, 28)
        Me.cmdadd.TabIndex = 317
        Me.cmdadd.Text = "&Add New"
        Me.cmdadd.UseVisualStyleBackColor = False
        '
        'cmdedit
        '
        Me.cmdedit.BackColor = System.Drawing.Color.Transparent
        Me.cmdedit.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.cmdedit.FlatAppearance.BorderSize = 0
        Me.cmdedit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdedit.ForeColor = System.Drawing.Color.Black
        Me.cmdedit.Location = New System.Drawing.Point(1014, 17)
        Me.cmdedit.Name = "cmdedit"
        Me.cmdedit.Size = New System.Drawing.Size(80, 28)
        Me.cmdedit.TabIndex = 321
        Me.cmdedit.Text = "&Edit"
        Me.cmdedit.UseVisualStyleBackColor = True
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(619, 550)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 320
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.Details)
        Me.TabControl1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(437, 30)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(781, 268)
        Me.TabControl1.TabIndex = 319
        '
        'Details
        '
        Me.Details.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.Details.Controls.Add(Me.CMBPAPERMILL)
        Me.Details.Controls.Add(Me.Label9)
        Me.Details.Controls.Add(Me.CMBPAPERMATERIAL)
        Me.Details.Controls.Add(Me.Label13)
        Me.Details.Controls.Add(Me.CMBINVITEMCODE)
        Me.Details.Controls.Add(Me.Label3)
        Me.Details.Controls.Add(Me.CMBINVITEMNAME)
        Me.Details.Controls.Add(Me.level4)
        Me.Details.Controls.Add(Me.TXTHSNCODE)
        Me.Details.Controls.Add(Me.Label8)
        Me.Details.Controls.Add(Me.TXTGSM)
        Me.Details.Controls.Add(Me.Label2)
        Me.Details.Controls.Add(Me.TXTWIDTH)
        Me.Details.Controls.Add(Me.Label1)
        Me.Details.Controls.Add(Me.TXTCATEGORY)
        Me.Details.Controls.Add(Me.TXTLENGTH)
        Me.Details.Controls.Add(Me.Label6)
        Me.Details.Controls.Add(Me.GroupBox5)
        Me.Details.Controls.Add(Me.lblgroup)
        Me.Details.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Details.Location = New System.Drawing.Point(4, 24)
        Me.Details.Name = "Details"
        Me.Details.Padding = New System.Windows.Forms.Padding(3)
        Me.Details.Size = New System.Drawing.Size(773, 240)
        Me.Details.TabIndex = 0
        Me.Details.Text = "Details"
        '
        'CMBINVITEMNAME
        '
        Me.CMBINVITEMNAME.BackColor = System.Drawing.Color.White
        Me.CMBINVITEMNAME.Enabled = False
        Me.CMBINVITEMNAME.FormattingEnabled = True
        Me.CMBINVITEMNAME.Location = New System.Drawing.Point(100, 105)
        Me.CMBINVITEMNAME.MaxLength = 200
        Me.CMBINVITEMNAME.Name = "CMBINVITEMNAME"
        Me.CMBINVITEMNAME.Size = New System.Drawing.Size(273, 23)
        Me.CMBINVITEMNAME.TabIndex = 357
        '
        'level4
        '
        Me.level4.AutoSize = True
        Me.level4.BackColor = System.Drawing.Color.Transparent
        Me.level4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.level4.Location = New System.Drawing.Point(32, 109)
        Me.level4.Name = "level4"
        Me.level4.Size = New System.Drawing.Size(65, 15)
        Me.level4.TabIndex = 358
        Me.level4.Text = "Item Name"
        '
        'TXTHSNCODE
        '
        Me.TXTHSNCODE.BackColor = System.Drawing.Color.White
        Me.TXTHSNCODE.Enabled = False
        Me.TXTHSNCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTHSNCODE.Location = New System.Drawing.Point(267, 49)
        Me.TXTHSNCODE.Name = "TXTHSNCODE"
        Me.TXTHSNCODE.ReadOnly = True
        Me.TXTHSNCODE.Size = New System.Drawing.Size(106, 22)
        Me.TXTHSNCODE.TabIndex = 355
        Me.TXTHSNCODE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(206, 53)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 14)
        Me.Label8.TabIndex = 356
        Me.Label8.Text = "HSN Code"
        '
        'TXTGSM
        '
        Me.TXTGSM.BackColor = System.Drawing.Color.White
        Me.TXTGSM.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTGSM.Location = New System.Drawing.Point(100, 77)
        Me.TXTGSM.Name = "TXTGSM"
        Me.TXTGSM.ReadOnly = True
        Me.TXTGSM.Size = New System.Drawing.Size(106, 22)
        Me.TXTGSM.TabIndex = 350
        Me.TXTGSM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(66, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 15)
        Me.Label2.TabIndex = 351
        Me.Label2.Text = "GSM"
        '
        'TXTWIDTH
        '
        Me.TXTWIDTH.BackColor = System.Drawing.Color.White
        Me.TXTWIDTH.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTWIDTH.Location = New System.Drawing.Point(267, 77)
        Me.TXTWIDTH.Name = "TXTWIDTH"
        Me.TXTWIDTH.ReadOnly = True
        Me.TXTWIDTH.Size = New System.Drawing.Size(106, 22)
        Me.TXTWIDTH.TabIndex = 348
        Me.TXTWIDTH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(225, 81)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 14)
        Me.Label1.TabIndex = 349
        Me.Label1.Text = "Width"
        '
        'TXTCATEGORY
        '
        Me.TXTCATEGORY.BackColor = System.Drawing.Color.White
        Me.TXTCATEGORY.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCATEGORY.Location = New System.Drawing.Point(100, 21)
        Me.TXTCATEGORY.Name = "TXTCATEGORY"
        Me.TXTCATEGORY.ReadOnly = True
        Me.TXTCATEGORY.Size = New System.Drawing.Size(273, 22)
        Me.TXTCATEGORY.TabIndex = 347
        '
        'TXTLENGTH
        '
        Me.TXTLENGTH.BackColor = System.Drawing.Color.White
        Me.TXTLENGTH.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTLENGTH.Location = New System.Drawing.Point(100, 49)
        Me.TXTLENGTH.Name = "TXTLENGTH"
        Me.TXTLENGTH.ReadOnly = True
        Me.TXTLENGTH.Size = New System.Drawing.Size(106, 22)
        Me.TXTLENGTH.TabIndex = 337
        Me.TXTLENGTH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(54, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 15)
        Me.Label6.TabIndex = 342
        Me.Label6.Text = "Length"
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.txtremarks)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox5.Location = New System.Drawing.Point(388, 21)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(259, 95)
        Me.GroupBox5.TabIndex = 339
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Remarks"
        '
        'txtremarks
        '
        Me.txtremarks.BackColor = System.Drawing.Color.White
        Me.txtremarks.ForeColor = System.Drawing.Color.DimGray
        Me.txtremarks.Location = New System.Drawing.Point(6, 17)
        Me.txtremarks.Multiline = True
        Me.txtremarks.Name = "txtremarks"
        Me.txtremarks.ReadOnly = True
        Me.txtremarks.Size = New System.Drawing.Size(247, 72)
        Me.txtremarks.TabIndex = 0
        '
        'lblgroup
        '
        Me.lblgroup.AutoSize = True
        Me.lblgroup.BackColor = System.Drawing.Color.Transparent
        Me.lblgroup.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblgroup.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblgroup.Location = New System.Drawing.Point(44, 25)
        Me.lblgroup.Name = "lblgroup"
        Me.lblgroup.Size = New System.Drawing.Size(55, 15)
        Me.lblgroup.TabIndex = 340
        Me.lblgroup.Text = "Category"
        Me.lblgroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CMBPAPERMILL
        '
        Me.CMBPAPERMILL.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBPAPERMILL.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBPAPERMILL.FormattingEnabled = True
        Me.CMBPAPERMILL.Location = New System.Drawing.Point(100, 164)
        Me.CMBPAPERMILL.Name = "CMBPAPERMILL"
        Me.CMBPAPERMILL.Size = New System.Drawing.Size(273, 23)
        Me.CMBPAPERMILL.TabIndex = 367
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(31, 168)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 15)
        Me.Label9.TabIndex = 371
        Me.Label9.Text = "Paper Mill"
        '
        'CMBPAPERMATERIAL
        '
        Me.CMBPAPERMATERIAL.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBPAPERMATERIAL.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBPAPERMATERIAL.FormattingEnabled = True
        Me.CMBPAPERMATERIAL.Location = New System.Drawing.Point(100, 135)
        Me.CMBPAPERMATERIAL.Name = "CMBPAPERMATERIAL"
        Me.CMBPAPERMATERIAL.Size = New System.Drawing.Size(273, 23)
        Me.CMBPAPERMATERIAL.TabIndex = 366
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(30, 139)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(66, 15)
        Me.Label13.TabIndex = 370
        Me.Label13.Text = "Paper Type"
        '
        'CMBINVITEMCODE
        '
        Me.CMBINVITEMCODE.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBINVITEMCODE.FormattingEnabled = True
        Me.CMBINVITEMCODE.Location = New System.Drawing.Point(100, 193)
        Me.CMBINVITEMCODE.MaxLength = 200
        Me.CMBINVITEMCODE.Name = "CMBINVITEMCODE"
        Me.CMBINVITEMCODE.Size = New System.Drawing.Size(273, 23)
        Me.CMBINVITEMCODE.TabIndex = 368
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(31, 197)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 15)
        Me.Label3.TabIndex = 369
        Me.Label3.Text = "Item Code"
        '
        'NonInvItemMasterDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.KeyPreview = True
        Me.Name = "NonInvItemMasterDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "NonInv ItemMaster Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        CType(Me.PBEXCEL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridname, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridledger, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.Details.ResumeLayout(False)
        Me.Details.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Private WithEvents gridname As DevExpress.XtraGrid.GridControl
    Private WithEvents gridledger As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdadd As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Details As System.Windows.Forms.TabPage
    Friend WithEvents TXTCATEGORY As System.Windows.Forms.TextBox
    Friend WithEvents TXTLENGTH As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblgroup As System.Windows.Forms.Label
    Friend WithEvents Gitemid As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TXTGSM As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TXTWIDTH As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TXTHSNCODE As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents CMBINVITEMNAME As ComboBox
    Friend WithEvents level4 As Label
    Friend WithEvents PBEXCEL As PictureBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents txtremarks As TextBox
    Private WithEvents cmdedit As Button
    Private WithEvents CMDREFRESH As Button
    Friend WithEvents CMBPAPERMILL As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents CMBPAPERMATERIAL As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents CMBINVITEMCODE As ComboBox
    Friend WithEvents Label3 As Label
End Class
