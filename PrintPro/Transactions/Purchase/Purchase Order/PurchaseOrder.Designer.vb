<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PurchaseOrder
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PurchaseOrder))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.lblgroup = New System.Windows.Forms.Label()
        Me.CMBNAME = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXTDELDAYS = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.DTDELDATE = New System.Windows.Forms.DateTimePicker()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.cmdclear = New System.Windows.Forms.Button()
        Me.txtremarks = New System.Windows.Forms.TextBox()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.tooldelete = New System.Windows.Forms.ToolStripButton()
        Me.TOOLPRINT = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolprevious = New System.Windows.Forms.ToolStripButton()
        Me.toolnext = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tstxtbillno = New System.Windows.Forms.TextBox()
        Me.cmddelete = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TBITEMDTLS = New System.Windows.Forms.TabPage()
        Me.TXTDESC = New System.Windows.Forms.TextBox()
        Me.TXTSRNO = New System.Windows.Forms.TextBox()
        Me.gridbill = New System.Windows.Forms.DataGridView()
        Me.gsrno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GITEMNAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GGSM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GSIZE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GWT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GQTY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GUNIT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GRATE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GAMT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GDESC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GOUTQTY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GCLOSED = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtqty = New System.Windows.Forms.TextBox()
        Me.txtrate = New System.Windows.Forms.TextBox()
        Me.txtamount = New System.Windows.Forms.TextBox()
        Me.CMBUNIT = New System.Windows.Forms.ComboBox()
        Me.txtwt = New System.Windows.Forms.TextBox()
        Me.CMBNONINVITEM = New System.Windows.Forms.ComboBox()
        Me.txtsize = New System.Windows.Forms.TextBox()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TXTIMGPATH = New System.Windows.Forms.TextBox()
        Me.PBSOFTCOPY = New System.Windows.Forms.PictureBox()
        Me.CMDVIEW = New System.Windows.Forms.Button()
        Me.CMDREMOVE = New System.Windows.Forms.Button()
        Me.CMDUPLOAD = New System.Windows.Forms.Button()
        Me.txtuploadname = New System.Windows.Forms.TextBox()
        Me.TXTUPLOADSRNO = New System.Windows.Forms.TextBox()
        Me.txtuploadremarks = New System.Windows.Forms.TextBox()
        Me.gridupload = New System.Windows.Forms.DataGridView()
        Me.GUSRNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GUREMARKS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GUNAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GUIMGPATH = New System.Windows.Forms.DataGridViewImageColumn()
        Me.TXTGSM = New System.Windows.Forms.TextBox()
        Me.lbllocked = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.DTPODATE = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TXTPONO = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbltotalqty = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lbltotalamt = New System.Windows.Forms.Label()
        Me.CMBCODE = New System.Windows.Forms.ComboBox()
        Me.txtadd = New System.Windows.Forms.TextBox()
        Me.CMDCLOSE = New System.Windows.Forms.Button()
        Me.LBLCLOSED = New System.Windows.Forms.Label()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CHKVERIFY = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TXTCOPYPONO = New System.Windows.Forms.TextBox()
        Me.TXTREQNO = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CMDSELECTPURCHASERTN = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TXTSHEETSPERREAM = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.PBlock = New System.Windows.Forms.PictureBox()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TBITEMDTLS.SuspendLayout()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        CType(Me.PBSOFTCOPY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridupload, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.PBlock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'lblgroup
        '
        Me.lblgroup.AutoSize = True
        Me.lblgroup.BackColor = System.Drawing.Color.Transparent
        Me.lblgroup.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblgroup.Location = New System.Drawing.Point(35, 59)
        Me.lblgroup.Name = "lblgroup"
        Me.lblgroup.Size = New System.Drawing.Size(38, 15)
        Me.lblgroup.TabIndex = 160
        Me.lblgroup.Text = "Name"
        '
        'CMBNAME
        '
        Me.CMBNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBNAME.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBNAME.FormattingEnabled = True
        Me.CMBNAME.Items.AddRange(New Object() {""})
        Me.CMBNAME.Location = New System.Drawing.Point(74, 55)
        Me.CMBNAME.MaxLength = 200
        Me.CMBNAME.Name = "CMBNAME"
        Me.CMBNAME.Size = New System.Drawing.Size(190, 23)
        Me.CMBNAME.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(18, 89)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 15)
        Me.Label1.TabIndex = 488
        Me.Label1.Text = "Del Days"
        '
        'TXTDELDAYS
        '
        Me.TXTDELDAYS.BackColor = System.Drawing.Color.White
        Me.TXTDELDAYS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTDELDAYS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDELDAYS.Location = New System.Drawing.Point(74, 85)
        Me.TXTDELDAYS.MaxLength = 10
        Me.TXTDELDAYS.Name = "TXTDELDAYS"
        Me.TXTDELDAYS.Size = New System.Drawing.Size(41, 23)
        Me.TXTDELDAYS.TabIndex = 1
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(121, 88)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(53, 15)
        Me.Label18.TabIndex = 489
        Me.Label18.Text = "Del Date"
        '
        'DTDELDATE
        '
        Me.DTDELDATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTDELDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTDELDATE.Location = New System.Drawing.Point(177, 85)
        Me.DTDELDATE.Name = "DTDELDATE"
        Me.DTDELDATE.Size = New System.Drawing.Size(87, 23)
        Me.DTDELDATE.TabIndex = 2
        '
        'cmdok
        '
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Location = New System.Drawing.Point(307, 424)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 7
        Me.cmdok.Text = "&Save"
        Me.cmdok.UseVisualStyleBackColor = True
        '
        'cmdclear
        '
        Me.cmdclear.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdclear.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdclear.Location = New System.Drawing.Point(395, 424)
        Me.cmdclear.Name = "cmdclear"
        Me.cmdclear.Size = New System.Drawing.Size(80, 28)
        Me.cmdclear.TabIndex = 8
        Me.cmdclear.Text = "&Clear"
        Me.cmdclear.UseVisualStyleBackColor = True
        '
        'txtremarks
        '
        Me.txtremarks.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtremarks.ForeColor = System.Drawing.Color.DimGray
        Me.txtremarks.Location = New System.Drawing.Point(17, 404)
        Me.txtremarks.MaxLength = 2000
        Me.txtremarks.Multiline = True
        Me.txtremarks.Name = "txtremarks"
        Me.txtremarks.Size = New System.Drawing.Size(207, 82)
        Me.txtremarks.TabIndex = 6
        '
        'cmdcancel
        '
        Me.cmdcancel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdcancel.Location = New System.Drawing.Point(571, 424)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(80, 28)
        Me.cmdcancel.TabIndex = 10
        Me.cmdcancel.Text = "E&xit"
        Me.cmdcancel.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripButton, Me.SaveToolStripButton, Me.tooldelete, Me.TOOLPRINT, Me.ToolStripSeparator3, Me.toolprevious, Me.toolnext, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1284, 25)
        Me.ToolStrip1.TabIndex = 734
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'OpenToolStripButton
        '
        Me.OpenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.OpenToolStripButton.Image = CType(resources.GetObject("OpenToolStripButton.Image"), System.Drawing.Image)
        Me.OpenToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenToolStripButton.Name = "OpenToolStripButton"
        Me.OpenToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.OpenToolStripButton.Text = "&Open"
        '
        'SaveToolStripButton
        '
        Me.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveToolStripButton.Image = CType(resources.GetObject("SaveToolStripButton.Image"), System.Drawing.Image)
        Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripButton.Name = "SaveToolStripButton"
        Me.SaveToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.SaveToolStripButton.Text = "&Save"
        '
        'tooldelete
        '
        Me.tooldelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tooldelete.Image = CType(resources.GetObject("tooldelete.Image"), System.Drawing.Image)
        Me.tooldelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tooldelete.Name = "tooldelete"
        Me.tooldelete.Size = New System.Drawing.Size(23, 22)
        Me.tooldelete.Text = "&Delete"
        '
        'TOOLPRINT
        '
        Me.TOOLPRINT.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLPRINT.Image = Global.PrintPro.My.Resources.Resources.printer
        Me.TOOLPRINT.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLPRINT.Name = "TOOLPRINT"
        Me.TOOLPRINT.Size = New System.Drawing.Size(23, 22)
        Me.TOOLPRINT.Text = "ToolStripButton1"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'toolprevious
        '
        Me.toolprevious.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toolprevious.Image = Global.PrintPro.My.Resources.Resources.POINT02
        Me.toolprevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolprevious.Name = "toolprevious"
        Me.toolprevious.Size = New System.Drawing.Size(73, 22)
        Me.toolprevious.Text = "Previous"
        '
        'toolnext
        '
        Me.toolnext.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toolnext.Image = Global.PrintPro.My.Resources.Resources.POINT04
        Me.toolnext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolnext.Name = "toolnext"
        Me.toolnext.Size = New System.Drawing.Size(51, 22)
        Me.toolnext.Text = "Next"
        Me.toolnext.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tstxtbillno
        '
        Me.tstxtbillno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tstxtbillno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstxtbillno.Location = New System.Drawing.Point(231, 1)
        Me.tstxtbillno.Name = "tstxtbillno"
        Me.tstxtbillno.Size = New System.Drawing.Size(71, 21)
        Me.tstxtbillno.TabIndex = 22
        Me.tstxtbillno.TabStop = False
        Me.tstxtbillno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmddelete
        '
        Me.cmddelete.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddelete.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmddelete.Location = New System.Drawing.Point(483, 424)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(80, 28)
        Me.cmddelete.TabIndex = 9
        Me.cmddelete.Text = "Delete"
        Me.cmddelete.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TBITEMDTLS)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(21, 137)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1085, 231)
        Me.TabControl1.TabIndex = 4
        '
        'TBITEMDTLS
        '
        Me.TBITEMDTLS.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.TBITEMDTLS.Controls.Add(Me.TXTDESC)
        Me.TBITEMDTLS.Controls.Add(Me.TXTSRNO)
        Me.TBITEMDTLS.Controls.Add(Me.gridbill)
        Me.TBITEMDTLS.Controls.Add(Me.txtqty)
        Me.TBITEMDTLS.Controls.Add(Me.txtrate)
        Me.TBITEMDTLS.Controls.Add(Me.txtamount)
        Me.TBITEMDTLS.Controls.Add(Me.CMBUNIT)
        Me.TBITEMDTLS.Controls.Add(Me.txtwt)
        Me.TBITEMDTLS.Controls.Add(Me.CMBNONINVITEM)
        Me.TBITEMDTLS.Controls.Add(Me.txtsize)
        Me.TBITEMDTLS.Location = New System.Drawing.Point(4, 24)
        Me.TBITEMDTLS.Name = "TBITEMDTLS"
        Me.TBITEMDTLS.Padding = New System.Windows.Forms.Padding(3)
        Me.TBITEMDTLS.Size = New System.Drawing.Size(1077, 203)
        Me.TBITEMDTLS.TabIndex = 0
        Me.TBITEMDTLS.Text = "1. Item Details"
        '
        'TXTDESC
        '
        Me.TXTDESC.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDESC.Location = New System.Drawing.Point(823, 6)
        Me.TXTDESC.MaxLength = 200
        Me.TXTDESC.Name = "TXTDESC"
        Me.TXTDESC.Size = New System.Drawing.Size(200, 23)
        Me.TXTDESC.TabIndex = 8
        '
        'TXTSRNO
        '
        Me.TXTSRNO.BackColor = System.Drawing.Color.Linen
        Me.TXTSRNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTSRNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSRNO.Location = New System.Drawing.Point(3, 6)
        Me.TXTSRNO.Name = "TXTSRNO"
        Me.TXTSRNO.ReadOnly = True
        Me.TXTSRNO.Size = New System.Drawing.Size(50, 23)
        Me.TXTSRNO.TabIndex = 0
        Me.TXTSRNO.TabStop = False
        '
        'gridbill
        '
        Me.gridbill.AllowUserToAddRows = False
        Me.gridbill.AllowUserToDeleteRows = False
        Me.gridbill.AllowUserToResizeColumns = False
        Me.gridbill.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridbill.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gridbill.BackgroundColor = System.Drawing.Color.White
        Me.gridbill.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.gridbill.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridbill.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gridbill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridbill.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gsrno, Me.GITEMNAME, Me.GGSM, Me.GSIZE, Me.GWT, Me.GQTY, Me.GUNIT, Me.GRATE, Me.GAMT, Me.GDESC, Me.GOUTQTY, Me.GCLOSED})
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridbill.DefaultCellStyle = DataGridViewCellStyle11
        Me.gridbill.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.gridbill.GridColor = System.Drawing.SystemColors.Control
        Me.gridbill.Location = New System.Drawing.Point(3, 29)
        Me.gridbill.MultiSelect = False
        Me.gridbill.Name = "gridbill"
        Me.gridbill.RowHeadersVisible = False
        Me.gridbill.RowHeadersWidth = 30
        Me.gridbill.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.Black
        Me.gridbill.RowsDefaultCellStyle = DataGridViewCellStyle12
        Me.gridbill.RowTemplate.Height = 20
        Me.gridbill.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridbill.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gridbill.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridbill.Size = New System.Drawing.Size(1050, 168)
        Me.gridbill.TabIndex = 485
        Me.gridbill.TabStop = False
        '
        'gsrno
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.gsrno.DefaultCellStyle = DataGridViewCellStyle3
        Me.gsrno.HeaderText = "Sr"
        Me.gsrno.Name = "gsrno"
        Me.gsrno.ReadOnly = True
        Me.gsrno.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gsrno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gsrno.Width = 50
        '
        'GITEMNAME
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.GITEMNAME.DefaultCellStyle = DataGridViewCellStyle4
        Me.GITEMNAME.HeaderText = "Item Name"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.ReadOnly = True
        Me.GITEMNAME.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GITEMNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GITEMNAME.Width = 250
        '
        'GGSM
        '
        Me.GGSM.HeaderText = "Gsm"
        Me.GGSM.Name = "GGSM"
        Me.GGSM.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GGSM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GGSM.Visible = False
        '
        'GSIZE
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.GSIZE.DefaultCellStyle = DataGridViewCellStyle5
        Me.GSIZE.HeaderText = "Size"
        Me.GSIZE.Name = "GSIZE"
        Me.GSIZE.ReadOnly = True
        Me.GSIZE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GSIZE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GWT
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GWT.DefaultCellStyle = DataGridViewCellStyle6
        Me.GWT.HeaderText = "Wt."
        Me.GWT.Name = "GWT"
        Me.GWT.ReadOnly = True
        Me.GWT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GWT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GWT.Width = 60
        '
        'GQTY
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GQTY.DefaultCellStyle = DataGridViewCellStyle7
        Me.GQTY.HeaderText = "Qty."
        Me.GQTY.Name = "GQTY"
        Me.GQTY.ReadOnly = True
        Me.GQTY.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GQTY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GQTY.Width = 80
        '
        'GUNIT
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.GUNIT.DefaultCellStyle = DataGridViewCellStyle8
        Me.GUNIT.HeaderText = "Unit"
        Me.GUNIT.Name = "GUNIT"
        Me.GUNIT.ReadOnly = True
        Me.GUNIT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GUNIT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GRATE
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.NullValue = Nothing
        Me.GRATE.DefaultCellStyle = DataGridViewCellStyle9
        Me.GRATE.HeaderText = "Rate"
        Me.GRATE.Name = "GRATE"
        Me.GRATE.ReadOnly = True
        Me.GRATE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GRATE.Width = 80
        '
        'GAMT
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.NullValue = Nothing
        Me.GAMT.DefaultCellStyle = DataGridViewCellStyle10
        Me.GAMT.HeaderText = "Amount"
        Me.GAMT.Name = "GAMT"
        Me.GAMT.ReadOnly = True
        Me.GAMT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GAMT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GDESC
        '
        Me.GDESC.HeaderText = "Desc"
        Me.GDESC.Name = "GDESC"
        Me.GDESC.ReadOnly = True
        Me.GDESC.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GDESC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GDESC.Width = 200
        '
        'GOUTQTY
        '
        Me.GOUTQTY.HeaderText = "OUTQTY"
        Me.GOUTQTY.Name = "GOUTQTY"
        Me.GOUTQTY.ReadOnly = True
        Me.GOUTQTY.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GOUTQTY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GOUTQTY.Visible = False
        Me.GOUTQTY.Width = 10
        '
        'GCLOSED
        '
        Me.GCLOSED.HeaderText = "Closed"
        Me.GCLOSED.Name = "GCLOSED"
        Me.GCLOSED.Visible = False
        '
        'txtqty
        '
        Me.txtqty.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtqty.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtqty.Location = New System.Drawing.Point(463, 6)
        Me.txtqty.MaxLength = 10
        Me.txtqty.Name = "txtqty"
        Me.txtqty.Size = New System.Drawing.Size(80, 23)
        Me.txtqty.TabIndex = 4
        Me.txtqty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtrate
        '
        Me.txtrate.BackColor = System.Drawing.Color.White
        Me.txtrate.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtrate.Location = New System.Drawing.Point(643, 6)
        Me.txtrate.MaxLength = 10
        Me.txtrate.Name = "txtrate"
        Me.txtrate.Size = New System.Drawing.Size(80, 23)
        Me.txtrate.TabIndex = 6
        Me.txtrate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtamount
        '
        Me.txtamount.BackColor = System.Drawing.Color.Linen
        Me.txtamount.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtamount.Location = New System.Drawing.Point(723, 6)
        Me.txtamount.MaxLength = 10
        Me.txtamount.Name = "txtamount"
        Me.txtamount.ReadOnly = True
        Me.txtamount.Size = New System.Drawing.Size(100, 23)
        Me.txtamount.TabIndex = 7
        Me.txtamount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMBUNIT
        '
        Me.CMBUNIT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBUNIT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBUNIT.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBUNIT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBUNIT.FormattingEnabled = True
        Me.CMBUNIT.Location = New System.Drawing.Point(543, 6)
        Me.CMBUNIT.MaxDropDownItems = 14
        Me.CMBUNIT.MaxLength = 10
        Me.CMBUNIT.Name = "CMBUNIT"
        Me.CMBUNIT.Size = New System.Drawing.Size(100, 23)
        Me.CMBUNIT.TabIndex = 5
        '
        'txtwt
        '
        Me.txtwt.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtwt.Location = New System.Drawing.Point(403, 6)
        Me.txtwt.MaxLength = 10
        Me.txtwt.Name = "txtwt"
        Me.txtwt.Size = New System.Drawing.Size(60, 23)
        Me.txtwt.TabIndex = 3
        Me.txtwt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMBNONINVITEM
        '
        Me.CMBNONINVITEM.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBNONINVITEM.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBNONINVITEM.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBNONINVITEM.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBNONINVITEM.FormattingEnabled = True
        Me.CMBNONINVITEM.Location = New System.Drawing.Point(53, 6)
        Me.CMBNONINVITEM.MaxDropDownItems = 14
        Me.CMBNONINVITEM.MaxLength = 200
        Me.CMBNONINVITEM.Name = "CMBNONINVITEM"
        Me.CMBNONINVITEM.Size = New System.Drawing.Size(250, 23)
        Me.CMBNONINVITEM.TabIndex = 1
        '
        'txtsize
        '
        Me.txtsize.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsize.Location = New System.Drawing.Point(303, 6)
        Me.txtsize.MaxLength = 10
        Me.txtsize.Name = "txtsize"
        Me.txtsize.Size = New System.Drawing.Size(100, 23)
        Me.txtsize.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TXTIMGPATH)
        Me.TabPage1.Controls.Add(Me.PBSOFTCOPY)
        Me.TabPage1.Controls.Add(Me.CMDVIEW)
        Me.TabPage1.Controls.Add(Me.CMDREMOVE)
        Me.TabPage1.Controls.Add(Me.CMDUPLOAD)
        Me.TabPage1.Controls.Add(Me.txtuploadname)
        Me.TabPage1.Controls.Add(Me.TXTUPLOADSRNO)
        Me.TabPage1.Controls.Add(Me.txtuploadremarks)
        Me.TabPage1.Controls.Add(Me.gridupload)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1077, 205)
        Me.TabPage1.TabIndex = 1
        Me.TabPage1.Text = "2.Upload Docs"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TXTIMGPATH
        '
        Me.TXTIMGPATH.BackColor = System.Drawing.Color.White
        Me.TXTIMGPATH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTIMGPATH.ForeColor = System.Drawing.Color.Black
        Me.TXTIMGPATH.Location = New System.Drawing.Point(979, 142)
        Me.TXTIMGPATH.Name = "TXTIMGPATH"
        Me.TXTIMGPATH.Size = New System.Drawing.Size(22, 23)
        Me.TXTIMGPATH.TabIndex = 686
        Me.TXTIMGPATH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTIMGPATH.Visible = False
        '
        'PBSOFTCOPY
        '
        Me.PBSOFTCOPY.BackColor = System.Drawing.Color.White
        Me.PBSOFTCOPY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PBSOFTCOPY.ErrorImage = Nothing
        Me.PBSOFTCOPY.InitialImage = Nothing
        Me.PBSOFTCOPY.Location = New System.Drawing.Point(714, 26)
        Me.PBSOFTCOPY.Name = "PBSOFTCOPY"
        Me.PBSOFTCOPY.Size = New System.Drawing.Size(132, 139)
        Me.PBSOFTCOPY.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBSOFTCOPY.TabIndex = 685
        Me.PBSOFTCOPY.TabStop = False
        '
        'CMDVIEW
        '
        Me.CMDVIEW.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDVIEW.Location = New System.Drawing.Point(873, 76)
        Me.CMDVIEW.Name = "CMDVIEW"
        Me.CMDVIEW.Size = New System.Drawing.Size(80, 28)
        Me.CMDVIEW.TabIndex = 682
        Me.CMDVIEW.Text = "&View"
        Me.CMDVIEW.UseVisualStyleBackColor = True
        '
        'CMDREMOVE
        '
        Me.CMDREMOVE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDREMOVE.Location = New System.Drawing.Point(873, 119)
        Me.CMDREMOVE.Name = "CMDREMOVE"
        Me.CMDREMOVE.Size = New System.Drawing.Size(80, 28)
        Me.CMDREMOVE.TabIndex = 683
        Me.CMDREMOVE.Text = "&Remove"
        Me.CMDREMOVE.UseVisualStyleBackColor = True
        '
        'CMDUPLOAD
        '
        Me.CMDUPLOAD.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDUPLOAD.Location = New System.Drawing.Point(873, 26)
        Me.CMDUPLOAD.Name = "CMDUPLOAD"
        Me.CMDUPLOAD.Size = New System.Drawing.Size(80, 28)
        Me.CMDUPLOAD.TabIndex = 680
        Me.CMDUPLOAD.Text = "&Upload"
        Me.CMDUPLOAD.UseVisualStyleBackColor = True
        '
        'txtuploadname
        '
        Me.txtuploadname.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtuploadname.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtuploadname.Location = New System.Drawing.Point(355, 3)
        Me.txtuploadname.MaxLength = 1000
        Me.txtuploadname.Name = "txtuploadname"
        Me.txtuploadname.Size = New System.Drawing.Size(302, 23)
        Me.txtuploadname.TabIndex = 681
        '
        'TXTUPLOADSRNO
        '
        Me.TXTUPLOADSRNO.BackColor = System.Drawing.Color.Linen
        Me.TXTUPLOADSRNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTUPLOADSRNO.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTUPLOADSRNO.Location = New System.Drawing.Point(7, 3)
        Me.TXTUPLOADSRNO.Name = "TXTUPLOADSRNO"
        Me.TXTUPLOADSRNO.ReadOnly = True
        Me.TXTUPLOADSRNO.Size = New System.Drawing.Size(49, 23)
        Me.TXTUPLOADSRNO.TabIndex = 678
        Me.TXTUPLOADSRNO.TabStop = False
        '
        'txtuploadremarks
        '
        Me.txtuploadremarks.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtuploadremarks.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtuploadremarks.Location = New System.Drawing.Point(55, 3)
        Me.txtuploadremarks.MaxLength = 1000
        Me.txtuploadremarks.Name = "txtuploadremarks"
        Me.txtuploadremarks.Size = New System.Drawing.Size(301, 23)
        Me.txtuploadremarks.TabIndex = 679
        '
        'gridupload
        '
        Me.gridupload.AllowUserToAddRows = False
        Me.gridupload.AllowUserToDeleteRows = False
        Me.gridupload.AllowUserToResizeColumns = False
        Me.gridupload.AllowUserToResizeRows = False
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.Black
        Me.gridupload.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle13
        Me.gridupload.BackgroundColor = System.Drawing.Color.White
        Me.gridupload.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.gridupload.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.gridupload.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.gridupload.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridupload.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GUSRNO, Me.GUREMARKS, Me.GUNAME, Me.GUIMGPATH})
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridupload.DefaultCellStyle = DataGridViewCellStyle15
        Me.gridupload.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.gridupload.GridColor = System.Drawing.SystemColors.Control
        Me.gridupload.Location = New System.Drawing.Point(6, 26)
        Me.gridupload.MultiSelect = False
        Me.gridupload.Name = "gridupload"
        Me.gridupload.ReadOnly = True
        Me.gridupload.RowHeadersVisible = False
        Me.gridupload.RowHeadersWidth = 30
        Me.gridupload.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.White
        Me.gridupload.RowsDefaultCellStyle = DataGridViewCellStyle16
        Me.gridupload.RowTemplate.Height = 20
        Me.gridupload.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridupload.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gridupload.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridupload.Size = New System.Drawing.Size(685, 139)
        Me.gridupload.TabIndex = 684
        Me.gridupload.TabStop = False
        '
        'GUSRNO
        '
        Me.GUSRNO.HeaderText = "Sr."
        Me.GUSRNO.Name = "GUSRNO"
        Me.GUSRNO.ReadOnly = True
        Me.GUSRNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GUSRNO.Width = 50
        '
        'GUREMARKS
        '
        Me.GUREMARKS.HeaderText = "Remarks"
        Me.GUREMARKS.Name = "GUREMARKS"
        Me.GUREMARKS.ReadOnly = True
        Me.GUREMARKS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GUREMARKS.Width = 300
        '
        'GUNAME
        '
        Me.GUNAME.HeaderText = "Name"
        Me.GUNAME.Name = "GUNAME"
        Me.GUNAME.ReadOnly = True
        Me.GUNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GUNAME.Width = 300
        '
        'GUIMGPATH
        '
        Me.GUIMGPATH.HeaderText = "ImgPath"
        Me.GUIMGPATH.Name = "GUIMGPATH"
        Me.GUIMGPATH.ReadOnly = True
        Me.GUIMGPATH.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GUIMGPATH.Visible = False
        '
        'TXTGSM
        '
        Me.TXTGSM.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTGSM.Location = New System.Drawing.Point(748, 38)
        Me.TXTGSM.MaxLength = 10
        Me.TXTGSM.Name = "TXTGSM"
        Me.TXTGSM.Size = New System.Drawing.Size(11, 23)
        Me.TXTGSM.TabIndex = 1
        Me.TXTGSM.Visible = False
        '
        'lbllocked
        '
        Me.lbllocked.AutoSize = True
        Me.lbllocked.BackColor = System.Drawing.Color.Transparent
        Me.lbllocked.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllocked.ForeColor = System.Drawing.Color.Red
        Me.lbllocked.Location = New System.Drawing.Point(718, 400)
        Me.lbllocked.Name = "lbllocked"
        Me.lbllocked.Size = New System.Drawing.Size(64, 23)
        Me.lbllocked.TabIndex = 824
        Me.lbllocked.Text = "Locked"
        Me.lbllocked.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(880, 87)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(67, 15)
        Me.Label13.TabIndex = 846
        Me.Label13.Text = "Order Date"
        '
        'DTPODATE
        '
        Me.DTPODATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPODATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPODATE.Location = New System.Drawing.Point(949, 83)
        Me.DTPODATE.Name = "DTPODATE"
        Me.DTPODATE.Size = New System.Drawing.Size(88, 23)
        Me.DTPODATE.TabIndex = 0
        Me.DTPODATE.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(903, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 15)
        Me.Label3.TabIndex = 845
        Me.Label3.Text = "PO No."
        '
        'TXTPONO
        '
        Me.TXTPONO.BackColor = System.Drawing.Color.Linen
        Me.TXTPONO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTPONO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPONO.Location = New System.Drawing.Point(949, 51)
        Me.TXTPONO.MaxLength = 50
        Me.TXTPONO.Name = "TXTPONO"
        Me.TXTPONO.ReadOnly = True
        Me.TXTPONO.Size = New System.Drawing.Size(88, 23)
        Me.TXTPONO.TabIndex = 843
        Me.TXTPONO.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(18, 375)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 15)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Remarks"
        '
        'lbltotalqty
        '
        Me.lbltotalqty.BackColor = System.Drawing.Color.Transparent
        Me.lbltotalqty.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalqty.Location = New System.Drawing.Point(455, 371)
        Me.lbltotalqty.Name = "lbltotalqty"
        Me.lbltotalqty.Size = New System.Drawing.Size(83, 22)
        Me.lbltotalqty.TabIndex = 849
        Me.lbltotalqty.Text = "0.00"
        Me.lbltotalqty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(415, 375)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(37, 15)
        Me.Label11.TabIndex = 850
        Me.Label11.Text = "Total "
        '
        'lbltotalamt
        '
        Me.lbltotalamt.BackColor = System.Drawing.Color.Transparent
        Me.lbltotalamt.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalamt.Location = New System.Drawing.Point(717, 371)
        Me.lbltotalamt.Name = "lbltotalamt"
        Me.lbltotalamt.Size = New System.Drawing.Size(83, 22)
        Me.lbltotalamt.TabIndex = 851
        Me.lbltotalamt.Text = "0.00"
        Me.lbltotalamt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CMBCODE
        '
        Me.CMBCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCODE.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCODE.FormattingEnabled = True
        Me.CMBCODE.Location = New System.Drawing.Point(542, 26)
        Me.CMBCODE.MaxDropDownItems = 14
        Me.CMBCODE.Name = "CMBCODE"
        Me.CMBCODE.Size = New System.Drawing.Size(44, 21)
        Me.CMBCODE.TabIndex = 853
        Me.CMBCODE.Visible = False
        '
        'txtadd
        '
        Me.txtadd.BackColor = System.Drawing.Color.Linen
        Me.txtadd.ForeColor = System.Drawing.Color.DimGray
        Me.txtadd.Location = New System.Drawing.Point(542, 28)
        Me.txtadd.Multiline = True
        Me.txtadd.Name = "txtadd"
        Me.txtadd.ReadOnly = True
        Me.txtadd.Size = New System.Drawing.Size(49, 22)
        Me.txtadd.TabIndex = 852
        Me.txtadd.TabStop = False
        Me.txtadd.Visible = False
        '
        'CMDCLOSE
        '
        Me.CMDCLOSE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDCLOSE.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDCLOSE.Location = New System.Drawing.Point(924, 424)
        Me.CMDCLOSE.Name = "CMDCLOSE"
        Me.CMDCLOSE.Size = New System.Drawing.Size(80, 28)
        Me.CMDCLOSE.TabIndex = 12
        Me.CMDCLOSE.Text = "C&lose"
        Me.CMDCLOSE.UseVisualStyleBackColor = True
        Me.CMDCLOSE.Visible = False
        '
        'LBLCLOSED
        '
        Me.LBLCLOSED.AutoSize = True
        Me.LBLCLOSED.BackColor = System.Drawing.Color.Transparent
        Me.LBLCLOSED.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLCLOSED.ForeColor = System.Drawing.Color.Red
        Me.LBLCLOSED.Location = New System.Drawing.Point(654, 463)
        Me.LBLCLOSED.Name = "LBLCLOSED"
        Me.LBLCLOSED.Size = New System.Drawing.Size(63, 23)
        Me.LBLCLOSED.TabIndex = 857
        Me.LBLCLOSED.Text = "Closed"
        Me.LBLCLOSED.Visible = False
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.Color.White)
        Me.BlendPanel1.Controls.Add(Me.CHKVERIFY)
        Me.BlendPanel1.Controls.Add(Me.Label8)
        Me.BlendPanel1.Controls.Add(Me.TXTCOPYPONO)
        Me.BlendPanel1.Controls.Add(Me.TXTREQNO)
        Me.BlendPanel1.Controls.Add(Me.Label7)
        Me.BlendPanel1.Controls.Add(Me.CMDSELECTPURCHASERTN)
        Me.BlendPanel1.Controls.Add(Me.TXTGSM)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.TXTSHEETSPERREAM)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.Label21)
        Me.BlendPanel1.Controls.Add(Me.Label22)
        Me.BlendPanel1.Controls.Add(Me.LBLCLOSED)
        Me.BlendPanel1.Controls.Add(Me.CMDCLOSE)
        Me.BlendPanel1.Controls.Add(Me.txtadd)
        Me.BlendPanel1.Controls.Add(Me.CMBCODE)
        Me.BlendPanel1.Controls.Add(Me.lbltotalamt)
        Me.BlendPanel1.Controls.Add(Me.Label11)
        Me.BlendPanel1.Controls.Add(Me.lbltotalqty)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.TXTPONO)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.DTPODATE)
        Me.BlendPanel1.Controls.Add(Me.Label13)
        Me.BlendPanel1.Controls.Add(Me.PBlock)
        Me.BlendPanel1.Controls.Add(Me.lbllocked)
        Me.BlendPanel1.Controls.Add(Me.TabControl1)
        Me.BlendPanel1.Controls.Add(Me.cmddelete)
        Me.BlendPanel1.Controls.Add(Me.tstxtbillno)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Controls.Add(Me.txtremarks)
        Me.BlendPanel1.Controls.Add(Me.cmdclear)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.DTDELDATE)
        Me.BlendPanel1.Controls.Add(Me.Label18)
        Me.BlendPanel1.Controls.Add(Me.TXTDELDAYS)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.CMBNAME)
        Me.BlendPanel1.Controls.Add(Me.lblgroup)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1284, 504)
        Me.BlendPanel1.TabIndex = 1
        '
        'CHKVERIFY
        '
        Me.CHKVERIFY.AutoSize = True
        Me.CHKVERIFY.BackColor = System.Drawing.Color.Transparent
        Me.CHKVERIFY.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKVERIFY.ForeColor = System.Drawing.Color.Maroon
        Me.CHKVERIFY.Location = New System.Drawing.Point(839, 384)
        Me.CHKVERIFY.Name = "CHKVERIFY"
        Me.CHKVERIFY.Size = New System.Drawing.Size(69, 19)
        Me.CHKVERIFY.TabIndex = 649
        Me.CHKVERIFY.Text = "&Verified"
        Me.CHKVERIFY.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(365, 4)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 14)
        Me.Label8.TabIndex = 988
        Me.Label8.Text = "Copy PO"
        '
        'TXTCOPYPONO
        '
        Me.TXTCOPYPONO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCOPYPONO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCOPYPONO.Location = New System.Drawing.Point(414, 0)
        Me.TXTCOPYPONO.Name = "TXTCOPYPONO"
        Me.TXTCOPYPONO.Size = New System.Drawing.Size(61, 22)
        Me.TXTCOPYPONO.TabIndex = 987
        Me.TXTCOPYPONO.TabStop = False
        Me.TXTCOPYPONO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTREQNO
        '
        Me.TXTREQNO.BackColor = System.Drawing.Color.Linen
        Me.TXTREQNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTREQNO.Location = New System.Drawing.Point(601, 60)
        Me.TXTREQNO.Name = "TXTREQNO"
        Me.TXTREQNO.ReadOnly = True
        Me.TXTREQNO.Size = New System.Drawing.Size(84, 23)
        Me.TXTREQNO.TabIndex = 985
        Me.TXTREQNO.TabStop = False
        Me.TXTREQNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTREQNO.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(550, 64)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 15)
        Me.Label7.TabIndex = 986
        Me.Label7.Text = "Req. No"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label7.Visible = False
        '
        'CMDSELECTPURCHASERTN
        '
        Me.CMDSELECTPURCHASERTN.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDSELECTPURCHASERTN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDSELECTPURCHASERTN.Location = New System.Drawing.Point(437, 458)
        Me.CMDSELECTPURCHASERTN.Name = "CMDSELECTPURCHASERTN"
        Me.CMDSELECTPURCHASERTN.Size = New System.Drawing.Size(80, 28)
        Me.CMDSELECTPURCHASERTN.TabIndex = 11
        Me.CMDSELECTPURCHASERTN.Text = "&Select Req"
        Me.CMDSELECTPURCHASERTN.UseVisualStyleBackColor = True
        Me.CMDSELECTPURCHASERTN.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(816, 444)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 14)
        Me.Label5.TabIndex = 863
        Me.Label5.Text = "Locked (Closed)"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.LightGreen
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Location = New System.Drawing.Point(797, 443)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(18, 17)
        Me.Label6.TabIndex = 862
        Me.Label6.Text = "   "
        '
        'TXTSHEETSPERREAM
        '
        Me.TXTSHEETSPERREAM.BackColor = System.Drawing.Color.White
        Me.TXTSHEETSPERREAM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTSHEETSPERREAM.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSHEETSPERREAM.Location = New System.Drawing.Point(379, 56)
        Me.TXTSHEETSPERREAM.MaxLength = 10
        Me.TXTSHEETSPERREAM.Name = "TXTSHEETSPERREAM"
        Me.TXTSHEETSPERREAM.Size = New System.Drawing.Size(41, 23)
        Me.TXTSHEETSPERREAM.TabIndex = 3
        Me.TXTSHEETSPERREAM.Text = "500"
        Me.TXTSHEETSPERREAM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(295, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 15)
        Me.Label4.TabIndex = 861
        Me.Label4.Text = "Sheets / Ream"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Red
        Me.Label21.Location = New System.Drawing.Point(816, 466)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(133, 14)
        Me.Label21.TabIndex = 859
        Me.Label21.Text = "Locked (Docket Raised)"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label22.Location = New System.Drawing.Point(797, 465)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(18, 17)
        Me.Label22.TabIndex = 858
        Me.Label22.Text = "   "
        '
        'PBlock
        '
        Me.PBlock.BackColor = System.Drawing.Color.Transparent
        Me.PBlock.Image = Global.PrintPro.My.Resources.Resources.lock_copy
        Me.PBlock.Location = New System.Drawing.Point(720, 424)
        Me.PBlock.Name = "PBlock"
        Me.PBlock.Size = New System.Drawing.Size(62, 62)
        Me.PBlock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBlock.TabIndex = 825
        Me.PBlock.TabStop = False
        Me.PBlock.Visible = False
        '
        'PurchaseOrder
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1284, 504)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "PurchaseOrder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Purchase Order"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TBITEMDTLS.ResumeLayout(False)
        Me.TBITEMDTLS.PerformLayout()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.PBSOFTCOPY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridupload, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.PBlock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents LBLCLOSED As System.Windows.Forms.Label
    Friend WithEvents CMDCLOSE As System.Windows.Forms.Button
    Friend WithEvents txtadd As System.Windows.Forms.TextBox
    Friend WithEvents CMBCODE As System.Windows.Forms.ComboBox
    Friend WithEvents lbltotalamt As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lbltotalqty As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TXTPONO As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DTPODATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents PBlock As System.Windows.Forms.PictureBox
    Friend WithEvents lbllocked As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TBITEMDTLS As System.Windows.Forms.TabPage
    Friend WithEvents TXTDESC As System.Windows.Forms.TextBox
    Friend WithEvents TXTSRNO As System.Windows.Forms.TextBox
    Friend WithEvents gridbill As System.Windows.Forms.DataGridView
    Friend WithEvents txtqty As System.Windows.Forms.TextBox
    Friend WithEvents txtrate As System.Windows.Forms.TextBox
    Friend WithEvents txtamount As System.Windows.Forms.TextBox
    Friend WithEvents CMBUNIT As System.Windows.Forms.ComboBox
    Friend WithEvents txtsize As System.Windows.Forms.TextBox
    Friend WithEvents txtwt As System.Windows.Forms.TextBox
    Friend WithEvents CMBNONINVITEM As System.Windows.Forms.ComboBox
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TXTIMGPATH As System.Windows.Forms.TextBox
    Friend WithEvents PBSOFTCOPY As System.Windows.Forms.PictureBox
    Friend WithEvents CMDVIEW As System.Windows.Forms.Button
    Friend WithEvents CMDREMOVE As System.Windows.Forms.Button
    Friend WithEvents CMDUPLOAD As System.Windows.Forms.Button
    Friend WithEvents txtuploadname As System.Windows.Forms.TextBox
    Friend WithEvents TXTUPLOADSRNO As System.Windows.Forms.TextBox
    Friend WithEvents txtuploadremarks As System.Windows.Forms.TextBox
    Friend WithEvents gridupload As System.Windows.Forms.DataGridView
    Friend WithEvents GUSRNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GUREMARKS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GUNAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GUIMGPATH As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents cmddelete As System.Windows.Forms.Button
    Friend WithEvents tstxtbillno As System.Windows.Forms.TextBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents OpenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents tooldelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolprevious As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolnext As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Friend WithEvents txtremarks As System.Windows.Forms.TextBox
    Friend WithEvents cmdclear As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents DTDELDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TXTDELDAYS As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CMBNAME As System.Windows.Forms.ComboBox
    Friend WithEvents lblgroup As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents TXTSHEETSPERREAM As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TOOLPRINT As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents TXTGSM As TextBox
    Friend WithEvents CMDSELECTPURCHASERTN As Button
    Friend WithEvents TXTREQNO As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents TXTCOPYPONO As TextBox
    Friend WithEvents CHKVERIFY As CheckBox
    Friend WithEvents gsrno As DataGridViewTextBoxColumn
    Friend WithEvents GITEMNAME As DataGridViewTextBoxColumn
    Friend WithEvents GGSM As DataGridViewTextBoxColumn
    Friend WithEvents GSIZE As DataGridViewTextBoxColumn
    Friend WithEvents GWT As DataGridViewTextBoxColumn
    Friend WithEvents GQTY As DataGridViewTextBoxColumn
    Friend WithEvents GUNIT As DataGridViewTextBoxColumn
    Friend WithEvents GRATE As DataGridViewTextBoxColumn
    Friend WithEvents GAMT As DataGridViewTextBoxColumn
    Friend WithEvents GDESC As DataGridViewTextBoxColumn
    Friend WithEvents GOUTQTY As DataGridViewTextBoxColumn
    Friend WithEvents GCLOSED As DataGridViewTextBoxColumn
End Class
