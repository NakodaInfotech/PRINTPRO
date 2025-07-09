<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MRP
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
        Me.components = New System.ComponentModel.Container
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.Label12 = New System.Windows.Forms.Label
        Me.CMBITEMCODE = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.TXTPERCENTAGE = New System.Windows.Forms.TextBox
        Me.TXTSHEETS = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TXTPAPER = New System.Windows.Forms.TextBox
        Me.TXTNOOFUPS = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.TXTPAPERHT = New System.Windows.Forms.TextBox
        Me.TXTPAPERWIDTH = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.CMDSELECTSTOCK = New System.Windows.Forms.Button
        Me.TXTLEAFLETS = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.CMDSELECTBATCH = New System.Windows.Forms.Button
        Me.TXTBATCHNO = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TXTHT = New System.Windows.Forms.TextBox
        Me.TXTWIDTH = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.CMBITEMNAME = New System.Windows.Forms.ComboBox
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.Label12)
        Me.BlendPanel1.Controls.Add(Me.CMBITEMCODE)
        Me.BlendPanel1.Controls.Add(Me.Label11)
        Me.BlendPanel1.Controls.Add(Me.TXTPERCENTAGE)
        Me.BlendPanel1.Controls.Add(Me.TXTSHEETS)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.TXTPAPER)
        Me.BlendPanel1.Controls.Add(Me.TXTNOOFUPS)
        Me.BlendPanel1.Controls.Add(Me.Label8)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.Label7)
        Me.BlendPanel1.Controls.Add(Me.TXTPAPERHT)
        Me.BlendPanel1.Controls.Add(Me.TXTPAPERWIDTH)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.CMDSELECTSTOCK)
        Me.BlendPanel1.Controls.Add(Me.TXTLEAFLETS)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.CMDSELECTBATCH)
        Me.BlendPanel1.Controls.Add(Me.TXTBATCHNO)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.TXTHT)
        Me.BlendPanel1.Controls.Add(Me.TXTWIDTH)
        Me.BlendPanel1.Controls.Add(Me.Label10)
        Me.BlendPanel1.Controls.Add(Me.CMBITEMNAME)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(611, 332)
        Me.BlendPanel1.TabIndex = 0
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(39, 35)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(61, 15)
        Me.Label12.TabIndex = 660
        Me.Label12.Text = "Item Code"
        '
        'CMBITEMCODE
        '
        Me.CMBITEMCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBITEMCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBITEMCODE.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBITEMCODE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBITEMCODE.FormattingEnabled = True
        Me.CMBITEMCODE.Location = New System.Drawing.Point(102, 32)
        Me.CMBITEMCODE.Name = "CMBITEMCODE"
        Me.CMBITEMCODE.Size = New System.Drawing.Size(121, 23)
        Me.CMBITEMCODE.TabIndex = 0
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(210, 142)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(16, 15)
        Me.Label11.TabIndex = 658
        Me.Label11.Text = "%"
        '
        'TXTPERCENTAGE
        '
        Me.TXTPERCENTAGE.BackColor = System.Drawing.SystemColors.Window
        Me.TXTPERCENTAGE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTPERCENTAGE.Location = New System.Drawing.Point(172, 138)
        Me.TXTPERCENTAGE.MaxLength = 6
        Me.TXTPERCENTAGE.Name = "TXTPERCENTAGE"
        Me.TXTPERCENTAGE.Size = New System.Drawing.Size(37, 23)
        Me.TXTPERCENTAGE.TabIndex = 657
        Me.TXTPERCENTAGE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTSHEETS
        '
        Me.TXTSHEETS.BackColor = System.Drawing.Color.White
        Me.TXTSHEETS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTSHEETS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSHEETS.Location = New System.Drawing.Point(352, 245)
        Me.TXTSHEETS.MaxLength = 20
        Me.TXTSHEETS.Multiline = True
        Me.TXTSHEETS.Name = "TXTSHEETS"
        Me.TXTSHEETS.Size = New System.Drawing.Size(101, 23)
        Me.TXTSHEETS.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(279, 248)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 15)
        Me.Label9.TabIndex = 655
        Me.Label9.Text = "Sheets Reqd."
        '
        'TXTPAPER
        '
        Me.TXTPAPER.BackColor = System.Drawing.Color.White
        Me.TXTPAPER.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTPAPER.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPAPER.Location = New System.Drawing.Point(102, 183)
        Me.TXTPAPER.MaxLength = 20
        Me.TXTPAPER.Multiline = True
        Me.TXTPAPER.Name = "TXTPAPER"
        Me.TXTPAPER.Size = New System.Drawing.Size(135, 23)
        Me.TXTPAPER.TabIndex = 5
        '
        'TXTNOOFUPS
        '
        Me.TXTNOOFUPS.BackColor = System.Drawing.Color.White
        Me.TXTNOOFUPS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTNOOFUPS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNOOFUPS.Location = New System.Drawing.Point(148, 245)
        Me.TXTNOOFUPS.MaxLength = 20
        Me.TXTNOOFUPS.Multiline = True
        Me.TXTNOOFUPS.Name = "TXTNOOFUPS"
        Me.TXTNOOFUPS.Size = New System.Drawing.Size(101, 23)
        Me.TXTNOOFUPS.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(81, 248)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 15)
        Me.Label8.TabIndex = 652
        Me.Label8.Text = "No. Of Ups"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(378, 209)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 15)
        Me.Label6.TabIndex = 651
        Me.Label6.Text = "Height"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(268, 209)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 15)
        Me.Label7.TabIndex = 650
        Me.Label7.Text = "Width"
        '
        'TXTPAPERHT
        '
        Me.TXTPAPERHT.BackColor = System.Drawing.Color.White
        Me.TXTPAPERHT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTPAPERHT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPAPERHT.Location = New System.Drawing.Point(352, 183)
        Me.TXTPAPERHT.MaxLength = 20
        Me.TXTPAPERHT.Multiline = True
        Me.TXTPAPERHT.Name = "TXTPAPERHT"
        Me.TXTPAPERHT.Size = New System.Drawing.Size(101, 23)
        Me.TXTPAPERHT.TabIndex = 7
        '
        'TXTPAPERWIDTH
        '
        Me.TXTPAPERWIDTH.BackColor = System.Drawing.Color.White
        Me.TXTPAPERWIDTH.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTPAPERWIDTH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPAPERWIDTH.Location = New System.Drawing.Point(243, 183)
        Me.TXTPAPERWIDTH.MaxLength = 20
        Me.TXTPAPERWIDTH.Multiline = True
        Me.TXTPAPERWIDTH.Name = "TXTPAPERWIDTH"
        Me.TXTPAPERWIDTH.Size = New System.Drawing.Size(101, 23)
        Me.TXTPAPERWIDTH.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(6, 186)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 15)
        Me.Label5.TabIndex = 647
        Me.Label5.Text = "Paper Material"
        '
        'CMDSELECTSTOCK
        '
        Me.CMDSELECTSTOCK.Location = New System.Drawing.Point(299, 283)
        Me.CMDSELECTSTOCK.Name = "CMDSELECTSTOCK"
        Me.CMDSELECTSTOCK.Size = New System.Drawing.Size(99, 28)
        Me.CMDSELECTSTOCK.TabIndex = 4
        Me.CMDSELECTSTOCK.Text = "S&elect Paper"
        Me.CMDSELECTSTOCK.UseVisualStyleBackColor = True
        '
        'TXTLEAFLETS
        '
        Me.TXTLEAFLETS.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTLEAFLETS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTLEAFLETS.Location = New System.Drawing.Point(102, 137)
        Me.TXTLEAFLETS.MaxLength = 100
        Me.TXTLEAFLETS.Name = "TXTLEAFLETS"
        Me.TXTLEAFLETS.Size = New System.Drawing.Size(64, 23)
        Me.TXTLEAFLETS.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(52, 141)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 15)
        Me.Label4.TabIndex = 644
        Me.Label4.Text = "Leaflets"
        '
        'CMDSELECTBATCH
        '
        Me.CMDSELECTBATCH.Location = New System.Drawing.Point(212, 283)
        Me.CMDSELECTBATCH.Name = "CMDSELECTBATCH"
        Me.CMDSELECTBATCH.Size = New System.Drawing.Size(81, 28)
        Me.CMDSELECTBATCH.TabIndex = 2
        Me.CMDSELECTBATCH.Text = "Select &Batch"
        Me.CMDSELECTBATCH.UseVisualStyleBackColor = True
        '
        'TXTBATCHNO
        '
        Me.TXTBATCHNO.BackColor = System.Drawing.Color.Linen
        Me.TXTBATCHNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTBATCHNO.Location = New System.Drawing.Point(102, 108)
        Me.TXTBATCHNO.MaxLength = 100
        Me.TXTBATCHNO.Name = "TXTBATCHNO"
        Me.TXTBATCHNO.ReadOnly = True
        Me.TXTBATCHNO.Size = New System.Drawing.Size(122, 23)
        Me.TXTBATCHNO.TabIndex = 165
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(41, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 15)
        Me.Label3.TabIndex = 164
        Me.Label3.Text = "Batch No."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(488, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 15)
        Me.Label2.TabIndex = 163
        Me.Label2.Text = "Height"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(384, 87)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 15)
        Me.Label1.TabIndex = 162
        Me.Label1.Text = "Width"
        '
        'TXTHT
        '
        Me.TXTHT.BackColor = System.Drawing.Color.Linen
        Me.TXTHT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTHT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTHT.Location = New System.Drawing.Point(475, 61)
        Me.TXTHT.MaxLength = 20
        Me.TXTHT.Multiline = True
        Me.TXTHT.Name = "TXTHT"
        Me.TXTHT.Size = New System.Drawing.Size(101, 23)
        Me.TXTHT.TabIndex = 161
        '
        'TXTWIDTH
        '
        Me.TXTWIDTH.BackColor = System.Drawing.Color.Linen
        Me.TXTWIDTH.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTWIDTH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTWIDTH.Location = New System.Drawing.Point(359, 61)
        Me.TXTWIDTH.MaxLength = 20
        Me.TXTWIDTH.Multiline = True
        Me.TXTWIDTH.Name = "TXTWIDTH"
        Me.TXTWIDTH.Size = New System.Drawing.Size(101, 23)
        Me.TXTWIDTH.TabIndex = 160
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(34, 65)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 15)
        Me.Label10.TabIndex = 159
        Me.Label10.Text = "Item Name"
        '
        'CMBITEMNAME
        '
        Me.CMBITEMNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBITEMNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBITEMNAME.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBITEMNAME.FormattingEnabled = True
        Me.CMBITEMNAME.Location = New System.Drawing.Point(102, 61)
        Me.CMBITEMNAME.Name = "CMBITEMNAME"
        Me.CMBITEMNAME.Size = New System.Drawing.Size(251, 23)
        Me.CMBITEMNAME.TabIndex = 1
        '
        'EP
        '
        Me.EP.ContainerControl = Me
        '
        'MRP
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(611, 332)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "MRP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Material Resource Planning"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMBITEMNAME As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TXTHT As System.Windows.Forms.TextBox
    Friend WithEvents TXTWIDTH As System.Windows.Forms.TextBox
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TXTBATCHNO As System.Windows.Forms.TextBox
    Friend WithEvents CMDSELECTBATCH As System.Windows.Forms.Button
    Friend WithEvents TXTLEAFLETS As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CMDSELECTSTOCK As System.Windows.Forms.Button
    Friend WithEvents TXTNOOFUPS As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TXTPAPERHT As System.Windows.Forms.TextBox
    Friend WithEvents TXTPAPERWIDTH As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TXTPAPER As System.Windows.Forms.TextBox
    Friend WithEvents TXTSHEETS As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TXTPERCENTAGE As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CMBITEMCODE As System.Windows.Forms.ComboBox
End Class
