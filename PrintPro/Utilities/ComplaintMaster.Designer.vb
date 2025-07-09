<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ComplaintMaster
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ComplaintMaster))
        Me.Ep = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.CMDDELETE = New System.Windows.Forms.Button()
        Me.CMDCLEAR = New System.Windows.Forms.Button()
        Me.CMDSAVE = New System.Windows.Forms.Button()
        Me.CMDEXIT = New System.Windows.Forms.Button()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.TXTBILLNO = New System.Windows.Forms.TextBox()
        Me.DTCOMPLAINTDATE = New System.Windows.Forms.DateTimePicker()
        Me.CMBREASONMASTER = New System.Windows.Forms.ComboBox()
        Me.CMBPROBLEMMASTER = New System.Windows.Forms.ComboBox()
        Me.TXTGRIDSRNO = New System.Windows.Forms.TextBox()
        Me.TXTGRIDREMARKS = New System.Windows.Forms.TextBox()
        Me.GRIDCOMPLAINT = New System.Windows.Forms.DataGridView()
        Me.GSRNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GPROBLEMMASTER = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GREASONMASTER = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GREMARKS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CMBOPERATOR = New System.Windows.Forms.ComboBox()
        Me.TXTCOMPLAINNO = New System.Windows.Forms.TextBox()
        Me.TXTREMARKS = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.tooldelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolprevious = New System.Windows.Forms.ToolStripButton()
        Me.toolnext = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        CType(Me.Ep, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.GRIDCOMPLAINT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
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
        'CMDDELETE
        '
        Me.CMDDELETE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDDELETE.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDDELETE.Location = New System.Drawing.Point(461, 376)
        Me.CMDDELETE.Name = "CMDDELETE"
        Me.CMDDELETE.Size = New System.Drawing.Size(80, 28)
        Me.CMDDELETE.TabIndex = 9
        Me.CMDDELETE.Text = "Delete"
        Me.CMDDELETE.UseVisualStyleBackColor = True
        '
        'CMDCLEAR
        '
        Me.CMDCLEAR.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDCLEAR.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDCLEAR.Location = New System.Drawing.Point(375, 376)
        Me.CMDCLEAR.Name = "CMDCLEAR"
        Me.CMDCLEAR.Size = New System.Drawing.Size(80, 28)
        Me.CMDCLEAR.TabIndex = 8
        Me.CMDCLEAR.Text = "&Clear"
        Me.CMDCLEAR.UseVisualStyleBackColor = True
        '
        'CMDSAVE
        '
        Me.CMDSAVE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDSAVE.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDSAVE.Location = New System.Drawing.Point(289, 376)
        Me.CMDSAVE.Name = "CMDSAVE"
        Me.CMDSAVE.Size = New System.Drawing.Size(80, 28)
        Me.CMDSAVE.TabIndex = 7
        Me.CMDSAVE.Text = "&Save"
        Me.CMDSAVE.UseVisualStyleBackColor = True
        '
        'CMDEXIT
        '
        Me.CMDEXIT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDEXIT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDEXIT.Location = New System.Drawing.Point(547, 376)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXIT.TabIndex = 10
        Me.CMDEXIT.Text = "E&xit"
        Me.CMDEXIT.UseVisualStyleBackColor = True
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.Color.White)
        Me.BlendPanel1.Controls.Add(Me.TXTBILLNO)
        Me.BlendPanel1.Controls.Add(Me.DTCOMPLAINTDATE)
        Me.BlendPanel1.Controls.Add(Me.CMBREASONMASTER)
        Me.BlendPanel1.Controls.Add(Me.CMBPROBLEMMASTER)
        Me.BlendPanel1.Controls.Add(Me.TXTGRIDSRNO)
        Me.BlendPanel1.Controls.Add(Me.TXTGRIDREMARKS)
        Me.BlendPanel1.Controls.Add(Me.GRIDCOMPLAINT)
        Me.BlendPanel1.Controls.Add(Me.CMBOPERATOR)
        Me.BlendPanel1.Controls.Add(Me.TXTCOMPLAINNO)
        Me.BlendPanel1.Controls.Add(Me.TXTREMARKS)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.CMDDELETE)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel1.Controls.Add(Me.CMDCLEAR)
        Me.BlendPanel1.Controls.Add(Me.CMDSAVE)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(833, 579)
        Me.BlendPanel1.TabIndex = 0
        '
        'TXTBILLNO
        '
        Me.TXTBILLNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTBILLNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTBILLNO.Location = New System.Drawing.Point(198, 2)
        Me.TXTBILLNO.MaxLength = 10
        Me.TXTBILLNO.Name = "TXTBILLNO"
        Me.TXTBILLNO.Size = New System.Drawing.Size(71, 23)
        Me.TXTBILLNO.TabIndex = 749
        Me.TXTBILLNO.TabStop = False
        Me.TXTBILLNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DTCOMPLAINTDATE
        '
        Me.DTCOMPLAINTDATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTCOMPLAINTDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTCOMPLAINTDATE.Location = New System.Drawing.Point(517, 66)
        Me.DTCOMPLAINTDATE.Name = "DTCOMPLAINTDATE"
        Me.DTCOMPLAINTDATE.Size = New System.Drawing.Size(88, 23)
        Me.DTCOMPLAINTDATE.TabIndex = 1
        '
        'CMBREASONMASTER
        '
        Me.CMBREASONMASTER.FormattingEnabled = True
        Me.CMBREASONMASTER.Location = New System.Drawing.Point(248, 123)
        Me.CMBREASONMASTER.Name = "CMBREASONMASTER"
        Me.CMBREASONMASTER.Size = New System.Drawing.Size(200, 23)
        Me.CMBREASONMASTER.TabIndex = 4
        '
        'CMBPROBLEMMASTER
        '
        Me.CMBPROBLEMMASTER.FormattingEnabled = True
        Me.CMBPROBLEMMASTER.Location = New System.Drawing.Point(47, 123)
        Me.CMBPROBLEMMASTER.Name = "CMBPROBLEMMASTER"
        Me.CMBPROBLEMMASTER.Size = New System.Drawing.Size(203, 23)
        Me.CMBPROBLEMMASTER.TabIndex = 3
        '
        'TXTGRIDSRNO
        '
        Me.TXTGRIDSRNO.BackColor = System.Drawing.Color.Linen
        Me.TXTGRIDSRNO.Location = New System.Drawing.Point(12, 123)
        Me.TXTGRIDSRNO.Name = "TXTGRIDSRNO"
        Me.TXTGRIDSRNO.Size = New System.Drawing.Size(35, 23)
        Me.TXTGRIDSRNO.TabIndex = 748
        Me.TXTGRIDSRNO.TabStop = False
        '
        'TXTGRIDREMARKS
        '
        Me.TXTGRIDREMARKS.Location = New System.Drawing.Point(447, 123)
        Me.TXTGRIDREMARKS.Name = "TXTGRIDREMARKS"
        Me.TXTGRIDREMARKS.Size = New System.Drawing.Size(241, 23)
        Me.TXTGRIDREMARKS.TabIndex = 5
        '
        'GRIDCOMPLAINT
        '
        Me.GRIDCOMPLAINT.AllowUserToAddRows = False
        Me.GRIDCOMPLAINT.AllowUserToDeleteRows = False
        Me.GRIDCOMPLAINT.AllowUserToResizeColumns = False
        Me.GRIDCOMPLAINT.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GRIDCOMPLAINT.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GRIDCOMPLAINT.BackgroundColor = System.Drawing.Color.White
        Me.GRIDCOMPLAINT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDCOMPLAINT.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GRIDCOMPLAINT.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GRIDCOMPLAINT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDCOMPLAINT.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GSRNO, Me.GPROBLEMMASTER, Me.GREASONMASTER, Me.GREMARKS})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDCOMPLAINT.DefaultCellStyle = DataGridViewCellStyle3
        Me.GRIDCOMPLAINT.GridColor = System.Drawing.SystemColors.Control
        Me.GRIDCOMPLAINT.Location = New System.Drawing.Point(12, 146)
        Me.GRIDCOMPLAINT.MultiSelect = False
        Me.GRIDCOMPLAINT.Name = "GRIDCOMPLAINT"
        Me.GRIDCOMPLAINT.RowHeadersVisible = False
        Me.GRIDCOMPLAINT.RowHeadersWidth = 30
        Me.GRIDCOMPLAINT.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDCOMPLAINT.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.GRIDCOMPLAINT.RowTemplate.Height = 20
        Me.GRIDCOMPLAINT.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDCOMPLAINT.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GRIDCOMPLAINT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDCOMPLAINT.Size = New System.Drawing.Size(702, 184)
        Me.GRIDCOMPLAINT.TabIndex = 2
        Me.GRIDCOMPLAINT.TabStop = False
        '
        'GSRNO
        '
        Me.GSRNO.HeaderText = "Sr.No"
        Me.GSRNO.Name = "GSRNO"
        Me.GSRNO.Width = 35
        '
        'GPROBLEMMASTER
        '
        Me.GPROBLEMMASTER.HeaderText = "ProblemMaster"
        Me.GPROBLEMMASTER.Name = "GPROBLEMMASTER"
        Me.GPROBLEMMASTER.Width = 200
        '
        'GREASONMASTER
        '
        Me.GREASONMASTER.HeaderText = "ReasonMaster"
        Me.GREASONMASTER.Name = "GREASONMASTER"
        Me.GREASONMASTER.Width = 200
        '
        'GREMARKS
        '
        Me.GREMARKS.HeaderText = "Remarks"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.Width = 240
        '
        'CMBOPERATOR
        '
        Me.CMBOPERATOR.FormattingEnabled = True
        Me.CMBOPERATOR.Location = New System.Drawing.Point(72, 58)
        Me.CMBOPERATOR.Name = "CMBOPERATOR"
        Me.CMBOPERATOR.Size = New System.Drawing.Size(178, 23)
        Me.CMBOPERATOR.TabIndex = 0
        '
        'TXTCOMPLAINNO
        '
        Me.TXTCOMPLAINNO.BackColor = System.Drawing.Color.Linen
        Me.TXTCOMPLAINNO.Location = New System.Drawing.Point(517, 37)
        Me.TXTCOMPLAINNO.Name = "TXTCOMPLAINNO"
        Me.TXTCOMPLAINNO.ReadOnly = True
        Me.TXTCOMPLAINNO.Size = New System.Drawing.Size(88, 23)
        Me.TXTCOMPLAINNO.TabIndex = 742
        Me.TXTCOMPLAINNO.TabStop = False
        '
        'TXTREMARKS
        '
        Me.TXTREMARKS.Location = New System.Drawing.Point(85, 374)
        Me.TXTREMARKS.Name = "TXTREMARKS"
        Me.TXTREMARKS.Size = New System.Drawing.Size(156, 23)
        Me.TXTREMARKS.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(25, 378)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 15)
        Me.Label5.TabIndex = 739
        Me.Label5.Text = "Remarks"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(479, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 15)
        Me.Label4.TabIndex = 738
        Me.Label4.Text = "Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(455, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 15)
        Me.Label3.TabIndex = 737
        Me.Label3.Text = "Comp No"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(9, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 15)
        Me.Label2.TabIndex = 736
        Me.Label2.Text = "Operator"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripButton, Me.tooldelete, Me.ToolStripSeparator2, Me.toolprevious, Me.toolnext, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(833, 25)
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
        'tooldelete
        '
        Me.tooldelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tooldelete.Image = CType(resources.GetObject("tooldelete.Image"), System.Drawing.Image)
        Me.tooldelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tooldelete.Name = "tooldelete"
        Me.tooldelete.Size = New System.Drawing.Size(23, 22)
        Me.tooldelete.Text = "&Delete"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
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
        'ComplaintMaster
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(833, 579)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "ComplaintMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "ComplaintMaster"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Ep, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.GRIDCOMPLAINT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Ep As ErrorProvider
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents CMDDELETE As Button
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents OpenToolStripButton As ToolStripButton
    Friend WithEvents tooldelete As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents toolprevious As ToolStripButton
    Friend WithEvents toolnext As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents CMDEXIT As Button
    Friend WithEvents CMDCLEAR As Button
    Friend WithEvents CMDSAVE As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents CMBOPERATOR As ComboBox
    Friend WithEvents TXTCOMPLAINNO As TextBox
    Friend WithEvents GRIDCOMPLAINT As DataGridView
    Friend WithEvents TXTGRIDSRNO As TextBox
    Friend WithEvents TXTGRIDREMARKS As TextBox
    Friend WithEvents CMBPROBLEMMASTER As ComboBox
    Friend WithEvents CMBREASONMASTER As ComboBox
    Friend WithEvents GSRNO As DataGridViewTextBoxColumn
    Friend WithEvents GPROBLEMMASTER As DataGridViewTextBoxColumn
    Friend WithEvents GREASONMASTER As DataGridViewTextBoxColumn
    Friend WithEvents GREMARKS As DataGridViewTextBoxColumn
    Friend WithEvents TXTREMARKS As TextBox
    Friend WithEvents DTCOMPLAINTDATE As DateTimePicker
    Friend WithEvents TXTBILLNO As TextBox
End Class
