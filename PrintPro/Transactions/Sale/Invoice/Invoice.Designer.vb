<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Invoice
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
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle31 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle32 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Invoice))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CHKEXPORTGST = New System.Windows.Forms.CheckBox()
        Me.CMBHSNCODE = New System.Windows.Forms.ComboBox()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.CHKTCS = New System.Windows.Forms.CheckBox()
        Me.TXTTCSPER = New System.Windows.Forms.TextBox()
        Me.TXTTCSAMT = New System.Windows.Forms.TextBox()
        Me.CHKPACKET = New System.Windows.Forms.CheckBox()
        Me.cmbstate = New System.Windows.Forms.ComboBox()
        Me.LBLPLACEOFSUPPLY = New System.Windows.Forms.Label()
        Me.TXTMULTIPONO = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.TXTEWAYBILLNO = New System.Windows.Forms.TextBox()
        Me.TXTMULTICHALLANNO = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.TXTGSTIN = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.TXTSTATECODE = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TXTCOPIES = New System.Windows.Forms.TextBox()
        Me.DueDate = New System.Windows.Forms.DateTimePicker()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.TXTCRDAYS = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.cmdshowdetails = New System.Windows.Forms.Button()
        Me.PBCN = New System.Windows.Forms.PictureBox()
        Me.PBRECD = New System.Windows.Forms.PictureBox()
        Me.TXTTRANSNAME = New System.Windows.Forms.TextBox()
        Me.CMBNAME = New System.Windows.Forms.ComboBox()
        Me.txtchallandate = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtpodate = New System.Windows.Forms.TextBox()
        Me.CHKFORMBOX = New System.Windows.Forms.CheckedListBox()
        Me.txtname = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtdeladd = New System.Windows.Forms.TextBox()
        Me.challandate = New System.Windows.Forms.DateTimePicker()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtchallanno = New System.Windows.Forms.TextBox()
        Me.TXTBAL = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXTEXTRAAMT = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TXTAMTREC = New System.Windows.Forms.TextBox()
        Me.txtpono = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.CHKMANUAL = New System.Windows.Forms.CheckBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.LBLTOTALQTY = New System.Windows.Forms.Label()
        Me.LBLTOTALGRIDAMT = New System.Windows.Forms.Label()
        Me.LBLTOTALIGSTAMT = New System.Windows.Forms.Label()
        Me.LBLTOTALSGSTAMT = New System.Windows.Forms.Label()
        Me.LBLTOTALCGSTAMT = New System.Windows.Forms.Label()
        Me.LBLTOTALTAXABLEAMT = New System.Windows.Forms.Label()
        Me.LBLTOTALOTHERAMT = New System.Windows.Forms.Label()
        Me.lbltotalamt = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.gridinvoice = New System.Windows.Forms.DataGridView()
        Me.GITEMCODE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GITEMNAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GHSNCODE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GMATERIALCODE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GQTY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GBATCHNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GRATE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GAMOUNT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GOTHERAMT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GTAXABLEAMT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GCGSTPER = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GCGSTAMT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GSGSTPER = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GSGSTAMT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GIGSTPER = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GIGSTAMT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GGRIDTOTAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GGRIDCHALLANNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TBADD = New System.Windows.Forms.TabPage()
        Me.ACKDATE = New System.Windows.Forms.DateTimePicker()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.TXTACKNO = New System.Windows.Forms.TextBox()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.TXTNEWIMGPATH = New System.Windows.Forms.TextBox()
        Me.TXTFILENAME = New System.Windows.Forms.TextBox()
        Me.CMDGETQRCODE = New System.Windows.Forms.Button()
        Me.CMDUPLOADIRN = New System.Windows.Forms.Button()
        Me.PBQRCODE = New System.Windows.Forms.PictureBox()
        Me.TXTIRNNO = New System.Windows.Forms.TextBox()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.LRDATE = New System.Windows.Forms.MaskedTextBox()
        Me.TXTVEHICLENO = New System.Windows.Forms.TextBox()
        Me.CMBFROMCITY = New System.Windows.Forms.ComboBox()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.CMBTOCITY = New System.Windows.Forms.ComboBox()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.TXTLRNO = New System.Windows.Forms.TextBox()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
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
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TXTINKDETAILS = New System.Windows.Forms.TextBox()
        Me.TXTQCVARNISH = New System.Windows.Forms.TextBox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.TXTQCPAPER = New System.Windows.Forms.TextBox()
        Me.TXTQCBATCH = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.TXTQCADHESIVE = New System.Windows.Forms.TextBox()
        Me.TXTQCGSM = New System.Windows.Forms.TextBox()
        Me.TXTQCTEXT = New System.Windows.Forms.TextBox()
        Me.LBLGRAIN = New System.Windows.Forms.Label()
        Me.QCDATE = New System.Windows.Forms.DateTimePicker()
        Me.TXTQCGRAIN = New System.Windows.Forms.TextBox()
        Me.TXTQCVISUAL = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.TXTQCPHARMA = New System.Windows.Forms.TextBox()
        Me.TXTQCHEAD = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.TXTQCUPS = New System.Windows.Forms.TextBox()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.TXTQCREMARKS = New System.Windows.Forms.TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.TXTQCLABEL = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.LABEL555 = New System.Windows.Forms.Label()
        Me.TXTQCCOLOR = New System.Windows.Forms.TextBox()
        Me.TXTQCSHIPPER = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.TXTQCPACKET = New System.Windows.Forms.TextBox()
        Me.TXTQCPERFOR = New System.Windows.Forms.TextBox()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.LBLDESIGN = New System.Windows.Forms.Label()
        Me.TXTQCFINALAMT = New System.Windows.Forms.TextBox()
        Me.TXTQCDESIGN = New System.Windows.Forms.TextBox()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.TXTQCSTICKER = New System.Windows.Forms.TextBox()
        Me.TXTQCSIZE = New System.Windows.Forms.TextBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbllocked = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PBlock = New System.Windows.Forms.PictureBox()
        Me.chkdone = New System.Windows.Forms.CheckBox()
        Me.TXTSUBTOTAL = New System.Windows.Forms.TextBox()
        Me.CMBEXTRACHGSNAME = New System.Windows.Forms.ComboBox()
        Me.CMBEXTRAADDSUB = New System.Windows.Forms.ComboBox()
        Me.TXTEXTRACHGS = New System.Windows.Forms.TextBox()
        Me.CMBOTHERCHGSNAME = New System.Windows.Forms.ComboBox()
        Me.CMBTAX = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txttax = New System.Windows.Forms.TextBox()
        Me.TXTTRANSADD = New System.Windows.Forms.TextBox()
        Me.CMBCODE = New System.Windows.Forms.ComboBox()
        Me.CMDSELECTCHALLAN = New System.Windows.Forms.Button()
        Me.CMDDELETE = New System.Windows.Forms.Button()
        Me.TXTJOBNO = New System.Windows.Forms.TextBox()
        Me.TXTORDERSRNO = New System.Windows.Forms.TextBox()
        Me.txtorderno = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TXTINVOICENO = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.invoicedate = New System.Windows.Forms.DateTimePicker()
        Me.cmbregister = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.CHKDISPUTE = New System.Windows.Forms.CheckBox()
        Me.CHKBILLCHECKED = New System.Windows.Forms.CheckBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtremarks = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtpakagingchgs = New System.Windows.Forms.TextBox()
        Me.cmbaddsub = New System.Windows.Forms.ComboBox()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.TXTOTHERCHGS = New System.Windows.Forms.TextBox()
        Me.cmdclear = New System.Windows.Forms.Button()
        Me.txtreturn = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtroundoff = New System.Windows.Forms.TextBox()
        Me.lblgtotal = New System.Windows.Forms.Label()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.txtgrandtotal = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.txtprocessing = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtinwords = New System.Windows.Forms.TextBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.tstxtbillno = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtprintto = New System.Windows.Forms.TextBox()
        Me.txtprintfrom = New System.Windows.Forms.TextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tooldelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.TOOLEINV = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TOOLEWB = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.toolprevious = New System.Windows.Forms.ToolStripButton()
        Me.toolnext = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Ep = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.txtinvoice = New System.Windows.Forms.TextBox()
        Me.txtdespatched = New System.Windows.Forms.TextBox()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.PBCN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBRECD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.gridinvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TBADD.SuspendLayout()
        CType(Me.PBQRCODE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.PBSOFTCOPY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridupload, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PBlock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.Ep, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CHKEXPORTGST)
        Me.BlendPanel1.Controls.Add(Me.CMBHSNCODE)
        Me.BlendPanel1.Controls.Add(Me.Label62)
        Me.BlendPanel1.Controls.Add(Me.CHKTCS)
        Me.BlendPanel1.Controls.Add(Me.TXTTCSPER)
        Me.BlendPanel1.Controls.Add(Me.TXTTCSAMT)
        Me.BlendPanel1.Controls.Add(Me.CHKPACKET)
        Me.BlendPanel1.Controls.Add(Me.cmbstate)
        Me.BlendPanel1.Controls.Add(Me.LBLPLACEOFSUPPLY)
        Me.BlendPanel1.Controls.Add(Me.TXTMULTIPONO)
        Me.BlendPanel1.Controls.Add(Me.Label35)
        Me.BlendPanel1.Controls.Add(Me.TXTEWAYBILLNO)
        Me.BlendPanel1.Controls.Add(Me.TXTMULTICHALLANNO)
        Me.BlendPanel1.Controls.Add(Me.Label33)
        Me.BlendPanel1.Controls.Add(Me.TXTGSTIN)
        Me.BlendPanel1.Controls.Add(Me.Label32)
        Me.BlendPanel1.Controls.Add(Me.TXTSTATECODE)
        Me.BlendPanel1.Controls.Add(Me.Label13)
        Me.BlendPanel1.Controls.Add(Me.TXTCOPIES)
        Me.BlendPanel1.Controls.Add(Me.DueDate)
        Me.BlendPanel1.Controls.Add(Me.Label30)
        Me.BlendPanel1.Controls.Add(Me.TXTCRDAYS)
        Me.BlendPanel1.Controls.Add(Me.Label26)
        Me.BlendPanel1.Controls.Add(Me.cmdshowdetails)
        Me.BlendPanel1.Controls.Add(Me.PBCN)
        Me.BlendPanel1.Controls.Add(Me.PBRECD)
        Me.BlendPanel1.Controls.Add(Me.TXTTRANSNAME)
        Me.BlendPanel1.Controls.Add(Me.CMBNAME)
        Me.BlendPanel1.Controls.Add(Me.txtchallandate)
        Me.BlendPanel1.Controls.Add(Me.Label8)
        Me.BlendPanel1.Controls.Add(Me.txtpodate)
        Me.BlendPanel1.Controls.Add(Me.CHKFORMBOX)
        Me.BlendPanel1.Controls.Add(Me.txtname)
        Me.BlendPanel1.Controls.Add(Me.Label12)
        Me.BlendPanel1.Controls.Add(Me.txtdeladd)
        Me.BlendPanel1.Controls.Add(Me.challandate)
        Me.BlendPanel1.Controls.Add(Me.Label29)
        Me.BlendPanel1.Controls.Add(Me.Label10)
        Me.BlendPanel1.Controls.Add(Me.Label7)
        Me.BlendPanel1.Controls.Add(Me.Label25)
        Me.BlendPanel1.Controls.Add(Me.txtchallanno)
        Me.BlendPanel1.Controls.Add(Me.TXTBAL)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.TXTEXTRAAMT)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.TXTAMTREC)
        Me.BlendPanel1.Controls.Add(Me.txtpono)
        Me.BlendPanel1.Controls.Add(Me.TabControl1)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.lbllocked)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.PBlock)
        Me.BlendPanel1.Controls.Add(Me.chkdone)
        Me.BlendPanel1.Controls.Add(Me.TXTSUBTOTAL)
        Me.BlendPanel1.Controls.Add(Me.CMBEXTRACHGSNAME)
        Me.BlendPanel1.Controls.Add(Me.CMBEXTRAADDSUB)
        Me.BlendPanel1.Controls.Add(Me.TXTEXTRACHGS)
        Me.BlendPanel1.Controls.Add(Me.CMBOTHERCHGSNAME)
        Me.BlendPanel1.Controls.Add(Me.CMBTAX)
        Me.BlendPanel1.Controls.Add(Me.Label11)
        Me.BlendPanel1.Controls.Add(Me.txttax)
        Me.BlendPanel1.Controls.Add(Me.TXTTRANSADD)
        Me.BlendPanel1.Controls.Add(Me.CMBCODE)
        Me.BlendPanel1.Controls.Add(Me.CMDSELECTCHALLAN)
        Me.BlendPanel1.Controls.Add(Me.CMDDELETE)
        Me.BlendPanel1.Controls.Add(Me.TXTJOBNO)
        Me.BlendPanel1.Controls.Add(Me.TXTORDERSRNO)
        Me.BlendPanel1.Controls.Add(Me.txtorderno)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.TXTINVOICENO)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.invoicedate)
        Me.BlendPanel1.Controls.Add(Me.cmbregister)
        Me.BlendPanel1.Controls.Add(Me.Label23)
        Me.BlendPanel1.Controls.Add(Me.CHKDISPUTE)
        Me.BlendPanel1.Controls.Add(Me.CHKBILLCHECKED)
        Me.BlendPanel1.Controls.Add(Me.GroupBox5)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.Label19)
        Me.BlendPanel1.Controls.Add(Me.txtpakagingchgs)
        Me.BlendPanel1.Controls.Add(Me.cmbaddsub)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.TXTOTHERCHGS)
        Me.BlendPanel1.Controls.Add(Me.cmdclear)
        Me.BlendPanel1.Controls.Add(Me.txtreturn)
        Me.BlendPanel1.Controls.Add(Me.Label17)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.Label16)
        Me.BlendPanel1.Controls.Add(Me.txtroundoff)
        Me.BlendPanel1.Controls.Add(Me.lblgtotal)
        Me.BlendPanel1.Controls.Add(Me.GroupBox8)
        Me.BlendPanel1.Controls.Add(Me.txtgrandtotal)
        Me.BlendPanel1.Controls.Add(Me.Label15)
        Me.BlendPanel1.Controls.Add(Me.GroupBox7)
        Me.BlendPanel1.Controls.Add(Me.txtprocessing)
        Me.BlendPanel1.Controls.Add(Me.GroupBox4)
        Me.BlendPanel1.Controls.Add(Me.Label14)
        Me.BlendPanel1.Controls.Add(Me.txtinwords)
        Me.BlendPanel1.Controls.Add(Me.GroupBox6)
        Me.BlendPanel1.Controls.Add(Me.tstxtbillno)
        Me.BlendPanel1.Controls.Add(Me.Label21)
        Me.BlendPanel1.Controls.Add(Me.Label20)
        Me.BlendPanel1.Controls.Add(Me.txtprintto)
        Me.BlendPanel1.Controls.Add(Me.txtprintfrom)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1268, 659)
        Me.BlendPanel1.TabIndex = 0
        '
        'CHKEXPORTGST
        '
        Me.CHKEXPORTGST.AutoSize = True
        Me.CHKEXPORTGST.BackColor = System.Drawing.Color.Transparent
        Me.CHKEXPORTGST.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKEXPORTGST.Location = New System.Drawing.Point(1042, 168)
        Me.CHKEXPORTGST.Name = "CHKEXPORTGST"
        Me.CHKEXPORTGST.Size = New System.Drawing.Size(84, 19)
        Me.CHKEXPORTGST.TabIndex = 944
        Me.CHKEXPORTGST.Text = "Export GST"
        Me.CHKEXPORTGST.UseVisualStyleBackColor = False
        '
        'CMBHSNCODE
        '
        Me.CMBHSNCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBHSNCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBHSNCODE.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBHSNCODE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBHSNCODE.FormattingEnabled = True
        Me.CMBHSNCODE.Location = New System.Drawing.Point(1047, 81)
        Me.CMBHSNCODE.MaxDropDownItems = 14
        Me.CMBHSNCODE.Name = "CMBHSNCODE"
        Me.CMBHSNCODE.Size = New System.Drawing.Size(106, 23)
        Me.CMBHSNCODE.TabIndex = 942
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.BackColor = System.Drawing.Color.Transparent
        Me.Label62.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label62.Location = New System.Drawing.Point(985, 85)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(56, 14)
        Me.Label62.TabIndex = 943
        Me.Label62.Text = "EWB HSN"
        '
        'CHKTCS
        '
        Me.CHKTCS.AutoSize = True
        Me.CHKTCS.BackColor = System.Drawing.Color.Transparent
        Me.CHKTCS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKTCS.Location = New System.Drawing.Point(1003, 566)
        Me.CHKTCS.Name = "CHKTCS"
        Me.CHKTCS.Size = New System.Drawing.Size(79, 19)
        Me.CHKTCS.TabIndex = 941
        Me.CHKTCS.Text = "Apply TCS"
        Me.CHKTCS.UseVisualStyleBackColor = False
        '
        'TXTTCSPER
        '
        Me.TXTTCSPER.BackColor = System.Drawing.Color.Linen
        Me.TXTTCSPER.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTCSPER.ForeColor = System.Drawing.Color.Black
        Me.TXTTCSPER.Location = New System.Drawing.Point(1085, 564)
        Me.TXTTCSPER.Name = "TXTTCSPER"
        Me.TXTTCSPER.ReadOnly = True
        Me.TXTTCSPER.Size = New System.Drawing.Size(37, 23)
        Me.TXTTCSPER.TabIndex = 940
        Me.TXTTCSPER.TabStop = False
        Me.TXTTCSPER.Text = "0.00"
        Me.TXTTCSPER.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTTCSAMT
        '
        Me.TXTTCSAMT.BackColor = System.Drawing.Color.Linen
        Me.TXTTCSAMT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTCSAMT.ForeColor = System.Drawing.Color.Black
        Me.TXTTCSAMT.Location = New System.Drawing.Point(1126, 564)
        Me.TXTTCSAMT.Name = "TXTTCSAMT"
        Me.TXTTCSAMT.ReadOnly = True
        Me.TXTTCSAMT.Size = New System.Drawing.Size(83, 23)
        Me.TXTTCSAMT.TabIndex = 939
        Me.TXTTCSAMT.TabStop = False
        Me.TXTTCSAMT.Text = "0.00"
        Me.TXTTCSAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CHKPACKET
        '
        Me.CHKPACKET.AutoSize = True
        Me.CHKPACKET.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CHKPACKET.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKPACKET.ForeColor = System.Drawing.Color.Black
        Me.CHKPACKET.Location = New System.Drawing.Point(724, 3)
        Me.CHKPACKET.Name = "CHKPACKET"
        Me.CHKPACKET.Size = New System.Drawing.Size(134, 19)
        Me.CHKPACKET.TabIndex = 938
        Me.CHKPACKET.Text = "Print Packet Details"
        Me.CHKPACKET.UseVisualStyleBackColor = False
        '
        'cmbstate
        '
        Me.cmbstate.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbstate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbstate.BackColor = System.Drawing.Color.White
        Me.cmbstate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbstate.FormattingEnabled = True
        Me.cmbstate.Location = New System.Drawing.Point(97, 181)
        Me.cmbstate.MaxDropDownItems = 14
        Me.cmbstate.Name = "cmbstate"
        Me.cmbstate.Size = New System.Drawing.Size(225, 22)
        Me.cmbstate.TabIndex = 937
        '
        'LBLPLACEOFSUPPLY
        '
        Me.LBLPLACEOFSUPPLY.AutoSize = True
        Me.LBLPLACEOFSUPPLY.BackColor = System.Drawing.Color.Transparent
        Me.LBLPLACEOFSUPPLY.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LBLPLACEOFSUPPLY.Location = New System.Drawing.Point(1, 183)
        Me.LBLPLACEOFSUPPLY.Name = "LBLPLACEOFSUPPLY"
        Me.LBLPLACEOFSUPPLY.Size = New System.Drawing.Size(93, 15)
        Me.LBLPLACEOFSUPPLY.TabIndex = 936
        Me.LBLPLACEOFSUPPLY.Text = "Place Of Supply"
        '
        'TXTMULTIPONO
        '
        Me.TXTMULTIPONO.BackColor = System.Drawing.Color.Linen
        Me.TXTMULTIPONO.ForeColor = System.Drawing.Color.DimGray
        Me.TXTMULTIPONO.Location = New System.Drawing.Point(449, 81)
        Me.TXTMULTIPONO.Name = "TXTMULTIPONO"
        Me.TXTMULTIPONO.ReadOnly = True
        Me.TXTMULTIPONO.Size = New System.Drawing.Size(222, 23)
        Me.TXTMULTIPONO.TabIndex = 877
        Me.TXTMULTIPONO.TabStop = False
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.BackColor = System.Drawing.Color.Transparent
        Me.Label35.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label35.Location = New System.Drawing.Point(363, 199)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(85, 15)
        Me.Label35.TabIndex = 876
        Me.Label35.Text = "E-Way Bill No."
        '
        'TXTEWAYBILLNO
        '
        Me.TXTEWAYBILLNO.BackColor = System.Drawing.Color.White
        Me.TXTEWAYBILLNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTEWAYBILLNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTEWAYBILLNO.Location = New System.Drawing.Point(450, 195)
        Me.TXTEWAYBILLNO.Name = "TXTEWAYBILLNO"
        Me.TXTEWAYBILLNO.Size = New System.Drawing.Size(222, 23)
        Me.TXTEWAYBILLNO.TabIndex = 5
        '
        'TXTMULTICHALLANNO
        '
        Me.TXTMULTICHALLANNO.BackColor = System.Drawing.Color.Linen
        Me.TXTMULTICHALLANNO.Enabled = False
        Me.TXTMULTICHALLANNO.Location = New System.Drawing.Point(450, 166)
        Me.TXTMULTICHALLANNO.Name = "TXTMULTICHALLANNO"
        Me.TXTMULTICHALLANNO.Size = New System.Drawing.Size(79, 23)
        Me.TXTMULTICHALLANNO.TabIndex = 874
        Me.TXTMULTICHALLANNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTMULTICHALLANNO.Visible = False
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Black
        Me.Label33.Location = New System.Drawing.Point(1002, 198)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(39, 15)
        Me.Label33.TabIndex = 873
        Me.Label33.Text = "GSTIN"
        '
        'TXTGSTIN
        '
        Me.TXTGSTIN.BackColor = System.Drawing.Color.Linen
        Me.TXTGSTIN.Location = New System.Drawing.Point(1042, 194)
        Me.TXTGSTIN.Name = "TXTGSTIN"
        Me.TXTGSTIN.ReadOnly = True
        Me.TXTGSTIN.Size = New System.Drawing.Size(111, 23)
        Me.TXTGSTIN.TabIndex = 872
        Me.TXTGSTIN.TabStop = False
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.BackColor = System.Drawing.Color.Transparent
        Me.Label32.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.Black
        Me.Label32.Location = New System.Drawing.Point(824, 197)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(64, 15)
        Me.Label32.TabIndex = 871
        Me.Label32.Text = "State Code"
        '
        'TXTSTATECODE
        '
        Me.TXTSTATECODE.BackColor = System.Drawing.Color.Linen
        Me.TXTSTATECODE.Location = New System.Drawing.Point(889, 194)
        Me.TXTSTATECODE.Name = "TXTSTATECODE"
        Me.TXTSTATECODE.ReadOnly = True
        Me.TXTSTATECODE.Size = New System.Drawing.Size(90, 23)
        Me.TXTSTATECODE.TabIndex = 870
        Me.TXTSTATECODE.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.White
        Me.Label13.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(622, 5)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(44, 14)
        Me.Label13.TabIndex = 828
        Me.Label13.Text = "Copies"
        '
        'TXTCOPIES
        '
        Me.TXTCOPIES.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCOPIES.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCOPIES.Location = New System.Drawing.Point(667, 1)
        Me.TXTCOPIES.Name = "TXTCOPIES"
        Me.TXTCOPIES.Size = New System.Drawing.Size(29, 22)
        Me.TXTCOPIES.TabIndex = 827
        Me.TXTCOPIES.Text = "1"
        Me.TXTCOPIES.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DueDate
        '
        Me.DueDate.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DueDate.Location = New System.Drawing.Point(889, 165)
        Me.DueDate.Name = "DueDate"
        Me.DueDate.Size = New System.Drawing.Size(90, 23)
        Me.DueDate.TabIndex = 3
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(830, 169)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(56, 15)
        Me.Label30.TabIndex = 826
        Me.Label30.Text = "Due Date"
        '
        'TXTCRDAYS
        '
        Me.TXTCRDAYS.BackColor = System.Drawing.Color.White
        Me.TXTCRDAYS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCRDAYS.Location = New System.Drawing.Point(889, 137)
        Me.TXTCRDAYS.MaxLength = 2
        Me.TXTCRDAYS.Name = "TXTCRDAYS"
        Me.TXTCRDAYS.Size = New System.Drawing.Size(90, 23)
        Me.TXTCRDAYS.TabIndex = 2
        Me.TXTCRDAYS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label26.Location = New System.Drawing.Point(835, 141)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(51, 15)
        Me.Label26.TabIndex = 825
        Me.Label26.Text = "Cr. Days"
        '
        'cmdshowdetails
        '
        Me.cmdshowdetails.BackColor = System.Drawing.Color.Transparent
        Me.cmdshowdetails.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdshowdetails.FlatAppearance.BorderSize = 0
        Me.cmdshowdetails.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdshowdetails.ForeColor = System.Drawing.Color.Black
        Me.cmdshowdetails.Location = New System.Drawing.Point(446, 508)
        Me.cmdshowdetails.Name = "cmdshowdetails"
        Me.cmdshowdetails.Size = New System.Drawing.Size(88, 28)
        Me.cmdshowdetails.TabIndex = 822
        Me.cmdshowdetails.Text = "S&how Details"
        Me.cmdshowdetails.UseVisualStyleBackColor = False
        Me.cmdshowdetails.Visible = False
        '
        'PBCN
        '
        Me.PBCN.BackColor = System.Drawing.Color.Transparent
        Me.PBCN.Image = Global.PrintPro.My.Resources.Resources.CN
        Me.PBCN.Location = New System.Drawing.Point(547, 473)
        Me.PBCN.Name = "PBCN"
        Me.PBCN.Size = New System.Drawing.Size(57, 36)
        Me.PBCN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBCN.TabIndex = 821
        Me.PBCN.TabStop = False
        Me.PBCN.Visible = False
        '
        'PBRECD
        '
        Me.PBRECD.BackColor = System.Drawing.Color.Transparent
        Me.PBRECD.Image = Global.PrintPro.My.Resources.Resources.recd
        Me.PBRECD.Location = New System.Drawing.Point(446, 468)
        Me.PBRECD.Name = "PBRECD"
        Me.PBRECD.Size = New System.Drawing.Size(74, 36)
        Me.PBRECD.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBRECD.TabIndex = 820
        Me.PBRECD.TabStop = False
        Me.PBRECD.Visible = False
        '
        'TXTTRANSNAME
        '
        Me.TXTTRANSNAME.BackColor = System.Drawing.Color.Linen
        Me.TXTTRANSNAME.ForeColor = System.Drawing.Color.DimGray
        Me.TXTTRANSNAME.Location = New System.Drawing.Point(450, 137)
        Me.TXTTRANSNAME.Name = "TXTTRANSNAME"
        Me.TXTTRANSNAME.ReadOnly = True
        Me.TXTTRANSNAME.Size = New System.Drawing.Size(222, 23)
        Me.TXTTRANSNAME.TabIndex = 106
        Me.TXTTRANSNAME.TabStop = False
        '
        'CMBNAME
        '
        Me.CMBNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBNAME.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBNAME.FormattingEnabled = True
        Me.CMBNAME.Location = New System.Drawing.Point(97, 53)
        Me.CMBNAME.Name = "CMBNAME"
        Me.CMBNAME.Size = New System.Drawing.Size(225, 23)
        Me.CMBNAME.TabIndex = 4
        '
        'txtchallandate
        '
        Me.txtchallandate.BackColor = System.Drawing.Color.Linen
        Me.txtchallandate.ForeColor = System.Drawing.Color.DimGray
        Me.txtchallandate.Location = New System.Drawing.Point(595, 165)
        Me.txtchallandate.Name = "txtchallandate"
        Me.txtchallandate.ReadOnly = True
        Me.txtchallandate.Size = New System.Drawing.Size(77, 23)
        Me.txtchallandate.TabIndex = 105
        Me.txtchallandate.TabStop = False
        Me.txtchallandate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(56, 57)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 15)
        Me.Label8.TabIndex = 101
        Me.Label8.Text = "Name"
        '
        'txtpodate
        '
        Me.txtpodate.BackColor = System.Drawing.Color.Linen
        Me.txtpodate.ForeColor = System.Drawing.Color.DimGray
        Me.txtpodate.Location = New System.Drawing.Point(450, 109)
        Me.txtpodate.Name = "txtpodate"
        Me.txtpodate.ReadOnly = True
        Me.txtpodate.Size = New System.Drawing.Size(79, 23)
        Me.txtpodate.TabIndex = 104
        Me.txtpodate.TabStop = False
        '
        'CHKFORMBOX
        '
        Me.CHKFORMBOX.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKFORMBOX.FormattingEnabled = True
        Me.CHKFORMBOX.Location = New System.Drawing.Point(694, 79)
        Me.CHKFORMBOX.Name = "CHKFORMBOX"
        Me.CHKFORMBOX.Size = New System.Drawing.Size(107, 94)
        Me.CHKFORMBOX.TabIndex = 3
        '
        'txtname
        '
        Me.txtname.BackColor = System.Drawing.Color.Linen
        Me.txtname.ForeColor = System.Drawing.Color.DimGray
        Me.txtname.Location = New System.Drawing.Point(450, 53)
        Me.txtname.Name = "txtname"
        Me.txtname.ReadOnly = True
        Me.txtname.Size = New System.Drawing.Size(222, 23)
        Me.txtname.TabIndex = 103
        Me.txtname.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(328, 141)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(119, 15)
        Me.Label12.TabIndex = 102
        Me.Label12.Text = "Despatched Through"
        '
        'txtdeladd
        '
        Me.txtdeladd.BackColor = System.Drawing.Color.Linen
        Me.txtdeladd.ForeColor = System.Drawing.Color.DimGray
        Me.txtdeladd.Location = New System.Drawing.Point(97, 79)
        Me.txtdeladd.Multiline = True
        Me.txtdeladd.Name = "txtdeladd"
        Me.txtdeladd.ReadOnly = True
        Me.txtdeladd.Size = New System.Drawing.Size(225, 94)
        Me.txtdeladd.TabIndex = 1
        Me.txtdeladd.TabStop = False
        '
        'challandate
        '
        Me.challandate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.challandate.Location = New System.Drawing.Point(595, 165)
        Me.challandate.Name = "challandate"
        Me.challandate.Size = New System.Drawing.Size(77, 23)
        Me.challandate.TabIndex = 2
        Me.challandate.Visible = False
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(697, 60)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(38, 15)
        Me.Label29.TabIndex = 819
        Me.Label29.Text = "Form "
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(541, 169)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 15)
        Me.Label10.TabIndex = 100
        Me.Label10.Text = "Ch. Date"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(45, 82)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 15)
        Me.Label7.TabIndex = 104
        Me.Label7.Text = "Address"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(775, 544)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(25, 15)
        Me.Label25.TabIndex = 755
        Me.Label25.Text = "Tax"
        '
        'txtchallanno
        '
        Me.txtchallanno.BackColor = System.Drawing.Color.Linen
        Me.txtchallanno.Location = New System.Drawing.Point(450, 166)
        Me.txtchallanno.Name = "txtchallanno"
        Me.txtchallanno.Size = New System.Drawing.Size(79, 23)
        Me.txtchallanno.TabIndex = 3
        Me.txtchallanno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTBAL
        '
        Me.TXTBAL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTBAL.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTBAL.Location = New System.Drawing.Point(768, 28)
        Me.TXTBAL.Name = "TXTBAL"
        Me.TXTBAL.Size = New System.Drawing.Size(33, 21)
        Me.TXTBAL.TabIndex = 754
        Me.TXTBAL.TabStop = False
        Me.TXTBAL.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(376, 169)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 15)
        Me.Label4.TabIndex = 98
        Me.Label4.Text = "Challan No."
        '
        'TXTEXTRAAMT
        '
        Me.TXTEXTRAAMT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTEXTRAAMT.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTEXTRAAMT.Location = New System.Drawing.Point(768, 28)
        Me.TXTEXTRAAMT.Name = "TXTEXTRAAMT"
        Me.TXTEXTRAAMT.Size = New System.Drawing.Size(33, 21)
        Me.TXTEXTRAAMT.TabIndex = 753
        Me.TXTEXTRAAMT.TabStop = False
        Me.TXTEXTRAAMT.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(392, 113)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 15)
        Me.Label3.TabIndex = 96
        Me.Label3.Text = "P.O. Date"
        '
        'TXTAMTREC
        '
        Me.TXTAMTREC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTAMTREC.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTAMTREC.Location = New System.Drawing.Point(768, 28)
        Me.TXTAMTREC.Name = "TXTAMTREC"
        Me.TXTAMTREC.Size = New System.Drawing.Size(33, 21)
        Me.TXTAMTREC.TabIndex = 752
        Me.TXTAMTREC.TabStop = False
        Me.TXTAMTREC.Visible = False
        '
        'txtpono
        '
        Me.txtpono.BackColor = System.Drawing.Color.Linen
        Me.txtpono.ForeColor = System.Drawing.Color.DimGray
        Me.txtpono.Location = New System.Drawing.Point(450, 81)
        Me.txtpono.Name = "txtpono"
        Me.txtpono.ReadOnly = True
        Me.txtpono.Size = New System.Drawing.Size(222, 23)
        Me.txtpono.TabIndex = 4
        Me.txtpono.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TBADD)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(13, 218)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1242, 217)
        Me.TabControl1.TabIndex = 6
        '
        'TabPage1
        '
        Me.TabPage1.AutoScroll = True
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.CHKMANUAL)
        Me.TabPage1.Controls.Add(Me.Label22)
        Me.TabPage1.Controls.Add(Me.LBLTOTALQTY)
        Me.TabPage1.Controls.Add(Me.LBLTOTALGRIDAMT)
        Me.TabPage1.Controls.Add(Me.LBLTOTALIGSTAMT)
        Me.TabPage1.Controls.Add(Me.LBLTOTALSGSTAMT)
        Me.TabPage1.Controls.Add(Me.LBLTOTALCGSTAMT)
        Me.TabPage1.Controls.Add(Me.LBLTOTALTAXABLEAMT)
        Me.TabPage1.Controls.Add(Me.LBLTOTALOTHERAMT)
        Me.TabPage1.Controls.Add(Me.lbltotalamt)
        Me.TabPage1.Controls.Add(Me.Label18)
        Me.TabPage1.Controls.Add(Me.gridinvoice)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1234, 189)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "1. Invoice Details"
        '
        'CHKMANUAL
        '
        Me.CHKMANUAL.AutoSize = True
        Me.CHKMANUAL.BackColor = System.Drawing.Color.Transparent
        Me.CHKMANUAL.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKMANUAL.Location = New System.Drawing.Point(1154, 3)
        Me.CHKMANUAL.Name = "CHKMANUAL"
        Me.CHKMANUAL.Size = New System.Drawing.Size(15, 14)
        Me.CHKMANUAL.TabIndex = 935
        Me.CHKMANUAL.UseVisualStyleBackColor = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(347, 151)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(58, 15)
        Me.Label22.TabIndex = 814
        Me.Label22.Text = "Total Qty."
        '
        'LBLTOTALQTY
        '
        Me.LBLTOTALQTY.BackColor = System.Drawing.Color.Transparent
        Me.LBLTOTALQTY.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTOTALQTY.ForeColor = System.Drawing.Color.Black
        Me.LBLTOTALQTY.Location = New System.Drawing.Point(414, 151)
        Me.LBLTOTALQTY.Name = "LBLTOTALQTY"
        Me.LBLTOTALQTY.Size = New System.Drawing.Size(88, 15)
        Me.LBLTOTALQTY.TabIndex = 813
        Me.LBLTOTALQTY.Text = "0"
        Me.LBLTOTALQTY.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LBLTOTALGRIDAMT
        '
        Me.LBLTOTALGRIDAMT.BackColor = System.Drawing.Color.Transparent
        Me.LBLTOTALGRIDAMT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTOTALGRIDAMT.ForeColor = System.Drawing.Color.Black
        Me.LBLTOTALGRIDAMT.Location = New System.Drawing.Point(1573, 151)
        Me.LBLTOTALGRIDAMT.Name = "LBLTOTALGRIDAMT"
        Me.LBLTOTALGRIDAMT.Size = New System.Drawing.Size(88, 15)
        Me.LBLTOTALGRIDAMT.TabIndex = 812
        Me.LBLTOTALGRIDAMT.Text = "0"
        Me.LBLTOTALGRIDAMT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LBLTOTALIGSTAMT
        '
        Me.LBLTOTALIGSTAMT.BackColor = System.Drawing.Color.Transparent
        Me.LBLTOTALIGSTAMT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTOTALIGSTAMT.ForeColor = System.Drawing.Color.Black
        Me.LBLTOTALIGSTAMT.Location = New System.Drawing.Point(1487, 151)
        Me.LBLTOTALIGSTAMT.Name = "LBLTOTALIGSTAMT"
        Me.LBLTOTALIGSTAMT.Size = New System.Drawing.Size(88, 15)
        Me.LBLTOTALIGSTAMT.TabIndex = 811
        Me.LBLTOTALIGSTAMT.Text = "0"
        Me.LBLTOTALIGSTAMT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LBLTOTALSGSTAMT
        '
        Me.LBLTOTALSGSTAMT.BackColor = System.Drawing.Color.Transparent
        Me.LBLTOTALSGSTAMT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTOTALSGSTAMT.ForeColor = System.Drawing.Color.Black
        Me.LBLTOTALSGSTAMT.Location = New System.Drawing.Point(1298, 151)
        Me.LBLTOTALSGSTAMT.Name = "LBLTOTALSGSTAMT"
        Me.LBLTOTALSGSTAMT.Size = New System.Drawing.Size(88, 15)
        Me.LBLTOTALSGSTAMT.TabIndex = 810
        Me.LBLTOTALSGSTAMT.Text = "0"
        Me.LBLTOTALSGSTAMT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LBLTOTALCGSTAMT
        '
        Me.LBLTOTALCGSTAMT.BackColor = System.Drawing.Color.Transparent
        Me.LBLTOTALCGSTAMT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTOTALCGSTAMT.ForeColor = System.Drawing.Color.Black
        Me.LBLTOTALCGSTAMT.Location = New System.Drawing.Point(1081, 151)
        Me.LBLTOTALCGSTAMT.Name = "LBLTOTALCGSTAMT"
        Me.LBLTOTALCGSTAMT.Size = New System.Drawing.Size(88, 15)
        Me.LBLTOTALCGSTAMT.TabIndex = 809
        Me.LBLTOTALCGSTAMT.Text = "0"
        Me.LBLTOTALCGSTAMT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LBLTOTALTAXABLEAMT
        '
        Me.LBLTOTALTAXABLEAMT.BackColor = System.Drawing.Color.Transparent
        Me.LBLTOTALTAXABLEAMT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTOTALTAXABLEAMT.ForeColor = System.Drawing.Color.Black
        Me.LBLTOTALTAXABLEAMT.Location = New System.Drawing.Point(911, 151)
        Me.LBLTOTALTAXABLEAMT.Name = "LBLTOTALTAXABLEAMT"
        Me.LBLTOTALTAXABLEAMT.Size = New System.Drawing.Size(88, 15)
        Me.LBLTOTALTAXABLEAMT.TabIndex = 808
        Me.LBLTOTALTAXABLEAMT.Text = "0"
        Me.LBLTOTALTAXABLEAMT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LBLTOTALOTHERAMT
        '
        Me.LBLTOTALOTHERAMT.BackColor = System.Drawing.Color.Transparent
        Me.LBLTOTALOTHERAMT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTOTALOTHERAMT.ForeColor = System.Drawing.Color.Black
        Me.LBLTOTALOTHERAMT.Location = New System.Drawing.Point(811, 151)
        Me.LBLTOTALOTHERAMT.Name = "LBLTOTALOTHERAMT"
        Me.LBLTOTALOTHERAMT.Size = New System.Drawing.Size(88, 15)
        Me.LBLTOTALOTHERAMT.TabIndex = 807
        Me.LBLTOTALOTHERAMT.Text = "0"
        Me.LBLTOTALOTHERAMT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbltotalamt
        '
        Me.lbltotalamt.BackColor = System.Drawing.Color.Transparent
        Me.lbltotalamt.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalamt.ForeColor = System.Drawing.Color.Black
        Me.lbltotalamt.Location = New System.Drawing.Point(700, 151)
        Me.lbltotalamt.Name = "lbltotalamt"
        Me.lbltotalamt.Size = New System.Drawing.Size(88, 15)
        Me.lbltotalamt.TabIndex = 746
        Me.lbltotalamt.Text = "0.00"
        Me.lbltotalamt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(629, 151)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(61, 15)
        Me.Label18.TabIndex = 745
        Me.Label18.Text = "Total Amt."
        '
        'gridinvoice
        '
        Me.gridinvoice.AllowUserToAddRows = False
        Me.gridinvoice.AllowUserToDeleteRows = False
        Me.gridinvoice.AllowUserToResizeColumns = False
        Me.gridinvoice.AllowUserToResizeRows = False
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridinvoice.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle17
        Me.gridinvoice.BackgroundColor = System.Drawing.Color.White
        Me.gridinvoice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.gridinvoice.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.gridinvoice.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle18
        Me.gridinvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridinvoice.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GITEMCODE, Me.GITEMNAME, Me.GHSNCODE, Me.GMATERIALCODE, Me.GQTY, Me.GBATCHNO, Me.GRATE, Me.GAMOUNT, Me.GOTHERAMT, Me.GTAXABLEAMT, Me.GCGSTPER, Me.GCGSTAMT, Me.GSGSTPER, Me.GSGSTAMT, Me.GIGSTPER, Me.GIGSTAMT, Me.GGRIDTOTAL, Me.GGRIDCHALLANNO})
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle27.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle27.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridinvoice.DefaultCellStyle = DataGridViewCellStyle27
        Me.gridinvoice.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.gridinvoice.GridColor = System.Drawing.SystemColors.Control
        Me.gridinvoice.Location = New System.Drawing.Point(6, 19)
        Me.gridinvoice.MultiSelect = False
        Me.gridinvoice.Name = "gridinvoice"
        Me.gridinvoice.RowHeadersVisible = False
        Me.gridinvoice.RowHeadersWidth = 30
        Me.gridinvoice.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle28.SelectionBackColor = System.Drawing.Color.Black
        Me.gridinvoice.RowsDefaultCellStyle = DataGridViewCellStyle28
        Me.gridinvoice.RowTemplate.Height = 20
        Me.gridinvoice.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridinvoice.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.gridinvoice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridinvoice.Size = New System.Drawing.Size(1779, 129)
        Me.gridinvoice.TabIndex = 0
        Me.gridinvoice.TabStop = False
        '
        'GITEMCODE
        '
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.GITEMCODE.DefaultCellStyle = DataGridViewCellStyle19
        Me.GITEMCODE.HeaderText = "Item Code"
        Me.GITEMCODE.MinimumWidth = 2
        Me.GITEMCODE.Name = "GITEMCODE"
        Me.GITEMCODE.ReadOnly = True
        Me.GITEMCODE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GITEMCODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GITEMCODE.Width = 97
        '
        'GITEMNAME
        '
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.GITEMNAME.DefaultCellStyle = DataGridViewCellStyle20
        Me.GITEMNAME.HeaderText = "Item Name"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.ReadOnly = True
        Me.GITEMNAME.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GITEMNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GITEMNAME.Width = 97
        '
        'GHSNCODE
        '
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.GHSNCODE.DefaultCellStyle = DataGridViewCellStyle21
        Me.GHSNCODE.HeaderText = "HSN Code"
        Me.GHSNCODE.Name = "GHSNCODE"
        Me.GHSNCODE.ReadOnly = True
        Me.GHSNCODE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GHSNCODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GHSNCODE.Width = 97
        '
        'GMATERIALCODE
        '
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.GMATERIALCODE.DefaultCellStyle = DataGridViewCellStyle22
        Me.GMATERIALCODE.HeaderText = "MCode"
        Me.GMATERIALCODE.Name = "GMATERIALCODE"
        Me.GMATERIALCODE.ReadOnly = True
        Me.GMATERIALCODE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GMATERIALCODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GMATERIALCODE.Width = 97
        '
        'GQTY
        '
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle23.NullValue = Nothing
        Me.GQTY.DefaultCellStyle = DataGridViewCellStyle23
        Me.GQTY.HeaderText = "Quantity"
        Me.GQTY.Name = "GQTY"
        Me.GQTY.ReadOnly = True
        Me.GQTY.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GQTY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GQTY.Width = 97
        '
        'GBATCHNO
        '
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.GBATCHNO.DefaultCellStyle = DataGridViewCellStyle24
        Me.GBATCHNO.HeaderText = "Batch No"
        Me.GBATCHNO.Name = "GBATCHNO"
        Me.GBATCHNO.ReadOnly = True
        Me.GBATCHNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GBATCHNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GBATCHNO.Width = 97
        '
        'GRATE
        '
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle25.NullValue = Nothing
        Me.GRATE.DefaultCellStyle = DataGridViewCellStyle25
        Me.GRATE.HeaderText = "Rate"
        Me.GRATE.MaxInputLength = 10
        Me.GRATE.Name = "GRATE"
        Me.GRATE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GRATE.Width = 97
        '
        'GAMOUNT
        '
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle26.NullValue = Nothing
        Me.GAMOUNT.DefaultCellStyle = DataGridViewCellStyle26
        Me.GAMOUNT.HeaderText = "Amount"
        Me.GAMOUNT.Name = "GAMOUNT"
        Me.GAMOUNT.ReadOnly = True
        Me.GAMOUNT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GAMOUNT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GAMOUNT.Width = 97
        '
        'GOTHERAMT
        '
        Me.GOTHERAMT.HeaderText = "Other Amt."
        Me.GOTHERAMT.Name = "GOTHERAMT"
        Me.GOTHERAMT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GOTHERAMT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GOTHERAMT.Width = 97
        '
        'GTAXABLEAMT
        '
        Me.GTAXABLEAMT.HeaderText = "Taxable Amt."
        Me.GTAXABLEAMT.Name = "GTAXABLEAMT"
        Me.GTAXABLEAMT.ReadOnly = True
        Me.GTAXABLEAMT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GTAXABLEAMT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GTAXABLEAMT.Width = 97
        '
        'GCGSTPER
        '
        Me.GCGSTPER.HeaderText = "CGST%"
        Me.GCGSTPER.Name = "GCGSTPER"
        Me.GCGSTPER.ReadOnly = True
        Me.GCGSTPER.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GCGSTPER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GCGSTPER.Width = 97
        '
        'GCGSTAMT
        '
        Me.GCGSTAMT.HeaderText = "CGST Amt."
        Me.GCGSTAMT.Name = "GCGSTAMT"
        Me.GCGSTAMT.ReadOnly = True
        Me.GCGSTAMT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GCGSTAMT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GCGSTAMT.Width = 97
        '
        'GSGSTPER
        '
        Me.GSGSTPER.HeaderText = "SGST%"
        Me.GSGSTPER.Name = "GSGSTPER"
        Me.GSGSTPER.ReadOnly = True
        Me.GSGSTPER.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GSGSTPER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GSGSTPER.Width = 97
        '
        'GSGSTAMT
        '
        Me.GSGSTAMT.HeaderText = "SGST Amt."
        Me.GSGSTAMT.Name = "GSGSTAMT"
        Me.GSGSTAMT.ReadOnly = True
        Me.GSGSTAMT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GSGSTAMT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GSGSTAMT.Width = 97
        '
        'GIGSTPER
        '
        Me.GIGSTPER.HeaderText = "IGST %"
        Me.GIGSTPER.Name = "GIGSTPER"
        Me.GIGSTPER.ReadOnly = True
        Me.GIGSTPER.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GIGSTPER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GIGSTPER.Width = 97
        '
        'GIGSTAMT
        '
        Me.GIGSTAMT.HeaderText = "IGST Amt."
        Me.GIGSTAMT.Name = "GIGSTAMT"
        Me.GIGSTAMT.ReadOnly = True
        Me.GIGSTAMT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GIGSTAMT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GIGSTAMT.Width = 97
        '
        'GGRIDTOTAL
        '
        Me.GGRIDTOTAL.HeaderText = "Grid Total"
        Me.GGRIDTOTAL.Name = "GGRIDTOTAL"
        Me.GGRIDTOTAL.ReadOnly = True
        Me.GGRIDTOTAL.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GGRIDTOTAL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GGRIDTOTAL.Width = 97
        '
        'GGRIDCHALLANNO
        '
        Me.GGRIDCHALLANNO.HeaderText = "Challan No"
        Me.GGRIDCHALLANNO.Name = "GGRIDCHALLANNO"
        Me.GGRIDCHALLANNO.ReadOnly = True
        Me.GGRIDCHALLANNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GGRIDCHALLANNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GGRIDCHALLANNO.Width = 97
        '
        'TBADD
        '
        Me.TBADD.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.TBADD.Controls.Add(Me.ACKDATE)
        Me.TBADD.Controls.Add(Me.Label63)
        Me.TBADD.Controls.Add(Me.TXTACKNO)
        Me.TBADD.Controls.Add(Me.Label64)
        Me.TBADD.Controls.Add(Me.TXTNEWIMGPATH)
        Me.TBADD.Controls.Add(Me.TXTFILENAME)
        Me.TBADD.Controls.Add(Me.CMDGETQRCODE)
        Me.TBADD.Controls.Add(Me.CMDUPLOADIRN)
        Me.TBADD.Controls.Add(Me.PBQRCODE)
        Me.TBADD.Controls.Add(Me.TXTIRNNO)
        Me.TBADD.Controls.Add(Me.Label61)
        Me.TBADD.Controls.Add(Me.Label59)
        Me.TBADD.Controls.Add(Me.LRDATE)
        Me.TBADD.Controls.Add(Me.TXTVEHICLENO)
        Me.TBADD.Controls.Add(Me.CMBFROMCITY)
        Me.TBADD.Controls.Add(Me.Label60)
        Me.TBADD.Controls.Add(Me.CMBTOCITY)
        Me.TBADD.Controls.Add(Me.Label56)
        Me.TBADD.Controls.Add(Me.Label57)
        Me.TBADD.Controls.Add(Me.TXTLRNO)
        Me.TBADD.Controls.Add(Me.Label58)
        Me.TBADD.Location = New System.Drawing.Point(4, 22)
        Me.TBADD.Name = "TBADD"
        Me.TBADD.Size = New System.Drawing.Size(1234, 191)
        Me.TBADD.TabIndex = 3
        Me.TBADD.Text = "2. Additional Details"
        '
        'ACKDATE
        '
        Me.ACKDATE.CustomFormat = "dd/MM/yyyy"
        Me.ACKDATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ACKDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.ACKDATE.Location = New System.Drawing.Point(697, 61)
        Me.ACKDATE.Name = "ACKDATE"
        Me.ACKDATE.Size = New System.Drawing.Size(85, 23)
        Me.ACKDATE.TabIndex = 953
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.BackColor = System.Drawing.Color.Transparent
        Me.Label63.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label63.Location = New System.Drawing.Point(640, 65)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(54, 15)
        Me.Label63.TabIndex = 954
        Me.Label63.Text = "Ack Date"
        Me.Label63.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTACKNO
        '
        Me.TXTACKNO.BackColor = System.Drawing.Color.White
        Me.TXTACKNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTACKNO.Location = New System.Drawing.Point(697, 33)
        Me.TXTACKNO.Name = "TXTACKNO"
        Me.TXTACKNO.Size = New System.Drawing.Size(170, 23)
        Me.TXTACKNO.TabIndex = 951
        Me.TXTACKNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.BackColor = System.Drawing.Color.Transparent
        Me.Label64.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label64.ForeColor = System.Drawing.Color.Black
        Me.Label64.Location = New System.Drawing.Point(651, 37)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(43, 14)
        Me.Label64.TabIndex = 952
        Me.Label64.Text = "Ack No"
        Me.Label64.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTNEWIMGPATH
        '
        Me.TXTNEWIMGPATH.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNEWIMGPATH.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTNEWIMGPATH.Location = New System.Drawing.Point(1143, 13)
        Me.TXTNEWIMGPATH.Multiline = True
        Me.TXTNEWIMGPATH.Name = "TXTNEWIMGPATH"
        Me.TXTNEWIMGPATH.Size = New System.Drawing.Size(27, 22)
        Me.TXTNEWIMGPATH.TabIndex = 950
        Me.TXTNEWIMGPATH.Visible = False
        '
        'TXTFILENAME
        '
        Me.TXTFILENAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFILENAME.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTFILENAME.Location = New System.Drawing.Point(1127, 13)
        Me.TXTFILENAME.Multiline = True
        Me.TXTFILENAME.Name = "TXTFILENAME"
        Me.TXTFILENAME.Size = New System.Drawing.Size(10, 22)
        Me.TXTFILENAME.TabIndex = 949
        Me.TXTFILENAME.Visible = False
        '
        'CMDGETQRCODE
        '
        Me.CMDGETQRCODE.BackColor = System.Drawing.Color.Transparent
        Me.CMDGETQRCODE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDGETQRCODE.FlatAppearance.BorderSize = 0
        Me.CMDGETQRCODE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDGETQRCODE.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDGETQRCODE.Location = New System.Drawing.Point(623, 155)
        Me.CMDGETQRCODE.Name = "CMDGETQRCODE"
        Me.CMDGETQRCODE.Size = New System.Drawing.Size(100, 27)
        Me.CMDGETQRCODE.TabIndex = 948
        Me.CMDGETQRCODE.Text = "&Get QRCode"
        Me.CMDGETQRCODE.UseVisualStyleBackColor = False
        '
        'CMDUPLOADIRN
        '
        Me.CMDUPLOADIRN.BackColor = System.Drawing.Color.Transparent
        Me.CMDUPLOADIRN.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDUPLOADIRN.FlatAppearance.BorderSize = 0
        Me.CMDUPLOADIRN.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDUPLOADIRN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDUPLOADIRN.Location = New System.Drawing.Point(623, 121)
        Me.CMDUPLOADIRN.Name = "CMDUPLOADIRN"
        Me.CMDUPLOADIRN.Size = New System.Drawing.Size(100, 27)
        Me.CMDUPLOADIRN.TabIndex = 947
        Me.CMDUPLOADIRN.Text = "&Upload"
        Me.CMDUPLOADIRN.UseVisualStyleBackColor = False
        '
        'PBQRCODE
        '
        Me.PBQRCODE.BackColor = System.Drawing.Color.Transparent
        Me.PBQRCODE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PBQRCODE.Location = New System.Drawing.Point(467, 34)
        Me.PBQRCODE.Name = "PBQRCODE"
        Me.PBQRCODE.Size = New System.Drawing.Size(150, 150)
        Me.PBQRCODE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBQRCODE.TabIndex = 946
        Me.PBQRCODE.TabStop = False
        '
        'TXTIRNNO
        '
        Me.TXTIRNNO.BackColor = System.Drawing.Color.White
        Me.TXTIRNNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTIRNNO.Location = New System.Drawing.Point(467, 5)
        Me.TXTIRNNO.Name = "TXTIRNNO"
        Me.TXTIRNNO.Size = New System.Drawing.Size(400, 22)
        Me.TXTIRNNO.TabIndex = 944
        '
        'Label61
        '
        Me.Label61.BackColor = System.Drawing.Color.Transparent
        Me.Label61.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label61.ForeColor = System.Drawing.Color.Black
        Me.Label61.Location = New System.Drawing.Point(432, 9)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(33, 14)
        Me.Label61.TabIndex = 945
        Me.Label61.Text = "IRN"
        Me.Label61.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.BackColor = System.Drawing.Color.Transparent
        Me.Label59.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label59.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label59.Location = New System.Drawing.Point(16, 17)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(67, 15)
        Me.Label59.TabIndex = 943
        Me.Label59.Text = "Vehicle No."
        '
        'LRDATE
        '
        Me.LRDATE.AsciiOnly = True
        Me.LRDATE.BackColor = System.Drawing.Color.White
        Me.LRDATE.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.LRDATE.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.LRDATE.Location = New System.Drawing.Point(85, 71)
        Me.LRDATE.Mask = "00/00/0000"
        Me.LRDATE.Name = "LRDATE"
        Me.LRDATE.Size = New System.Drawing.Size(87, 23)
        Me.LRDATE.TabIndex = 242
        Me.LRDATE.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.LRDATE.ValidatingType = GetType(Date)
        '
        'TXTVEHICLENO
        '
        Me.TXTVEHICLENO.BackColor = System.Drawing.Color.White
        Me.TXTVEHICLENO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTVEHICLENO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTVEHICLENO.Location = New System.Drawing.Point(85, 13)
        Me.TXTVEHICLENO.Name = "TXTVEHICLENO"
        Me.TXTVEHICLENO.Size = New System.Drawing.Size(146, 23)
        Me.TXTVEHICLENO.TabIndex = 942
        '
        'CMBFROMCITY
        '
        Me.CMBFROMCITY.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBFROMCITY.FormattingEnabled = True
        Me.CMBFROMCITY.Location = New System.Drawing.Point(85, 100)
        Me.CMBFROMCITY.MaxDropDownItems = 14
        Me.CMBFROMCITY.Name = "CMBFROMCITY"
        Me.CMBFROMCITY.Size = New System.Drawing.Size(146, 23)
        Me.CMBFROMCITY.TabIndex = 240
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.BackColor = System.Drawing.Color.Transparent
        Me.Label60.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label60.Location = New System.Drawing.Point(25, 104)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(59, 15)
        Me.Label60.TabIndex = 241
        Me.Label60.Text = "From City"
        '
        'CMBTOCITY
        '
        Me.CMBTOCITY.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBTOCITY.FormattingEnabled = True
        Me.CMBTOCITY.Location = New System.Drawing.Point(85, 129)
        Me.CMBTOCITY.MaxDropDownItems = 14
        Me.CMBTOCITY.Name = "CMBTOCITY"
        Me.CMBTOCITY.Size = New System.Drawing.Size(146, 23)
        Me.CMBTOCITY.TabIndex = 236
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.BackColor = System.Drawing.Color.Transparent
        Me.Label56.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label56.Location = New System.Drawing.Point(41, 133)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(43, 15)
        Me.Label56.TabIndex = 239
        Me.Label56.Text = "To City"
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.BackColor = System.Drawing.Color.Transparent
        Me.Label57.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.Location = New System.Drawing.Point(38, 46)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(46, 15)
        Me.Label57.TabIndex = 232
        Me.Label57.Text = "L.R. No."
        '
        'TXTLRNO
        '
        Me.TXTLRNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTLRNO.Location = New System.Drawing.Point(85, 42)
        Me.TXTLRNO.MaxLength = 20
        Me.TXTLRNO.Name = "TXTLRNO"
        Me.TXTLRNO.Size = New System.Drawing.Size(87, 23)
        Me.TXTLRNO.TabIndex = 234
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.BackColor = System.Drawing.Color.Transparent
        Me.Label58.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label58.Location = New System.Drawing.Point(31, 75)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(53, 15)
        Me.Label58.TabIndex = 238
        Me.Label58.Text = "L.R. Date"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.TXTIMGPATH)
        Me.TabPage2.Controls.Add(Me.PBSOFTCOPY)
        Me.TabPage2.Controls.Add(Me.CMDVIEW)
        Me.TabPage2.Controls.Add(Me.CMDREMOVE)
        Me.TabPage2.Controls.Add(Me.CMDUPLOAD)
        Me.TabPage2.Controls.Add(Me.txtuploadname)
        Me.TabPage2.Controls.Add(Me.TXTUPLOADSRNO)
        Me.TabPage2.Controls.Add(Me.txtuploadremarks)
        Me.TabPage2.Controls.Add(Me.gridupload)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1234, 191)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "3. Upload Docs"
        '
        'TXTIMGPATH
        '
        Me.TXTIMGPATH.BackColor = System.Drawing.Color.White
        Me.TXTIMGPATH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTIMGPATH.ForeColor = System.Drawing.Color.Black
        Me.TXTIMGPATH.Location = New System.Drawing.Point(790, 93)
        Me.TXTIMGPATH.Name = "TXTIMGPATH"
        Me.TXTIMGPATH.Size = New System.Drawing.Size(22, 23)
        Me.TXTIMGPATH.TabIndex = 668
        Me.TXTIMGPATH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTIMGPATH.Visible = False
        '
        'PBSOFTCOPY
        '
        Me.PBSOFTCOPY.BackColor = System.Drawing.Color.White
        Me.PBSOFTCOPY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PBSOFTCOPY.ErrorImage = Nothing
        Me.PBSOFTCOPY.InitialImage = Nothing
        Me.PBSOFTCOPY.Location = New System.Drawing.Point(755, 5)
        Me.PBSOFTCOPY.Name = "PBSOFTCOPY"
        Me.PBSOFTCOPY.Size = New System.Drawing.Size(88, 87)
        Me.PBSOFTCOPY.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBSOFTCOPY.TabIndex = 667
        Me.PBSOFTCOPY.TabStop = False
        '
        'CMDVIEW
        '
        Me.CMDVIEW.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDVIEW.Location = New System.Drawing.Point(670, 33)
        Me.CMDVIEW.Name = "CMDVIEW"
        Me.CMDVIEW.Size = New System.Drawing.Size(80, 28)
        Me.CMDVIEW.TabIndex = 3
        Me.CMDVIEW.Text = "&View"
        Me.CMDVIEW.UseVisualStyleBackColor = True
        '
        'CMDREMOVE
        '
        Me.CMDREMOVE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDREMOVE.Location = New System.Drawing.Point(670, 60)
        Me.CMDREMOVE.Name = "CMDREMOVE"
        Me.CMDREMOVE.Size = New System.Drawing.Size(80, 28)
        Me.CMDREMOVE.TabIndex = 4
        Me.CMDREMOVE.Text = "&Remove"
        Me.CMDREMOVE.UseVisualStyleBackColor = True
        '
        'CMDUPLOAD
        '
        Me.CMDUPLOAD.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDUPLOAD.Location = New System.Drawing.Point(669, 6)
        Me.CMDUPLOAD.Name = "CMDUPLOAD"
        Me.CMDUPLOAD.Size = New System.Drawing.Size(80, 28)
        Me.CMDUPLOAD.TabIndex = 1
        Me.CMDUPLOAD.Text = "&Upload"
        Me.CMDUPLOAD.UseVisualStyleBackColor = True
        '
        'txtuploadname
        '
        Me.txtuploadname.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtuploadname.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtuploadname.Location = New System.Drawing.Point(345, 4)
        Me.txtuploadname.MaxLength = 1000
        Me.txtuploadname.Name = "txtuploadname"
        Me.txtuploadname.Size = New System.Drawing.Size(302, 23)
        Me.txtuploadname.TabIndex = 2
        '
        'TXTUPLOADSRNO
        '
        Me.TXTUPLOADSRNO.BackColor = System.Drawing.Color.Linen
        Me.TXTUPLOADSRNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTUPLOADSRNO.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTUPLOADSRNO.Location = New System.Drawing.Point(5, 4)
        Me.TXTUPLOADSRNO.Name = "TXTUPLOADSRNO"
        Me.TXTUPLOADSRNO.ReadOnly = True
        Me.TXTUPLOADSRNO.Size = New System.Drawing.Size(40, 23)
        Me.TXTUPLOADSRNO.TabIndex = 661
        Me.TXTUPLOADSRNO.TabStop = False
        '
        'txtuploadremarks
        '
        Me.txtuploadremarks.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtuploadremarks.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtuploadremarks.Location = New System.Drawing.Point(45, 4)
        Me.txtuploadremarks.MaxLength = 1000
        Me.txtuploadremarks.Name = "txtuploadremarks"
        Me.txtuploadremarks.Size = New System.Drawing.Size(301, 23)
        Me.txtuploadremarks.TabIndex = 0
        '
        'gridupload
        '
        Me.gridupload.AllowUserToAddRows = False
        Me.gridupload.AllowUserToDeleteRows = False
        Me.gridupload.AllowUserToResizeColumns = False
        Me.gridupload.AllowUserToResizeRows = False
        DataGridViewCellStyle29.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle29.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle29.SelectionBackColor = System.Drawing.Color.Black
        Me.gridupload.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle29
        Me.gridupload.BackgroundColor = System.Drawing.Color.White
        Me.gridupload.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.gridupload.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle30.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle30.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle30.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle30.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.gridupload.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle30
        Me.gridupload.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridupload.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GUSRNO, Me.GUREMARKS, Me.GUNAME, Me.GUIMGPATH})
        DataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle31.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle31.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle31.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle31.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle31.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle31.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridupload.DefaultCellStyle = DataGridViewCellStyle31
        Me.gridupload.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.gridupload.GridColor = System.Drawing.SystemColors.Control
        Me.gridupload.Location = New System.Drawing.Point(4, 27)
        Me.gridupload.MultiSelect = False
        Me.gridupload.Name = "gridupload"
        Me.gridupload.ReadOnly = True
        Me.gridupload.RowHeadersVisible = False
        Me.gridupload.RowHeadersWidth = 30
        Me.gridupload.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle32.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle32.SelectionForeColor = System.Drawing.Color.White
        Me.gridupload.RowsDefaultCellStyle = DataGridViewCellStyle32
        Me.gridupload.RowTemplate.Height = 20
        Me.gridupload.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridupload.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gridupload.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridupload.Size = New System.Drawing.Size(663, 156)
        Me.gridupload.TabIndex = 651
        Me.gridupload.TabStop = False
        '
        'GUSRNO
        '
        Me.GUSRNO.HeaderText = "Sr."
        Me.GUSRNO.Name = "GUSRNO"
        Me.GUSRNO.ReadOnly = True
        Me.GUSRNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GUSRNO.Width = 40
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
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.GroupBox1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1234, 191)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "4. QC"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TXTINKDETAILS)
        Me.GroupBox1.Controls.Add(Me.TXTQCVARNISH)
        Me.GroupBox1.Controls.Add(Me.Label51)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.Label49)
        Me.GroupBox1.Controls.Add(Me.TXTQCPAPER)
        Me.GroupBox1.Controls.Add(Me.TXTQCBATCH)
        Me.GroupBox1.Controls.Add(Me.Label27)
        Me.GroupBox1.Controls.Add(Me.TXTQCADHESIVE)
        Me.GroupBox1.Controls.Add(Me.TXTQCGSM)
        Me.GroupBox1.Controls.Add(Me.TXTQCTEXT)
        Me.GroupBox1.Controls.Add(Me.LBLGRAIN)
        Me.GroupBox1.Controls.Add(Me.QCDATE)
        Me.GroupBox1.Controls.Add(Me.TXTQCGRAIN)
        Me.GroupBox1.Controls.Add(Me.TXTQCVISUAL)
        Me.GroupBox1.Controls.Add(Me.Label31)
        Me.GroupBox1.Controls.Add(Me.Label55)
        Me.GroupBox1.Controls.Add(Me.TXTQCPHARMA)
        Me.GroupBox1.Controls.Add(Me.TXTQCHEAD)
        Me.GroupBox1.Controls.Add(Me.Label34)
        Me.GroupBox1.Controls.Add(Me.Label54)
        Me.GroupBox1.Controls.Add(Me.TXTQCUPS)
        Me.GroupBox1.Controls.Add(Me.Label53)
        Me.GroupBox1.Controls.Add(Me.Label36)
        Me.GroupBox1.Controls.Add(Me.Label52)
        Me.GroupBox1.Controls.Add(Me.Label37)
        Me.GroupBox1.Controls.Add(Me.TXTQCREMARKS)
        Me.GroupBox1.Controls.Add(Me.Label38)
        Me.GroupBox1.Controls.Add(Me.Label50)
        Me.GroupBox1.Controls.Add(Me.Label39)
        Me.GroupBox1.Controls.Add(Me.TXTQCLABEL)
        Me.GroupBox1.Controls.Add(Me.Label40)
        Me.GroupBox1.Controls.Add(Me.LABEL555)
        Me.GroupBox1.Controls.Add(Me.TXTQCCOLOR)
        Me.GroupBox1.Controls.Add(Me.TXTQCSHIPPER)
        Me.GroupBox1.Controls.Add(Me.Label41)
        Me.GroupBox1.Controls.Add(Me.Label46)
        Me.GroupBox1.Controls.Add(Me.Label42)
        Me.GroupBox1.Controls.Add(Me.TXTQCPACKET)
        Me.GroupBox1.Controls.Add(Me.TXTQCPERFOR)
        Me.GroupBox1.Controls.Add(Me.Label47)
        Me.GroupBox1.Controls.Add(Me.LBLDESIGN)
        Me.GroupBox1.Controls.Add(Me.TXTQCFINALAMT)
        Me.GroupBox1.Controls.Add(Me.TXTQCDESIGN)
        Me.GroupBox1.Controls.Add(Me.Label48)
        Me.GroupBox1.Controls.Add(Me.Label44)
        Me.GroupBox1.Controls.Add(Me.TXTQCSTICKER)
        Me.GroupBox1.Controls.Add(Me.TXTQCSIZE)
        Me.GroupBox1.Controls.Add(Me.Label45)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1211, 189)
        Me.GroupBox1.TabIndex = 945
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'TXTINKDETAILS
        '
        Me.TXTINKDETAILS.BackColor = System.Drawing.Color.White
        Me.TXTINKDETAILS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTINKDETAILS.Location = New System.Drawing.Point(760, 149)
        Me.TXTINKDETAILS.MaxLength = 100
        Me.TXTINKDETAILS.Name = "TXTINKDETAILS"
        Me.TXTINKDETAILS.Size = New System.Drawing.Size(315, 23)
        Me.TXTINKDETAILS.TabIndex = 22
        Me.TXTINKDETAILS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTQCVARNISH
        '
        Me.TXTQCVARNISH.BackColor = System.Drawing.Color.White
        Me.TXTQCVARNISH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTQCVARNISH.Location = New System.Drawing.Point(346, 64)
        Me.TXTQCVARNISH.MaxLength = 32776
        Me.TXTQCVARNISH.Name = "TXTQCVARNISH"
        Me.TXTQCVARNISH.Size = New System.Drawing.Size(101, 23)
        Me.TXTQCVARNISH.TabIndex = 8
        Me.TXTQCVARNISH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.BackColor = System.Drawing.Color.Transparent
        Me.Label51.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label51.Location = New System.Drawing.Point(692, 153)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(66, 15)
        Me.Label51.TabIndex = 932
        Me.Label51.Text = "Ink Details"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label24.Location = New System.Drawing.Point(27, 11)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(120, 15)
        Me.Label24.TabIndex = 879
        Me.Label24.Text = "Used Paper Material"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.BackColor = System.Drawing.Color.Transparent
        Me.Label49.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label49.Location = New System.Drawing.Point(20, 39)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(127, 15)
        Me.Label49.TabIndex = 930
        Me.Label49.Text = "Text/Graphic/Pictures"
        '
        'TXTQCPAPER
        '
        Me.TXTQCPAPER.BackColor = System.Drawing.Color.White
        Me.TXTQCPAPER.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTQCPAPER.Location = New System.Drawing.Point(149, 7)
        Me.TXTQCPAPER.MaxLength = 32776
        Me.TXTQCPAPER.Name = "TXTQCPAPER"
        Me.TXTQCPAPER.Size = New System.Drawing.Size(101, 23)
        Me.TXTQCPAPER.TabIndex = 0
        Me.TXTQCPAPER.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTQCBATCH
        '
        Me.TXTQCBATCH.BackColor = System.Drawing.Color.White
        Me.TXTQCBATCH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTQCBATCH.Location = New System.Drawing.Point(149, 149)
        Me.TXTQCBATCH.MaxLength = 32776
        Me.TXTQCBATCH.Name = "TXTQCBATCH"
        Me.TXTQCBATCH.Size = New System.Drawing.Size(101, 23)
        Me.TXTQCBATCH.TabIndex = 5
        Me.TXTQCBATCH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label27.Location = New System.Drawing.Point(276, 11)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(67, 15)
        Me.Label27.TabIndex = 881
        Me.Label27.Text = "Paper GSM"
        '
        'TXTQCADHESIVE
        '
        Me.TXTQCADHESIVE.BackColor = System.Drawing.Color.White
        Me.TXTQCADHESIVE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTQCADHESIVE.Location = New System.Drawing.Point(149, 64)
        Me.TXTQCADHESIVE.MaxLength = 32776
        Me.TXTQCADHESIVE.Name = "TXTQCADHESIVE"
        Me.TXTQCADHESIVE.Size = New System.Drawing.Size(101, 23)
        Me.TXTQCADHESIVE.TabIndex = 2
        Me.TXTQCADHESIVE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTQCGSM
        '
        Me.TXTQCGSM.BackColor = System.Drawing.Color.White
        Me.TXTQCGSM.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTQCGSM.Location = New System.Drawing.Point(346, 7)
        Me.TXTQCGSM.MaxLength = 32776
        Me.TXTQCGSM.Name = "TXTQCGSM"
        Me.TXTQCGSM.Size = New System.Drawing.Size(101, 23)
        Me.TXTQCGSM.TabIndex = 6
        Me.TXTQCGSM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTQCTEXT
        '
        Me.TXTQCTEXT.BackColor = System.Drawing.Color.White
        Me.TXTQCTEXT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTQCTEXT.Location = New System.Drawing.Point(149, 35)
        Me.TXTQCTEXT.MaxLength = 32776
        Me.TXTQCTEXT.Name = "TXTQCTEXT"
        Me.TXTQCTEXT.Size = New System.Drawing.Size(101, 23)
        Me.TXTQCTEXT.TabIndex = 1
        Me.TXTQCTEXT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LBLGRAIN
        '
        Me.LBLGRAIN.BackColor = System.Drawing.Color.Transparent
        Me.LBLGRAIN.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLGRAIN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LBLGRAIN.Location = New System.Drawing.Point(31, 125)
        Me.LBLGRAIN.Name = "LBLGRAIN"
        Me.LBLGRAIN.Size = New System.Drawing.Size(117, 15)
        Me.LBLGRAIN.TabIndex = 883
        Me.LBLGRAIN.Text = "Close Size Label"
        Me.LBLGRAIN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'QCDATE
        '
        Me.QCDATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QCDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.QCDATE.Location = New System.Drawing.Point(760, 7)
        Me.QCDATE.Name = "QCDATE"
        Me.QCDATE.Size = New System.Drawing.Size(90, 23)
        Me.QCDATE.TabIndex = 18
        '
        'TXTQCGRAIN
        '
        Me.TXTQCGRAIN.BackColor = System.Drawing.Color.White
        Me.TXTQCGRAIN.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTQCGRAIN.Location = New System.Drawing.Point(149, 121)
        Me.TXTQCGRAIN.MaxLength = 32776
        Me.TXTQCGRAIN.Name = "TXTQCGRAIN"
        Me.TXTQCGRAIN.Size = New System.Drawing.Size(101, 23)
        Me.TXTQCGRAIN.TabIndex = 4
        Me.TXTQCGRAIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTQCVISUAL
        '
        Me.TXTQCVISUAL.BackColor = System.Drawing.Color.White
        Me.TXTQCVISUAL.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTQCVISUAL.Location = New System.Drawing.Point(760, 35)
        Me.TXTQCVISUAL.MaxLength = 32776
        Me.TXTQCVISUAL.Name = "TXTQCVISUAL"
        Me.TXTQCVISUAL.Size = New System.Drawing.Size(101, 23)
        Me.TXTQCVISUAL.TabIndex = 19
        Me.TXTQCVISUAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label31.Location = New System.Drawing.Point(267, 39)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(76, 15)
        Me.Label31.TabIndex = 885
        Me.Label31.Text = "Pharmacode"
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.BackColor = System.Drawing.Color.Transparent
        Me.Label55.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label55.Location = New System.Drawing.Point(673, 39)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(85, 15)
        Me.Label55.TabIndex = 926
        Me.Label55.Text = "Visual Defects"
        '
        'TXTQCPHARMA
        '
        Me.TXTQCPHARMA.BackColor = System.Drawing.Color.White
        Me.TXTQCPHARMA.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTQCPHARMA.Location = New System.Drawing.Point(346, 35)
        Me.TXTQCPHARMA.MaxLength = 32776
        Me.TXTQCPHARMA.Name = "TXTQCPHARMA"
        Me.TXTQCPHARMA.Size = New System.Drawing.Size(101, 23)
        Me.TXTQCPHARMA.TabIndex = 7
        Me.TXTQCPHARMA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTQCHEAD
        '
        Me.TXTQCHEAD.BackColor = System.Drawing.Color.White
        Me.TXTQCHEAD.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTQCHEAD.Location = New System.Drawing.Point(557, 149)
        Me.TXTQCHEAD.MaxLength = 32776
        Me.TXTQCHEAD.Name = "TXTQCHEAD"
        Me.TXTQCHEAD.Size = New System.Drawing.Size(101, 23)
        Me.TXTQCHEAD.TabIndex = 17
        Me.TXTQCHEAD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.BackColor = System.Drawing.Color.Transparent
        Me.Label34.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label34.Location = New System.Drawing.Point(508, 39)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(46, 15)
        Me.Label34.TabIndex = 887
        Me.Label34.Text = "Ups No"
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.BackColor = System.Drawing.Color.Transparent
        Me.Label54.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label54.Location = New System.Drawing.Point(500, 153)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(54, 15)
        Me.Label54.TabIndex = 924
        Me.Label54.Text = "QC Head"
        '
        'TXTQCUPS
        '
        Me.TXTQCUPS.BackColor = System.Drawing.Color.White
        Me.TXTQCUPS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTQCUPS.Location = New System.Drawing.Point(557, 35)
        Me.TXTQCUPS.MaxLength = 32776
        Me.TXTQCUPS.Name = "TXTQCUPS"
        Me.TXTQCUPS.Size = New System.Drawing.Size(101, 23)
        Me.TXTQCUPS.TabIndex = 13
        Me.TXTQCUPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.BackColor = System.Drawing.Color.Transparent
        Me.Label53.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label53.Location = New System.Drawing.Point(130, 125)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(0, 15)
        Me.Label53.TabIndex = 922
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.BackColor = System.Drawing.Color.Transparent
        Me.Label36.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label36.Location = New System.Drawing.Point(127, 125)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(0, 15)
        Me.Label36.TabIndex = 889
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.BackColor = System.Drawing.Color.Transparent
        Me.Label52.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label52.Location = New System.Drawing.Point(704, 94)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(54, 15)
        Me.Label52.TabIndex = 921
        Me.Label52.Text = "Remarks"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.BackColor = System.Drawing.Color.Transparent
        Me.Label37.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label37.Location = New System.Drawing.Point(34, 36)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(0, 15)
        Me.Label37.TabIndex = 890
        '
        'TXTQCREMARKS
        '
        Me.TXTQCREMARKS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTQCREMARKS.ForeColor = System.Drawing.Color.DimGray
        Me.TXTQCREMARKS.Location = New System.Drawing.Point(760, 93)
        Me.TXTQCREMARKS.Multiline = True
        Me.TXTQCREMARKS.Name = "TXTQCREMARKS"
        Me.TXTQCREMARKS.Size = New System.Drawing.Size(315, 50)
        Me.TXTQCREMARKS.TabIndex = 21
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label38.Location = New System.Drawing.Point(3, 154)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(144, 15)
        Me.Label38.TabIndex = 892
        Me.Label38.Text = "Batch Approved/Rejected"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.BackColor = System.Drawing.Color.Transparent
        Me.Label50.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label50.Location = New System.Drawing.Point(725, 11)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(32, 15)
        Me.Label50.TabIndex = 917
        Me.Label50.Text = "Date"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.BackColor = System.Drawing.Color.Transparent
        Me.Label39.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label39.Location = New System.Drawing.Point(33, 68)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(114, 15)
        Me.Label39.TabIndex = 894
        Me.Label39.Text = "Adhesive Tape/Glue"
        '
        'TXTQCLABEL
        '
        Me.TXTQCLABEL.BackColor = System.Drawing.Color.White
        Me.TXTQCLABEL.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTQCLABEL.Location = New System.Drawing.Point(760, 64)
        Me.TXTQCLABEL.MaxLength = 32776
        Me.TXTQCLABEL.Name = "TXTQCLABEL"
        Me.TXTQCLABEL.Size = New System.Drawing.Size(101, 23)
        Me.TXTQCLABEL.TabIndex = 20
        Me.TXTQCLABEL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.BackColor = System.Drawing.Color.Transparent
        Me.Label40.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label40.Location = New System.Drawing.Point(270, 154)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(73, 15)
        Me.Label40.TabIndex = 897
        Me.Label40.Text = "Color Shade"
        '
        'LABEL555
        '
        Me.LABEL555.AutoSize = True
        Me.LABEL555.BackColor = System.Drawing.Color.Transparent
        Me.LABEL555.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LABEL555.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LABEL555.Location = New System.Drawing.Point(685, 68)
        Me.LABEL555.Name = "LABEL555"
        Me.LABEL555.Size = New System.Drawing.Size(73, 15)
        Me.LABEL555.TabIndex = 915
        Me.LABEL555.Text = "Label Status"
        '
        'TXTQCCOLOR
        '
        Me.TXTQCCOLOR.BackColor = System.Drawing.Color.White
        Me.TXTQCCOLOR.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTQCCOLOR.Location = New System.Drawing.Point(346, 149)
        Me.TXTQCCOLOR.MaxLength = 32776
        Me.TXTQCCOLOR.Name = "TXTQCCOLOR"
        Me.TXTQCCOLOR.Size = New System.Drawing.Size(101, 23)
        Me.TXTQCCOLOR.TabIndex = 11
        Me.TXTQCCOLOR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTQCSHIPPER
        '
        Me.TXTQCSHIPPER.BackColor = System.Drawing.Color.White
        Me.TXTQCSHIPPER.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTQCSHIPPER.Location = New System.Drawing.Point(557, 121)
        Me.TXTQCSHIPPER.MaxLength = 32776
        Me.TXTQCSHIPPER.Name = "TXTQCSHIPPER"
        Me.TXTQCSHIPPER.Size = New System.Drawing.Size(101, 23)
        Me.TXTQCSHIPPER.TabIndex = 16
        Me.TXTQCSHIPPER.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.BackColor = System.Drawing.Color.Transparent
        Me.Label41.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label41.Location = New System.Drawing.Point(294, 68)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(49, 15)
        Me.Label41.TabIndex = 899
        Me.Label41.Text = "Varnish"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.BackColor = System.Drawing.Color.Transparent
        Me.Label46.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label46.Location = New System.Drawing.Point(468, 125)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(86, 15)
        Me.Label46.TabIndex = 913
        Me.Label46.Text = "Shipper Status"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.BackColor = System.Drawing.Color.Transparent
        Me.Label42.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label42.Location = New System.Drawing.Point(485, 68)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(69, 15)
        Me.Label42.TabIndex = 901
        Me.Label42.Text = "Perforation"
        '
        'TXTQCPACKET
        '
        Me.TXTQCPACKET.BackColor = System.Drawing.Color.White
        Me.TXTQCPACKET.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTQCPACKET.Location = New System.Drawing.Point(346, 121)
        Me.TXTQCPACKET.MaxLength = 32776
        Me.TXTQCPACKET.Name = "TXTQCPACKET"
        Me.TXTQCPACKET.Size = New System.Drawing.Size(101, 23)
        Me.TXTQCPACKET.TabIndex = 10
        Me.TXTQCPACKET.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTQCPERFOR
        '
        Me.TXTQCPERFOR.BackColor = System.Drawing.Color.White
        Me.TXTQCPERFOR.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTQCPERFOR.Location = New System.Drawing.Point(557, 64)
        Me.TXTQCPERFOR.MaxLength = 32776
        Me.TXTQCPERFOR.Name = "TXTQCPERFOR"
        Me.TXTQCPERFOR.Size = New System.Drawing.Size(101, 23)
        Me.TXTQCPERFOR.TabIndex = 14
        Me.TXTQCPERFOR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.BackColor = System.Drawing.Color.Transparent
        Me.Label47.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label47.Location = New System.Drawing.Point(263, 125)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(80, 15)
        Me.Label47.TabIndex = 911
        Me.Label47.Text = "Packet Status"
        '
        'LBLDESIGN
        '
        Me.LBLDESIGN.BackColor = System.Drawing.Color.Transparent
        Me.LBLDESIGN.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLDESIGN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LBLDESIGN.Location = New System.Drawing.Point(480, 11)
        Me.LBLDESIGN.Name = "LBLDESIGN"
        Me.LBLDESIGN.Size = New System.Drawing.Size(75, 15)
        Me.LBLDESIGN.TabIndex = 903
        Me.LBLDESIGN.Text = "Design"
        Me.LBLDESIGN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTQCFINALAMT
        '
        Me.TXTQCFINALAMT.BackColor = System.Drawing.Color.White
        Me.TXTQCFINALAMT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTQCFINALAMT.Location = New System.Drawing.Point(345, 93)
        Me.TXTQCFINALAMT.MaxLength = 32776
        Me.TXTQCFINALAMT.Name = "TXTQCFINALAMT"
        Me.TXTQCFINALAMT.Size = New System.Drawing.Size(101, 23)
        Me.TXTQCFINALAMT.TabIndex = 9
        Me.TXTQCFINALAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTQCDESIGN
        '
        Me.TXTQCDESIGN.BackColor = System.Drawing.Color.White
        Me.TXTQCDESIGN.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTQCDESIGN.Location = New System.Drawing.Point(557, 7)
        Me.TXTQCDESIGN.MaxLength = 32776
        Me.TXTQCDESIGN.Name = "TXTQCDESIGN"
        Me.TXTQCDESIGN.Size = New System.Drawing.Size(101, 23)
        Me.TXTQCDESIGN.TabIndex = 12
        Me.TXTQCDESIGN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.BackColor = System.Drawing.Color.Transparent
        Me.Label48.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label48.Location = New System.Drawing.Point(258, 97)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(85, 15)
        Me.Label48.TabIndex = 909
        Me.Label48.Text = "Final Quantity"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.BackColor = System.Drawing.Color.Transparent
        Me.Label44.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label44.Location = New System.Drawing.Point(55, 97)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(92, 15)
        Me.Label44.TabIndex = 905
        Me.Label44.Text = "Open Size Label"
        '
        'TXTQCSTICKER
        '
        Me.TXTQCSTICKER.BackColor = System.Drawing.Color.White
        Me.TXTQCSTICKER.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTQCSTICKER.Location = New System.Drawing.Point(557, 93)
        Me.TXTQCSTICKER.MaxLength = 32776
        Me.TXTQCSTICKER.Name = "TXTQCSTICKER"
        Me.TXTQCSTICKER.Size = New System.Drawing.Size(101, 23)
        Me.TXTQCSTICKER.TabIndex = 15
        Me.TXTQCSTICKER.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTQCSIZE
        '
        Me.TXTQCSIZE.BackColor = System.Drawing.Color.White
        Me.TXTQCSIZE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTQCSIZE.Location = New System.Drawing.Point(149, 93)
        Me.TXTQCSIZE.MaxLength = 32776
        Me.TXTQCSIZE.Name = "TXTQCSIZE"
        Me.TXTQCSIZE.Size = New System.Drawing.Size(101, 23)
        Me.TXTQCSIZE.TabIndex = 3
        Me.TXTQCSIZE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.BackColor = System.Drawing.Color.Transparent
        Me.Label45.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label45.Location = New System.Drawing.Point(511, 97)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(43, 15)
        Me.Label45.TabIndex = 907
        Me.Label45.Text = "Sticker"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(420, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 15)
        Me.Label2.TabIndex = 94
        Me.Label2.Text = "P.O."
        '
        'lbllocked
        '
        Me.lbllocked.AutoSize = True
        Me.lbllocked.BackColor = System.Drawing.Color.Transparent
        Me.lbllocked.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllocked.ForeColor = System.Drawing.Color.Red
        Me.lbllocked.Location = New System.Drawing.Point(381, 521)
        Me.lbllocked.Name = "lbllocked"
        Me.lbllocked.Size = New System.Drawing.Size(57, 19)
        Me.lbllocked.TabIndex = 749
        Me.lbllocked.Text = "Locked"
        Me.lbllocked.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(409, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 15)
        Me.Label1.TabIndex = 92
        Me.Label1.Text = "Name"
        '
        'PBlock
        '
        Me.PBlock.BackColor = System.Drawing.Color.Transparent
        Me.PBlock.Image = CType(resources.GetObject("PBlock.Image"), System.Drawing.Image)
        Me.PBlock.Location = New System.Drawing.Point(380, 456)
        Me.PBlock.Name = "PBlock"
        Me.PBlock.Size = New System.Drawing.Size(60, 60)
        Me.PBlock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBlock.TabIndex = 750
        Me.PBlock.TabStop = False
        Me.PBlock.Visible = False
        '
        'chkdone
        '
        Me.chkdone.AutoSize = True
        Me.chkdone.BackColor = System.Drawing.Color.Transparent
        Me.chkdone.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdone.Location = New System.Drawing.Point(758, 29)
        Me.chkdone.Name = "chkdone"
        Me.chkdone.Size = New System.Drawing.Size(53, 19)
        Me.chkdone.TabIndex = 748
        Me.chkdone.Text = "done"
        Me.chkdone.UseVisualStyleBackColor = False
        Me.chkdone.Visible = False
        '
        'TXTSUBTOTAL
        '
        Me.TXTSUBTOTAL.BackColor = System.Drawing.Color.Linen
        Me.TXTSUBTOTAL.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSUBTOTAL.ForeColor = System.Drawing.Color.Black
        Me.TXTSUBTOTAL.Location = New System.Drawing.Point(907, 517)
        Me.TXTSUBTOTAL.Name = "TXTSUBTOTAL"
        Me.TXTSUBTOTAL.ReadOnly = True
        Me.TXTSUBTOTAL.Size = New System.Drawing.Size(90, 23)
        Me.TXTSUBTOTAL.TabIndex = 747
        Me.TXTSUBTOTAL.TabStop = False
        Me.TXTSUBTOTAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMBEXTRACHGSNAME
        '
        Me.CMBEXTRACHGSNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBEXTRACHGSNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBEXTRACHGSNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBEXTRACHGSNAME.ForeColor = System.Drawing.Color.Black
        Me.CMBEXTRACHGSNAME.FormattingEnabled = True
        Me.CMBEXTRACHGSNAME.Location = New System.Drawing.Point(807, 566)
        Me.CMBEXTRACHGSNAME.MaxDropDownItems = 14
        Me.CMBEXTRACHGSNAME.Name = "CMBEXTRACHGSNAME"
        Me.CMBEXTRACHGSNAME.Size = New System.Drawing.Size(78, 22)
        Me.CMBEXTRACHGSNAME.TabIndex = 13
        '
        'CMBEXTRAADDSUB
        '
        Me.CMBEXTRAADDSUB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBEXTRAADDSUB.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBEXTRAADDSUB.ForeColor = System.Drawing.Color.Black
        Me.CMBEXTRAADDSUB.FormattingEnabled = True
        Me.CMBEXTRAADDSUB.Items.AddRange(New Object() {"Add", "Sub."})
        Me.CMBEXTRAADDSUB.Location = New System.Drawing.Point(755, 566)
        Me.CMBEXTRAADDSUB.Name = "CMBEXTRAADDSUB"
        Me.CMBEXTRAADDSUB.Size = New System.Drawing.Size(47, 23)
        Me.CMBEXTRAADDSUB.TabIndex = 12
        '
        'TXTEXTRACHGS
        '
        Me.TXTEXTRACHGS.BackColor = System.Drawing.Color.White
        Me.TXTEXTRACHGS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTEXTRACHGS.ForeColor = System.Drawing.Color.Black
        Me.TXTEXTRACHGS.Location = New System.Drawing.Point(907, 566)
        Me.TXTEXTRACHGS.MaxLength = 10
        Me.TXTEXTRACHGS.Name = "TXTEXTRACHGS"
        Me.TXTEXTRACHGS.Size = New System.Drawing.Size(90, 23)
        Me.TXTEXTRACHGS.TabIndex = 14
        Me.TXTEXTRACHGS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMBOTHERCHGSNAME
        '
        Me.CMBOTHERCHGSNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBOTHERCHGSNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBOTHERCHGSNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBOTHERCHGSNAME.ForeColor = System.Drawing.Color.Black
        Me.CMBOTHERCHGSNAME.FormattingEnabled = True
        Me.CMBOTHERCHGSNAME.Location = New System.Drawing.Point(824, 465)
        Me.CMBOTHERCHGSNAME.MaxDropDownItems = 14
        Me.CMBOTHERCHGSNAME.Name = "CMBOTHERCHGSNAME"
        Me.CMBOTHERCHGSNAME.Size = New System.Drawing.Size(78, 22)
        Me.CMBOTHERCHGSNAME.TabIndex = 9
        '
        'CMBTAX
        '
        Me.CMBTAX.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBTAX.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBTAX.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBTAX.ForeColor = System.Drawing.Color.Black
        Me.CMBTAX.FormattingEnabled = True
        Me.CMBTAX.Location = New System.Drawing.Point(806, 542)
        Me.CMBTAX.MaxDropDownItems = 14
        Me.CMBTAX.Name = "CMBTAX"
        Me.CMBTAX.Size = New System.Drawing.Size(78, 23)
        Me.CMBTAX.TabIndex = 12
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(886, 544)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(16, 15)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "%"
        '
        'txttax
        '
        Me.txttax.BackColor = System.Drawing.Color.Linen
        Me.txttax.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttax.ForeColor = System.Drawing.Color.Black
        Me.txttax.Location = New System.Drawing.Point(907, 541)
        Me.txttax.Name = "txttax"
        Me.txttax.ReadOnly = True
        Me.txttax.Size = New System.Drawing.Size(90, 23)
        Me.txttax.TabIndex = 8
        Me.txttax.TabStop = False
        Me.txttax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTTRANSADD
        '
        Me.TXTTRANSADD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTTRANSADD.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTRANSADD.Location = New System.Drawing.Point(768, 28)
        Me.TXTTRANSADD.Name = "TXTTRANSADD"
        Me.TXTTRANSADD.Size = New System.Drawing.Size(33, 21)
        Me.TXTTRANSADD.TabIndex = 737
        Me.TXTTRANSADD.TabStop = False
        Me.TXTTRANSADD.Visible = False
        '
        'CMBCODE
        '
        Me.CMBCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCODE.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCODE.FormattingEnabled = True
        Me.CMBCODE.Location = New System.Drawing.Point(762, 28)
        Me.CMBCODE.MaxDropDownItems = 14
        Me.CMBCODE.Name = "CMBCODE"
        Me.CMBCODE.Size = New System.Drawing.Size(44, 21)
        Me.CMBCODE.TabIndex = 736
        Me.CMBCODE.Visible = False
        '
        'CMDSELECTCHALLAN
        '
        Me.CMDSELECTCHALLAN.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDSELECTCHALLAN.Location = New System.Drawing.Point(505, 543)
        Me.CMDSELECTCHALLAN.Name = "CMDSELECTCHALLAN"
        Me.CMDSELECTCHALLAN.Size = New System.Drawing.Size(108, 28)
        Me.CMDSELECTCHALLAN.TabIndex = 18
        Me.CMDSELECTCHALLAN.Text = "S&elect Challan"
        Me.CMDSELECTCHALLAN.UseVisualStyleBackColor = True
        '
        'CMDDELETE
        '
        Me.CMDDELETE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDDELETE.Location = New System.Drawing.Point(562, 576)
        Me.CMDDELETE.Name = "CMDDELETE"
        Me.CMDDELETE.Size = New System.Drawing.Size(80, 28)
        Me.CMDDELETE.TabIndex = 21
        Me.CMDDELETE.Text = "&Delete"
        Me.CMDDELETE.UseVisualStyleBackColor = True
        '
        'TXTJOBNO
        '
        Me.TXTJOBNO.BackColor = System.Drawing.SystemColors.Window
        Me.TXTJOBNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTJOBNO.Location = New System.Drawing.Point(764, 27)
        Me.TXTJOBNO.Name = "TXTJOBNO"
        Me.TXTJOBNO.ReadOnly = True
        Me.TXTJOBNO.Size = New System.Drawing.Size(41, 23)
        Me.TXTJOBNO.TabIndex = 548
        Me.TXTJOBNO.Visible = False
        '
        'TXTORDERSRNO
        '
        Me.TXTORDERSRNO.BackColor = System.Drawing.SystemColors.Window
        Me.TXTORDERSRNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTORDERSRNO.Location = New System.Drawing.Point(764, 27)
        Me.TXTORDERSRNO.Name = "TXTORDERSRNO"
        Me.TXTORDERSRNO.ReadOnly = True
        Me.TXTORDERSRNO.Size = New System.Drawing.Size(41, 23)
        Me.TXTORDERSRNO.TabIndex = 546
        Me.TXTORDERSRNO.Visible = False
        '
        'txtorderno
        '
        Me.txtorderno.BackColor = System.Drawing.SystemColors.Window
        Me.txtorderno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtorderno.Location = New System.Drawing.Point(756, 27)
        Me.txtorderno.Name = "txtorderno"
        Me.txtorderno.ReadOnly = True
        Me.txtorderno.Size = New System.Drawing.Size(56, 23)
        Me.txtorderno.TabIndex = 544
        Me.txtorderno.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(818, 85)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 15)
        Me.Label5.TabIndex = 542
        Me.Label5.Text = "Invoice No."
        '
        'TXTINVOICENO
        '
        Me.TXTINVOICENO.BackColor = System.Drawing.Color.Linen
        Me.TXTINVOICENO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTINVOICENO.Location = New System.Drawing.Point(889, 81)
        Me.TXTINVOICENO.Name = "TXTINVOICENO"
        Me.TXTINVOICENO.ReadOnly = True
        Me.TXTINVOICENO.Size = New System.Drawing.Size(90, 23)
        Me.TXTINVOICENO.TabIndex = 1
        Me.TXTINVOICENO.TabStop = False
        Me.TXTINVOICENO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(854, 113)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 15)
        Me.Label6.TabIndex = 541
        Me.Label6.Text = "Date"
        '
        'invoicedate
        '
        Me.invoicedate.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.invoicedate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.invoicedate.Location = New System.Drawing.Point(889, 109)
        Me.invoicedate.Name = "invoicedate"
        Me.invoicedate.Size = New System.Drawing.Size(90, 23)
        Me.invoicedate.TabIndex = 1
        '
        'cmbregister
        '
        Me.cmbregister.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbregister.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbregister.BackColor = System.Drawing.Color.LemonChiffon
        Me.cmbregister.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbregister.FormattingEnabled = True
        Me.cmbregister.Items.AddRange(New Object() {""})
        Me.cmbregister.Location = New System.Drawing.Point(889, 53)
        Me.cmbregister.Name = "cmbregister"
        Me.cmbregister.Size = New System.Drawing.Size(264, 23)
        Me.cmbregister.TabIndex = 0
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(835, 57)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(51, 15)
        Me.Label23.TabIndex = 543
        Me.Label23.Text = "Register"
        '
        'CHKDISPUTE
        '
        Me.CHKDISPUTE.AutoSize = True
        Me.CHKDISPUTE.BackColor = System.Drawing.Color.Transparent
        Me.CHKDISPUTE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKDISPUTE.ForeColor = System.Drawing.Color.Black
        Me.CHKDISPUTE.Location = New System.Drawing.Point(142, 610)
        Me.CHKDISPUTE.Name = "CHKDISPUTE"
        Me.CHKDISPUTE.Size = New System.Drawing.Size(126, 19)
        Me.CHKDISPUTE.TabIndex = 17
        Me.CHKDISPUTE.Text = "Bill Under Dispute"
        Me.CHKDISPUTE.UseVisualStyleBackColor = False
        '
        'CHKBILLCHECKED
        '
        Me.CHKBILLCHECKED.AutoSize = True
        Me.CHKBILLCHECKED.BackColor = System.Drawing.Color.Transparent
        Me.CHKBILLCHECKED.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKBILLCHECKED.ForeColor = System.Drawing.Color.Black
        Me.CHKBILLCHECKED.Location = New System.Drawing.Point(31, 610)
        Me.CHKBILLCHECKED.Name = "CHKBILLCHECKED"
        Me.CHKBILLCHECKED.Size = New System.Drawing.Size(93, 19)
        Me.CHKBILLCHECKED.TabIndex = 16
        Me.CHKBILLCHECKED.Text = "Bill Checked"
        Me.CHKBILLCHECKED.UseVisualStyleBackColor = False
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.txtremarks)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(27, 511)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(336, 86)
        Me.GroupBox5.TabIndex = 15
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Remarks"
        '
        'txtremarks
        '
        Me.txtremarks.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtremarks.ForeColor = System.Drawing.Color.DimGray
        Me.txtremarks.Location = New System.Drawing.Point(11, 19)
        Me.txtremarks.Multiline = True
        Me.txtremarks.Name = "txtremarks"
        Me.txtremarks.Size = New System.Drawing.Size(315, 56)
        Me.txtremarks.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(845, 521)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(57, 15)
        Me.Label9.TabIndex = 515
        Me.Label9.Text = "Sub Total"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(816, 494)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(86, 15)
        Me.Label19.TabIndex = 7
        Me.Label19.Text = "Pakaging Chgs"
        '
        'txtpakagingchgs
        '
        Me.txtpakagingchgs.BackColor = System.Drawing.Color.White
        Me.txtpakagingchgs.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpakagingchgs.ForeColor = System.Drawing.Color.Black
        Me.txtpakagingchgs.Location = New System.Drawing.Point(907, 490)
        Me.txtpakagingchgs.MaxLength = 5
        Me.txtpakagingchgs.Name = "txtpakagingchgs"
        Me.txtpakagingchgs.Size = New System.Drawing.Size(90, 23)
        Me.txtpakagingchgs.TabIndex = 11
        Me.txtpakagingchgs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbaddsub
        '
        Me.cmbaddsub.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbaddsub.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbaddsub.ForeColor = System.Drawing.Color.Black
        Me.cmbaddsub.FormattingEnabled = True
        Me.cmbaddsub.Items.AddRange(New Object() {"Add", "Sub."})
        Me.cmbaddsub.Location = New System.Drawing.Point(774, 465)
        Me.cmbaddsub.Name = "cmbaddsub"
        Me.cmbaddsub.Size = New System.Drawing.Size(47, 22)
        Me.cmbaddsub.TabIndex = 8
        '
        'cmdok
        '
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.Location = New System.Drawing.Point(391, 576)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 19
        Me.cmdok.Text = "&Save"
        Me.cmdok.UseVisualStyleBackColor = True
        '
        'TXTOTHERCHGS
        '
        Me.TXTOTHERCHGS.BackColor = System.Drawing.Color.White
        Me.TXTOTHERCHGS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTOTHERCHGS.ForeColor = System.Drawing.Color.Black
        Me.TXTOTHERCHGS.Location = New System.Drawing.Point(907, 465)
        Me.TXTOTHERCHGS.MaxLength = 5
        Me.TXTOTHERCHGS.Name = "TXTOTHERCHGS"
        Me.TXTOTHERCHGS.Size = New System.Drawing.Size(90, 23)
        Me.TXTOTHERCHGS.TabIndex = 10
        Me.TXTOTHERCHGS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdclear
        '
        Me.cmdclear.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdclear.Location = New System.Drawing.Point(476, 576)
        Me.cmdclear.Name = "cmdclear"
        Me.cmdclear.Size = New System.Drawing.Size(80, 28)
        Me.cmdclear.TabIndex = 20
        Me.cmdclear.Text = "&Clear"
        Me.cmdclear.UseVisualStyleBackColor = True
        '
        'txtreturn
        '
        Me.txtreturn.BackColor = System.Drawing.Color.White
        Me.txtreturn.Enabled = False
        Me.txtreturn.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtreturn.ForeColor = System.Drawing.Color.Black
        Me.txtreturn.Location = New System.Drawing.Point(655, 477)
        Me.txtreturn.Name = "txtreturn"
        Me.txtreturn.ReadOnly = True
        Me.txtreturn.Size = New System.Drawing.Size(79, 23)
        Me.txtreturn.TabIndex = 5
        Me.txtreturn.TabStop = False
        Me.txtreturn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtreturn.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(610, 478)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(43, 15)
        Me.Label17.TabIndex = 513
        Me.Label17.Text = "Return"
        Me.Label17.Visible = False
        '
        'cmdexit
        '
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.Location = New System.Drawing.Point(648, 576)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 22
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(840, 599)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(62, 15)
        Me.Label16.TabIndex = 532
        Me.Label16.Text = "Round Off"
        '
        'txtroundoff
        '
        Me.txtroundoff.BackColor = System.Drawing.Color.Linen
        Me.txtroundoff.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtroundoff.ForeColor = System.Drawing.Color.Black
        Me.txtroundoff.Location = New System.Drawing.Point(907, 595)
        Me.txtroundoff.MaxLength = 5
        Me.txtroundoff.Name = "txtroundoff"
        Me.txtroundoff.ReadOnly = True
        Me.txtroundoff.Size = New System.Drawing.Size(90, 23)
        Me.txtroundoff.TabIndex = 4
        Me.txtroundoff.TabStop = False
        Me.txtroundoff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblgtotal
        '
        Me.lblgtotal.AutoSize = True
        Me.lblgtotal.BackColor = System.Drawing.Color.Transparent
        Me.lblgtotal.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblgtotal.ForeColor = System.Drawing.Color.Black
        Me.lblgtotal.Location = New System.Drawing.Point(831, 625)
        Me.lblgtotal.Name = "lblgtotal"
        Me.lblgtotal.Size = New System.Drawing.Size(71, 15)
        Me.lblgtotal.TabIndex = 519
        Me.lblgtotal.Text = "Grand Total"
        '
        'GroupBox8
        '
        Me.GroupBox8.BackColor = System.Drawing.Color.Black
        Me.GroupBox8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox8.ForeColor = System.Drawing.Color.Black
        Me.GroupBox8.Location = New System.Drawing.Point(771, 515)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(240, 1)
        Me.GroupBox8.TabIndex = 523
        Me.GroupBox8.TabStop = False
        '
        'txtgrandtotal
        '
        Me.txtgrandtotal.BackColor = System.Drawing.Color.Linen
        Me.txtgrandtotal.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtgrandtotal.ForeColor = System.Drawing.Color.Black
        Me.txtgrandtotal.Location = New System.Drawing.Point(907, 621)
        Me.txtgrandtotal.Name = "txtgrandtotal"
        Me.txtgrandtotal.ReadOnly = True
        Me.txtgrandtotal.Size = New System.Drawing.Size(90, 23)
        Me.txtgrandtotal.TabIndex = 520
        Me.txtgrandtotal.TabStop = False
        Me.txtgrandtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(806, 445)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(96, 15)
        Me.Label15.TabIndex = 529
        Me.Label15.Text = "Processing Chgs"
        '
        'GroupBox7
        '
        Me.GroupBox7.BackColor = System.Drawing.Color.Black
        Me.GroupBox7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.ForeColor = System.Drawing.Color.Black
        Me.GroupBox7.Location = New System.Drawing.Point(771, 592)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(240, 1)
        Me.GroupBox7.TabIndex = 521
        Me.GroupBox7.TabStop = False
        '
        'txtprocessing
        '
        Me.txtprocessing.BackColor = System.Drawing.Color.White
        Me.txtprocessing.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtprocessing.ForeColor = System.Drawing.Color.Black
        Me.txtprocessing.Location = New System.Drawing.Point(907, 441)
        Me.txtprocessing.Name = "txtprocessing"
        Me.txtprocessing.Size = New System.Drawing.Size(90, 23)
        Me.txtprocessing.TabIndex = 7
        Me.txtprocessing.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Black
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.Color.Black
        Me.GroupBox4.Location = New System.Drawing.Point(752, 444)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1, 203)
        Me.GroupBox4.TabIndex = 524
        Me.GroupBox4.TabStop = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(31, 450)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(57, 15)
        Me.Label14.TabIndex = 511
        Me.Label14.Text = "In Words"
        '
        'txtinwords
        '
        Me.txtinwords.BackColor = System.Drawing.Color.Linen
        Me.txtinwords.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtinwords.ForeColor = System.Drawing.Color.Black
        Me.txtinwords.Location = New System.Drawing.Point(88, 446)
        Me.txtinwords.Multiline = True
        Me.txtinwords.Name = "txtinwords"
        Me.txtinwords.ReadOnly = True
        Me.txtinwords.Size = New System.Drawing.Size(273, 59)
        Me.txtinwords.TabIndex = 512
        Me.txtinwords.TabStop = False
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.Black
        Me.GroupBox6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.ForeColor = System.Drawing.Color.Black
        Me.GroupBox6.Location = New System.Drawing.Point(771, 619)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(240, 1)
        Me.GroupBox6.TabIndex = 522
        Me.GroupBox6.TabStop = False
        '
        'tstxtbillno
        '
        Me.tstxtbillno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tstxtbillno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstxtbillno.Location = New System.Drawing.Point(335, 2)
        Me.tstxtbillno.Name = "tstxtbillno"
        Me.tstxtbillno.Size = New System.Drawing.Size(68, 22)
        Me.tstxtbillno.TabIndex = 23
        Me.tstxtbillno.TabStop = False
        Me.tstxtbillno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.White
        Me.Label21.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(545, 5)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(19, 15)
        Me.Label21.TabIndex = 493
        Me.Label21.Text = "To"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.White
        Me.Label20.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(429, 5)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(65, 15)
        Me.Label20.TabIndex = 492
        Me.Label20.Text = "Print From"
        '
        'txtprintto
        '
        Me.txtprintto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtprintto.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtprintto.Location = New System.Drawing.Point(567, 1)
        Me.txtprintto.Name = "txtprintto"
        Me.txtprintto.Size = New System.Drawing.Size(45, 22)
        Me.txtprintto.TabIndex = 25
        Me.txtprintto.TabStop = False
        Me.txtprintto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtprintfrom
        '
        Me.txtprintfrom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtprintfrom.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtprintfrom.Location = New System.Drawing.Point(497, 1)
        Me.txtprintfrom.Name = "txtprintfrom"
        Me.txtprintfrom.Size = New System.Drawing.Size(45, 22)
        Me.txtprintfrom.TabIndex = 23
        Me.txtprintfrom.TabStop = False
        Me.txtprintfrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripButton, Me.SaveToolStripButton, Me.PrintToolStripButton, Me.ToolStripSeparator3, Me.tooldelete, Me.ToolStripSeparator4, Me.TOOLEINV, Me.ToolStripSeparator2, Me.TOOLEWB, Me.toolStripSeparator, Me.toolprevious, Me.toolnext, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1268, 25)
        Me.ToolStrip1.TabIndex = 24
        Me.ToolStrip1.Text = "v"
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
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
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
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'TOOLEINV
        '
        Me.TOOLEINV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLEINV.Image = Global.PrintPro.My.Resources.Resources.EINVOICE_LOGO
        Me.TOOLEINV.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLEINV.Name = "TOOLEINV"
        Me.TOOLEINV.Size = New System.Drawing.Size(23, 22)
        Me.TOOLEINV.Text = "Generate E-Invoice"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'TOOLEWB
        '
        Me.TOOLEWB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLEWB.Image = Global.PrintPro.My.Resources.Resources.CHALLAN
        Me.TOOLEWB.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLEWB.Name = "TOOLEWB"
        Me.TOOLEWB.Size = New System.Drawing.Size(23, 22)
        Me.TOOLEWB.Text = "Generate EWB"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'toolprevious
        '
        Me.toolprevious.Image = Global.PrintPro.My.Resources.Resources.POINT02
        Me.toolprevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolprevious.Name = "toolprevious"
        Me.toolprevious.Size = New System.Drawing.Size(72, 22)
        Me.toolprevious.Text = "Previous"
        '
        'toolnext
        '
        Me.toolnext.Image = Global.PrintPro.My.Resources.Resources.POINT04
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
        'Ep
        '
        Me.Ep.BlinkRate = 0
        Me.Ep.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.Ep.ContainerControl = Me
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'txtinvoice
        '
        Me.txtinvoice.BackColor = System.Drawing.Color.Linen
        Me.txtinvoice.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtinvoice.Location = New System.Drawing.Point(889, 81)
        Me.txtinvoice.Name = "txtinvoice"
        Me.txtinvoice.ReadOnly = True
        Me.txtinvoice.Size = New System.Drawing.Size(90, 23)
        Me.txtinvoice.TabIndex = 1
        Me.txtinvoice.TabStop = False
        Me.txtinvoice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtdespatched
        '
        Me.txtdespatched.BackColor = System.Drawing.Color.Linen
        Me.txtdespatched.ForeColor = System.Drawing.Color.DimGray
        Me.txtdespatched.Location = New System.Drawing.Point(450, 137)
        Me.txtdespatched.Name = "txtdespatched"
        Me.txtdespatched.ReadOnly = True
        Me.txtdespatched.Size = New System.Drawing.Size(222, 20)
        Me.txtdespatched.TabIndex = 106
        Me.txtdespatched.TabStop = False
        '
        'Invoice
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1268, 659)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.KeyPreview = True
        Me.Name = "Invoice"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Invoice"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.PBCN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBRECD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.gridinvoice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TBADD.ResumeLayout(False)
        Me.TBADD.PerformLayout()
        CType(Me.PBQRCODE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.PBSOFTCOPY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridupload, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PBlock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.Ep, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents OpenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents tooldelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolprevious As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolnext As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tstxtbillno As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtprintto As System.Windows.Forms.TextBox
    Friend WithEvents txtprintfrom As System.Windows.Forms.TextBox
    Friend WithEvents CHKDISPUTE As System.Windows.Forms.CheckBox
    Friend WithEvents CHKBILLCHECKED As System.Windows.Forms.CheckBox
    Friend WithEvents TXTTRANSNAME As System.Windows.Forms.TextBox
    Friend WithEvents txtchallandate As System.Windows.Forms.TextBox
    Friend WithEvents txtpodate As System.Windows.Forms.TextBox
    Friend WithEvents txtname As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents challandate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtchallanno As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtpono As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CMBNAME As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtdeladd As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents gridinvoice As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtremarks As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtpakagingchgs As System.Windows.Forms.TextBox
    Friend WithEvents cmbaddsub As System.Windows.Forms.ComboBox
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents TXTOTHERCHGS As System.Windows.Forms.TextBox
    Friend WithEvents cmdclear As System.Windows.Forms.Button
    Friend WithEvents txtreturn As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtroundoff As System.Windows.Forms.TextBox
    Friend WithEvents lblgtotal As System.Windows.Forms.Label
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents txtgrandtotal As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents txtprocessing As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtinwords As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TXTINVOICENO As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents invoicedate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbregister As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TXTJOBNO As System.Windows.Forms.TextBox
    Friend WithEvents TXTORDERSRNO As System.Windows.Forms.TextBox
    Friend WithEvents txtorderno As System.Windows.Forms.TextBox
    Friend WithEvents Ep As System.Windows.Forms.ErrorProvider
    Friend WithEvents CMDDELETE As System.Windows.Forms.Button
    Friend WithEvents CMDSELECTCHALLAN As System.Windows.Forms.Button
    Friend WithEvents TXTTRANSADD As System.Windows.Forms.TextBox
    Friend WithEvents CMBCODE As System.Windows.Forms.ComboBox
    Friend WithEvents CMBTAX As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txttax As System.Windows.Forms.TextBox
    Friend WithEvents CMBEXTRACHGSNAME As System.Windows.Forms.ComboBox
    Friend WithEvents CMBEXTRAADDSUB As System.Windows.Forms.ComboBox
    Friend WithEvents TXTEXTRACHGS As System.Windows.Forms.TextBox
    Friend WithEvents CMBOTHERCHGSNAME As System.Windows.Forms.ComboBox
    Friend WithEvents lbltotalamt As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TXTSUBTOTAL As System.Windows.Forms.TextBox
    Friend WithEvents chkdone As System.Windows.Forms.CheckBox
    Friend WithEvents lbllocked As System.Windows.Forms.Label
    Friend WithEvents PBlock As System.Windows.Forms.PictureBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
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
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TXTAMTREC As System.Windows.Forms.TextBox
    Friend WithEvents TXTBAL As System.Windows.Forms.TextBox
    Friend WithEvents TXTEXTRAAMT As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents CHKFORMBOX As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents cmdshowdetails As System.Windows.Forms.Button
    Friend WithEvents PBCN As System.Windows.Forms.PictureBox
    Friend WithEvents PBRECD As System.Windows.Forms.PictureBox
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DueDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents TXTCRDAYS As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TXTCOPIES As System.Windows.Forms.TextBox
    Friend WithEvents LBLTOTALIGSTAMT As System.Windows.Forms.Label
    Friend WithEvents LBLTOTALSGSTAMT As System.Windows.Forms.Label
    Friend WithEvents LBLTOTALCGSTAMT As System.Windows.Forms.Label
    Friend WithEvents LBLTOTALTAXABLEAMT As System.Windows.Forms.Label
    Friend WithEvents LBLTOTALOTHERAMT As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents TXTGSTIN As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents TXTSTATECODE As System.Windows.Forms.TextBox
    Friend WithEvents LBLTOTALGRIDAMT As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents LBLTOTALQTY As System.Windows.Forms.Label
    Friend WithEvents TXTMULTICHALLANNO As System.Windows.Forms.TextBox
    Friend WithEvents CHKMANUAL As System.Windows.Forms.CheckBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents TXTEWAYBILLNO As System.Windows.Forms.TextBox
    Friend WithEvents TXTMULTIPONO As System.Windows.Forms.TextBox
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Label52 As Label
    Friend WithEvents TXTQCREMARKS As TextBox
    Friend WithEvents Label50 As Label
    Friend WithEvents TXTQCLABEL As TextBox
    Friend WithEvents LABEL555 As Label
    Friend WithEvents TXTQCSHIPPER As TextBox
    Friend WithEvents Label46 As Label
    Friend WithEvents TXTQCPACKET As TextBox
    Friend WithEvents Label47 As Label
    Friend WithEvents TXTQCFINALAMT As TextBox
    Friend WithEvents Label48 As Label
    Friend WithEvents TXTQCSTICKER As TextBox
    Friend WithEvents Label45 As Label
    Friend WithEvents TXTQCSIZE As TextBox
    Friend WithEvents Label44 As Label
    Friend WithEvents TXTQCDESIGN As TextBox
    Friend WithEvents LBLDESIGN As Label
    Friend WithEvents TXTQCPERFOR As TextBox
    Friend WithEvents Label42 As Label
    Friend WithEvents TXTQCVARNISH As TextBox
    Friend WithEvents Label41 As Label
    Friend WithEvents TXTQCCOLOR As TextBox
    Friend WithEvents Label40 As Label
    Friend WithEvents Label39 As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents TXTQCUPS As TextBox
    Friend WithEvents Label34 As Label
    Friend WithEvents TXTQCPHARMA As TextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents TXTQCGRAIN As TextBox
    Friend WithEvents LBLGRAIN As Label
    Friend WithEvents TXTQCGSM As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents TXTQCPAPER As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents Label53 As Label
    Friend WithEvents TXTQCVISUAL As TextBox
    Friend WithEvents Label55 As Label
    Friend WithEvents TXTQCHEAD As TextBox
    Friend WithEvents Label54 As Label
    Friend WithEvents QCDATE As DateTimePicker
    Friend WithEvents TXTQCBATCH As TextBox
    Friend WithEvents TXTQCADHESIVE As TextBox
    Friend WithEvents TXTQCTEXT As TextBox
    Friend WithEvents Label49 As Label
    Friend WithEvents TXTINKDETAILS As TextBox
    Friend WithEvents Label51 As Label
    Friend WithEvents LBLPLACEOFSUPPLY As Label
    Friend WithEvents cmbstate As ComboBox
    Friend WithEvents CHKPACKET As CheckBox
    Friend WithEvents CHKTCS As CheckBox
    Friend WithEvents TXTTCSPER As TextBox
    Friend WithEvents TXTTCSAMT As TextBox
    Friend WithEvents TOOLEWB As ToolStripButton
    Friend WithEvents TBADD As TabPage
    Friend WithEvents CMBTOCITY As ComboBox
    Friend WithEvents Label56 As Label
    Friend WithEvents Label57 As Label
    Friend WithEvents TXTLRNO As TextBox
    Friend WithEvents Label58 As Label
    Friend WithEvents CMBFROMCITY As ComboBox
    Friend WithEvents Label60 As Label
    Friend WithEvents LRDATE As MaskedTextBox
    Friend WithEvents txtinvoice As TextBox
    Friend WithEvents txtdespatched As TextBox
    Friend WithEvents Label59 As Label
    Friend WithEvents TXTVEHICLENO As TextBox
    Friend WithEvents TXTNEWIMGPATH As TextBox
    Friend WithEvents TXTFILENAME As TextBox
    Friend WithEvents CMDGETQRCODE As Button
    Friend WithEvents CMDUPLOADIRN As Button
    Friend WithEvents PBQRCODE As PictureBox
    Friend WithEvents TXTIRNNO As TextBox
    Friend WithEvents Label61 As Label
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents TOOLEINV As ToolStripButton
    Friend WithEvents CMBHSNCODE As ComboBox
    Friend WithEvents Label62 As Label
    Friend WithEvents ACKDATE As DateTimePicker
    Friend WithEvents Label63 As Label
    Friend WithEvents TXTACKNO As TextBox
    Friend WithEvents Label64 As Label
    Friend WithEvents CHKEXPORTGST As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GITEMCODE As DataGridViewTextBoxColumn
    Friend WithEvents GITEMNAME As DataGridViewTextBoxColumn
    Friend WithEvents GHSNCODE As DataGridViewTextBoxColumn
    Friend WithEvents GMATERIALCODE As DataGridViewTextBoxColumn
    Friend WithEvents GQTY As DataGridViewTextBoxColumn
    Friend WithEvents GBATCHNO As DataGridViewTextBoxColumn
    Friend WithEvents GRATE As DataGridViewTextBoxColumn
    Friend WithEvents GAMOUNT As DataGridViewTextBoxColumn
    Friend WithEvents GOTHERAMT As DataGridViewTextBoxColumn
    Friend WithEvents GTAXABLEAMT As DataGridViewTextBoxColumn
    Friend WithEvents GCGSTPER As DataGridViewTextBoxColumn
    Friend WithEvents GCGSTAMT As DataGridViewTextBoxColumn
    Friend WithEvents GSGSTPER As DataGridViewTextBoxColumn
    Friend WithEvents GSGSTAMT As DataGridViewTextBoxColumn
    Friend WithEvents GIGSTPER As DataGridViewTextBoxColumn
    Friend WithEvents GIGSTAMT As DataGridViewTextBoxColumn
    Friend WithEvents GGRIDTOTAL As DataGridViewTextBoxColumn
    Friend WithEvents GGRIDCHALLANNO As DataGridViewTextBoxColumn
End Class
