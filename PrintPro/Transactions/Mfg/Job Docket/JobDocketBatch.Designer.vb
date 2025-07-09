<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class JobDocketBatch
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(JobDocketBatch))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.tooldelete = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.toolprevious = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolnext = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tstxtbillno = New System.Windows.Forms.TextBox()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.cmdclear = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.jobdate = New System.Windows.Forms.DateTimePicker()
        Me.TXTBOMITEMCODE = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CMDSELECTORDER = New System.Windows.Forms.Button()
        Me.txtitemcode = New System.Windows.Forms.TextBox()
        Me.txtorderno = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtfileno = New System.Windows.Forms.TextBox()
        Me.TXTORDERGSRNO = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtshadecard = New System.Windows.Forms.TextBox()
        Me.txtpartyname = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtleafletsize = New System.Windows.Forms.TextBox()
        Me.txtqty = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtfoldingsize = New System.Windows.Forms.TextBox()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CMDDELETE = New System.Windows.Forms.Button()
        Me.txtmaterial = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtdesign = New System.Windows.Forms.TextBox()
        Me.txtjobdocketno = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtpapersize = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtgsm = New System.Windows.Forms.TextBox()
        Me.txtpono = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtgrain = New System.Windows.Forms.TextBox()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtcutsize = New System.Windows.Forms.TextBox()
        Me.txtups = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txttotalsheets = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.PBlock = New System.Windows.Forms.PictureBox()
        Me.lbllocked = New System.Windows.Forms.Label()
        Me.TXTPERCENTAGE = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtmaterialcode = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.LBLCLOSE = New System.Windows.Forms.Label()
        Me.TXTPROPRINTINGQTY = New System.Windows.Forms.TextBox()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.LBLCUTTINGDONE = New System.Windows.Forms.Label()
        Me.LBLFOLDINGDONE = New System.Windows.Forms.Label()
        Me.LBLFINISHED = New System.Windows.Forms.Label()
        Me.TXTPRODFINISHQTY = New System.Windows.Forms.TextBox()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.LBLPROD2DONE = New System.Windows.Forms.Label()
        Me.LBLPACKINGPRODONE = New System.Windows.Forms.Label()
        Me.LBLPROD1DONE = New System.Windows.Forms.Label()
        Me.LBLFABPRODONE = New System.Windows.Forms.Label()
        Me.LBLNUMPRODONE = New System.Windows.Forms.Label()
        Me.LBLENVLPRODONE = New System.Windows.Forms.Label()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.LBLPUNCPRODONE = New System.Windows.Forms.Label()
        Me.LBLBINDPRODONE = New System.Windows.Forms.Label()
        Me.LBLGUMPRODONE = New System.Windows.Forms.Label()
        Me.LBLFOILPRODONE = New System.Windows.Forms.Label()
        Me.LBLUVPRODONE = New System.Windows.Forms.Label()
        Me.LBLLAMPRODONE = New System.Windows.Forms.Label()
        Me.LBLLAMCUTPRODONE = New System.Windows.Forms.Label()
        Me.LBLPRINTPRODONE = New System.Windows.Forms.Label()
        Me.DTPREV = New System.Windows.Forms.MaskedTextBox()
        Me.LBLREQDONE = New System.Windows.Forms.Label()
        Me.CMBOUTVENDORNAME = New System.Windows.Forms.ComboBox()
        Me.LBLVENDORNAME = New System.Windows.Forms.Label()
        Me.txtadd = New System.Windows.Forms.TextBox()
        Me.CMBCODE = New System.Windows.Forms.ComboBox()
        Me.TXTCLOSESIZE = New System.Windows.Forms.TextBox()
        Me.LBLCLOSESIZE = New System.Windows.Forms.Label()
        Me.TXTOPENSIZE = New System.Windows.Forms.TextBox()
        Me.LBLOPENSIZE = New System.Windows.Forms.Label()
        Me.CMBMACHINE = New System.Windows.Forms.ComboBox()
        Me.LBLMACHINE = New System.Windows.Forms.Label()
        Me.LBLPREVDATE = New System.Windows.Forms.Label()
        Me.TXTPREVJOBNO = New System.Windows.Forms.TextBox()
        Me.LBLPREV = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TXTNUMBERINGUPS = New System.Windows.Forms.TextBox()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.TXTFOLDINGUPS = New System.Windows.Forms.TextBox()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.TXTFINALUPS = New System.Windows.Forms.TextBox()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.TXTPUNCHINGUPS = New System.Windows.Forms.TextBox()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.TXTLAMINATIONUPS = New System.Windows.Forms.TextBox()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.CMBCOL2PLATETYPE = New System.Windows.Forms.ComboBox()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.TXTCOL2PLATES = New System.Windows.Forms.TextBox()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.TXTCOL2 = New System.Windows.Forms.TextBox()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.CMBLAMM = New System.Windows.Forms.ComboBox()
        Me.CMBLENVELOPE = New System.Windows.Forms.ComboBox()
        Me.CMBLUV = New System.Windows.Forms.ComboBox()
        Me.CMBLPUNCHING = New System.Windows.Forms.ComboBox()
        Me.CMBLGUM = New System.Windows.Forms.ComboBox()
        Me.CMBLBINDING = New System.Windows.Forms.ComboBox()
        Me.CMBVENDOR = New System.Windows.Forms.ComboBox()
        Me.CMBLFABRICATION = New System.Windows.Forms.ComboBox()
        Me.CMBLNUMBERING = New System.Windows.Forms.ComboBox()
        Me.CMBVENDOR1 = New System.Windows.Forms.ComboBox()
        Me.CMBLPACKING = New System.Windows.Forms.ComboBox()
        Me.CMBLAM = New System.Windows.Forms.ComboBox()
        Me.TXTLAMINATION1 = New System.Windows.Forms.TextBox()
        Me.TXTLAMINATION2 = New System.Windows.Forms.TextBox()
        Me.CMBLAM1 = New System.Windows.Forms.ComboBox()
        Me.CMBLAM2 = New System.Windows.Forms.ComboBox()
        Me.CMBLAMMODE = New System.Windows.Forms.ComboBox()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.TXTFILMSIZE2 = New System.Windows.Forms.TextBox()
        Me.CMBUV = New System.Windows.Forms.ComboBox()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.CMBPUNCHING = New System.Windows.Forms.ComboBox()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.CMBENVELOPE = New System.Windows.Forms.ComboBox()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.CMBGUMMING = New System.Windows.Forms.ComboBox()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.CMBBINDING = New System.Windows.Forms.ComboBox()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.CMBPACKING = New System.Windows.Forms.ComboBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.CMBFABRICATION = New System.Windows.Forms.ComboBox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.CMBNUMBERING = New System.Windows.Forms.ComboBox()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.CMBLAMINATION = New System.Windows.Forms.ComboBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.TXTFILMSIZE = New System.Windows.Forms.TextBox()
        Me.TXTSHEETS = New System.Windows.Forms.TextBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.TXTKGS = New System.Windows.Forms.TextBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.TXTYIELD = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.TXTCOL1PLATES = New System.Windows.Forms.TextBox()
        Me.CMBMODE = New System.Windows.Forms.ComboBox()
        Me.TXTCOL1 = New System.Windows.Forms.TextBox()
        Me.TXTCUTSHEET = New System.Windows.Forms.TextBox()
        Me.CMBCOL1PLATETYPE = New System.Windows.Forms.ComboBox()
        Me.TXTEXTRA = New System.Windows.Forms.TextBox()
        Me.TXTTOTAL = New System.Windows.Forms.TextBox()
        Me.TXTTIME = New System.Windows.Forms.TextBox()
        Me.TXTCUTSIZEG = New System.Windows.Forms.TextBox()
        Me.TXTCOLORUPS = New System.Windows.Forms.TextBox()
        Me.TXTFULLSIZE = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TXTCOLORSHEET = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.CMBNONINVITEM = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TXTSHIPTO = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TXTORDERTYPE = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TXTPOSITIVENEGATIVE = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TXTMAINITEM = New System.Windows.Forms.TextBox()
        Me.chkdone = New System.Windows.Forms.CheckBox()
        Me.TXTGUPS = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.TXTJOBQTY = New System.Windows.Forms.TextBox()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ToolStrip1.SuspendLayout()
        CType(Me.PBlock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BlendPanel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripButton, Me.SaveToolStripButton, Me.PrintToolStripButton, Me.tooldelete, Me.toolStripSeparator, Me.toolprevious, Me.ToolStripSeparator2, Me.toolnext, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1311, 25)
        Me.ToolStrip1.TabIndex = 158
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
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = CType(resources.GetObject("PrintToolStripButton.Image"), System.Drawing.Image)
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PrintToolStripButton.Text = "&Print"
        '
        'tooldelete
        '
        Me.tooldelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tooldelete.Image = CType(resources.GetObject("tooldelete.Image"), System.Drawing.Image)
        Me.tooldelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tooldelete.Name = "tooldelete"
        Me.tooldelete.Size = New System.Drawing.Size(23, 22)
        Me.tooldelete.Text = "&Delete "
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'toolprevious
        '
        Me.toolprevious.Image = CType(resources.GetObject("toolprevious.Image"), System.Drawing.Image)
        Me.toolprevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolprevious.Name = "toolprevious"
        Me.toolprevious.Size = New System.Drawing.Size(72, 22)
        Me.toolprevious.Text = "Previous"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'toolnext
        '
        Me.toolnext.Image = CType(resources.GetObject("toolnext.Image"), System.Drawing.Image)
        Me.toolnext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolnext.Name = "toolnext"
        Me.toolnext.Size = New System.Drawing.Size(52, 22)
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
        Me.tstxtbillno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstxtbillno.Location = New System.Drawing.Point(244, 2)
        Me.tstxtbillno.MaxLength = 10
        Me.tstxtbillno.Name = "tstxtbillno"
        Me.tstxtbillno.Size = New System.Drawing.Size(56, 22)
        Me.tstxtbillno.TabIndex = 487
        Me.tstxtbillno.TabStop = False
        Me.tstxtbillno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdok
        '
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.Location = New System.Drawing.Point(467, 539)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 6
        Me.cmdok.Text = "&Save"
        Me.cmdok.UseVisualStyleBackColor = True
        '
        'cmdclear
        '
        Me.cmdclear.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdclear.Location = New System.Drawing.Point(553, 539)
        Me.cmdclear.Name = "cmdclear"
        Me.cmdclear.Size = New System.Drawing.Size(80, 28)
        Me.cmdclear.TabIndex = 7
        Me.cmdclear.Text = "&Clear"
        Me.cmdclear.UseVisualStyleBackColor = True
        '
        'cmdexit
        '
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.Location = New System.Drawing.Point(725, 539)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 9
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = True
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label27.Location = New System.Drawing.Point(210, 33)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(32, 15)
        Me.Label27.TabIndex = 509
        Me.Label27.Text = "Date"
        '
        'jobdate
        '
        Me.jobdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.jobdate.Location = New System.Drawing.Point(245, 29)
        Me.jobdate.Name = "jobdate"
        Me.jobdate.Size = New System.Drawing.Size(86, 23)
        Me.jobdate.TabIndex = 0
        '
        'TXTBOMITEMCODE
        '
        Me.TXTBOMITEMCODE.BackColor = System.Drawing.Color.Linen
        Me.TXTBOMITEMCODE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTBOMITEMCODE.Location = New System.Drawing.Point(114, 115)
        Me.TXTBOMITEMCODE.Name = "TXTBOMITEMCODE"
        Me.TXTBOMITEMCODE.ReadOnly = True
        Me.TXTBOMITEMCODE.Size = New System.Drawing.Size(217, 23)
        Me.TXTBOMITEMCODE.TabIndex = 3
        Me.TXTBOMITEMCODE.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(21, 119)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 15)
        Me.Label1.TabIndex = 91
        Me.Label1.Text = "Sub Product"
        '
        'CMDSELECTORDER
        '
        Me.CMDSELECTORDER.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDSELECTORDER.Location = New System.Drawing.Point(358, 539)
        Me.CMDSELECTORDER.Name = "CMDSELECTORDER"
        Me.CMDSELECTORDER.Size = New System.Drawing.Size(103, 28)
        Me.CMDSELECTORDER.TabIndex = 1
        Me.CMDSELECTORDER.Text = "S&elect Order"
        Me.CMDSELECTORDER.UseVisualStyleBackColor = True
        '
        'txtitemcode
        '
        Me.txtitemcode.BackColor = System.Drawing.Color.Linen
        Me.txtitemcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtitemcode.Location = New System.Drawing.Point(113, 230)
        Me.txtitemcode.Name = "txtitemcode"
        Me.txtitemcode.ReadOnly = True
        Me.txtitemcode.Size = New System.Drawing.Size(217, 23)
        Me.txtitemcode.TabIndex = 2
        Me.txtitemcode.TabStop = False
        '
        'txtorderno
        '
        Me.txtorderno.BackColor = System.Drawing.Color.Linen
        Me.txtorderno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtorderno.Location = New System.Drawing.Point(429, 54)
        Me.txtorderno.Name = "txtorderno"
        Me.txtorderno.ReadOnly = True
        Me.txtorderno.Size = New System.Drawing.Size(73, 23)
        Me.txtorderno.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(19, 234)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 15)
        Me.Label2.TabIndex = 93
        Me.Label2.Text = "Main Item Code"
        '
        'txtfileno
        '
        Me.txtfileno.BackColor = System.Drawing.Color.Linen
        Me.txtfileno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtfileno.Location = New System.Drawing.Point(429, 184)
        Me.txtfileno.Name = "txtfileno"
        Me.txtfileno.ReadOnly = True
        Me.txtfileno.Size = New System.Drawing.Size(108, 23)
        Me.txtfileno.TabIndex = 4
        Me.txtfileno.TabStop = False
        '
        'TXTORDERGSRNO
        '
        Me.TXTORDERGSRNO.BackColor = System.Drawing.Color.Linen
        Me.TXTORDERGSRNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTORDERGSRNO.Location = New System.Drawing.Point(429, 80)
        Me.TXTORDERGSRNO.Name = "TXTORDERGSRNO"
        Me.TXTORDERGSRNO.ReadOnly = True
        Me.TXTORDERGSRNO.Size = New System.Drawing.Size(73, 23)
        Me.TXTORDERGSRNO.TabIndex = 522
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(379, 188)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 15)
        Me.Label3.TabIndex = 97
        Me.Label3.Text = "File No."
        '
        'txtshadecard
        '
        Me.txtshadecard.BackColor = System.Drawing.Color.Linen
        Me.txtshadecard.Location = New System.Drawing.Point(136, 137)
        Me.txtshadecard.Name = "txtshadecard"
        Me.txtshadecard.ReadOnly = True
        Me.txtshadecard.Size = New System.Drawing.Size(106, 23)
        Me.txtshadecard.TabIndex = 119
        Me.txtshadecard.TabStop = False
        '
        'txtpartyname
        '
        Me.txtpartyname.BackColor = System.Drawing.Color.Linen
        Me.txtpartyname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtpartyname.Location = New System.Drawing.Point(114, 58)
        Me.txtpartyname.MaxLength = 100
        Me.txtpartyname.Name = "txtpartyname"
        Me.txtpartyname.ReadOnly = True
        Me.txtpartyname.Size = New System.Drawing.Size(217, 23)
        Me.txtpartyname.TabIndex = 524
        Me.txtpartyname.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(68, 25)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 15)
        Me.Label11.TabIndex = 107
        Me.Label11.Text = "Leaflet Size"
        '
        'txtleafletsize
        '
        Me.txtleafletsize.BackColor = System.Drawing.Color.Linen
        Me.txtleafletsize.Location = New System.Drawing.Point(136, 21)
        Me.txtleafletsize.Name = "txtleafletsize"
        Me.txtleafletsize.ReadOnly = True
        Me.txtleafletsize.Size = New System.Drawing.Size(106, 23)
        Me.txtleafletsize.TabIndex = 106
        Me.txtleafletsize.TabStop = False
        '
        'txtqty
        '
        Me.txtqty.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtqty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtqty.Location = New System.Drawing.Point(429, 104)
        Me.txtqty.MaxLength = 100
        Me.txtqty.Name = "txtqty"
        Me.txtqty.ReadOnly = True
        Me.txtqty.Size = New System.Drawing.Size(73, 23)
        Me.txtqty.TabIndex = 2
        Me.txtqty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(62, 54)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 15)
        Me.Label6.TabIndex = 109
        Me.Label6.Text = "Folding Size"
        '
        'txtfoldingsize
        '
        Me.txtfoldingsize.BackColor = System.Drawing.Color.Linen
        Me.txtfoldingsize.Location = New System.Drawing.Point(136, 50)
        Me.txtfoldingsize.Name = "txtfoldingsize"
        Me.txtfoldingsize.ReadOnly = True
        Me.txtfoldingsize.Size = New System.Drawing.Size(106, 23)
        Me.txtfoldingsize.TabIndex = 108
        Me.txtfoldingsize.TabStop = False
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.BackColor = System.Drawing.Color.Transparent
        Me.Label66.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label66.Location = New System.Drawing.Point(39, 62)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(73, 15)
        Me.Label66.TabIndex = 525
        Me.Label66.Text = "Client Name"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(292, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 15)
        Me.Label7.TabIndex = 111
        Me.Label7.Text = "Material"
        '
        'CMDDELETE
        '
        Me.CMDDELETE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDDELETE.Location = New System.Drawing.Point(639, 539)
        Me.CMDDELETE.Name = "CMDDELETE"
        Me.CMDDELETE.Size = New System.Drawing.Size(80, 28)
        Me.CMDDELETE.TabIndex = 8
        Me.CMDDELETE.Text = "&Delete"
        Me.CMDDELETE.UseVisualStyleBackColor = True
        '
        'txtmaterial
        '
        Me.txtmaterial.BackColor = System.Drawing.Color.Linen
        Me.txtmaterial.Location = New System.Drawing.Point(350, 21)
        Me.txtmaterial.Name = "txtmaterial"
        Me.txtmaterial.ReadOnly = True
        Me.txtmaterial.Size = New System.Drawing.Size(106, 23)
        Me.txtmaterial.TabIndex = 110
        Me.txtmaterial.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(373, 108)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 15)
        Me.Label4.TabIndex = 99
        Me.Label4.Text = "Quantity"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(303, 54)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 15)
        Me.Label8.TabIndex = 113
        Me.Label8.Text = "Design"
        '
        'txtdesign
        '
        Me.txtdesign.BackColor = System.Drawing.Color.Linen
        Me.txtdesign.Location = New System.Drawing.Point(350, 50)
        Me.txtdesign.Name = "txtdesign"
        Me.txtdesign.ReadOnly = True
        Me.txtdesign.Size = New System.Drawing.Size(106, 23)
        Me.txtdesign.TabIndex = 112
        Me.txtdesign.TabStop = False
        '
        'txtjobdocketno
        '
        Me.txtjobdocketno.BackColor = System.Drawing.Color.Linen
        Me.txtjobdocketno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtjobdocketno.Location = New System.Drawing.Point(114, 29)
        Me.txtjobdocketno.Name = "txtjobdocketno"
        Me.txtjobdocketno.ReadOnly = True
        Me.txtjobdocketno.Size = New System.Drawing.Size(73, 23)
        Me.txtjobdocketno.TabIndex = 102
        Me.txtjobdocketno.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(71, 83)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 15)
        Me.Label9.TabIndex = 115
        Me.Label9.Text = "Paper Size"
        '
        'txtpapersize
        '
        Me.txtpapersize.BackColor = System.Drawing.Color.Linen
        Me.txtpapersize.Location = New System.Drawing.Point(136, 79)
        Me.txtpapersize.Name = "txtpapersize"
        Me.txtpapersize.ReadOnly = True
        Me.txtpapersize.Size = New System.Drawing.Size(106, 23)
        Me.txtpapersize.TabIndex = 114
        Me.txtpapersize.TabStop = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(26, 33)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(86, 15)
        Me.Label16.TabIndex = 103
        Me.Label16.Text = "Job Docket No."
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(280, 83)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(67, 15)
        Me.Label10.TabIndex = 117
        Me.Label10.Text = "Paper GSM"
        '
        'txtgsm
        '
        Me.txtgsm.BackColor = System.Drawing.Color.Linen
        Me.txtgsm.Location = New System.Drawing.Point(350, 79)
        Me.txtgsm.Name = "txtgsm"
        Me.txtgsm.ReadOnly = True
        Me.txtgsm.Size = New System.Drawing.Size(106, 23)
        Me.txtgsm.TabIndex = 116
        Me.txtgsm.TabStop = False
        '
        'txtpono
        '
        Me.txtpono.BackColor = System.Drawing.Color.Linen
        Me.txtpono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtpono.Location = New System.Drawing.Point(113, 201)
        Me.txtpono.Name = "txtpono"
        Me.txtpono.ReadOnly = True
        Me.txtpono.Size = New System.Drawing.Size(217, 23)
        Me.txtpono.TabIndex = 7
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(256, 112)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(91, 15)
        Me.Label14.TabIndex = 151
        Me.Label14.Text = "Grain Direction"
        '
        'txtgrain
        '
        Me.txtgrain.BackColor = System.Drawing.Color.Linen
        Me.txtgrain.Location = New System.Drawing.Point(350, 108)
        Me.txtgrain.Name = "txtgrain"
        Me.txtgrain.ReadOnly = True
        Me.txtgrain.Size = New System.Drawing.Size(106, 23)
        Me.txtgrain.TabIndex = 150
        Me.txtgrain.TabStop = False
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.BackColor = System.Drawing.Color.Transparent
        Me.Label64.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label64.Location = New System.Drawing.Point(67, 205)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(44, 15)
        Me.Label64.TabIndex = 521
        Me.Label64.Text = "PO No."
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(50, 112)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(84, 15)
        Me.Label12.TabIndex = 119
        Me.Label12.Text = "Paper Cut Size"
        '
        'txtcutsize
        '
        Me.txtcutsize.BackColor = System.Drawing.Color.Linen
        Me.txtcutsize.Location = New System.Drawing.Point(136, 108)
        Me.txtcutsize.Name = "txtcutsize"
        Me.txtcutsize.ReadOnly = True
        Me.txtcutsize.Size = New System.Drawing.Size(106, 23)
        Me.txtcutsize.TabIndex = 118
        Me.txtcutsize.TabStop = False
        '
        'txtups
        '
        Me.txtups.BackColor = System.Drawing.Color.Linen
        Me.txtups.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtups.Location = New System.Drawing.Point(429, 130)
        Me.txtups.Name = "txtups"
        Me.txtups.ReadOnly = True
        Me.txtups.Size = New System.Drawing.Size(73, 23)
        Me.txtups.TabIndex = 104
        Me.txtups.TabStop = False
        Me.txtups.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(276, 169)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(72, 15)
        Me.Label15.TabIndex = 153
        Me.Label15.Text = "Total Sheets"
        Me.Label15.Visible = False
        '
        'txttotalsheets
        '
        Me.txttotalsheets.BackColor = System.Drawing.Color.Linen
        Me.txttotalsheets.Location = New System.Drawing.Point(351, 165)
        Me.txttotalsheets.Name = "txttotalsheets"
        Me.txttotalsheets.ReadOnly = True
        Me.txttotalsheets.Size = New System.Drawing.Size(106, 23)
        Me.txttotalsheets.TabIndex = 152
        Me.txttotalsheets.TabStop = False
        Me.txttotalsheets.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txttotalsheets.Visible = False
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label31.Location = New System.Drawing.Point(364, 136)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(63, 15)
        Me.Label31.TabIndex = 105
        Me.Label31.Text = "No. of Ups"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label29.Location = New System.Drawing.Point(65, 141)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(69, 15)
        Me.Label29.TabIndex = 155
        Me.Label29.Text = "Shade Card"
        '
        'PBlock
        '
        Me.PBlock.BackColor = System.Drawing.Color.Transparent
        Me.PBlock.Image = CType(resources.GetObject("PBlock.Image"), System.Drawing.Image)
        Me.PBlock.Location = New System.Drawing.Point(1149, 464)
        Me.PBlock.Name = "PBlock"
        Me.PBlock.Size = New System.Drawing.Size(60, 60)
        Me.PBlock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBlock.TabIndex = 572
        Me.PBlock.TabStop = False
        Me.PBlock.Visible = False
        '
        'lbllocked
        '
        Me.lbllocked.AutoSize = True
        Me.lbllocked.BackColor = System.Drawing.Color.Transparent
        Me.lbllocked.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllocked.ForeColor = System.Drawing.Color.Red
        Me.lbllocked.Location = New System.Drawing.Point(1152, 442)
        Me.lbllocked.Name = "lbllocked"
        Me.lbllocked.Size = New System.Drawing.Size(57, 19)
        Me.lbllocked.TabIndex = 571
        Me.lbllocked.Text = "Locked"
        Me.lbllocked.Visible = False
        '
        'TXTPERCENTAGE
        '
        Me.TXTPERCENTAGE.BackColor = System.Drawing.SystemColors.Window
        Me.TXTPERCENTAGE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTPERCENTAGE.Location = New System.Drawing.Point(508, 104)
        Me.TXTPERCENTAGE.MaxLength = 6
        Me.TXTPERCENTAGE.Name = "TXTPERCENTAGE"
        Me.TXTPERCENTAGE.Size = New System.Drawing.Size(37, 23)
        Me.TXTPERCENTAGE.TabIndex = 574
        Me.TXTPERCENTAGE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTPERCENTAGE.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(551, 213)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(16, 15)
        Me.Label5.TabIndex = 575
        Me.Label5.Text = "%"
        Me.Label5.Visible = False
        '
        'txtmaterialcode
        '
        Me.txtmaterialcode.BackColor = System.Drawing.Color.Linen
        Me.txtmaterialcode.Location = New System.Drawing.Point(350, 137)
        Me.txtmaterialcode.Name = "txtmaterialcode"
        Me.txtmaterialcode.ReadOnly = True
        Me.txtmaterialcode.Size = New System.Drawing.Size(106, 23)
        Me.txtmaterialcode.TabIndex = 576
        Me.txtmaterialcode.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(263, 141)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(85, 15)
        Me.Label13.TabIndex = 577
        Me.Label13.Text = "Material Code"
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.Color.White)
        Me.BlendPanel1.Controls.Add(Me.LBLCLOSE)
        Me.BlendPanel1.Controls.Add(Me.TXTPROPRINTINGQTY)
        Me.BlendPanel1.Controls.Add(Me.Label62)
        Me.BlendPanel1.Controls.Add(Me.LBLCUTTINGDONE)
        Me.BlendPanel1.Controls.Add(Me.LBLFOLDINGDONE)
        Me.BlendPanel1.Controls.Add(Me.LBLFINISHED)
        Me.BlendPanel1.Controls.Add(Me.TXTPRODFINISHQTY)
        Me.BlendPanel1.Controls.Add(Me.Label61)
        Me.BlendPanel1.Controls.Add(Me.LBLPROD2DONE)
        Me.BlendPanel1.Controls.Add(Me.LBLPACKINGPRODONE)
        Me.BlendPanel1.Controls.Add(Me.LBLPROD1DONE)
        Me.BlendPanel1.Controls.Add(Me.LBLFABPRODONE)
        Me.BlendPanel1.Controls.Add(Me.LBLNUMPRODONE)
        Me.BlendPanel1.Controls.Add(Me.LBLENVLPRODONE)
        Me.BlendPanel1.Controls.Add(Me.Label73)
        Me.BlendPanel1.Controls.Add(Me.LBLPUNCPRODONE)
        Me.BlendPanel1.Controls.Add(Me.LBLBINDPRODONE)
        Me.BlendPanel1.Controls.Add(Me.LBLGUMPRODONE)
        Me.BlendPanel1.Controls.Add(Me.LBLFOILPRODONE)
        Me.BlendPanel1.Controls.Add(Me.LBLUVPRODONE)
        Me.BlendPanel1.Controls.Add(Me.LBLLAMPRODONE)
        Me.BlendPanel1.Controls.Add(Me.LBLLAMCUTPRODONE)
        Me.BlendPanel1.Controls.Add(Me.LBLPRINTPRODONE)
        Me.BlendPanel1.Controls.Add(Me.DTPREV)
        Me.BlendPanel1.Controls.Add(Me.LBLREQDONE)
        Me.BlendPanel1.Controls.Add(Me.CMBOUTVENDORNAME)
        Me.BlendPanel1.Controls.Add(Me.LBLVENDORNAME)
        Me.BlendPanel1.Controls.Add(Me.txtadd)
        Me.BlendPanel1.Controls.Add(Me.CMBCODE)
        Me.BlendPanel1.Controls.Add(Me.TXTCLOSESIZE)
        Me.BlendPanel1.Controls.Add(Me.LBLCLOSESIZE)
        Me.BlendPanel1.Controls.Add(Me.TXTOPENSIZE)
        Me.BlendPanel1.Controls.Add(Me.LBLOPENSIZE)
        Me.BlendPanel1.Controls.Add(Me.CMBMACHINE)
        Me.BlendPanel1.Controls.Add(Me.LBLMACHINE)
        Me.BlendPanel1.Controls.Add(Me.LBLPREVDATE)
        Me.BlendPanel1.Controls.Add(Me.TXTPREVJOBNO)
        Me.BlendPanel1.Controls.Add(Me.LBLPREV)
        Me.BlendPanel1.Controls.Add(Me.GroupBox2)
        Me.BlendPanel1.Controls.Add(Me.Label22)
        Me.BlendPanel1.Controls.Add(Me.Label47)
        Me.BlendPanel1.Controls.Add(Me.Label21)
        Me.BlendPanel1.Controls.Add(Me.CMBNONINVITEM)
        Me.BlendPanel1.Controls.Add(Me.Label20)
        Me.BlendPanel1.Controls.Add(Me.TXTSHIPTO)
        Me.BlendPanel1.Controls.Add(Me.Label19)
        Me.BlendPanel1.Controls.Add(Me.TXTORDERTYPE)
        Me.BlendPanel1.Controls.Add(Me.GroupBox1)
        Me.BlendPanel1.Controls.Add(Me.Label18)
        Me.BlendPanel1.Controls.Add(Me.TXTMAINITEM)
        Me.BlendPanel1.Controls.Add(Me.chkdone)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.TXTPERCENTAGE)
        Me.BlendPanel1.Controls.Add(Me.lbllocked)
        Me.BlendPanel1.Controls.Add(Me.PBlock)
        Me.BlendPanel1.Controls.Add(Me.Label31)
        Me.BlendPanel1.Controls.Add(Me.txtups)
        Me.BlendPanel1.Controls.Add(Me.Label64)
        Me.BlendPanel1.Controls.Add(Me.txtpono)
        Me.BlendPanel1.Controls.Add(Me.Label16)
        Me.BlendPanel1.Controls.Add(Me.txtjobdocketno)
        Me.BlendPanel1.Controls.Add(Me.TXTGUPS)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.CMDDELETE)
        Me.BlendPanel1.Controls.Add(Me.Label66)
        Me.BlendPanel1.Controls.Add(Me.txtqty)
        Me.BlendPanel1.Controls.Add(Me.txtpartyname)
        Me.BlendPanel1.Controls.Add(Me.TXTORDERGSRNO)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.txtorderno)
        Me.BlendPanel1.Controls.Add(Me.txtitemcode)
        Me.BlendPanel1.Controls.Add(Me.Label23)
        Me.BlendPanel1.Controls.Add(Me.txtfileno)
        Me.BlendPanel1.Controls.Add(Me.Label26)
        Me.BlendPanel1.Controls.Add(Me.CMDSELECTORDER)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.TXTBOMITEMCODE)
        Me.BlendPanel1.Controls.Add(Me.jobdate)
        Me.BlendPanel1.Controls.Add(Me.TXTJOBQTY)
        Me.BlendPanel1.Controls.Add(Me.Label27)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.cmdclear)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.tstxtbillno)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1311, 570)
        Me.BlendPanel1.TabIndex = 0
        '
        'LBLCLOSE
        '
        Me.LBLCLOSE.AutoSize = True
        Me.LBLCLOSE.BackColor = System.Drawing.Color.Transparent
        Me.LBLCLOSE.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLCLOSE.ForeColor = System.Drawing.Color.Red
        Me.LBLCLOSE.Location = New System.Drawing.Point(1140, 373)
        Me.LBLCLOSE.Name = "LBLCLOSE"
        Me.LBLCLOSE.Size = New System.Drawing.Size(161, 19)
        Me.LBLCLOSE.TabIndex = 1163
        Me.LBLCLOSE.Text = "Jobdocket Batch Close"
        Me.LBLCLOSE.Visible = False
        '
        'TXTPROPRINTINGQTY
        '
        Me.TXTPROPRINTINGQTY.BackColor = System.Drawing.Color.Linen
        Me.TXTPROPRINTINGQTY.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPROPRINTINGQTY.Location = New System.Drawing.Point(959, 543)
        Me.TXTPROPRINTINGQTY.MaxLength = 100
        Me.TXTPROPRINTINGQTY.Name = "TXTPROPRINTINGQTY"
        Me.TXTPROPRINTINGQTY.ReadOnly = True
        Me.TXTPROPRINTINGQTY.Size = New System.Drawing.Size(105, 23)
        Me.TXTPROPRINTINGQTY.TabIndex = 1161
        Me.TXTPROPRINTINGQTY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTPROPRINTINGQTY.Visible = False
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.BackColor = System.Drawing.Color.Transparent
        Me.Label62.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label62.Location = New System.Drawing.Point(830, 547)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(132, 15)
        Me.Label62.TabIndex = 1162
        Me.Label62.Text = "Production Printin Qty "
        Me.Label62.Visible = False
        '
        'LBLCUTTINGDONE
        '
        Me.LBLCUTTINGDONE.AutoSize = True
        Me.LBLCUTTINGDONE.BackColor = System.Drawing.Color.Transparent
        Me.LBLCUTTINGDONE.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLCUTTINGDONE.ForeColor = System.Drawing.Color.Red
        Me.LBLCUTTINGDONE.Location = New System.Drawing.Point(1184, 84)
        Me.LBLCUTTINGDONE.Name = "LBLCUTTINGDONE"
        Me.LBLCUTTINGDONE.Size = New System.Drawing.Size(97, 19)
        Me.LBLCUTTINGDONE.TabIndex = 1160
        Me.LBLCUTTINGDONE.Text = "Cutting Done"
        Me.LBLCUTTINGDONE.Visible = False
        '
        'LBLFOLDINGDONE
        '
        Me.LBLFOLDINGDONE.AutoSize = True
        Me.LBLFOLDINGDONE.BackColor = System.Drawing.Color.Transparent
        Me.LBLFOLDINGDONE.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLFOLDINGDONE.ForeColor = System.Drawing.Color.Red
        Me.LBLFOLDINGDONE.Location = New System.Drawing.Point(1137, 83)
        Me.LBLFOLDINGDONE.Name = "LBLFOLDINGDONE"
        Me.LBLFOLDINGDONE.Size = New System.Drawing.Size(99, 19)
        Me.LBLFOLDINGDONE.TabIndex = 1159
        Me.LBLFOLDINGDONE.Text = "Folding Done"
        Me.LBLFOLDINGDONE.Visible = False
        '
        'LBLFINISHED
        '
        Me.LBLFINISHED.AutoSize = True
        Me.LBLFINISHED.BackColor = System.Drawing.Color.Transparent
        Me.LBLFINISHED.Font = New System.Drawing.Font("Calibri", 16.0!, System.Drawing.FontStyle.Bold)
        Me.LBLFINISHED.ForeColor = System.Drawing.Color.Red
        Me.LBLFINISHED.Location = New System.Drawing.Point(1136, 527)
        Me.LBLFINISHED.Name = "LBLFINISHED"
        Me.LBLFINISHED.Size = New System.Drawing.Size(124, 27)
        Me.LBLFINISHED.TabIndex = 1158
        Me.LBLFINISHED.Text = "Job Finished"
        Me.LBLFINISHED.Visible = False
        '
        'TXTPRODFINISHQTY
        '
        Me.TXTPRODFINISHQTY.BackColor = System.Drawing.Color.Linen
        Me.TXTPRODFINISHQTY.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPRODFINISHQTY.Location = New System.Drawing.Point(168, 542)
        Me.TXTPRODFINISHQTY.MaxLength = 100
        Me.TXTPRODFINISHQTY.Name = "TXTPRODFINISHQTY"
        Me.TXTPRODFINISHQTY.ReadOnly = True
        Me.TXTPRODFINISHQTY.Size = New System.Drawing.Size(105, 23)
        Me.TXTPRODFINISHQTY.TabIndex = 1156
        Me.TXTPRODFINISHQTY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTPRODFINISHQTY.Visible = False
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.BackColor = System.Drawing.Color.Transparent
        Me.Label61.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label61.Location = New System.Drawing.Point(39, 546)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(129, 15)
        Me.Label61.TabIndex = 1157
        Me.Label61.Text = "Production Finish Qty "
        Me.Label61.Visible = False
        '
        'LBLPROD2DONE
        '
        Me.LBLPROD2DONE.AutoSize = True
        Me.LBLPROD2DONE.BackColor = System.Drawing.Color.Transparent
        Me.LBLPROD2DONE.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLPROD2DONE.ForeColor = System.Drawing.Color.Red
        Me.LBLPROD2DONE.Location = New System.Drawing.Point(1153, 83)
        Me.LBLPROD2DONE.Name = "LBLPROD2DONE"
        Me.LBLPROD2DONE.Size = New System.Drawing.Size(133, 19)
        Me.LBLPROD2DONE.TabIndex = 1155
        Me.LBLPROD2DONE.Text = "Production2 Done"
        Me.LBLPROD2DONE.Visible = False
        '
        'LBLPACKINGPRODONE
        '
        Me.LBLPACKINGPRODONE.AutoSize = True
        Me.LBLPACKINGPRODONE.BackColor = System.Drawing.Color.Transparent
        Me.LBLPACKINGPRODONE.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLPACKINGPRODONE.ForeColor = System.Drawing.Color.Red
        Me.LBLPACKINGPRODONE.Location = New System.Drawing.Point(1155, 84)
        Me.LBLPACKINGPRODONE.Name = "LBLPACKINGPRODONE"
        Me.LBLPACKINGPRODONE.Size = New System.Drawing.Size(102, 19)
        Me.LBLPACKINGPRODONE.TabIndex = 1154
        Me.LBLPACKINGPRODONE.Text = "Packing Done"
        Me.LBLPACKINGPRODONE.Visible = False
        '
        'LBLPROD1DONE
        '
        Me.LBLPROD1DONE.AutoSize = True
        Me.LBLPROD1DONE.BackColor = System.Drawing.Color.Transparent
        Me.LBLPROD1DONE.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLPROD1DONE.ForeColor = System.Drawing.Color.Red
        Me.LBLPROD1DONE.Location = New System.Drawing.Point(1133, 84)
        Me.LBLPROD1DONE.Name = "LBLPROD1DONE"
        Me.LBLPROD1DONE.Size = New System.Drawing.Size(133, 19)
        Me.LBLPROD1DONE.TabIndex = 1153
        Me.LBLPROD1DONE.Text = "Production1 Done"
        Me.LBLPROD1DONE.Visible = False
        '
        'LBLFABPRODONE
        '
        Me.LBLFABPRODONE.AutoSize = True
        Me.LBLFABPRODONE.BackColor = System.Drawing.Color.Transparent
        Me.LBLFABPRODONE.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLFABPRODONE.ForeColor = System.Drawing.Color.Red
        Me.LBLFABPRODONE.Location = New System.Drawing.Point(1133, 80)
        Me.LBLFABPRODONE.Name = "LBLFABPRODONE"
        Me.LBLFABPRODONE.Size = New System.Drawing.Size(125, 19)
        Me.LBLFABPRODONE.TabIndex = 1152
        Me.LBLFABPRODONE.Text = "Fabrication Done"
        Me.LBLFABPRODONE.Visible = False
        '
        'LBLNUMPRODONE
        '
        Me.LBLNUMPRODONE.AutoSize = True
        Me.LBLNUMPRODONE.BackColor = System.Drawing.Color.Transparent
        Me.LBLNUMPRODONE.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLNUMPRODONE.ForeColor = System.Drawing.Color.Red
        Me.LBLNUMPRODONE.Location = New System.Drawing.Point(1133, 78)
        Me.LBLNUMPRODONE.Name = "LBLNUMPRODONE"
        Me.LBLNUMPRODONE.Size = New System.Drawing.Size(126, 19)
        Me.LBLNUMPRODONE.TabIndex = 1151
        Me.LBLNUMPRODONE.Text = "Numbering Done"
        Me.LBLNUMPRODONE.Visible = False
        '
        'LBLENVLPRODONE
        '
        Me.LBLENVLPRODONE.AutoSize = True
        Me.LBLENVLPRODONE.BackColor = System.Drawing.Color.Transparent
        Me.LBLENVLPRODONE.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLENVLPRODONE.ForeColor = System.Drawing.Color.Red
        Me.LBLENVLPRODONE.Location = New System.Drawing.Point(1133, 83)
        Me.LBLENVLPRODONE.Name = "LBLENVLPRODONE"
        Me.LBLENVLPRODONE.Size = New System.Drawing.Size(159, 19)
        Me.LBLENVLPRODONE.TabIndex = 1150
        Me.LBLENVLPRODONE.Text = "Envelop Making Done"
        Me.LBLENVLPRODONE.Visible = False
        '
        'Label73
        '
        Me.Label73.AutoSize = True
        Me.Label73.BackColor = System.Drawing.Color.Transparent
        Me.Label73.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label73.Location = New System.Drawing.Point(1158, 91)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(0, 15)
        Me.Label73.TabIndex = 1149
        Me.Label73.Visible = False
        '
        'LBLPUNCPRODONE
        '
        Me.LBLPUNCPRODONE.AutoSize = True
        Me.LBLPUNCPRODONE.BackColor = System.Drawing.Color.Transparent
        Me.LBLPUNCPRODONE.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLPUNCPRODONE.ForeColor = System.Drawing.Color.Red
        Me.LBLPUNCPRODONE.Location = New System.Drawing.Point(1133, 83)
        Me.LBLPUNCPRODONE.Name = "LBLPUNCPRODONE"
        Me.LBLPUNCPRODONE.Size = New System.Drawing.Size(113, 19)
        Me.LBLPUNCPRODONE.TabIndex = 1148
        Me.LBLPUNCPRODONE.Text = "Punching Done"
        Me.LBLPUNCPRODONE.Visible = False
        '
        'LBLBINDPRODONE
        '
        Me.LBLBINDPRODONE.AutoSize = True
        Me.LBLBINDPRODONE.BackColor = System.Drawing.Color.Transparent
        Me.LBLBINDPRODONE.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLBINDPRODONE.ForeColor = System.Drawing.Color.Red
        Me.LBLBINDPRODONE.Location = New System.Drawing.Point(1133, 83)
        Me.LBLBINDPRODONE.Name = "LBLBINDPRODONE"
        Me.LBLBINDPRODONE.Size = New System.Drawing.Size(101, 19)
        Me.LBLBINDPRODONE.TabIndex = 1147
        Me.LBLBINDPRODONE.Text = "Binding Done"
        Me.LBLBINDPRODONE.Visible = False
        '
        'LBLGUMPRODONE
        '
        Me.LBLGUMPRODONE.AutoSize = True
        Me.LBLGUMPRODONE.BackColor = System.Drawing.Color.Transparent
        Me.LBLGUMPRODONE.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLGUMPRODONE.ForeColor = System.Drawing.Color.Red
        Me.LBLGUMPRODONE.Location = New System.Drawing.Point(1133, 82)
        Me.LBLGUMPRODONE.Name = "LBLGUMPRODONE"
        Me.LBLGUMPRODONE.Size = New System.Drawing.Size(115, 19)
        Me.LBLGUMPRODONE.TabIndex = 1146
        Me.LBLGUMPRODONE.Text = "Gumming Done"
        Me.LBLGUMPRODONE.Visible = False
        '
        'LBLFOILPRODONE
        '
        Me.LBLFOILPRODONE.AutoSize = True
        Me.LBLFOILPRODONE.BackColor = System.Drawing.Color.Transparent
        Me.LBLFOILPRODONE.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLFOILPRODONE.ForeColor = System.Drawing.Color.Red
        Me.LBLFOILPRODONE.Location = New System.Drawing.Point(1133, 79)
        Me.LBLFOILPRODONE.Name = "LBLFOILPRODONE"
        Me.LBLFOILPRODONE.Size = New System.Drawing.Size(94, 19)
        Me.LBLFOILPRODONE.TabIndex = 1145
        Me.LBLFOILPRODONE.Text = "Foiling Done"
        Me.LBLFOILPRODONE.Visible = False
        '
        'LBLUVPRODONE
        '
        Me.LBLUVPRODONE.AutoSize = True
        Me.LBLUVPRODONE.BackColor = System.Drawing.Color.Transparent
        Me.LBLUVPRODONE.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLUVPRODONE.ForeColor = System.Drawing.Color.Red
        Me.LBLUVPRODONE.Location = New System.Drawing.Point(1133, 80)
        Me.LBLUVPRODONE.Name = "LBLUVPRODONE"
        Me.LBLUVPRODONE.Size = New System.Drawing.Size(68, 19)
        Me.LBLUVPRODONE.TabIndex = 1144
        Me.LBLUVPRODONE.Text = "UV Done"
        Me.LBLUVPRODONE.Visible = False
        '
        'LBLLAMPRODONE
        '
        Me.LBLLAMPRODONE.AutoSize = True
        Me.LBLLAMPRODONE.BackColor = System.Drawing.Color.Transparent
        Me.LBLLAMPRODONE.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLLAMPRODONE.ForeColor = System.Drawing.Color.Red
        Me.LBLLAMPRODONE.Location = New System.Drawing.Point(1134, 74)
        Me.LBLLAMPRODONE.Name = "LBLLAMPRODONE"
        Me.LBLLAMPRODONE.Size = New System.Drawing.Size(125, 19)
        Me.LBLLAMPRODONE.TabIndex = 1143
        Me.LBLLAMPRODONE.Text = "Lamination Done"
        Me.LBLLAMPRODONE.Visible = False
        '
        'LBLLAMCUTPRODONE
        '
        Me.LBLLAMCUTPRODONE.AutoSize = True
        Me.LBLLAMCUTPRODONE.BackColor = System.Drawing.Color.Transparent
        Me.LBLLAMCUTPRODONE.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLLAMCUTPRODONE.ForeColor = System.Drawing.Color.Red
        Me.LBLLAMCUTPRODONE.Location = New System.Drawing.Point(1110, 85)
        Me.LBLLAMCUTPRODONE.Name = "LBLLAMCUTPRODONE"
        Me.LBLLAMCUTPRODONE.Size = New System.Drawing.Size(183, 19)
        Me.LBLLAMCUTPRODONE.TabIndex = 1142
        Me.LBLLAMCUTPRODONE.Text = "Lamination Cuttting Done"
        Me.LBLLAMCUTPRODONE.Visible = False
        '
        'LBLPRINTPRODONE
        '
        Me.LBLPRINTPRODONE.AutoSize = True
        Me.LBLPRINTPRODONE.BackColor = System.Drawing.Color.Transparent
        Me.LBLPRINTPRODONE.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLPRINTPRODONE.ForeColor = System.Drawing.Color.Red
        Me.LBLPRINTPRODONE.Location = New System.Drawing.Point(1144, 416)
        Me.LBLPRINTPRODONE.Name = "LBLPRINTPRODONE"
        Me.LBLPRINTPRODONE.Size = New System.Drawing.Size(125, 19)
        Me.LBLPRINTPRODONE.TabIndex = 1141
        Me.LBLPRINTPRODONE.Text = "Production Done"
        Me.LBLPRINTPRODONE.Visible = False
        '
        'DTPREV
        '
        Me.DTPREV.AsciiOnly = True
        Me.DTPREV.BackColor = System.Drawing.SystemColors.Window
        Me.DTPREV.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.DTPREV.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.DTPREV.Location = New System.Drawing.Point(576, 28)
        Me.DTPREV.Mask = "00/00/0000"
        Me.DTPREV.Name = "DTPREV"
        Me.DTPREV.Size = New System.Drawing.Size(93, 23)
        Me.DTPREV.TabIndex = 1140
        Me.DTPREV.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.DTPREV.ValidatingType = GetType(Date)
        '
        'LBLREQDONE
        '
        Me.LBLREQDONE.AutoSize = True
        Me.LBLREQDONE.BackColor = System.Drawing.Color.Transparent
        Me.LBLREQDONE.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLREQDONE.ForeColor = System.Drawing.Color.Red
        Me.LBLREQDONE.Location = New System.Drawing.Point(1144, 394)
        Me.LBLREQDONE.Name = "LBLREQDONE"
        Me.LBLREQDONE.Size = New System.Drawing.Size(103, 19)
        Me.LBLREQDONE.TabIndex = 1138
        Me.LBLREQDONE.Text = "Request done"
        Me.LBLREQDONE.Visible = False
        '
        'CMBOUTVENDORNAME
        '
        Me.CMBOUTVENDORNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBOUTVENDORNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBOUTVENDORNAME.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBOUTVENDORNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBOUTVENDORNAME.FormattingEnabled = True
        Me.CMBOUTVENDORNAME.Location = New System.Drawing.Point(959, 29)
        Me.CMBOUTVENDORNAME.MaxDropDownItems = 14
        Me.CMBOUTVENDORNAME.MaxLength = 200
        Me.CMBOUTVENDORNAME.Name = "CMBOUTVENDORNAME"
        Me.CMBOUTVENDORNAME.Size = New System.Drawing.Size(172, 23)
        Me.CMBOUTVENDORNAME.TabIndex = 6
        Me.CMBOUTVENDORNAME.Visible = False
        '
        'LBLVENDORNAME
        '
        Me.LBLVENDORNAME.AutoSize = True
        Me.LBLVENDORNAME.BackColor = System.Drawing.Color.Transparent
        Me.LBLVENDORNAME.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LBLVENDORNAME.Location = New System.Drawing.Point(877, 33)
        Me.LBLVENDORNAME.Name = "LBLVENDORNAME"
        Me.LBLVENDORNAME.Size = New System.Drawing.Size(79, 15)
        Me.LBLVENDORNAME.TabIndex = 1137
        Me.LBLVENDORNAME.Text = "Vendor Name"
        Me.LBLVENDORNAME.Visible = False
        '
        'txtadd
        '
        Me.txtadd.BackColor = System.Drawing.Color.Linen
        Me.txtadd.ForeColor = System.Drawing.Color.DimGray
        Me.txtadd.Location = New System.Drawing.Point(1155, 29)
        Me.txtadd.Multiline = True
        Me.txtadd.Name = "txtadd"
        Me.txtadd.ReadOnly = True
        Me.txtadd.Size = New System.Drawing.Size(49, 22)
        Me.txtadd.TabIndex = 1130
        Me.txtadd.TabStop = False
        Me.txtadd.Visible = False
        '
        'CMBCODE
        '
        Me.CMBCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCODE.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCODE.FormattingEnabled = True
        Me.CMBCODE.Location = New System.Drawing.Point(1160, 30)
        Me.CMBCODE.MaxDropDownItems = 14
        Me.CMBCODE.Name = "CMBCODE"
        Me.CMBCODE.Size = New System.Drawing.Size(44, 21)
        Me.CMBCODE.TabIndex = 1131
        Me.CMBCODE.Visible = False
        '
        'TXTCLOSESIZE
        '
        Me.TXTCLOSESIZE.BackColor = System.Drawing.Color.White
        Me.TXTCLOSESIZE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCLOSESIZE.Location = New System.Drawing.Point(429, 210)
        Me.TXTCLOSESIZE.MaxLength = 50
        Me.TXTCLOSESIZE.Name = "TXTCLOSESIZE"
        Me.TXTCLOSESIZE.Size = New System.Drawing.Size(108, 23)
        Me.TXTCLOSESIZE.TabIndex = 3
        Me.TXTCLOSESIZE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTCLOSESIZE.Visible = False
        '
        'LBLCLOSESIZE
        '
        Me.LBLCLOSESIZE.AutoSize = True
        Me.LBLCLOSESIZE.BackColor = System.Drawing.Color.Transparent
        Me.LBLCLOSESIZE.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LBLCLOSESIZE.Location = New System.Drawing.Point(366, 214)
        Me.LBLCLOSESIZE.Name = "LBLCLOSESIZE"
        Me.LBLCLOSESIZE.Size = New System.Drawing.Size(61, 15)
        Me.LBLCLOSESIZE.TabIndex = 1129
        Me.LBLCLOSESIZE.Text = "Close Size"
        Me.LBLCLOSESIZE.Visible = False
        '
        'TXTOPENSIZE
        '
        Me.TXTOPENSIZE.BackColor = System.Drawing.Color.White
        Me.TXTOPENSIZE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTOPENSIZE.Location = New System.Drawing.Point(429, 236)
        Me.TXTOPENSIZE.MaxLength = 50
        Me.TXTOPENSIZE.Name = "TXTOPENSIZE"
        Me.TXTOPENSIZE.Size = New System.Drawing.Size(108, 23)
        Me.TXTOPENSIZE.TabIndex = 4
        Me.TXTOPENSIZE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTOPENSIZE.Visible = False
        '
        'LBLOPENSIZE
        '
        Me.LBLOPENSIZE.AutoSize = True
        Me.LBLOPENSIZE.BackColor = System.Drawing.Color.Transparent
        Me.LBLOPENSIZE.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LBLOPENSIZE.Location = New System.Drawing.Point(367, 239)
        Me.LBLOPENSIZE.Name = "LBLOPENSIZE"
        Me.LBLOPENSIZE.Size = New System.Drawing.Size(60, 15)
        Me.LBLOPENSIZE.TabIndex = 1127
        Me.LBLOPENSIZE.Text = "Open Size"
        Me.LBLOPENSIZE.Visible = False
        '
        'CMBMACHINE
        '
        Me.CMBMACHINE.BackColor = System.Drawing.Color.White
        Me.CMBMACHINE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBMACHINE.ForeColor = System.Drawing.Color.Black
        Me.CMBMACHINE.FormattingEnabled = True
        Me.CMBMACHINE.Items.AddRange(New Object() {"", "MTB", "Solana"})
        Me.CMBMACHINE.Location = New System.Drawing.Point(750, 29)
        Me.CMBMACHINE.Name = "CMBMACHINE"
        Me.CMBMACHINE.Size = New System.Drawing.Size(100, 23)
        Me.CMBMACHINE.TabIndex = 5
        Me.CMBMACHINE.Visible = False
        '
        'LBLMACHINE
        '
        Me.LBLMACHINE.AutoSize = True
        Me.LBLMACHINE.BackColor = System.Drawing.Color.Transparent
        Me.LBLMACHINE.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LBLMACHINE.Location = New System.Drawing.Point(689, 33)
        Me.LBLMACHINE.Name = "LBLMACHINE"
        Me.LBLMACHINE.Size = New System.Drawing.Size(55, 15)
        Me.LBLMACHINE.TabIndex = 1121
        Me.LBLMACHINE.Text = "Machine"
        Me.LBLMACHINE.Visible = False
        '
        'LBLPREVDATE
        '
        Me.LBLPREVDATE.AutoSize = True
        Me.LBLPREVDATE.BackColor = System.Drawing.Color.Transparent
        Me.LBLPREVDATE.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LBLPREVDATE.Location = New System.Drawing.Point(511, 33)
        Me.LBLPREVDATE.Name = "LBLPREVDATE"
        Me.LBLPREVDATE.Size = New System.Drawing.Size(59, 15)
        Me.LBLPREVDATE.TabIndex = 1077
        Me.LBLPREVDATE.Text = "Prev Date"
        Me.LBLPREVDATE.Visible = False
        '
        'TXTPREVJOBNO
        '
        Me.TXTPREVJOBNO.BackColor = System.Drawing.Color.White
        Me.TXTPREVJOBNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPREVJOBNO.Location = New System.Drawing.Point(429, 29)
        Me.TXTPREVJOBNO.MaxLength = 10
        Me.TXTPREVJOBNO.Name = "TXTPREVJOBNO"
        Me.TXTPREVJOBNO.Size = New System.Drawing.Size(73, 23)
        Me.TXTPREVJOBNO.TabIndex = 1
        Me.TXTPREVJOBNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTPREVJOBNO.Visible = False
        '
        'LBLPREV
        '
        Me.LBLPREV.AutoSize = True
        Me.LBLPREV.BackColor = System.Drawing.Color.Transparent
        Me.LBLPREV.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LBLPREV.Location = New System.Drawing.Point(357, 33)
        Me.LBLPREV.Name = "LBLPREV"
        Me.LBLPREV.Size = New System.Drawing.Size(70, 15)
        Me.LBLPREV.TabIndex = 1075
        Me.LBLPREV.Text = "Prev Job No"
        Me.LBLPREV.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.TXTNUMBERINGUPS)
        Me.GroupBox2.Controls.Add(Me.Label69)
        Me.GroupBox2.Controls.Add(Me.TXTFOLDINGUPS)
        Me.GroupBox2.Controls.Add(Me.Label68)
        Me.GroupBox2.Controls.Add(Me.TXTFINALUPS)
        Me.GroupBox2.Controls.Add(Me.Label67)
        Me.GroupBox2.Controls.Add(Me.TXTPUNCHINGUPS)
        Me.GroupBox2.Controls.Add(Me.Label65)
        Me.GroupBox2.Controls.Add(Me.TXTLAMINATIONUPS)
        Me.GroupBox2.Controls.Add(Me.Label63)
        Me.GroupBox2.Controls.Add(Me.CMBCOL2PLATETYPE)
        Me.GroupBox2.Controls.Add(Me.Label59)
        Me.GroupBox2.Controls.Add(Me.TXTCOL2PLATES)
        Me.GroupBox2.Controls.Add(Me.Label58)
        Me.GroupBox2.Controls.Add(Me.TXTCOL2)
        Me.GroupBox2.Controls.Add(Me.Label49)
        Me.GroupBox2.Controls.Add(Me.CMBLAMM)
        Me.GroupBox2.Controls.Add(Me.CMBLENVELOPE)
        Me.GroupBox2.Controls.Add(Me.CMBLUV)
        Me.GroupBox2.Controls.Add(Me.CMBLPUNCHING)
        Me.GroupBox2.Controls.Add(Me.CMBLGUM)
        Me.GroupBox2.Controls.Add(Me.CMBLBINDING)
        Me.GroupBox2.Controls.Add(Me.CMBVENDOR)
        Me.GroupBox2.Controls.Add(Me.CMBLFABRICATION)
        Me.GroupBox2.Controls.Add(Me.CMBLNUMBERING)
        Me.GroupBox2.Controls.Add(Me.CMBVENDOR1)
        Me.GroupBox2.Controls.Add(Me.CMBLPACKING)
        Me.GroupBox2.Controls.Add(Me.CMBLAM)
        Me.GroupBox2.Controls.Add(Me.TXTLAMINATION1)
        Me.GroupBox2.Controls.Add(Me.TXTLAMINATION2)
        Me.GroupBox2.Controls.Add(Me.CMBLAM1)
        Me.GroupBox2.Controls.Add(Me.CMBLAM2)
        Me.GroupBox2.Controls.Add(Me.CMBLAMMODE)
        Me.GroupBox2.Controls.Add(Me.Label60)
        Me.GroupBox2.Controls.Add(Me.Label48)
        Me.GroupBox2.Controls.Add(Me.TXTFILMSIZE2)
        Me.GroupBox2.Controls.Add(Me.CMBUV)
        Me.GroupBox2.Controls.Add(Me.Label57)
        Me.GroupBox2.Controls.Add(Me.CMBPUNCHING)
        Me.GroupBox2.Controls.Add(Me.Label56)
        Me.GroupBox2.Controls.Add(Me.CMBENVELOPE)
        Me.GroupBox2.Controls.Add(Me.Label55)
        Me.GroupBox2.Controls.Add(Me.CMBGUMMING)
        Me.GroupBox2.Controls.Add(Me.Label54)
        Me.GroupBox2.Controls.Add(Me.CMBBINDING)
        Me.GroupBox2.Controls.Add(Me.Label53)
        Me.GroupBox2.Controls.Add(Me.CMBPACKING)
        Me.GroupBox2.Controls.Add(Me.Label52)
        Me.GroupBox2.Controls.Add(Me.CMBFABRICATION)
        Me.GroupBox2.Controls.Add(Me.Label51)
        Me.GroupBox2.Controls.Add(Me.CMBNUMBERING)
        Me.GroupBox2.Controls.Add(Me.Label50)
        Me.GroupBox2.Controls.Add(Me.CMBLAMINATION)
        Me.GroupBox2.Controls.Add(Me.Label46)
        Me.GroupBox2.Controls.Add(Me.Label45)
        Me.GroupBox2.Controls.Add(Me.Label44)
        Me.GroupBox2.Controls.Add(Me.TXTFILMSIZE)
        Me.GroupBox2.Controls.Add(Me.TXTSHEETS)
        Me.GroupBox2.Controls.Add(Me.Label43)
        Me.GroupBox2.Controls.Add(Me.TXTKGS)
        Me.GroupBox2.Controls.Add(Me.Label42)
        Me.GroupBox2.Controls.Add(Me.TXTYIELD)
        Me.GroupBox2.Controls.Add(Me.Label41)
        Me.GroupBox2.Controls.Add(Me.Label36)
        Me.GroupBox2.Controls.Add(Me.TXTCOL1PLATES)
        Me.GroupBox2.Controls.Add(Me.CMBMODE)
        Me.GroupBox2.Controls.Add(Me.TXTCOL1)
        Me.GroupBox2.Controls.Add(Me.TXTCUTSHEET)
        Me.GroupBox2.Controls.Add(Me.CMBCOL1PLATETYPE)
        Me.GroupBox2.Controls.Add(Me.TXTEXTRA)
        Me.GroupBox2.Controls.Add(Me.TXTTOTAL)
        Me.GroupBox2.Controls.Add(Me.TXTTIME)
        Me.GroupBox2.Controls.Add(Me.TXTCUTSIZEG)
        Me.GroupBox2.Controls.Add(Me.TXTCOLORUPS)
        Me.GroupBox2.Controls.Add(Me.TXTFULLSIZE)
        Me.GroupBox2.Controls.Add(Me.Label34)
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.TXTCOLORSHEET)
        Me.GroupBox2.Controls.Add(Me.Label25)
        Me.GroupBox2.Controls.Add(Me.Label28)
        Me.GroupBox2.Controls.Add(Me.Label30)
        Me.GroupBox2.Controls.Add(Me.Label32)
        Me.GroupBox2.Controls.Add(Me.Label33)
        Me.GroupBox2.Controls.Add(Me.Label35)
        Me.GroupBox2.Controls.Add(Me.Label37)
        Me.GroupBox2.Controls.Add(Me.Label38)
        Me.GroupBox2.Controls.Add(Me.Label40)
        Me.GroupBox2.Controls.Add(Me.Label39)
        Me.GroupBox2.Location = New System.Drawing.Point(17, 277)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1114, 259)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Visible = False
        '
        'TXTNUMBERINGUPS
        '
        Me.TXTNUMBERINGUPS.BackColor = System.Drawing.Color.White
        Me.TXTNUMBERINGUPS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNUMBERINGUPS.Location = New System.Drawing.Point(1063, 67)
        Me.TXTNUMBERINGUPS.MaxLength = 50
        Me.TXTNUMBERINGUPS.Name = "TXTNUMBERINGUPS"
        Me.TXTNUMBERINGUPS.Size = New System.Drawing.Size(49, 23)
        Me.TXTNUMBERINGUPS.TabIndex = 1141
        Me.TXTNUMBERINGUPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.BackColor = System.Drawing.Color.Transparent
        Me.Label69.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label69.Location = New System.Drawing.Point(971, 72)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(91, 15)
        Me.Label69.TabIndex = 1142
        Me.Label69.Text = "Numbering Ups"
        '
        'TXTFOLDINGUPS
        '
        Me.TXTFOLDINGUPS.BackColor = System.Drawing.Color.White
        Me.TXTFOLDINGUPS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFOLDINGUPS.Location = New System.Drawing.Point(921, 66)
        Me.TXTFOLDINGUPS.MaxLength = 50
        Me.TXTFOLDINGUPS.Name = "TXTFOLDINGUPS"
        Me.TXTFOLDINGUPS.Size = New System.Drawing.Size(49, 23)
        Me.TXTFOLDINGUPS.TabIndex = 1139
        Me.TXTFOLDINGUPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.BackColor = System.Drawing.Color.Transparent
        Me.Label68.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label68.Location = New System.Drawing.Point(847, 71)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(72, 15)
        Me.Label68.TabIndex = 1140
        Me.Label68.Text = "Folding Ups"
        '
        'TXTFINALUPS
        '
        Me.TXTFINALUPS.BackColor = System.Drawing.Color.White
        Me.TXTFINALUPS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFINALUPS.Location = New System.Drawing.Point(921, 92)
        Me.TXTFINALUPS.MaxLength = 50
        Me.TXTFINALUPS.Name = "TXTFINALUPS"
        Me.TXTFINALUPS.Size = New System.Drawing.Size(49, 23)
        Me.TXTFINALUPS.TabIndex = 1137
        Me.TXTFINALUPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.BackColor = System.Drawing.Color.Transparent
        Me.Label67.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label67.Location = New System.Drawing.Point(859, 97)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(59, 15)
        Me.Label67.TabIndex = 1138
        Me.Label67.Text = "Final Ups"
        '
        'TXTPUNCHINGUPS
        '
        Me.TXTPUNCHINGUPS.BackColor = System.Drawing.Color.White
        Me.TXTPUNCHINGUPS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPUNCHINGUPS.Location = New System.Drawing.Point(796, 91)
        Me.TXTPUNCHINGUPS.MaxLength = 50
        Me.TXTPUNCHINGUPS.Name = "TXTPUNCHINGUPS"
        Me.TXTPUNCHINGUPS.Size = New System.Drawing.Size(49, 23)
        Me.TXTPUNCHINGUPS.TabIndex = 1135
        Me.TXTPUNCHINGUPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.BackColor = System.Drawing.Color.Transparent
        Me.Label65.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label65.Location = New System.Drawing.Point(711, 95)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(82, 15)
        Me.Label65.TabIndex = 1136
        Me.Label65.Text = "Punching Ups"
        '
        'TXTLAMINATIONUPS
        '
        Me.TXTLAMINATIONUPS.BackColor = System.Drawing.Color.White
        Me.TXTLAMINATIONUPS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTLAMINATIONUPS.Location = New System.Drawing.Point(796, 66)
        Me.TXTLAMINATIONUPS.MaxLength = 50
        Me.TXTLAMINATIONUPS.Name = "TXTLAMINATIONUPS"
        Me.TXTLAMINATIONUPS.Size = New System.Drawing.Size(49, 23)
        Me.TXTLAMINATIONUPS.TabIndex = 1133
        Me.TXTLAMINATIONUPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.BackColor = System.Drawing.Color.Transparent
        Me.Label63.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label63.Location = New System.Drawing.Point(701, 71)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(92, 15)
        Me.Label63.TabIndex = 1134
        Me.Label63.Text = "Lamination Ups"
        '
        'CMBCOL2PLATETYPE
        '
        Me.CMBCOL2PLATETYPE.BackColor = System.Drawing.Color.White
        Me.CMBCOL2PLATETYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBCOL2PLATETYPE.ForeColor = System.Drawing.Color.Black
        Me.CMBCOL2PLATETYPE.FormattingEnabled = True
        Me.CMBCOL2PLATETYPE.Items.AddRange(New Object() {"", "Old", "New"})
        Me.CMBCOL2PLATETYPE.Location = New System.Drawing.Point(256, 74)
        Me.CMBCOL2PLATETYPE.Name = "CMBCOL2PLATETYPE"
        Me.CMBCOL2PLATETYPE.Size = New System.Drawing.Size(72, 23)
        Me.CMBCOL2PLATETYPE.TabIndex = 1131
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.BackColor = System.Drawing.Color.Transparent
        Me.Label59.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label59.Location = New System.Drawing.Point(166, 78)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(91, 15)
        Me.Label59.TabIndex = 1132
        Me.Label59.Text = "Back Plate Type"
        '
        'TXTCOL2PLATES
        '
        Me.TXTCOL2PLATES.BackColor = System.Drawing.Color.White
        Me.TXTCOL2PLATES.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCOL2PLATES.Location = New System.Drawing.Point(256, 44)
        Me.TXTCOL2PLATES.MaxLength = 50
        Me.TXTCOL2PLATES.Name = "TXTCOL2PLATES"
        Me.TXTCOL2PLATES.Size = New System.Drawing.Size(72, 23)
        Me.TXTCOL2PLATES.TabIndex = 1129
        Me.TXTCOL2PLATES.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.BackColor = System.Drawing.Color.Transparent
        Me.Label58.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label58.Location = New System.Drawing.Point(182, 48)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(70, 15)
        Me.Label58.TabIndex = 1130
        Me.Label58.Text = "Back Plates"
        '
        'TXTCOL2
        '
        Me.TXTCOL2.BackColor = System.Drawing.Color.White
        Me.TXTCOL2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCOL2.Location = New System.Drawing.Point(256, 14)
        Me.TXTCOL2.MaxLength = 50
        Me.TXTCOL2.Name = "TXTCOL2"
        Me.TXTCOL2.Size = New System.Drawing.Size(72, 23)
        Me.TXTCOL2.TabIndex = 1
        Me.TXTCOL2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.BackColor = System.Drawing.Color.Transparent
        Me.Label49.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label49.Location = New System.Drawing.Point(188, 19)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(66, 15)
        Me.Label49.TabIndex = 1128
        Me.Label49.Text = "Back Color"
        '
        'CMBLAMM
        '
        Me.CMBLAMM.BackColor = System.Drawing.Color.White
        Me.CMBLAMM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBLAMM.ForeColor = System.Drawing.Color.Black
        Me.CMBLAMM.FormattingEnabled = True
        Me.CMBLAMM.Items.AddRange(New Object() {"", "Matt", "Gloss", "Thermal Matt", "Thermal Gloss", "Velvet", "BOPP"})
        Me.CMBLAMM.Location = New System.Drawing.Point(97, 134)
        Me.CMBLAMM.Name = "CMBLAMM"
        Me.CMBLAMM.Size = New System.Drawing.Size(154, 23)
        Me.CMBLAMM.TabIndex = 13
        '
        'CMBLENVELOPE
        '
        Me.CMBLENVELOPE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBLENVELOPE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBLENVELOPE.BackColor = System.Drawing.SystemColors.Window
        Me.CMBLENVELOPE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBLENVELOPE.FormattingEnabled = True
        Me.CMBLENVELOPE.Location = New System.Drawing.Point(472, 164)
        Me.CMBLENVELOPE.MaxDropDownItems = 14
        Me.CMBLENVELOPE.MaxLength = 200
        Me.CMBLENVELOPE.Name = "CMBLENVELOPE"
        Me.CMBLENVELOPE.Size = New System.Drawing.Size(86, 23)
        Me.CMBLENVELOPE.TabIndex = 28
        '
        'CMBLUV
        '
        Me.CMBLUV.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBLUV.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBLUV.BackColor = System.Drawing.SystemColors.Window
        Me.CMBLUV.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBLUV.FormattingEnabled = True
        Me.CMBLUV.Location = New System.Drawing.Point(170, 192)
        Me.CMBLUV.MaxDropDownItems = 14
        Me.CMBLUV.MaxLength = 200
        Me.CMBLUV.Name = "CMBLUV"
        Me.CMBLUV.Size = New System.Drawing.Size(86, 23)
        Me.CMBLUV.TabIndex = 24
        '
        'CMBLPUNCHING
        '
        Me.CMBLPUNCHING.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBLPUNCHING.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBLPUNCHING.BackColor = System.Drawing.SystemColors.Window
        Me.CMBLPUNCHING.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBLPUNCHING.FormattingEnabled = True
        Me.CMBLPUNCHING.Location = New System.Drawing.Point(169, 221)
        Me.CMBLPUNCHING.MaxDropDownItems = 14
        Me.CMBLPUNCHING.MaxLength = 200
        Me.CMBLPUNCHING.Name = "CMBLPUNCHING"
        Me.CMBLPUNCHING.Size = New System.Drawing.Size(86, 23)
        Me.CMBLPUNCHING.TabIndex = 26
        '
        'CMBLGUM
        '
        Me.CMBLGUM.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBLGUM.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBLGUM.BackColor = System.Drawing.SystemColors.Window
        Me.CMBLGUM.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBLGUM.FormattingEnabled = True
        Me.CMBLGUM.Location = New System.Drawing.Point(472, 193)
        Me.CMBLGUM.MaxDropDownItems = 14
        Me.CMBLGUM.MaxLength = 200
        Me.CMBLGUM.Name = "CMBLGUM"
        Me.CMBLGUM.Size = New System.Drawing.Size(86, 23)
        Me.CMBLGUM.TabIndex = 30
        '
        'CMBLBINDING
        '
        Me.CMBLBINDING.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBLBINDING.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBLBINDING.BackColor = System.Drawing.SystemColors.Window
        Me.CMBLBINDING.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBLBINDING.FormattingEnabled = True
        Me.CMBLBINDING.Location = New System.Drawing.Point(472, 221)
        Me.CMBLBINDING.MaxDropDownItems = 14
        Me.CMBLBINDING.MaxLength = 200
        Me.CMBLBINDING.Name = "CMBLBINDING"
        Me.CMBLBINDING.Size = New System.Drawing.Size(86, 23)
        Me.CMBLBINDING.TabIndex = 32
        '
        'CMBVENDOR
        '
        Me.CMBVENDOR.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBVENDOR.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBVENDOR.BackColor = System.Drawing.SystemColors.Window
        Me.CMBVENDOR.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBVENDOR.FormattingEnabled = True
        Me.CMBVENDOR.Location = New System.Drawing.Point(739, 222)
        Me.CMBVENDOR.MaxDropDownItems = 14
        Me.CMBVENDOR.MaxLength = 200
        Me.CMBVENDOR.Name = "CMBVENDOR"
        Me.CMBVENDOR.Size = New System.Drawing.Size(86, 23)
        Me.CMBVENDOR.TabIndex = 39
        '
        'CMBLFABRICATION
        '
        Me.CMBLFABRICATION.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBLFABRICATION.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBLFABRICATION.BackColor = System.Drawing.SystemColors.Window
        Me.CMBLFABRICATION.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBLFABRICATION.FormattingEnabled = True
        Me.CMBLFABRICATION.Location = New System.Drawing.Point(740, 193)
        Me.CMBLFABRICATION.MaxDropDownItems = 14
        Me.CMBLFABRICATION.MaxLength = 200
        Me.CMBLFABRICATION.Name = "CMBLFABRICATION"
        Me.CMBLFABRICATION.Size = New System.Drawing.Size(86, 23)
        Me.CMBLFABRICATION.TabIndex = 36
        '
        'CMBLNUMBERING
        '
        Me.CMBLNUMBERING.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBLNUMBERING.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBLNUMBERING.BackColor = System.Drawing.SystemColors.Window
        Me.CMBLNUMBERING.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBLNUMBERING.FormattingEnabled = True
        Me.CMBLNUMBERING.Location = New System.Drawing.Point(739, 164)
        Me.CMBLNUMBERING.MaxDropDownItems = 14
        Me.CMBLNUMBERING.MaxLength = 200
        Me.CMBLNUMBERING.Name = "CMBLNUMBERING"
        Me.CMBLNUMBERING.Size = New System.Drawing.Size(86, 23)
        Me.CMBLNUMBERING.TabIndex = 34
        '
        'CMBVENDOR1
        '
        Me.CMBVENDOR1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBVENDOR1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBVENDOR1.BackColor = System.Drawing.SystemColors.Window
        Me.CMBVENDOR1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBVENDOR1.FormattingEnabled = True
        Me.CMBVENDOR1.Location = New System.Drawing.Point(995, 164)
        Me.CMBVENDOR1.MaxDropDownItems = 14
        Me.CMBVENDOR1.MaxLength = 200
        Me.CMBVENDOR1.Name = "CMBVENDOR1"
        Me.CMBVENDOR1.Size = New System.Drawing.Size(86, 23)
        Me.CMBVENDOR1.TabIndex = 42
        '
        'CMBLPACKING
        '
        Me.CMBLPACKING.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBLPACKING.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBLPACKING.BackColor = System.Drawing.SystemColors.Window
        Me.CMBLPACKING.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBLPACKING.FormattingEnabled = True
        Me.CMBLPACKING.Location = New System.Drawing.Point(995, 192)
        Me.CMBLPACKING.MaxDropDownItems = 14
        Me.CMBLPACKING.MaxLength = 200
        Me.CMBLPACKING.Name = "CMBLPACKING"
        Me.CMBLPACKING.Size = New System.Drawing.Size(86, 23)
        Me.CMBLPACKING.TabIndex = 44
        '
        'CMBLAM
        '
        Me.CMBLAM.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBLAM.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBLAM.BackColor = System.Drawing.SystemColors.Window
        Me.CMBLAM.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBLAM.FormattingEnabled = True
        Me.CMBLAM.Location = New System.Drawing.Point(170, 162)
        Me.CMBLAM.MaxDropDownItems = 14
        Me.CMBLAM.MaxLength = 200
        Me.CMBLAM.Name = "CMBLAM"
        Me.CMBLAM.Size = New System.Drawing.Size(86, 23)
        Me.CMBLAM.TabIndex = 22
        '
        'TXTLAMINATION1
        '
        Me.TXTLAMINATION1.BackColor = System.Drawing.Color.White
        Me.TXTLAMINATION1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTLAMINATION1.Location = New System.Drawing.Point(589, 222)
        Me.TXTLAMINATION1.MaxLength = 10
        Me.TXTLAMINATION1.Name = "TXTLAMINATION1"
        Me.TXTLAMINATION1.Size = New System.Drawing.Size(68, 23)
        Me.TXTLAMINATION1.TabIndex = 37
        Me.TXTLAMINATION1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTLAMINATION2
        '
        Me.TXTLAMINATION2.BackColor = System.Drawing.Color.White
        Me.TXTLAMINATION2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTLAMINATION2.Location = New System.Drawing.Point(847, 163)
        Me.TXTLAMINATION2.MaxLength = 10
        Me.TXTLAMINATION2.Name = "TXTLAMINATION2"
        Me.TXTLAMINATION2.Size = New System.Drawing.Size(68, 23)
        Me.TXTLAMINATION2.TabIndex = 40
        Me.TXTLAMINATION2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMBLAM1
        '
        Me.CMBLAM1.BackColor = System.Drawing.Color.White
        Me.CMBLAM1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBLAM1.ForeColor = System.Drawing.Color.Black
        Me.CMBLAM1.FormattingEnabled = True
        Me.CMBLAM1.Items.AddRange(New Object() {"", "Yes", "No", "Out"})
        Me.CMBLAM1.Location = New System.Drawing.Point(665, 222)
        Me.CMBLAM1.Name = "CMBLAM1"
        Me.CMBLAM1.Size = New System.Drawing.Size(68, 23)
        Me.CMBLAM1.TabIndex = 38
        '
        'CMBLAM2
        '
        Me.CMBLAM2.BackColor = System.Drawing.Color.White
        Me.CMBLAM2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBLAM2.ForeColor = System.Drawing.Color.Black
        Me.CMBLAM2.FormattingEnabled = True
        Me.CMBLAM2.Items.AddRange(New Object() {"", "Yes", "No", "Out"})
        Me.CMBLAM2.Location = New System.Drawing.Point(921, 163)
        Me.CMBLAM2.Name = "CMBLAM2"
        Me.CMBLAM2.Size = New System.Drawing.Size(68, 23)
        Me.CMBLAM2.TabIndex = 41
        '
        'CMBLAMMODE
        '
        Me.CMBLAMMODE.BackColor = System.Drawing.Color.White
        Me.CMBLAMMODE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBLAMMODE.ForeColor = System.Drawing.Color.Black
        Me.CMBLAMMODE.FormattingEnabled = True
        Me.CMBLAMMODE.Items.AddRange(New Object() {"", "F", "B", "FB", "S/B", "D/G"})
        Me.CMBLAMMODE.Location = New System.Drawing.Point(432, 133)
        Me.CMBLAMMODE.Name = "CMBLAMMODE"
        Me.CMBLAMMODE.Size = New System.Drawing.Size(69, 23)
        Me.CMBLAMMODE.TabIndex = 15
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.BackColor = System.Drawing.Color.Transparent
        Me.Label60.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label60.Location = New System.Drawing.Point(388, 137)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(38, 15)
        Me.Label60.TabIndex = 1121
        Me.Label60.Text = "Mode"
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.BackColor = System.Drawing.Color.Transparent
        Me.Label48.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label48.Location = New System.Drawing.Point(781, 137)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(65, 15)
        Me.Label48.TabIndex = 1117
        Me.Label48.Text = "Film Size 2"
        '
        'TXTFILMSIZE2
        '
        Me.TXTFILMSIZE2.BackColor = System.Drawing.Color.White
        Me.TXTFILMSIZE2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFILMSIZE2.Location = New System.Drawing.Point(852, 133)
        Me.TXTFILMSIZE2.MaxLength = 10
        Me.TXTFILMSIZE2.Name = "TXTFILMSIZE2"
        Me.TXTFILMSIZE2.Size = New System.Drawing.Size(58, 23)
        Me.TXTFILMSIZE2.TabIndex = 18
        Me.TXTFILMSIZE2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMBUV
        '
        Me.CMBUV.BackColor = System.Drawing.Color.White
        Me.CMBUV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBUV.ForeColor = System.Drawing.Color.Black
        Me.CMBUV.FormattingEnabled = True
        Me.CMBUV.Items.AddRange(New Object() {"", "Yes", "No", "Out"})
        Me.CMBUV.Location = New System.Drawing.Point(95, 192)
        Me.CMBUV.Name = "CMBUV"
        Me.CMBUV.Size = New System.Drawing.Size(68, 23)
        Me.CMBUV.TabIndex = 23
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.BackColor = System.Drawing.Color.Transparent
        Me.Label57.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label57.Location = New System.Drawing.Point(63, 196)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(26, 15)
        Me.Label57.TabIndex = 1114
        Me.Label57.Text = "U.V."
        '
        'CMBPUNCHING
        '
        Me.CMBPUNCHING.BackColor = System.Drawing.Color.White
        Me.CMBPUNCHING.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBPUNCHING.ForeColor = System.Drawing.Color.Black
        Me.CMBPUNCHING.FormattingEnabled = True
        Me.CMBPUNCHING.Items.AddRange(New Object() {"", "Yes", "No", "Out"})
        Me.CMBPUNCHING.Location = New System.Drawing.Point(95, 221)
        Me.CMBPUNCHING.Name = "CMBPUNCHING"
        Me.CMBPUNCHING.Size = New System.Drawing.Size(68, 23)
        Me.CMBPUNCHING.TabIndex = 25
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.BackColor = System.Drawing.Color.Transparent
        Me.Label56.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label56.Location = New System.Drawing.Point(31, 225)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(58, 15)
        Me.Label56.TabIndex = 1112
        Me.Label56.Text = "Punching"
        '
        'CMBENVELOPE
        '
        Me.CMBENVELOPE.BackColor = System.Drawing.Color.White
        Me.CMBENVELOPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBENVELOPE.ForeColor = System.Drawing.Color.Black
        Me.CMBENVELOPE.FormattingEnabled = True
        Me.CMBENVELOPE.Items.AddRange(New Object() {"", "Yes", "No", "Out"})
        Me.CMBENVELOPE.Location = New System.Drawing.Point(398, 163)
        Me.CMBENVELOPE.Name = "CMBENVELOPE"
        Me.CMBENVELOPE.Size = New System.Drawing.Size(68, 23)
        Me.CMBENVELOPE.TabIndex = 27
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.BackColor = System.Drawing.Color.Transparent
        Me.Label55.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label55.Location = New System.Drawing.Point(292, 167)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(100, 15)
        Me.Label55.TabIndex = 1110
        Me.Label55.Text = "Envelope Making"
        '
        'CMBGUMMING
        '
        Me.CMBGUMMING.BackColor = System.Drawing.Color.White
        Me.CMBGUMMING.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBGUMMING.ForeColor = System.Drawing.Color.Black
        Me.CMBGUMMING.FormattingEnabled = True
        Me.CMBGUMMING.Items.AddRange(New Object() {"", "Yes", "No", "Out"})
        Me.CMBGUMMING.Location = New System.Drawing.Point(398, 192)
        Me.CMBGUMMING.Name = "CMBGUMMING"
        Me.CMBGUMMING.Size = New System.Drawing.Size(68, 23)
        Me.CMBGUMMING.TabIndex = 29
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.BackColor = System.Drawing.Color.Transparent
        Me.Label54.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label54.Location = New System.Drawing.Point(330, 196)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(62, 15)
        Me.Label54.TabIndex = 1108
        Me.Label54.Text = "Gumming "
        '
        'CMBBINDING
        '
        Me.CMBBINDING.BackColor = System.Drawing.Color.White
        Me.CMBBINDING.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBBINDING.ForeColor = System.Drawing.Color.Black
        Me.CMBBINDING.FormattingEnabled = True
        Me.CMBBINDING.Items.AddRange(New Object() {"", "Yes", "No", "Out"})
        Me.CMBBINDING.Location = New System.Drawing.Point(398, 222)
        Me.CMBBINDING.Name = "CMBBINDING"
        Me.CMBBINDING.Size = New System.Drawing.Size(68, 23)
        Me.CMBBINDING.TabIndex = 31
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.BackColor = System.Drawing.Color.Transparent
        Me.Label53.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label53.Location = New System.Drawing.Point(343, 226)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(49, 15)
        Me.Label53.TabIndex = 1106
        Me.Label53.Text = "Binding"
        '
        'CMBPACKING
        '
        Me.CMBPACKING.BackColor = System.Drawing.Color.White
        Me.CMBPACKING.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBPACKING.ForeColor = System.Drawing.Color.Black
        Me.CMBPACKING.FormattingEnabled = True
        Me.CMBPACKING.Items.AddRange(New Object() {"", "Yes", "No", "Out"})
        Me.CMBPACKING.Location = New System.Drawing.Point(921, 192)
        Me.CMBPACKING.Name = "CMBPACKING"
        Me.CMBPACKING.Size = New System.Drawing.Size(68, 23)
        Me.CMBPACKING.TabIndex = 43
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.BackColor = System.Drawing.Color.Transparent
        Me.Label52.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label52.Location = New System.Drawing.Point(865, 196)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(50, 15)
        Me.Label52.TabIndex = 1104
        Me.Label52.Text = "Packing"
        '
        'CMBFABRICATION
        '
        Me.CMBFABRICATION.BackColor = System.Drawing.Color.White
        Me.CMBFABRICATION.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBFABRICATION.ForeColor = System.Drawing.Color.Black
        Me.CMBFABRICATION.FormattingEnabled = True
        Me.CMBFABRICATION.Items.AddRange(New Object() {"", "Yes", "No", "Out"})
        Me.CMBFABRICATION.Location = New System.Drawing.Point(666, 192)
        Me.CMBFABRICATION.Name = "CMBFABRICATION"
        Me.CMBFABRICATION.Size = New System.Drawing.Size(68, 23)
        Me.CMBFABRICATION.TabIndex = 35
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.BackColor = System.Drawing.Color.Transparent
        Me.Label51.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label51.Location = New System.Drawing.Point(590, 196)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(70, 15)
        Me.Label51.TabIndex = 1102
        Me.Label51.Text = "Fabrication"
        '
        'CMBNUMBERING
        '
        Me.CMBNUMBERING.BackColor = System.Drawing.Color.White
        Me.CMBNUMBERING.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBNUMBERING.ForeColor = System.Drawing.Color.Black
        Me.CMBNUMBERING.FormattingEnabled = True
        Me.CMBNUMBERING.Items.AddRange(New Object() {"", "Yes", "No", "Out"})
        Me.CMBNUMBERING.Location = New System.Drawing.Point(665, 163)
        Me.CMBNUMBERING.Name = "CMBNUMBERING"
        Me.CMBNUMBERING.Size = New System.Drawing.Size(68, 23)
        Me.CMBNUMBERING.TabIndex = 33
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.BackColor = System.Drawing.Color.Transparent
        Me.Label50.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label50.Location = New System.Drawing.Point(592, 167)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(67, 15)
        Me.Label50.TabIndex = 1100
        Me.Label50.Text = "Numbering"
        '
        'CMBLAMINATION
        '
        Me.CMBLAMINATION.BackColor = System.Drawing.Color.White
        Me.CMBLAMINATION.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBLAMINATION.ForeColor = System.Drawing.Color.Black
        Me.CMBLAMINATION.FormattingEnabled = True
        Me.CMBLAMINATION.Items.AddRange(New Object() {"", "Yes", "No", "Out"})
        Me.CMBLAMINATION.Location = New System.Drawing.Point(96, 163)
        Me.CMBLAMINATION.Name = "CMBLAMINATION"
        Me.CMBLAMINATION.Size = New System.Drawing.Size(68, 23)
        Me.CMBLAMINATION.TabIndex = 21
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.BackColor = System.Drawing.Color.Transparent
        Me.Label46.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label46.Location = New System.Drawing.Point(22, 167)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(68, 15)
        Me.Label46.TabIndex = 1092
        Me.Label46.Text = "Lamination"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.BackColor = System.Drawing.Color.Transparent
        Me.Label45.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label45.Location = New System.Drawing.Point(355, 107)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(387, 15)
        Me.Label45.TabIndex = 1090
        Me.Label45.Text = "....................................................LAMINATION..................." &
    "................................."
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.BackColor = System.Drawing.Color.Transparent
        Me.Label44.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label44.Location = New System.Drawing.Point(648, 137)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(55, 15)
        Me.Label44.TabIndex = 1089
        Me.Label44.Text = "Film Size"
        '
        'TXTFILMSIZE
        '
        Me.TXTFILMSIZE.BackColor = System.Drawing.Color.White
        Me.TXTFILMSIZE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFILMSIZE.Location = New System.Drawing.Point(709, 133)
        Me.TXTFILMSIZE.MaxLength = 10
        Me.TXTFILMSIZE.Name = "TXTFILMSIZE"
        Me.TXTFILMSIZE.Size = New System.Drawing.Size(58, 23)
        Me.TXTFILMSIZE.TabIndex = 17
        Me.TXTFILMSIZE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTSHEETS
        '
        Me.TXTSHEETS.BackColor = System.Drawing.Color.White
        Me.TXTSHEETS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSHEETS.Location = New System.Drawing.Point(562, 133)
        Me.TXTSHEETS.MaxLength = 10
        Me.TXTSHEETS.Name = "TXTSHEETS"
        Me.TXTSHEETS.Size = New System.Drawing.Size(68, 23)
        Me.TXTSHEETS.TabIndex = 16
        Me.TXTSHEETS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.BackColor = System.Drawing.Color.Transparent
        Me.Label43.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label43.Location = New System.Drawing.Point(514, 137)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(42, 15)
        Me.Label43.TabIndex = 1087
        Me.Label43.Text = "Sheets"
        '
        'TXTKGS
        '
        Me.TXTKGS.BackColor = System.Drawing.Color.White
        Me.TXTKGS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTKGS.Location = New System.Drawing.Point(1031, 133)
        Me.TXTKGS.MaxLength = 10
        Me.TXTKGS.Name = "TXTKGS"
        Me.TXTKGS.Size = New System.Drawing.Size(69, 23)
        Me.TXTKGS.TabIndex = 20
        Me.TXTKGS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.BackColor = System.Drawing.Color.Transparent
        Me.Label42.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label42.Location = New System.Drawing.Point(999, 137)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(26, 15)
        Me.Label42.TabIndex = 1085
        Me.Label42.Text = "Kgs"
        '
        'TXTYIELD
        '
        Me.TXTYIELD.BackColor = System.Drawing.Color.White
        Me.TXTYIELD.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTYIELD.Location = New System.Drawing.Point(303, 133)
        Me.TXTYIELD.MaxLength = 10
        Me.TXTYIELD.Name = "TXTYIELD"
        Me.TXTYIELD.Size = New System.Drawing.Size(68, 23)
        Me.TXTYIELD.TabIndex = 14
        Me.TXTYIELD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.BackColor = System.Drawing.Color.Transparent
        Me.Label41.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label41.Location = New System.Drawing.Point(263, 137)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(34, 15)
        Me.Label41.TabIndex = 1083
        Me.Label41.Text = "Yield"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.BackColor = System.Drawing.Color.Transparent
        Me.Label36.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label36.Location = New System.Drawing.Point(0, 137)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(95, 15)
        Me.Label36.TabIndex = 1081
        Me.Label36.Text = "Lamination Film"
        '
        'TXTCOL1PLATES
        '
        Me.TXTCOL1PLATES.BackColor = System.Drawing.Color.White
        Me.TXTCOL1PLATES.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCOL1PLATES.Location = New System.Drawing.Point(91, 44)
        Me.TXTCOL1PLATES.MaxLength = 50
        Me.TXTCOL1PLATES.Name = "TXTCOL1PLATES"
        Me.TXTCOL1PLATES.Size = New System.Drawing.Size(72, 23)
        Me.TXTCOL1PLATES.TabIndex = 3
        Me.TXTCOL1PLATES.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMBMODE
        '
        Me.CMBMODE.BackColor = System.Drawing.Color.White
        Me.CMBMODE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBMODE.ForeColor = System.Drawing.Color.Black
        Me.CMBMODE.FormattingEnabled = True
        Me.CMBMODE.Items.AddRange(New Object() {"", "F", "B", "FB", "S/B", "D/G"})
        Me.CMBMODE.Location = New System.Drawing.Point(372, 14)
        Me.CMBMODE.Name = "CMBMODE"
        Me.CMBMODE.Size = New System.Drawing.Size(89, 23)
        Me.CMBMODE.TabIndex = 2
        '
        'TXTCOL1
        '
        Me.TXTCOL1.BackColor = System.Drawing.Color.White
        Me.TXTCOL1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCOL1.Location = New System.Drawing.Point(91, 14)
        Me.TXTCOL1.MaxLength = 50
        Me.TXTCOL1.Name = "TXTCOL1"
        Me.TXTCOL1.Size = New System.Drawing.Size(72, 23)
        Me.TXTCOL1.TabIndex = 0
        Me.TXTCOL1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTCUTSHEET
        '
        Me.TXTCUTSHEET.BackColor = System.Drawing.Color.White
        Me.TXTCUTSHEET.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCUTSHEET.Location = New System.Drawing.Point(548, 14)
        Me.TXTCUTSHEET.MaxLength = 100
        Me.TXTCUTSHEET.Name = "TXTCUTSHEET"
        Me.TXTCUTSHEET.Size = New System.Drawing.Size(100, 23)
        Me.TXTCUTSHEET.TabIndex = 6
        Me.TXTCUTSHEET.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMBCOL1PLATETYPE
        '
        Me.CMBCOL1PLATETYPE.BackColor = System.Drawing.Color.White
        Me.CMBCOL1PLATETYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBCOL1PLATETYPE.ForeColor = System.Drawing.Color.Black
        Me.CMBCOL1PLATETYPE.FormattingEnabled = True
        Me.CMBCOL1PLATETYPE.Items.AddRange(New Object() {"", "Old", "New"})
        Me.CMBCOL1PLATETYPE.Location = New System.Drawing.Point(91, 74)
        Me.CMBCOL1PLATETYPE.Name = "CMBCOL1PLATETYPE"
        Me.CMBCOL1PLATETYPE.Size = New System.Drawing.Size(72, 23)
        Me.CMBCOL1PLATETYPE.TabIndex = 4
        '
        'TXTEXTRA
        '
        Me.TXTEXTRA.BackColor = System.Drawing.Color.White
        Me.TXTEXTRA.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTEXTRA.Location = New System.Drawing.Point(548, 41)
        Me.TXTEXTRA.MaxLength = 100
        Me.TXTEXTRA.Name = "TXTEXTRA"
        Me.TXTEXTRA.Size = New System.Drawing.Size(100, 23)
        Me.TXTEXTRA.TabIndex = 7
        Me.TXTEXTRA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTTOTAL
        '
        Me.TXTTOTAL.BackColor = System.Drawing.Color.White
        Me.TXTTOTAL.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOTAL.Location = New System.Drawing.Point(548, 68)
        Me.TXTTOTAL.MaxLength = 100
        Me.TXTTOTAL.Name = "TXTTOTAL"
        Me.TXTTOTAL.ReadOnly = True
        Me.TXTTOTAL.Size = New System.Drawing.Size(100, 23)
        Me.TXTTOTAL.TabIndex = 8
        Me.TXTTOTAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTTIME
        '
        Me.TXTTIME.BackColor = System.Drawing.Color.White
        Me.TXTTIME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTIME.Location = New System.Drawing.Point(964, 133)
        Me.TXTTIME.MaxLength = 100
        Me.TXTTIME.Name = "TXTTIME"
        Me.TXTTIME.Size = New System.Drawing.Size(21, 23)
        Me.TXTTIME.TabIndex = 19
        Me.TXTTIME.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTCUTSIZEG
        '
        Me.TXTCUTSIZEG.BackColor = System.Drawing.Color.White
        Me.TXTCUTSIZEG.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCUTSIZEG.Location = New System.Drawing.Point(796, 40)
        Me.TXTCUTSIZEG.MaxLength = 50
        Me.TXTCUTSIZEG.Name = "TXTCUTSIZEG"
        Me.TXTCUTSIZEG.Size = New System.Drawing.Size(115, 23)
        Me.TXTCUTSIZEG.TabIndex = 11
        Me.TXTCUTSIZEG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTCOLORUPS
        '
        Me.TXTCOLORUPS.BackColor = System.Drawing.Color.White
        Me.TXTCOLORUPS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCOLORUPS.Location = New System.Drawing.Point(797, 14)
        Me.TXTCOLORUPS.MaxLength = 100
        Me.TXTCOLORUPS.Name = "TXTCOLORUPS"
        Me.TXTCOLORUPS.Size = New System.Drawing.Size(114, 23)
        Me.TXTCOLORUPS.TabIndex = 9
        Me.TXTCOLORUPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTFULLSIZE
        '
        Me.TXTFULLSIZE.BackColor = System.Drawing.Color.White
        Me.TXTFULLSIZE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFULLSIZE.Location = New System.Drawing.Point(1012, 40)
        Me.TXTFULLSIZE.MaxLength = 50
        Me.TXTFULLSIZE.Name = "TXTFULLSIZE"
        Me.TXTFULLSIZE.Size = New System.Drawing.Size(100, 23)
        Me.TXTFULLSIZE.TabIndex = 12
        Me.TXTFULLSIZE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.BackColor = System.Drawing.Color.Transparent
        Me.Label34.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label34.Location = New System.Drawing.Point(922, 19)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(88, 15)
        Me.Label34.TabIndex = 1074
        Me.Label34.Text = "Full Sheets Qty"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label24.Location = New System.Drawing.Point(506, 47)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(35, 15)
        Me.Label24.TabIndex = 1067
        Me.Label24.Text = "Extra"
        '
        'TXTCOLORSHEET
        '
        Me.TXTCOLORSHEET.BackColor = System.Drawing.Color.White
        Me.TXTCOLORSHEET.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCOLORSHEET.Location = New System.Drawing.Point(1012, 14)
        Me.TXTCOLORSHEET.MaxLength = 100
        Me.TXTCOLORSHEET.Name = "TXTCOLORSHEET"
        Me.TXTCOLORSHEET.Size = New System.Drawing.Size(100, 23)
        Me.TXTCOLORSHEET.TabIndex = 10
        Me.TXTCOLORSHEET.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label25.Location = New System.Drawing.Point(508, 74)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(34, 15)
        Me.Label25.TabIndex = 1068
        Me.Label25.Text = "Total"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label28.Location = New System.Drawing.Point(20, 17)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(69, 15)
        Me.Label28.TabIndex = 1070
        Me.Label28.Text = "Front Color"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label30.Location = New System.Drawing.Point(17, 48)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(73, 15)
        Me.Label30.TabIndex = 1071
        Me.Label30.Text = "Front Plates"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.BackColor = System.Drawing.Color.Transparent
        Me.Label32.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label32.Location = New System.Drawing.Point(714, 45)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(81, 15)
        Me.Label32.TabIndex = 1072
        Me.Label32.Text = "Cut Sheet Size"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label33.Location = New System.Drawing.Point(467, 18)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(79, 15)
        Me.Label33.TabIndex = 1073
        Me.Label33.Text = "Cut Sheet Qty"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.BackColor = System.Drawing.Color.Transparent
        Me.Label35.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label35.Location = New System.Drawing.Point(925, 136)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(33, 15)
        Me.Label35.TabIndex = 1075
        Me.Label35.Text = "Time"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.BackColor = System.Drawing.Color.Transparent
        Me.Label37.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label37.Location = New System.Drawing.Point(923, 45)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(87, 15)
        Me.Label37.TabIndex = 1076
        Me.Label37.Text = "Full  Sheet Size"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label38.Location = New System.Drawing.Point(653, 19)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(143, 15)
        Me.Label38.TabIndex = 1077
        Me.Label38.Text = "Cut Sheet Ups in Full Size"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.BackColor = System.Drawing.Color.Transparent
        Me.Label40.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label40.Location = New System.Drawing.Point(330, 18)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(38, 15)
        Me.Label40.TabIndex = 1079
        Me.Label40.Text = "Mode"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.BackColor = System.Drawing.Color.Transparent
        Me.Label39.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label39.Location = New System.Drawing.Point(1, 78)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(94, 15)
        Me.Label39.TabIndex = 1078
        Me.Label39.Text = "Front Plate Type"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label22.Location = New System.Drawing.Point(361, 162)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(66, 15)
        Me.Label22.TabIndex = 980
        Me.Label22.Text = "Order Type"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.BackColor = System.Drawing.Color.Transparent
        Me.Label47.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label47.Location = New System.Drawing.Point(73, 148)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(39, 15)
        Me.Label47.TabIndex = 1119
        Me.Label47.Text = "Paper"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(364, 84)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(63, 15)
        Me.Label21.TabIndex = 979
        Me.Label21.Text = "Ord Sr No."
        '
        'CMBNONINVITEM
        '
        Me.CMBNONINVITEM.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBNONINVITEM.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBNONINVITEM.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBNONINVITEM.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBNONINVITEM.FormattingEnabled = True
        Me.CMBNONINVITEM.Location = New System.Drawing.Point(114, 144)
        Me.CMBNONINVITEM.MaxDropDownItems = 14
        Me.CMBNONINVITEM.MaxLength = 200
        Me.CMBNONINVITEM.Name = "CMBNONINVITEM"
        Me.CMBNONINVITEM.Size = New System.Drawing.Size(217, 23)
        Me.CMBNONINVITEM.TabIndex = 2
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(367, 58)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(60, 15)
        Me.Label20.TabIndex = 978
        Me.Label20.Text = "Order No."
        '
        'TXTSHIPTO
        '
        Me.TXTSHIPTO.BackColor = System.Drawing.Color.Linen
        Me.TXTSHIPTO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSHIPTO.Location = New System.Drawing.Point(113, 173)
        Me.TXTSHIPTO.Name = "TXTSHIPTO"
        Me.TXTSHIPTO.ReadOnly = True
        Me.TXTSHIPTO.Size = New System.Drawing.Size(217, 23)
        Me.TXTSHIPTO.TabIndex = 976
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(65, 177)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(46, 14)
        Me.Label19.TabIndex = 975
        Me.Label19.Text = "Ship To"
        '
        'TXTORDERTYPE
        '
        Me.TXTORDERTYPE.BackColor = System.Drawing.Color.Linen
        Me.TXTORDERTYPE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTORDERTYPE.Location = New System.Drawing.Point(429, 158)
        Me.TXTORDERTYPE.Name = "TXTORDERTYPE"
        Me.TXTORDERTYPE.ReadOnly = True
        Me.TXTORDERTYPE.Size = New System.Drawing.Size(108, 23)
        Me.TXTORDERTYPE.TabIndex = 977
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtshadecard)
        Me.GroupBox1.Controls.Add(Me.txtleafletsize)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TXTPOSITIVENEGATIVE)
        Me.GroupBox1.Controls.Add(Me.txtfoldingsize)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtmaterial)
        Me.GroupBox1.Controls.Add(Me.txtmaterialcode)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtdesign)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtpapersize)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label29)
        Me.GroupBox1.Controls.Add(Me.txtgsm)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txttotalsheets)
        Me.GroupBox1.Controls.Add(Me.txtgrain)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtcutsize)
        Me.GroupBox1.Location = New System.Drawing.Point(577, 72)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(470, 201)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(33, 170)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(101, 15)
        Me.Label17.TabIndex = 580
        Me.Label17.Text = "Positive/Negative"
        '
        'TXTPOSITIVENEGATIVE
        '
        Me.TXTPOSITIVENEGATIVE.BackColor = System.Drawing.Color.Linen
        Me.TXTPOSITIVENEGATIVE.Location = New System.Drawing.Point(136, 166)
        Me.TXTPOSITIVENEGATIVE.Name = "TXTPOSITIVENEGATIVE"
        Me.TXTPOSITIVENEGATIVE.ReadOnly = True
        Me.TXTPOSITIVENEGATIVE.Size = New System.Drawing.Size(106, 23)
        Me.TXTPOSITIVENEGATIVE.TabIndex = 579
        Me.TXTPOSITIVENEGATIVE.TabStop = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(28, 91)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(84, 15)
        Me.Label18.TabIndex = 582
        Me.Label18.Text = "Product Name"
        '
        'TXTMAINITEM
        '
        Me.TXTMAINITEM.BackColor = System.Drawing.Color.Linen
        Me.TXTMAINITEM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTMAINITEM.Location = New System.Drawing.Point(114, 87)
        Me.TXTMAINITEM.Name = "TXTMAINITEM"
        Me.TXTMAINITEM.ReadOnly = True
        Me.TXTMAINITEM.Size = New System.Drawing.Size(217, 23)
        Me.TXTMAINITEM.TabIndex = 581
        Me.TXTMAINITEM.TabStop = False
        '
        'chkdone
        '
        Me.chkdone.AutoSize = True
        Me.chkdone.BackColor = System.Drawing.Color.Transparent
        Me.chkdone.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdone.Location = New System.Drawing.Point(779, 57)
        Me.chkdone.Name = "chkdone"
        Me.chkdone.Size = New System.Drawing.Size(53, 19)
        Me.chkdone.TabIndex = 578
        Me.chkdone.Text = "done"
        Me.chkdone.UseVisualStyleBackColor = False
        Me.chkdone.Visible = False
        '
        'TXTGUPS
        '
        Me.TXTGUPS.BackColor = System.Drawing.Color.White
        Me.TXTGUPS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTGUPS.Location = New System.Drawing.Point(429, 132)
        Me.TXTGUPS.MaxLength = 100
        Me.TXTGUPS.Name = "TXTGUPS"
        Me.TXTGUPS.Size = New System.Drawing.Size(108, 23)
        Me.TXTGUPS.TabIndex = 5
        Me.TXTGUPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label23.Location = New System.Drawing.Point(1141, 79)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(0, 15)
        Me.Label23.TabIndex = 1066
        Me.Label23.Visible = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label26.Location = New System.Drawing.Point(396, 141)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(28, 15)
        Me.Label26.TabIndex = 1069
        Me.Label26.Text = "Ups"
        '
        'TXTJOBQTY
        '
        Me.TXTJOBQTY.BackColor = System.Drawing.Color.White
        Me.TXTJOBQTY.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTJOBQTY.Location = New System.Drawing.Point(514, 58)
        Me.TXTJOBQTY.MaxLength = 10
        Me.TXTJOBQTY.Name = "TXTJOBQTY"
        Me.TXTJOBQTY.Size = New System.Drawing.Size(10, 23)
        Me.TXTJOBQTY.TabIndex = 0
        Me.TXTJOBQTY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTJOBQTY.Visible = False
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'JobDocketBatch
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1311, 570)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "JobDocketBatch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Job Docket Batch"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.PBlock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents OpenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents tooldelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolprevious As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolnext As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tstxtbillno As System.Windows.Forms.TextBox
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents cmdclear As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents jobdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents TXTBOMITEMCODE As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CMDSELECTORDER As System.Windows.Forms.Button
    Friend WithEvents txtitemcode As System.Windows.Forms.TextBox
    Friend WithEvents txtorderno As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtfileno As System.Windows.Forms.TextBox
    Friend WithEvents TXTORDERGSRNO As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtshadecard As System.Windows.Forms.TextBox
    Friend WithEvents txtpartyname As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtleafletsize As System.Windows.Forms.TextBox
    Friend WithEvents txtqty As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtfoldingsize As System.Windows.Forms.TextBox
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CMDDELETE As System.Windows.Forms.Button
    Friend WithEvents txtmaterial As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtdesign As System.Windows.Forms.TextBox
    Friend WithEvents txtjobdocketno As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtpapersize As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtgsm As System.Windows.Forms.TextBox
    Friend WithEvents txtpono As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtgrain As System.Windows.Forms.TextBox
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtcutsize As System.Windows.Forms.TextBox
    Friend WithEvents txtups As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txttotalsheets As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents PBlock As System.Windows.Forms.PictureBox
    Friend WithEvents lbllocked As System.Windows.Forms.Label
    Friend WithEvents TXTPERCENTAGE As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtmaterialcode As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents chkdone As System.Windows.Forms.CheckBox
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label17 As Label
    Friend WithEvents TXTPOSITIVENEGATIVE As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents TXTMAINITEM As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TXTSHIPTO As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents TXTORDERTYPE As TextBox
    Friend WithEvents Label40 As Label
    Friend WithEvents Label39 As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents TXTFULLSIZE As TextBox
    Friend WithEvents TXTCOLORSHEET As TextBox
    Friend WithEvents TXTCOLORUPS As TextBox
    Friend WithEvents TXTCUTSIZEG As TextBox
    Friend WithEvents TXTTIME As TextBox
    Friend WithEvents TXTTOTAL As TextBox
    Friend WithEvents TXTEXTRA As TextBox
    Friend WithEvents TXTCUTSHEET As TextBox
    Friend WithEvents TXTGUPS As TextBox
    Friend WithEvents CMBCOL1PLATETYPE As ComboBox
    Friend WithEvents TXTCOL1PLATES As TextBox
    Friend WithEvents CMBMODE As ComboBox
    Friend WithEvents TXTCOL1 As TextBox
    Friend WithEvents TXTJOBQTY As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label36 As Label
    Friend WithEvents TXTYIELD As TextBox
    Friend WithEvents Label41 As Label
    Friend WithEvents CMBUV As ComboBox
    Friend WithEvents Label57 As Label
    Friend WithEvents CMBPUNCHING As ComboBox
    Friend WithEvents Label56 As Label
    Friend WithEvents CMBENVELOPE As ComboBox
    Friend WithEvents Label55 As Label
    Friend WithEvents CMBGUMMING As ComboBox
    Friend WithEvents Label54 As Label
    Friend WithEvents CMBBINDING As ComboBox
    Friend WithEvents Label53 As Label
    Friend WithEvents CMBPACKING As ComboBox
    Friend WithEvents Label52 As Label
    Friend WithEvents CMBFABRICATION As ComboBox
    Friend WithEvents Label51 As Label
    Friend WithEvents CMBNUMBERING As ComboBox
    Friend WithEvents Label50 As Label
    Friend WithEvents CMBLAMINATION As ComboBox
    Friend WithEvents Label46 As Label
    Friend WithEvents Label45 As Label
    Friend WithEvents Label44 As Label
    Friend WithEvents TXTFILMSIZE As TextBox
    Friend WithEvents TXTSHEETS As TextBox
    Friend WithEvents Label43 As Label
    Friend WithEvents TXTKGS As TextBox
    Friend WithEvents Label42 As Label
    Friend WithEvents Label48 As Label
    Friend WithEvents TXTFILMSIZE2 As TextBox
    Friend WithEvents Label47 As Label
    Friend WithEvents CMBNONINVITEM As ComboBox
    Friend WithEvents LBLMACHINE As Label
    Friend WithEvents LBLPREVDATE As Label
    Friend WithEvents TXTPREVJOBNO As TextBox
    Friend WithEvents LBLPREV As Label
    Friend WithEvents CMBLAMMODE As ComboBox
    Friend WithEvents Label60 As Label
    Friend WithEvents TXTLAMINATION1 As TextBox
    Friend WithEvents TXTLAMINATION2 As TextBox
    Friend WithEvents CMBLAM1 As ComboBox
    Friend WithEvents CMBLAM2 As ComboBox
    Friend WithEvents TXTCLOSESIZE As TextBox
    Friend WithEvents LBLCLOSESIZE As Label
    Friend WithEvents TXTOPENSIZE As TextBox
    Friend WithEvents LBLOPENSIZE As Label
    Friend WithEvents CMBMACHINE As ComboBox
    Friend WithEvents CMBLUV As ComboBox
    Friend WithEvents CMBLPUNCHING As ComboBox
    Friend WithEvents CMBLGUM As ComboBox
    Friend WithEvents CMBLBINDING As ComboBox
    Friend WithEvents CMBVENDOR As ComboBox
    Friend WithEvents CMBLFABRICATION As ComboBox
    Friend WithEvents CMBLNUMBERING As ComboBox
    Friend WithEvents CMBVENDOR1 As ComboBox
    Friend WithEvents CMBLPACKING As ComboBox
    Friend WithEvents CMBLAM As ComboBox
    Friend WithEvents CMBLENVELOPE As ComboBox
    Friend WithEvents txtadd As TextBox
    Friend WithEvents CMBCODE As ComboBox
    Friend WithEvents CMBOUTVENDORNAME As ComboBox
    Friend WithEvents LBLVENDORNAME As Label
    Friend WithEvents LBLREQDONE As Label
    Friend WithEvents CMBLAMM As ComboBox
    Friend WithEvents TXTCOL2 As TextBox
    Friend WithEvents Label49 As Label
    Friend WithEvents DTPREV As MaskedTextBox
    Friend WithEvents LBLPRINTPRODONE As Label
    Friend WithEvents LBLPACKINGPRODONE As Label
    Friend WithEvents LBLPROD1DONE As Label
    Friend WithEvents LBLFABPRODONE As Label
    Friend WithEvents LBLNUMPRODONE As Label
    Friend WithEvents LBLENVLPRODONE As Label
    Friend WithEvents Label73 As Label
    Friend WithEvents LBLPUNCPRODONE As Label
    Friend WithEvents LBLBINDPRODONE As Label
    Friend WithEvents LBLGUMPRODONE As Label
    Friend WithEvents LBLFOILPRODONE As Label
    Friend WithEvents LBLUVPRODONE As Label
    Friend WithEvents LBLLAMPRODONE As Label
    Friend WithEvents LBLLAMCUTPRODONE As Label
    Friend WithEvents LBLPROD2DONE As Label
    Friend WithEvents TXTCOL2PLATES As TextBox
    Friend WithEvents Label58 As Label
    Friend WithEvents CMBCOL2PLATETYPE As ComboBox
    Friend WithEvents Label59 As Label
    Friend WithEvents TXTPRODFINISHQTY As TextBox
    Friend WithEvents Label61 As Label
    Friend WithEvents LBLFINISHED As Label
    Friend WithEvents LBLCUTTINGDONE As Label
    Friend WithEvents LBLFOLDINGDONE As Label
    Friend WithEvents TXTPROPRINTINGQTY As TextBox
    Friend WithEvents Label62 As Label
    Friend WithEvents TXTLAMINATIONUPS As TextBox
    Friend WithEvents Label63 As Label
    Friend WithEvents TXTFINALUPS As TextBox
    Friend WithEvents Label67 As Label
    Friend WithEvents TXTPUNCHINGUPS As TextBox
    Friend WithEvents Label65 As Label
    Friend WithEvents LBLCLOSE As Label
    Friend WithEvents TXTFOLDINGUPS As TextBox
    Friend WithEvents Label68 As Label
    Friend WithEvents TXTNUMBERINGUPS As TextBox
    Friend WithEvents Label69 As Label
End Class
