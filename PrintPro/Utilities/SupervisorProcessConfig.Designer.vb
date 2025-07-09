<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SupervisorProcessConfig
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.GRIDSUP = New System.Windows.Forms.DataGridView()
        Me.gsrno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GSUPERVISOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GPROCESS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TXTSRNO = New System.Windows.Forms.TextBox()
        Me.TXTNO = New System.Windows.Forms.TextBox()
        Me.TXTADD = New System.Windows.Forms.TextBox()
        Me.cmbcode = New System.Windows.Forms.ComboBox()
        Me.CMBPROCESS = New System.Windows.Forms.ComboBox()
        Me.CMDEXIT = New System.Windows.Forms.Button()
        Me.CMBSUPERVISOR = New System.Windows.Forms.ComboBox()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        CType(Me.GRIDSUP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.GRIDSUP)
        Me.BlendPanel1.Controls.Add(Me.TXTSRNO)
        Me.BlendPanel1.Controls.Add(Me.TXTNO)
        Me.BlendPanel1.Controls.Add(Me.TXTADD)
        Me.BlendPanel1.Controls.Add(Me.cmbcode)
        Me.BlendPanel1.Controls.Add(Me.CMBPROCESS)
        Me.BlendPanel1.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel1.Controls.Add(Me.CMBSUPERVISOR)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(622, 561)
        Me.BlendPanel1.TabIndex = 0
        '
        'GRIDSUP
        '
        Me.GRIDSUP.AllowUserToAddRows = False
        Me.GRIDSUP.AllowUserToDeleteRows = False
        Me.GRIDSUP.AllowUserToResizeColumns = False
        Me.GRIDSUP.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDSUP.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GRIDSUP.BackgroundColor = System.Drawing.Color.White
        Me.GRIDSUP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDSUP.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.GRIDSUP.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GRIDSUP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDSUP.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gsrno, Me.GNO, Me.GSUPERVISOR, Me.GPROCESS})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDSUP.DefaultCellStyle = DataGridViewCellStyle3
        Me.GRIDSUP.GridColor = System.Drawing.SystemColors.Control
        Me.GRIDSUP.Location = New System.Drawing.Point(44, 54)
        Me.GRIDSUP.MultiSelect = False
        Me.GRIDSUP.Name = "GRIDSUP"
        Me.GRIDSUP.ReadOnly = True
        Me.GRIDSUP.RowHeadersVisible = False
        Me.GRIDSUP.RowHeadersWidth = 30
        Me.GRIDSUP.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDSUP.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.GRIDSUP.RowTemplate.Height = 20
        Me.GRIDSUP.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDSUP.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GRIDSUP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDSUP.Size = New System.Drawing.Size(533, 448)
        Me.GRIDSUP.TabIndex = 811
        Me.GRIDSUP.TabStop = False
        '
        'gsrno
        '
        Me.gsrno.HeaderText = "Sr."
        Me.gsrno.Name = "gsrno"
        Me.gsrno.ReadOnly = True
        Me.gsrno.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gsrno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gsrno.Visible = False
        Me.gsrno.Width = 50
        '
        'GNO
        '
        Me.GNO.HeaderText = "No"
        Me.GNO.Name = "GNO"
        Me.GNO.ReadOnly = True
        Me.GNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GNO.Visible = False
        '
        'GSUPERVISOR
        '
        Me.GSUPERVISOR.HeaderText = "Supervisor Name"
        Me.GSUPERVISOR.Name = "GSUPERVISOR"
        Me.GSUPERVISOR.ReadOnly = True
        Me.GSUPERVISOR.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GSUPERVISOR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GSUPERVISOR.Width = 300
        '
        'GPROCESS
        '
        Me.GPROCESS.HeaderText = "Process Name"
        Me.GPROCESS.Name = "GPROCESS"
        Me.GPROCESS.ReadOnly = True
        Me.GPROCESS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GPROCESS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GPROCESS.Width = 200
        '
        'TXTSRNO
        '
        Me.TXTSRNO.BackColor = System.Drawing.Color.Linen
        Me.TXTSRNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSRNO.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTSRNO.Location = New System.Drawing.Point(429, 2)
        Me.TXTSRNO.Name = "TXTSRNO"
        Me.TXTSRNO.ReadOnly = True
        Me.TXTSRNO.Size = New System.Drawing.Size(50, 23)
        Me.TXTSRNO.TabIndex = 810
        Me.TXTSRNO.TabStop = False
        Me.TXTSRNO.Text = " "
        Me.TXTSRNO.Visible = False
        '
        'TXTNO
        '
        Me.TXTNO.BackColor = System.Drawing.Color.White
        Me.TXTNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNO.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTNO.Location = New System.Drawing.Point(485, 3)
        Me.TXTNO.Name = "TXTNO"
        Me.TXTNO.Size = New System.Drawing.Size(41, 23)
        Me.TXTNO.TabIndex = 809
        Me.TXTNO.Text = " "
        Me.TXTNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTNO.Visible = False
        '
        'TXTADD
        '
        Me.TXTADD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTADD.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTADD.Location = New System.Drawing.Point(532, 4)
        Me.TXTADD.Name = "TXTADD"
        Me.TXTADD.Size = New System.Drawing.Size(29, 21)
        Me.TXTADD.TabIndex = 808
        Me.TXTADD.TabStop = False
        Me.TXTADD.Visible = False
        '
        'cmbcode
        '
        Me.cmbcode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbcode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbcode.FormattingEnabled = True
        Me.cmbcode.Location = New System.Drawing.Point(567, 3)
        Me.cmbcode.Name = "cmbcode"
        Me.cmbcode.Size = New System.Drawing.Size(25, 23)
        Me.cmbcode.TabIndex = 807
        Me.cmbcode.Visible = False
        '
        'CMBPROCESS
        '
        Me.CMBPROCESS.BackColor = System.Drawing.SystemColors.Window
        Me.CMBPROCESS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBPROCESS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBPROCESS.FormattingEnabled = True
        Me.CMBPROCESS.Items.AddRange(New Object() {"POSITIVE", "PLATE", "PAPER CUTTING", "PAPER SHEET CUTTING", "PRINTING", "FULL SHEET SORTING", "LEAFLET SORTING", "LEAFLET FULLSHEET CUTTING", "PRINTED LEAFLET CUTTING", "LEAFLET SORTING", "FOLDING", "MACHINE FOLDING", "UNFOLDING", "PACKING", "FINAL"})
        Me.CMBPROCESS.Location = New System.Drawing.Point(345, 31)
        Me.CMBPROCESS.MaxDropDownItems = 14
        Me.CMBPROCESS.MaxLength = 200
        Me.CMBPROCESS.Name = "CMBPROCESS"
        Me.CMBPROCESS.Size = New System.Drawing.Size(200, 23)
        Me.CMBPROCESS.TabIndex = 1
        '
        'CMDEXIT
        '
        Me.CMDEXIT.Location = New System.Drawing.Point(294, 508)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXIT.TabIndex = 6
        Me.CMDEXIT.Text = "E&xit"
        Me.CMDEXIT.UseVisualStyleBackColor = True
        '
        'CMBSUPERVISOR
        '
        Me.CMBSUPERVISOR.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBSUPERVISOR.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBSUPERVISOR.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBSUPERVISOR.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBSUPERVISOR.FormattingEnabled = True
        Me.CMBSUPERVISOR.Location = New System.Drawing.Point(44, 31)
        Me.CMBSUPERVISOR.MaxDropDownItems = 14
        Me.CMBSUPERVISOR.MaxLength = 200
        Me.CMBSUPERVISOR.Name = "CMBSUPERVISOR"
        Me.CMBSUPERVISOR.Size = New System.Drawing.Size(300, 23)
        Me.CMBSUPERVISOR.TabIndex = 0
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'SupervisorProcessConfig
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(622, 561)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "SupervisorProcessConfig"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Supervisor Process Config Filter"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.GRIDSUP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMBPROCESS As System.Windows.Forms.ComboBox
    Friend WithEvents CMDEXIT As System.Windows.Forms.Button
    Friend WithEvents CMBSUPERVISOR As System.Windows.Forms.ComboBox
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents TXTADD As System.Windows.Forms.TextBox
    Friend WithEvents cmbcode As System.Windows.Forms.ComboBox
    Friend WithEvents TXTNO As System.Windows.Forms.TextBox
    Friend WithEvents TXTSRNO As System.Windows.Forms.TextBox
    Friend WithEvents GRIDSUP As System.Windows.Forms.DataGridView
    Friend WithEvents gsrno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GSUPERVISOR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GPROCESS As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
