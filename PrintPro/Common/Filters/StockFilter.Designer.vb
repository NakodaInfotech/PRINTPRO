<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StockFilter
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
        Me.CHKSHOWALL = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TXTGSM = New System.Windows.Forms.TextBox()
        Me.CMBPAPERMILL = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CMBPAPERMATERIAL = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.CHKPAPERITEM = New System.Windows.Forms.CheckBox()
        Me.CHKPLATEITEM = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CMBCATEGORY = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtfrom = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chkdate = New System.Windows.Forms.CheckBox()
        Me.cmdshowreport = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RDBDETAILS = New System.Windows.Forms.RadioButton()
        Me.RDBSUMM = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CMBITEM = New System.Windows.Forms.ComboBox()
        Me.CMBGODOWN = New System.Windows.Forms.ComboBox()
        Me.RDBRATEWISE = New System.Windows.Forms.RadioButton()
        Me.BlendPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CHKSHOWALL)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.TXTGSM)
        Me.BlendPanel1.Controls.Add(Me.CMBPAPERMILL)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.CMBPAPERMATERIAL)
        Me.BlendPanel1.Controls.Add(Me.Label13)
        Me.BlendPanel1.Controls.Add(Me.CHKPAPERITEM)
        Me.BlendPanel1.Controls.Add(Me.CHKPLATEITEM)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.CMBCATEGORY)
        Me.BlendPanel1.Controls.Add(Me.GroupBox1)
        Me.BlendPanel1.Controls.Add(Me.cmdshowreport)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.GroupBox3)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.CMBITEM)
        Me.BlendPanel1.Controls.Add(Me.CMBGODOWN)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(440, 539)
        Me.BlendPanel1.TabIndex = 0
        '
        'CHKSHOWALL
        '
        Me.CHKSHOWALL.AutoSize = True
        Me.CHKSHOWALL.BackColor = System.Drawing.Color.Transparent
        Me.CHKSHOWALL.Location = New System.Drawing.Point(220, 171)
        Me.CHKSHOWALL.Name = "CHKSHOWALL"
        Me.CHKSHOWALL.Size = New System.Drawing.Size(124, 19)
        Me.CHKSHOWALL.TabIndex = 460
        Me.CHKSHOWALL.Text = "Show 0 Stock also"
        Me.CHKSHOWALL.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(69, 172)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 15)
        Me.Label3.TabIndex = 459
        Me.Label3.Text = "GSM"
        '
        'TXTGSM
        '
        Me.TXTGSM.Location = New System.Drawing.Point(105, 168)
        Me.TXTGSM.MaxLength = 3
        Me.TXTGSM.Name = "TXTGSM"
        Me.TXTGSM.Size = New System.Drawing.Size(106, 23)
        Me.TXTGSM.TabIndex = 5
        Me.TXTGSM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMBPAPERMILL
        '
        Me.CMBPAPERMILL.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBPAPERMILL.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBPAPERMILL.FormattingEnabled = True
        Me.CMBPAPERMILL.Location = New System.Drawing.Point(105, 139)
        Me.CMBPAPERMILL.Name = "CMBPAPERMILL"
        Me.CMBPAPERMILL.Size = New System.Drawing.Size(260, 23)
        Me.CMBPAPERMILL.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(36, 143)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 15)
        Me.Label9.TabIndex = 457
        Me.Label9.Text = "Paper Mill"
        '
        'CMBPAPERMATERIAL
        '
        Me.CMBPAPERMATERIAL.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBPAPERMATERIAL.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBPAPERMATERIAL.FormattingEnabled = True
        Me.CMBPAPERMATERIAL.Location = New System.Drawing.Point(105, 110)
        Me.CMBPAPERMATERIAL.Name = "CMBPAPERMATERIAL"
        Me.CMBPAPERMATERIAL.Size = New System.Drawing.Size(260, 23)
        Me.CMBPAPERMATERIAL.TabIndex = 3
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(35, 114)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(66, 15)
        Me.Label13.TabIndex = 456
        Me.Label13.Text = "Paper Type"
        '
        'CHKPAPERITEM
        '
        Me.CHKPAPERITEM.AutoSize = True
        Me.CHKPAPERITEM.BackColor = System.Drawing.Color.Transparent
        Me.CHKPAPERITEM.Location = New System.Drawing.Point(196, 219)
        Me.CHKPAPERITEM.Name = "CHKPAPERITEM"
        Me.CHKPAPERITEM.Size = New System.Drawing.Size(85, 19)
        Me.CHKPAPERITEM.TabIndex = 7
        Me.CHKPAPERITEM.Text = "Paper Item"
        Me.CHKPAPERITEM.UseVisualStyleBackColor = False
        '
        'CHKPLATEITEM
        '
        Me.CHKPLATEITEM.AutoSize = True
        Me.CHKPLATEITEM.BackColor = System.Drawing.Color.Transparent
        Me.CHKPLATEITEM.Location = New System.Drawing.Point(105, 219)
        Me.CHKPLATEITEM.Name = "CHKPLATEITEM"
        Me.CHKPLATEITEM.Size = New System.Drawing.Size(81, 19)
        Me.CHKPLATEITEM.TabIndex = 6
        Me.CHKPLATEITEM.Text = "Plate Item"
        Me.CHKPLATEITEM.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(47, 85)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 15)
        Me.Label6.TabIndex = 451
        Me.Label6.Text = "Category"
        '
        'CMBCATEGORY
        '
        Me.CMBCATEGORY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCATEGORY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCATEGORY.FormattingEnabled = True
        Me.CMBCATEGORY.Location = New System.Drawing.Point(105, 81)
        Me.CMBCATEGORY.Name = "CMBCATEGORY"
        Me.CMBCATEGORY.Size = New System.Drawing.Size(260, 23)
        Me.CMBCATEGORY.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.dtto)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.dtfrom)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.chkdate)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(80, 422)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(280, 53)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'dtto
        '
        Me.dtto.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtto.Location = New System.Drawing.Point(189, 20)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(83, 22)
        Me.dtto.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(161, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(25, 14)
        Me.Label4.TabIndex = 106
        Me.Label4.Text = "To :"
        '
        'dtfrom
        '
        Me.dtfrom.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfrom.Location = New System.Drawing.Point(50, 20)
        Me.dtfrom.Name = "dtfrom"
        Me.dtfrom.Size = New System.Drawing.Size(83, 22)
        Me.dtfrom.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(9, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 14)
        Me.Label7.TabIndex = 104
        Me.Label7.Text = "From :"
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.ForeColor = System.Drawing.Color.Black
        Me.chkdate.Location = New System.Drawing.Point(12, -2)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(52, 18)
        Me.chkdate.TabIndex = 0
        Me.chkdate.Text = "Date"
        Me.chkdate.UseVisualStyleBackColor = False
        '
        'cmdshowreport
        '
        Me.cmdshowreport.BackColor = System.Drawing.Color.Transparent
        Me.cmdshowreport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdshowreport.FlatAppearance.BorderSize = 0
        Me.cmdshowreport.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdshowreport.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdshowreport.Location = New System.Drawing.Point(133, 499)
        Me.cmdshowreport.Name = "cmdshowreport"
        Me.cmdshowreport.Size = New System.Drawing.Size(88, 28)
        Me.cmdshowreport.TabIndex = 10
        Me.cmdshowreport.Text = "Show Report"
        Me.cmdshowreport.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(227, 499)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 11
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.RDBRATEWISE)
        Me.GroupBox3.Controls.Add(Me.RDBDETAILS)
        Me.GroupBox3.Controls.Add(Me.RDBSUMM)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(80, 242)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(280, 104)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Reports"
        '
        'RDBDETAILS
        '
        Me.RDBDETAILS.AutoSize = True
        Me.RDBDETAILS.Checked = True
        Me.RDBDETAILS.Location = New System.Drawing.Point(20, 21)
        Me.RDBDETAILS.Name = "RDBDETAILS"
        Me.RDBDETAILS.Size = New System.Drawing.Size(59, 18)
        Me.RDBDETAILS.TabIndex = 0
        Me.RDBDETAILS.TabStop = True
        Me.RDBDETAILS.Text = "Detail"
        Me.RDBDETAILS.UseVisualStyleBackColor = True
        '
        'RDBSUMM
        '
        Me.RDBSUMM.AutoSize = True
        Me.RDBSUMM.Location = New System.Drawing.Point(20, 45)
        Me.RDBSUMM.Name = "RDBSUMM"
        Me.RDBSUMM.Size = New System.Drawing.Size(74, 18)
        Me.RDBSUMM.TabIndex = 1
        Me.RDBSUMM.Text = "Summary"
        Me.RDBSUMM.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(37, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 15)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Item Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(50, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Godown"
        '
        'CMBITEM
        '
        Me.CMBITEM.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBITEM.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBITEM.FormattingEnabled = True
        Me.CMBITEM.Location = New System.Drawing.Point(105, 52)
        Me.CMBITEM.Name = "CMBITEM"
        Me.CMBITEM.Size = New System.Drawing.Size(260, 23)
        Me.CMBITEM.TabIndex = 1
        '
        'CMBGODOWN
        '
        Me.CMBGODOWN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBGODOWN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBGODOWN.FormattingEnabled = True
        Me.CMBGODOWN.Location = New System.Drawing.Point(105, 23)
        Me.CMBGODOWN.Name = "CMBGODOWN"
        Me.CMBGODOWN.Size = New System.Drawing.Size(260, 23)
        Me.CMBGODOWN.TabIndex = 0
        '
        'RDBRATEWISE
        '
        Me.RDBRATEWISE.AutoSize = True
        Me.RDBRATEWISE.Location = New System.Drawing.Point(20, 69)
        Me.RDBRATEWISE.Name = "RDBRATEWISE"
        Me.RDBRATEWISE.Size = New System.Drawing.Size(81, 18)
        Me.RDBRATEWISE.TabIndex = 2
        Me.RDBRATEWISE.Text = "Rate Wise"
        Me.RDBRATEWISE.UseVisualStyleBackColor = True
        '
        'StockFilter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(440, 539)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "StockFilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Stock Filter"
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CMBITEM As System.Windows.Forms.ComboBox
    Friend WithEvents CMBGODOWN As System.Windows.Forms.ComboBox
    Friend WithEvents cmdshowreport As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents RDBDETAILS As System.Windows.Forms.RadioButton
    Friend WithEvents RDBSUMM As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CMBCATEGORY As System.Windows.Forms.ComboBox
    Friend WithEvents CHKPAPERITEM As CheckBox
    Friend WithEvents CHKPLATEITEM As CheckBox
    Friend WithEvents CMBPAPERMILL As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents CMBPAPERMATERIAL As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TXTGSM As TextBox
    Friend WithEvents CHKSHOWALL As CheckBox
    Friend WithEvents RDBRATEWISE As RadioButton
End Class
