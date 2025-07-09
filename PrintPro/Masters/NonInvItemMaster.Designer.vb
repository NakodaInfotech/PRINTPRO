<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NonInvItemMaster
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
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CMBITEMNAME = New System.Windows.Forms.ComboBox()
        Me.CMBPAPERMILL = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CMBPAPERMATERIAL = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.CHKPAPERITEM = New System.Windows.Forms.CheckBox()
        Me.CMBHSNCODE = New System.Windows.Forms.ComboBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CMBINVITEMCODE = New System.Windows.Forms.ComboBox()
        Me.level4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TXTGSM = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TXTWIDTH = New System.Windows.Forms.TextBox()
        Me.CMBNONINVITEM = New System.Windows.Forms.ComboBox()
        Me.cmdclear = New System.Windows.Forms.Button()
        Me.CMDOK = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.TXTREMARKS = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXTLENGTH = New System.Windows.Forms.TextBox()
        Me.CMBCATEGORY = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CHKPLATEITEM = New System.Windows.Forms.CheckBox()
        Me.Ep = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        CType(Me.Ep, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMBITEMNAME)
        Me.BlendPanel1.Controls.Add(Me.CMBPAPERMILL)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.CMBPAPERMATERIAL)
        Me.BlendPanel1.Controls.Add(Me.Label13)
        Me.BlendPanel1.Controls.Add(Me.CHKPAPERITEM)
        Me.BlendPanel1.Controls.Add(Me.CMBHSNCODE)
        Me.BlendPanel1.Controls.Add(Me.Label37)
        Me.BlendPanel1.Controls.Add(Me.Label8)
        Me.BlendPanel1.Controls.Add(Me.CMBINVITEMCODE)
        Me.BlendPanel1.Controls.Add(Me.level4)
        Me.BlendPanel1.Controls.Add(Me.Label7)
        Me.BlendPanel1.Controls.Add(Me.TXTGSM)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.TXTWIDTH)
        Me.BlendPanel1.Controls.Add(Me.CMBNONINVITEM)
        Me.BlendPanel1.Controls.Add(Me.cmdclear)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.TXTREMARKS)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.TXTLENGTH)
        Me.BlendPanel1.Controls.Add(Me.CMBCATEGORY)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.CHKPLATEITEM)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(451, 437)
        Me.BlendPanel1.TabIndex = 0
        '
        'CMBITEMNAME
        '
        Me.CMBITEMNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBITEMNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBITEMNAME.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBITEMNAME.FormattingEnabled = True
        Me.CMBITEMNAME.Location = New System.Drawing.Point(387, 279)
        Me.CMBITEMNAME.Name = "CMBITEMNAME"
        Me.CMBITEMNAME.Size = New System.Drawing.Size(251, 23)
        Me.CMBITEMNAME.TabIndex = 366
        Me.CMBITEMNAME.Visible = False
        '
        'CMBPAPERMILL
        '
        Me.CMBPAPERMILL.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBPAPERMILL.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBPAPERMILL.FormattingEnabled = True
        Me.CMBPAPERMILL.Location = New System.Drawing.Point(121, 246)
        Me.CMBPAPERMILL.Name = "CMBPAPERMILL"
        Me.CMBPAPERMILL.Size = New System.Drawing.Size(260, 23)
        Me.CMBPAPERMILL.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(52, 250)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 15)
        Me.Label9.TabIndex = 365
        Me.Label9.Text = "Paper Mill"
        '
        'CMBPAPERMATERIAL
        '
        Me.CMBPAPERMATERIAL.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBPAPERMATERIAL.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBPAPERMATERIAL.FormattingEnabled = True
        Me.CMBPAPERMATERIAL.Location = New System.Drawing.Point(121, 217)
        Me.CMBPAPERMATERIAL.Name = "CMBPAPERMATERIAL"
        Me.CMBPAPERMATERIAL.Size = New System.Drawing.Size(260, 23)
        Me.CMBPAPERMATERIAL.TabIndex = 8
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(51, 221)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(66, 15)
        Me.Label13.TabIndex = 363
        Me.Label13.Text = "Paper Type"
        '
        'CHKPAPERITEM
        '
        Me.CHKPAPERITEM.AutoSize = True
        Me.CHKPAPERITEM.BackColor = System.Drawing.Color.Transparent
        Me.CHKPAPERITEM.Location = New System.Drawing.Point(300, 190)
        Me.CHKPAPERITEM.Name = "CHKPAPERITEM"
        Me.CHKPAPERITEM.Size = New System.Drawing.Size(85, 19)
        Me.CHKPAPERITEM.TabIndex = 7
        Me.CHKPAPERITEM.Text = "Paper Item"
        Me.CHKPAPERITEM.UseVisualStyleBackColor = False
        '
        'CMBHSNCODE
        '
        Me.CMBHSNCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBHSNCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBHSNCODE.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBHSNCODE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBHSNCODE.FormattingEnabled = True
        Me.CMBHSNCODE.Location = New System.Drawing.Point(121, 104)
        Me.CMBHSNCODE.MaxDropDownItems = 14
        Me.CMBHSNCODE.Name = "CMBHSNCODE"
        Me.CMBHSNCODE.Size = New System.Drawing.Size(106, 23)
        Me.CMBHSNCODE.TabIndex = 2
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.BackColor = System.Drawing.Color.Transparent
        Me.Label37.ForeColor = System.Drawing.Color.Black
        Me.Label37.Location = New System.Drawing.Point(230, 109)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(109, 15)
        Me.Label37.TabIndex = 360
        Me.Label37.Text = "Press 'F1' To Select"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(28, 107)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(89, 14)
        Me.Label8.TabIndex = 358
        Me.Label8.Text = "HSN / SAC Code"
        '
        'CMBINVITEMCODE
        '
        Me.CMBINVITEMCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBINVITEMCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBINVITEMCODE.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBINVITEMCODE.FormattingEnabled = True
        Me.CMBINVITEMCODE.Location = New System.Drawing.Point(121, 275)
        Me.CMBINVITEMCODE.MaxLength = 200
        Me.CMBINVITEMCODE.Name = "CMBINVITEMCODE"
        Me.CMBINVITEMCODE.Size = New System.Drawing.Size(260, 23)
        Me.CMBINVITEMCODE.TabIndex = 10
        '
        'level4
        '
        Me.level4.AutoSize = True
        Me.level4.BackColor = System.Drawing.Color.Transparent
        Me.level4.Location = New System.Drawing.Point(52, 279)
        Me.level4.Name = "level4"
        Me.level4.Size = New System.Drawing.Size(61, 15)
        Me.level4.TabIndex = 355
        Me.level4.Text = "Item Code"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(85, 166)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 15)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "GSM"
        '
        'TXTGSM
        '
        Me.TXTGSM.Location = New System.Drawing.Point(121, 162)
        Me.TXTGSM.MaxLength = 10
        Me.TXTGSM.Name = "TXTGSM"
        Me.TXTGSM.Size = New System.Drawing.Size(106, 23)
        Me.TXTGSM.TabIndex = 5
        Me.TXTGSM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(232, 137)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 15)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Width"
        '
        'TXTWIDTH
        '
        Me.TXTWIDTH.Location = New System.Drawing.Point(275, 133)
        Me.TXTWIDTH.MaxLength = 6
        Me.TXTWIDTH.Name = "TXTWIDTH"
        Me.TXTWIDTH.Size = New System.Drawing.Size(106, 23)
        Me.TXTWIDTH.TabIndex = 4
        Me.TXTWIDTH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMBNONINVITEM
        '
        Me.CMBNONINVITEM.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBNONINVITEM.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBNONINVITEM.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBNONINVITEM.FormattingEnabled = True
        Me.CMBNONINVITEM.Location = New System.Drawing.Point(121, 75)
        Me.CMBNONINVITEM.MaxLength = 200
        Me.CMBNONINVITEM.Name = "CMBNONINVITEM"
        Me.CMBNONINVITEM.Size = New System.Drawing.Size(260, 23)
        Me.CMBNONINVITEM.TabIndex = 1
        '
        'cmdclear
        '
        Me.cmdclear.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdclear.Location = New System.Drawing.Point(165, 388)
        Me.cmdclear.Name = "cmdclear"
        Me.cmdclear.Size = New System.Drawing.Size(80, 28)
        Me.cmdclear.TabIndex = 13
        Me.cmdclear.Text = "&Clear"
        Me.cmdclear.UseVisualStyleBackColor = True
        '
        'CMDOK
        '
        Me.CMDOK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.Location = New System.Drawing.Point(79, 388)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(80, 28)
        Me.CMDOK.TabIndex = 12
        Me.CMDOK.Text = "&Save"
        Me.CMDOK.UseVisualStyleBackColor = True
        '
        'cmdexit
        '
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.Location = New System.Drawing.Point(251, 388)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 14
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = True
        '
        'TXTREMARKS
        '
        Me.TXTREMARKS.Location = New System.Drawing.Point(121, 304)
        Me.TXTREMARKS.MaxLength = 100
        Me.TXTREMARKS.Multiline = True
        Me.TXTREMARKS.Name = "TXTREMARKS"
        Me.TXTREMARKS.Size = New System.Drawing.Size(260, 72)
        Me.TXTREMARKS.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(63, 304)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 15)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Remarks"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(75, 137)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 15)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Length"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(7, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 15)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Non Inv Item Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(62, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Category"
        '
        'TXTLENGTH
        '
        Me.TXTLENGTH.Location = New System.Drawing.Point(121, 133)
        Me.TXTLENGTH.MaxLength = 6
        Me.TXTLENGTH.Name = "TXTLENGTH"
        Me.TXTLENGTH.Size = New System.Drawing.Size(106, 23)
        Me.TXTLENGTH.TabIndex = 3
        Me.TXTLENGTH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMBCATEGORY
        '
        Me.CMBCATEGORY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCATEGORY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCATEGORY.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBCATEGORY.FormattingEnabled = True
        Me.CMBCATEGORY.Location = New System.Drawing.Point(121, 46)
        Me.CMBCATEGORY.MaxLength = 100
        Me.CMBCATEGORY.Name = "CMBCATEGORY"
        Me.CMBCATEGORY.Size = New System.Drawing.Size(260, 23)
        Me.CMBCATEGORY.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(217, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Non Inventry Item Master"
        '
        'CHKPLATEITEM
        '
        Me.CHKPLATEITEM.AutoSize = True
        Me.CHKPLATEITEM.BackColor = System.Drawing.Color.Transparent
        Me.CHKPLATEITEM.Location = New System.Drawing.Point(300, 165)
        Me.CHKPLATEITEM.Name = "CHKPLATEITEM"
        Me.CHKPLATEITEM.Size = New System.Drawing.Size(81, 19)
        Me.CHKPLATEITEM.TabIndex = 6
        Me.CHKPLATEITEM.Text = "Plate Item"
        Me.CHKPLATEITEM.UseVisualStyleBackColor = False
        '
        'Ep
        '
        Me.Ep.BlinkRate = 0
        Me.Ep.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.Ep.ContainerControl = Me
        '
        'NonInvItemMaster
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(451, 437)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "NonInvItemMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Non Inv Item Master"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.Ep, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TXTREMARKS As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TXTLENGTH As System.Windows.Forms.TextBox
    Friend WithEvents CMBCATEGORY As System.Windows.Forms.ComboBox
    Friend WithEvents cmdclear As System.Windows.Forms.Button
    Friend WithEvents CMDOK As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents Ep As System.Windows.Forms.ErrorProvider
    Friend WithEvents CMBNONINVITEM As System.Windows.Forms.ComboBox
    Friend WithEvents CHKPLATEITEM As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TXTGSM As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TXTWIDTH As System.Windows.Forms.TextBox
    Friend WithEvents CMBINVITEMCODE As ComboBox
    Friend WithEvents level4 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents CMBHSNCODE As ComboBox
    Friend WithEvents Label37 As Label
    Friend WithEvents CHKPAPERITEM As CheckBox
    Friend WithEvents CMBPAPERMILL As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents CMBPAPERMATERIAL As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents CMBITEMNAME As ComboBox
End Class
