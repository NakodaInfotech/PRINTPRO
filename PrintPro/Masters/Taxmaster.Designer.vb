<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Taxmaster
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.lblgroup = New System.Windows.Forms.Label
        Me.txtremarks = New System.Windows.Forms.TextBox
        Me.txtname = New System.Windows.Forms.TextBox
        Me.Ep = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.lbl = New System.Windows.Forms.Label
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.cmddelete = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.txttax = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdok = New System.Windows.Forms.Button
        Me.chkchange = New System.Windows.Forms.CheckBox
        Me.cmdexit = New System.Windows.Forms.Button
        Me.RBVAT = New System.Windows.Forms.RadioButton
        Me.RBCST = New System.Windows.Forms.RadioButton
        Me.RBOTHER = New System.Windows.Forms.RadioButton
        CType(Me.Ep, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.BlendPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblgroup
        '
        Me.lblgroup.BackColor = System.Drawing.Color.Transparent
        Me.lblgroup.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblgroup.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblgroup.Location = New System.Drawing.Point(8, 13)
        Me.lblgroup.Name = "lblgroup"
        Me.lblgroup.Size = New System.Drawing.Size(79, 22)
        Me.lblgroup.TabIndex = 149
        Me.lblgroup.Text = "Tax Name"
        Me.lblgroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtremarks
        '
        Me.txtremarks.ForeColor = System.Drawing.Color.DimGray
        Me.txtremarks.Location = New System.Drawing.Point(7, 17)
        Me.txtremarks.Multiline = True
        Me.txtremarks.Name = "txtremarks"
        Me.txtremarks.Size = New System.Drawing.Size(292, 56)
        Me.txtremarks.TabIndex = 0
        '
        'txtname
        '
        Me.txtname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtname.Location = New System.Drawing.Point(90, 13)
        Me.txtname.Name = "txtname"
        Me.txtname.Size = New System.Drawing.Size(99, 22)
        Me.txtname.TabIndex = 0
        '
        'Ep
        '
        Me.Ep.BlinkRate = 0
        Me.Ep.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.Ep.ContainerControl = Me
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.txtremarks)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(15, 106)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(305, 82)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Remarks"
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(192, 17)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(119, 14)
        Me.lbl.TabIndex = 150
        Me.lbl.Text = "e.g. C.S.T. ,V.A.T. , ect.  "
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.RBOTHER)
        Me.BlendPanel1.Controls.Add(Me.RBCST)
        Me.BlendPanel1.Controls.Add(Me.RBVAT)
        Me.BlendPanel1.Controls.Add(Me.cmddelete)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.txttax)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Controls.Add(Me.chkchange)
        Me.BlendPanel1.Controls.Add(Me.GroupBox5)
        Me.BlendPanel1.Controls.Add(Me.lblgroup)
        Me.BlendPanel1.Controls.Add(Me.txtname)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(419, 200)
        Me.BlendPanel1.TabIndex = 0
        '
        'cmddelete
        '
        Me.cmddelete.BackColor = System.Drawing.Color.Transparent
        Me.cmddelete.BackgroundImage = Global.PrintPro.My.Resources.Resources.Delete
        Me.cmddelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmddelete.FlatAppearance.BorderSize = 0
        Me.cmddelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmddelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddelete.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmddelete.Location = New System.Drawing.Point(328, 42)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(77, 24)
        Me.cmddelete.TabIndex = 312
        Me.cmddelete.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(192, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(18, 22)
        Me.Label3.TabIndex = 156
        Me.Label3.Text = "%"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txttax
        '
        Me.txttax.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttax.Location = New System.Drawing.Point(90, 44)
        Me.txttax.Name = "txttax"
        Me.txttax.Size = New System.Drawing.Size(99, 22)
        Me.txttax.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(25, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 22)
        Me.Label1.TabIndex = 153
        Me.Label1.Text = "Tax "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdok.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Image = Global.PrintPro.My.Resources.Resources.Save
        Me.cmdok.Location = New System.Drawing.Point(335, 14)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(67, 26)
        Me.cmdok.TabIndex = 2
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'chkchange
        '
        Me.chkchange.AutoSize = True
        Me.chkchange.Location = New System.Drawing.Point(327, 109)
        Me.chkchange.Name = "chkchange"
        Me.chkchange.Size = New System.Drawing.Size(15, 14)
        Me.chkchange.TabIndex = 152
        Me.chkchange.UseVisualStyleBackColor = True
        Me.chkchange.Visible = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Image = Global.PrintPro.My.Resources.Resources._Exit
        Me.cmdexit.Location = New System.Drawing.Point(335, 68)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(67, 27)
        Me.cmdexit.TabIndex = 3
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'RBVAT
        '
        Me.RBVAT.AutoSize = True
        Me.RBVAT.BackColor = System.Drawing.Color.Transparent
        Me.RBVAT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBVAT.Location = New System.Drawing.Point(90, 72)
        Me.RBVAT.Name = "RBVAT"
        Me.RBVAT.Size = New System.Drawing.Size(51, 19)
        Me.RBVAT.TabIndex = 313
        Me.RBVAT.Text = "V.A.T."
        Me.RBVAT.UseVisualStyleBackColor = False
        '
        'RBCST
        '
        Me.RBCST.AutoSize = True
        Me.RBCST.BackColor = System.Drawing.Color.Transparent
        Me.RBCST.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBCST.Location = New System.Drawing.Point(147, 72)
        Me.RBCST.Name = "RBCST"
        Me.RBCST.Size = New System.Drawing.Size(51, 19)
        Me.RBCST.TabIndex = 314
        Me.RBCST.Text = "C.S.T."
        Me.RBCST.UseVisualStyleBackColor = False
        '
        'RBOTHER
        '
        Me.RBOTHER.AutoSize = True
        Me.RBOTHER.BackColor = System.Drawing.Color.Transparent
        Me.RBOTHER.Checked = True
        Me.RBOTHER.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBOTHER.Location = New System.Drawing.Point(204, 72)
        Me.RBOTHER.Name = "RBOTHER"
        Me.RBOTHER.Size = New System.Drawing.Size(56, 19)
        Me.RBOTHER.TabIndex = 315
        Me.RBOTHER.TabStop = True
        Me.RBOTHER.Text = "Other"
        Me.RBOTHER.UseVisualStyleBackColor = False
        '
        'Taxmaster
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(419, 200)
        Me.Controls.Add(Me.BlendPanel1)
        Me.KeyPreview = True
        Me.Name = "Taxmaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tax Master"
        CType(Me.Ep, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblgroup As System.Windows.Forms.Label
    Friend WithEvents txtremarks As System.Windows.Forms.TextBox
    Friend WithEvents txtname As System.Windows.Forms.TextBox
    Friend WithEvents Ep As System.Windows.Forms.ErrorProvider
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents chkchange As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents txttax As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmddelete As System.Windows.Forms.Button
    Friend WithEvents RBOTHER As System.Windows.Forms.RadioButton
    Friend WithEvents RBCST As System.Windows.Forms.RadioButton
    Friend WithEvents RBVAT As System.Windows.Forms.RadioButton
End Class
