<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OpeningStock
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TXTSRNO = New System.Windows.Forms.TextBox()
        Me.CMBiTEMNAME = New System.Windows.Forms.ComboBox()
        Me.CMBSHELF = New System.Windows.Forms.ComboBox()
        Me.CMBGODOWN = New System.Windows.Forms.ComboBox()
        Me.TXTSIZE = New System.Windows.Forms.TextBox()
        Me.TXTWT = New System.Windows.Forms.TextBox()
        Me.TXTPPRSRNO = New System.Windows.Forms.TextBox()
        Me.TXTBATCHNO = New System.Windows.Forms.TextBox()
        Me.CMBUNIT = New System.Windows.Forms.ComboBox()
        Me.TXTQTY = New System.Windows.Forms.TextBox()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.CMBITEMCODE = New System.Windows.Forms.ComboBox()
        Me.Ep = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TXTNO = New System.Windows.Forms.TextBox()
        Me.GRIDSTOCK = New System.Windows.Forms.DataGridView()
        Me.CMBPARTYNAME = New System.Windows.Forms.ComboBox()
        Me.CMBACCCODE = New System.Windows.Forms.ComboBox()
        Me.TXTADD = New System.Windows.Forms.TextBox()
        Me.OPENINGDATE = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CMBTYPE = New System.Windows.Forms.ComboBox()
        Me.TXTOUTQTY = New System.Windows.Forms.TextBox()
        Me.TXTSHEETSPERREAM = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TBITEMDTLS = New System.Windows.Forms.TabPage()
        Me.TXTAMOUNT = New System.Windows.Forms.TextBox()
        Me.TXTRATE = New System.Windows.Forms.TextBox()
        Me.gsrno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GPARTYNAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GGODOWM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GSHELF = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GITEMNAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GSIZE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GWT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GPPRSRNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GBATCHNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gUNIT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GTYPE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GOUTQTY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GRATE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GAMOUNT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.Ep, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDSTOCK, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TBITEMDTLS.SuspendLayout()
        Me.SuspendLayout()
        '
        'TXTSRNO
        '
        Me.TXTSRNO.BackColor = System.Drawing.Color.Linen
        Me.TXTSRNO.Location = New System.Drawing.Point(7, 6)
        Me.TXTSRNO.Name = "TXTSRNO"
        Me.TXTSRNO.ReadOnly = True
        Me.TXTSRNO.Size = New System.Drawing.Size(40, 23)
        Me.TXTSRNO.TabIndex = 0
        '
        'CMBiTEMNAME
        '
        Me.CMBiTEMNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBiTEMNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBiTEMNAME.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBiTEMNAME.FormattingEnabled = True
        Me.CMBiTEMNAME.Location = New System.Drawing.Point(447, 6)
        Me.CMBiTEMNAME.Name = "CMBiTEMNAME"
        Me.CMBiTEMNAME.Size = New System.Drawing.Size(160, 23)
        Me.CMBiTEMNAME.TabIndex = 4
        '
        'CMBSHELF
        '
        Me.CMBSHELF.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBSHELF.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBSHELF.BackColor = System.Drawing.Color.White
        Me.CMBSHELF.FormattingEnabled = True
        Me.CMBSHELF.Location = New System.Drawing.Point(337, 6)
        Me.CMBSHELF.Name = "CMBSHELF"
        Me.CMBSHELF.Size = New System.Drawing.Size(110, 23)
        Me.CMBSHELF.TabIndex = 3
        '
        'CMBGODOWN
        '
        Me.CMBGODOWN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBGODOWN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBGODOWN.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBGODOWN.FormattingEnabled = True
        Me.CMBGODOWN.Location = New System.Drawing.Point(227, 6)
        Me.CMBGODOWN.Name = "CMBGODOWN"
        Me.CMBGODOWN.Size = New System.Drawing.Size(110, 23)
        Me.CMBGODOWN.TabIndex = 2
        '
        'TXTSIZE
        '
        Me.TXTSIZE.Location = New System.Drawing.Point(607, 6)
        Me.TXTSIZE.MaxLength = 20
        Me.TXTSIZE.Name = "TXTSIZE"
        Me.TXTSIZE.Size = New System.Drawing.Size(80, 23)
        Me.TXTSIZE.TabIndex = 5
        '
        'TXTWT
        '
        Me.TXTWT.Location = New System.Drawing.Point(687, 6)
        Me.TXTWT.MaxLength = 20
        Me.TXTWT.Name = "TXTWT"
        Me.TXTWT.Size = New System.Drawing.Size(80, 23)
        Me.TXTWT.TabIndex = 6
        '
        'TXTPPRSRNO
        '
        Me.TXTPPRSRNO.Location = New System.Drawing.Point(767, 6)
        Me.TXTPPRSRNO.MaxLength = 50
        Me.TXTPPRSRNO.Name = "TXTPPRSRNO"
        Me.TXTPPRSRNO.Size = New System.Drawing.Size(80, 23)
        Me.TXTPPRSRNO.TabIndex = 7
        '
        'TXTBATCHNO
        '
        Me.TXTBATCHNO.Location = New System.Drawing.Point(847, 6)
        Me.TXTBATCHNO.MaxLength = 50
        Me.TXTBATCHNO.Name = "TXTBATCHNO"
        Me.TXTBATCHNO.Size = New System.Drawing.Size(80, 23)
        Me.TXTBATCHNO.TabIndex = 8
        '
        'CMBUNIT
        '
        Me.CMBUNIT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBUNIT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBUNIT.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBUNIT.FormattingEnabled = True
        Me.CMBUNIT.Location = New System.Drawing.Point(927, 6)
        Me.CMBUNIT.Name = "CMBUNIT"
        Me.CMBUNIT.Size = New System.Drawing.Size(80, 23)
        Me.CMBUNIT.TabIndex = 9
        '
        'TXTQTY
        '
        Me.TXTQTY.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTQTY.Location = New System.Drawing.Point(1007, 6)
        Me.TXTQTY.MaxLength = 20
        Me.TXTQTY.Name = "TXTQTY"
        Me.TXTQTY.Size = New System.Drawing.Size(100, 23)
        Me.TXTQTY.TabIndex = 10
        '
        'cmdexit
        '
        Me.cmdexit.Location = New System.Drawing.Point(575, 542)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 12
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = True
        '
        'CMBITEMCODE
        '
        Me.CMBITEMCODE.FormattingEnabled = True
        Me.CMBITEMCODE.Location = New System.Drawing.Point(485, 12)
        Me.CMBITEMCODE.Name = "CMBITEMCODE"
        Me.CMBITEMCODE.Size = New System.Drawing.Size(28, 23)
        Me.CMBITEMCODE.TabIndex = 35
        Me.CMBITEMCODE.Visible = False
        '
        'Ep
        '
        Me.Ep.BlinkRate = 0
        Me.Ep.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.Ep.ContainerControl = Me
        '
        'TXTNO
        '
        Me.TXTNO.BackColor = System.Drawing.Color.White
        Me.TXTNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNO.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTNO.Location = New System.Drawing.Point(449, 12)
        Me.TXTNO.Name = "TXTNO"
        Me.TXTNO.ReadOnly = True
        Me.TXTNO.Size = New System.Drawing.Size(30, 23)
        Me.TXTNO.TabIndex = 716
        Me.TXTNO.Text = " "
        Me.TXTNO.Visible = False
        '
        'GRIDSTOCK
        '
        Me.GRIDSTOCK.AllowUserToAddRows = False
        Me.GRIDSTOCK.AllowUserToDeleteRows = False
        Me.GRIDSTOCK.AllowUserToResizeColumns = False
        Me.GRIDSTOCK.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDSTOCK.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GRIDSTOCK.BackgroundColor = System.Drawing.Color.White
        Me.GRIDSTOCK.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDSTOCK.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.GRIDSTOCK.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GRIDSTOCK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDSTOCK.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gsrno, Me.GNO, Me.GPARTYNAME, Me.GGODOWM, Me.GSHELF, Me.GITEMNAME, Me.GSIZE, Me.GWT, Me.GPPRSRNO, Me.GBATCHNO, Me.gUNIT, Me.GQty, Me.GTYPE, Me.GOUTQTY, Me.GRATE, Me.GAMOUNT})
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDSTOCK.DefaultCellStyle = DataGridViewCellStyle9
        Me.GRIDSTOCK.GridColor = System.Drawing.SystemColors.Control
        Me.GRIDSTOCK.Location = New System.Drawing.Point(6, 28)
        Me.GRIDSTOCK.MultiSelect = False
        Me.GRIDSTOCK.Name = "GRIDSTOCK"
        Me.GRIDSTOCK.ReadOnly = True
        Me.GRIDSTOCK.RowHeadersVisible = False
        Me.GRIDSTOCK.RowHeadersWidth = 30
        Me.GRIDSTOCK.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDSTOCK.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.GRIDSTOCK.RowTemplate.Height = 20
        Me.GRIDSTOCK.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDSTOCK.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDSTOCK.Size = New System.Drawing.Size(1450, 399)
        Me.GRIDSTOCK.TabIndex = 17
        Me.GRIDSTOCK.TabStop = False
        '
        'CMBPARTYNAME
        '
        Me.CMBPARTYNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBPARTYNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBPARTYNAME.FormattingEnabled = True
        Me.CMBPARTYNAME.Location = New System.Drawing.Point(47, 6)
        Me.CMBPARTYNAME.Name = "CMBPARTYNAME"
        Me.CMBPARTYNAME.Size = New System.Drawing.Size(180, 23)
        Me.CMBPARTYNAME.TabIndex = 1
        '
        'CMBACCCODE
        '
        Me.CMBACCCODE.FormattingEnabled = True
        Me.CMBACCCODE.Location = New System.Drawing.Point(519, 12)
        Me.CMBACCCODE.Name = "CMBACCCODE"
        Me.CMBACCCODE.Size = New System.Drawing.Size(28, 23)
        Me.CMBACCCODE.TabIndex = 718
        Me.CMBACCCODE.Visible = False
        '
        'TXTADD
        '
        Me.TXTADD.BackColor = System.Drawing.Color.White
        Me.TXTADD.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTADD.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTADD.Location = New System.Drawing.Point(534, 12)
        Me.TXTADD.Name = "TXTADD"
        Me.TXTADD.ReadOnly = True
        Me.TXTADD.Size = New System.Drawing.Size(30, 23)
        Me.TXTADD.TabIndex = 719
        Me.TXTADD.Text = " "
        Me.TXTADD.Visible = False
        '
        'OPENINGDATE
        '
        Me.OPENINGDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.OPENINGDATE.Location = New System.Drawing.Point(90, 12)
        Me.OPENINGDATE.Name = "OPENINGDATE"
        Me.OPENINGDATE.Size = New System.Drawing.Size(86, 23)
        Me.OPENINGDATE.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(55, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 15)
        Me.Label1.TabIndex = 721
        Me.Label1.Text = "Date"
        '
        'CMBTYPE
        '
        Me.CMBTYPE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBTYPE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBTYPE.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBTYPE.FormattingEnabled = True
        Me.CMBTYPE.Items.AddRange(New Object() {"On Approval" & Global.Microsoft.VisualBasic.ChrW(9), "Accepted", "Rejected"})
        Me.CMBTYPE.Location = New System.Drawing.Point(1107, 6)
        Me.CMBTYPE.Name = "CMBTYPE"
        Me.CMBTYPE.Size = New System.Drawing.Size(100, 23)
        Me.CMBTYPE.TabIndex = 11
        '
        'TXTOUTQTY
        '
        Me.TXTOUTQTY.BackColor = System.Drawing.Color.White
        Me.TXTOUTQTY.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTOUTQTY.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTOUTQTY.Location = New System.Drawing.Point(1138, 16)
        Me.TXTOUTQTY.Name = "TXTOUTQTY"
        Me.TXTOUTQTY.ReadOnly = True
        Me.TXTOUTQTY.Size = New System.Drawing.Size(30, 23)
        Me.TXTOUTQTY.TabIndex = 722
        Me.TXTOUTQTY.Text = " "
        Me.TXTOUTQTY.Visible = False
        '
        'TXTSHEETSPERREAM
        '
        Me.TXTSHEETSPERREAM.BackColor = System.Drawing.Color.White
        Me.TXTSHEETSPERREAM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTSHEETSPERREAM.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSHEETSPERREAM.Location = New System.Drawing.Point(1071, 16)
        Me.TXTSHEETSPERREAM.MaxLength = 10
        Me.TXTSHEETSPERREAM.Name = "TXTSHEETSPERREAM"
        Me.TXTSHEETSPERREAM.Size = New System.Drawing.Size(41, 23)
        Me.TXTSHEETSPERREAM.TabIndex = 862
        Me.TXTSHEETSPERREAM.Text = "500"
        Me.TXTSHEETSPERREAM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(987, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 15)
        Me.Label4.TabIndex = 863
        Me.Label4.Text = "Sheets / Ream"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TBITEMDTLS)
        Me.TabControl1.Location = New System.Drawing.Point(26, 58)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1245, 478)
        Me.TabControl1.TabIndex = 864
        '
        'TBITEMDTLS
        '
        Me.TBITEMDTLS.AutoScroll = True
        Me.TBITEMDTLS.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.TBITEMDTLS.Controls.Add(Me.TXTAMOUNT)
        Me.TBITEMDTLS.Controls.Add(Me.TXTRATE)
        Me.TBITEMDTLS.Controls.Add(Me.GRIDSTOCK)
        Me.TBITEMDTLS.Controls.Add(Me.CMBPARTYNAME)
        Me.TBITEMDTLS.Controls.Add(Me.TXTSRNO)
        Me.TBITEMDTLS.Controls.Add(Me.CMBiTEMNAME)
        Me.TBITEMDTLS.Controls.Add(Me.CMBTYPE)
        Me.TBITEMDTLS.Controls.Add(Me.CMBSHELF)
        Me.TBITEMDTLS.Controls.Add(Me.CMBGODOWN)
        Me.TBITEMDTLS.Controls.Add(Me.TXTSIZE)
        Me.TBITEMDTLS.Controls.Add(Me.TXTWT)
        Me.TBITEMDTLS.Controls.Add(Me.TXTPPRSRNO)
        Me.TBITEMDTLS.Controls.Add(Me.TXTBATCHNO)
        Me.TBITEMDTLS.Controls.Add(Me.CMBUNIT)
        Me.TBITEMDTLS.Controls.Add(Me.TXTQTY)
        Me.TBITEMDTLS.Location = New System.Drawing.Point(4, 24)
        Me.TBITEMDTLS.Name = "TBITEMDTLS"
        Me.TBITEMDTLS.Padding = New System.Windows.Forms.Padding(3)
        Me.TBITEMDTLS.Size = New System.Drawing.Size(1237, 450)
        Me.TBITEMDTLS.TabIndex = 0
        Me.TBITEMDTLS.Text = "1. Item Details"
        Me.TBITEMDTLS.UseVisualStyleBackColor = True
        '
        'TXTAMOUNT
        '
        Me.TXTAMOUNT.BackColor = System.Drawing.Color.Linen
        Me.TXTAMOUNT.Location = New System.Drawing.Point(1307, 6)
        Me.TXTAMOUNT.MaxLength = 20
        Me.TXTAMOUNT.Name = "TXTAMOUNT"
        Me.TXTAMOUNT.ReadOnly = True
        Me.TXTAMOUNT.Size = New System.Drawing.Size(100, 23)
        Me.TXTAMOUNT.TabIndex = 19
        '
        'TXTRATE
        '
        Me.TXTRATE.Location = New System.Drawing.Point(1207, 6)
        Me.TXTRATE.MaxLength = 20
        Me.TXTRATE.Name = "TXTRATE"
        Me.TXTRATE.Size = New System.Drawing.Size(100, 23)
        Me.TXTRATE.TabIndex = 18
        '
        'gsrno
        '
        Me.gsrno.HeaderText = "Sr."
        Me.gsrno.Name = "gsrno"
        Me.gsrno.ReadOnly = True
        Me.gsrno.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gsrno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gsrno.Width = 40
        '
        'GNO
        '
        Me.GNO.HeaderText = "NO"
        Me.GNO.Name = "GNO"
        Me.GNO.ReadOnly = True
        Me.GNO.Visible = False
        '
        'GPARTYNAME
        '
        Me.GPARTYNAME.HeaderText = "Party Name"
        Me.GPARTYNAME.Name = "GPARTYNAME"
        Me.GPARTYNAME.ReadOnly = True
        Me.GPARTYNAME.Width = 180
        '
        'GGODOWM
        '
        Me.GGODOWM.HeaderText = "Godown "
        Me.GGODOWM.Name = "GGODOWM"
        Me.GGODOWM.ReadOnly = True
        Me.GGODOWM.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GGODOWM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GGODOWM.Width = 110
        '
        'GSHELF
        '
        Me.GSHELF.HeaderText = "Shelf"
        Me.GSHELF.Name = "GSHELF"
        Me.GSHELF.ReadOnly = True
        Me.GSHELF.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GSHELF.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GSHELF.Width = 110
        '
        'GITEMNAME
        '
        Me.GITEMNAME.HeaderText = "Item Name"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.ReadOnly = True
        Me.GITEMNAME.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GITEMNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GITEMNAME.Width = 160
        '
        'GSIZE
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GSIZE.DefaultCellStyle = DataGridViewCellStyle3
        Me.GSIZE.HeaderText = "Size"
        Me.GSIZE.Name = "GSIZE"
        Me.GSIZE.ReadOnly = True
        Me.GSIZE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GSIZE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GSIZE.Width = 80
        '
        'GWT
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight
        Me.GWT.DefaultCellStyle = DataGridViewCellStyle4
        Me.GWT.HeaderText = "Wt"
        Me.GWT.Name = "GWT"
        Me.GWT.ReadOnly = True
        Me.GWT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GWT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GWT.Width = 80
        '
        'GPPRSRNO
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight
        Me.GPPRSRNO.DefaultCellStyle = DataGridViewCellStyle5
        Me.GPPRSRNO.HeaderText = "PPR Sr No"
        Me.GPPRSRNO.Name = "GPPRSRNO"
        Me.GPPRSRNO.ReadOnly = True
        Me.GPPRSRNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GPPRSRNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GPPRSRNO.Width = 80
        '
        'GBATCHNO
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.GBATCHNO.DefaultCellStyle = DataGridViewCellStyle6
        Me.GBATCHNO.HeaderText = "Batch No"
        Me.GBATCHNO.Name = "GBATCHNO"
        Me.GBATCHNO.ReadOnly = True
        Me.GBATCHNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GBATCHNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GBATCHNO.Width = 80
        '
        'gUNIT
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.gUNIT.DefaultCellStyle = DataGridViewCellStyle7
        Me.gUNIT.HeaderText = "Unit"
        Me.gUNIT.Name = "gUNIT"
        Me.gUNIT.ReadOnly = True
        Me.gUNIT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gUNIT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gUNIT.Width = 80
        '
        'GQty
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight
        Me.GQty.DefaultCellStyle = DataGridViewCellStyle8
        Me.GQty.HeaderText = "Qty"
        Me.GQty.Name = "GQty"
        Me.GQty.ReadOnly = True
        Me.GQty.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GQty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GTYPE
        '
        Me.GTYPE.HeaderText = "TYPE"
        Me.GTYPE.Name = "GTYPE"
        Me.GTYPE.ReadOnly = True
        Me.GTYPE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GTYPE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GOUTQTY
        '
        Me.GOUTQTY.HeaderText = "OUTQTY"
        Me.GOUTQTY.Name = "GOUTQTY"
        Me.GOUTQTY.ReadOnly = True
        Me.GOUTQTY.Visible = False
        '
        'GRATE
        '
        Me.GRATE.HeaderText = "RATE"
        Me.GRATE.Name = "GRATE"
        Me.GRATE.ReadOnly = True
        Me.GRATE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GAMOUNT
        '
        Me.GAMOUNT.HeaderText = "AMOUNT"
        Me.GAMOUNT.Name = "GAMOUNT"
        Me.GAMOUNT.ReadOnly = True
        Me.GAMOUNT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GAMOUNT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'OpeningStock
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1283, 581)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.TXTSHEETSPERREAM)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TXTOUTQTY)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.OPENINGDATE)
        Me.Controls.Add(Me.TXTADD)
        Me.Controls.Add(Me.CMBACCCODE)
        Me.Controls.Add(Me.TXTNO)
        Me.Controls.Add(Me.CMBITEMCODE)
        Me.Controls.Add(Me.cmdexit)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "OpeningStock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Opening Stock"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Ep, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDSTOCK, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TBITEMDTLS.ResumeLayout(False)
        Me.TBITEMDTLS.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TXTSRNO As System.Windows.Forms.TextBox
    Friend WithEvents CMBiTEMNAME As System.Windows.Forms.ComboBox
    Friend WithEvents CMBSHELF As System.Windows.Forms.ComboBox
    Friend WithEvents CMBGODOWN As System.Windows.Forms.ComboBox
    Friend WithEvents TXTSIZE As System.Windows.Forms.TextBox
    Friend WithEvents TXTWT As System.Windows.Forms.TextBox
    Friend WithEvents TXTPPRSRNO As System.Windows.Forms.TextBox
    Friend WithEvents TXTBATCHNO As System.Windows.Forms.TextBox
    Friend WithEvents CMBUNIT As System.Windows.Forms.ComboBox
    Friend WithEvents TXTQTY As System.Windows.Forms.TextBox
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents CMBITEMCODE As System.Windows.Forms.ComboBox
    Friend WithEvents Ep As System.Windows.Forms.ErrorProvider
    Friend WithEvents TXTNO As System.Windows.Forms.TextBox
    Friend WithEvents CMBPARTYNAME As System.Windows.Forms.ComboBox
    Friend WithEvents GRIDSTOCK As System.Windows.Forms.DataGridView
    Friend WithEvents CMBACCCODE As System.Windows.Forms.ComboBox
    Friend WithEvents TXTADD As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents OPENINGDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents CMBTYPE As System.Windows.Forms.ComboBox
    Friend WithEvents TXTOUTQTY As System.Windows.Forms.TextBox
    Friend WithEvents TXTSHEETSPERREAM As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TBITEMDTLS As TabPage
    Friend WithEvents TXTAMOUNT As TextBox
    Friend WithEvents TXTRATE As TextBox
    Friend WithEvents gsrno As DataGridViewTextBoxColumn
    Friend WithEvents GNO As DataGridViewTextBoxColumn
    Friend WithEvents GPARTYNAME As DataGridViewTextBoxColumn
    Friend WithEvents GGODOWM As DataGridViewTextBoxColumn
    Friend WithEvents GSHELF As DataGridViewTextBoxColumn
    Friend WithEvents GITEMNAME As DataGridViewTextBoxColumn
    Friend WithEvents GSIZE As DataGridViewTextBoxColumn
    Friend WithEvents GWT As DataGridViewTextBoxColumn
    Friend WithEvents GPPRSRNO As DataGridViewTextBoxColumn
    Friend WithEvents GBATCHNO As DataGridViewTextBoxColumn
    Friend WithEvents gUNIT As DataGridViewTextBoxColumn
    Friend WithEvents GQty As DataGridViewTextBoxColumn
    Friend WithEvents GTYPE As DataGridViewTextBoxColumn
    Friend WithEvents GOUTQTY As DataGridViewTextBoxColumn
    Friend WithEvents GRATE As DataGridViewTextBoxColumn
    Friend WithEvents GAMOUNT As DataGridViewTextBoxColumn
End Class
