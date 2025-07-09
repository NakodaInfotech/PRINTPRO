<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReconcileData
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
        Me.CHKRECOJOBBATCH = New System.Windows.Forms.CheckBox()
        Me.CHKRECOORDER = New System.Windows.Forms.CheckBox()
        Me.CMDEXIT = New System.Windows.Forms.Button()
        Me.CMDCLEAR = New System.Windows.Forms.Button()
        Me.CHKRECOPENDINGDATA = New System.Windows.Forms.CheckBox()
        Me.CMDOK = New System.Windows.Forms.Button()
        Me.CHKRECOINV = New System.Windows.Forms.CheckBox()
        Me.CHKRECONONPURCHASE = New System.Windows.Forms.CheckBox()
        Me.CHKRECOPURCHASE = New System.Windows.Forms.CheckBox()
        Me.BlendPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CHKRECOJOBBATCH)
        Me.BlendPanel1.Controls.Add(Me.CHKRECOORDER)
        Me.BlendPanel1.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel1.Controls.Add(Me.CMDCLEAR)
        Me.BlendPanel1.Controls.Add(Me.CHKRECOPENDINGDATA)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.CHKRECOINV)
        Me.BlendPanel1.Controls.Add(Me.CHKRECONONPURCHASE)
        Me.BlendPanel1.Controls.Add(Me.CHKRECOPURCHASE)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(371, 276)
        Me.BlendPanel1.TabIndex = 0
        '
        'CHKRECOJOBBATCH
        '
        Me.CHKRECOJOBBATCH.AutoSize = True
        Me.CHKRECOJOBBATCH.BackColor = System.Drawing.Color.Transparent
        Me.CHKRECOJOBBATCH.Location = New System.Drawing.Point(27, 145)
        Me.CHKRECOJOBBATCH.Name = "CHKRECOJOBBATCH"
        Me.CHKRECOJOBBATCH.Size = New System.Drawing.Size(163, 19)
        Me.CHKRECOJOBBATCH.TabIndex = 5
        Me.CHKRECOJOBBATCH.Text = "Reco Pending Job | Batch"
        Me.CHKRECOJOBBATCH.UseVisualStyleBackColor = True
        '
        'CHKRECOORDER
        '
        Me.CHKRECOORDER.AutoSize = True
        Me.CHKRECOORDER.BackColor = System.Drawing.Color.Transparent
        Me.CHKRECOORDER.Location = New System.Drawing.Point(27, 120)
        Me.CHKRECOORDER.Name = "CHKRECOORDER"
        Me.CHKRECOORDER.Size = New System.Drawing.Size(147, 19)
        Me.CHKRECOORDER.TabIndex = 4
        Me.CHKRECOORDER.Text = "Sale | Purchase Order"
        Me.CHKRECOORDER.UseVisualStyleBackColor = False
        '
        'CMDEXIT
        '
        Me.CMDEXIT.Location = New System.Drawing.Point(220, 190)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXIT.TabIndex = 8
        Me.CMDEXIT.Text = "&Exit"
        Me.CMDEXIT.UseVisualStyleBackColor = True
        '
        'CMDCLEAR
        '
        Me.CMDCLEAR.Location = New System.Drawing.Point(134, 190)
        Me.CMDCLEAR.Name = "CMDCLEAR"
        Me.CMDCLEAR.Size = New System.Drawing.Size(80, 28)
        Me.CMDCLEAR.TabIndex = 7
        Me.CMDCLEAR.Text = "&Clear"
        Me.CMDCLEAR.UseVisualStyleBackColor = True
        '
        'CHKRECOPENDINGDATA
        '
        Me.CHKRECOPENDINGDATA.AutoSize = True
        Me.CHKRECOPENDINGDATA.BackColor = System.Drawing.Color.Transparent
        Me.CHKRECOPENDINGDATA.Location = New System.Drawing.Point(27, 95)
        Me.CHKRECOPENDINGDATA.Name = "CHKRECOPENDINGDATA"
        Me.CHKRECOPENDINGDATA.Size = New System.Drawing.Size(187, 19)
        Me.CHKRECOPENDINGDATA.TabIndex = 3
        Me.CHKRECOPENDINGDATA.Text = "Pending Data (GRN / Challan)"
        Me.CHKRECOPENDINGDATA.UseVisualStyleBackColor = False
        '
        'CMDOK
        '
        Me.CMDOK.Location = New System.Drawing.Point(48, 190)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(80, 28)
        Me.CMDOK.TabIndex = 6
        Me.CMDOK.Text = "&OK"
        Me.CMDOK.UseVisualStyleBackColor = True
        '
        'CHKRECOINV
        '
        Me.CHKRECOINV.AutoSize = True
        Me.CHKRECOINV.BackColor = System.Drawing.Color.Transparent
        Me.CHKRECOINV.Location = New System.Drawing.Point(27, 20)
        Me.CHKRECOINV.Name = "CHKRECOINV"
        Me.CHKRECOINV.Size = New System.Drawing.Size(92, 19)
        Me.CHKRECOINV.TabIndex = 0
        Me.CHKRECOINV.Text = "Sale Invoice"
        Me.CHKRECOINV.UseVisualStyleBackColor = False
        '
        'CHKRECONONPURCHASE
        '
        Me.CHKRECONONPURCHASE.AutoSize = True
        Me.CHKRECONONPURCHASE.BackColor = System.Drawing.Color.Transparent
        Me.CHKRECONONPURCHASE.Location = New System.Drawing.Point(27, 70)
        Me.CHKRECONONPURCHASE.Name = "CHKRECONONPURCHASE"
        Me.CHKRECONONPURCHASE.Size = New System.Drawing.Size(267, 19)
        Me.CHKRECONONPURCHASE.TabIndex = 2
        Me.CHKRECONONPURCHASE.Text = "Non-Purchase | Receipt | Payment | Journal"
        Me.CHKRECONONPURCHASE.UseVisualStyleBackColor = False
        '
        'CHKRECOPURCHASE
        '
        Me.CHKRECOPURCHASE.AutoSize = True
        Me.CHKRECOPURCHASE.BackColor = System.Drawing.Color.Transparent
        Me.CHKRECOPURCHASE.Location = New System.Drawing.Point(27, 45)
        Me.CHKRECOPURCHASE.Name = "CHKRECOPURCHASE"
        Me.CHKRECOPURCHASE.Size = New System.Drawing.Size(120, 19)
        Me.CHKRECOPURCHASE.TabIndex = 1
        Me.CHKRECOPURCHASE.Text = "Purchase Invoice"
        Me.CHKRECOPURCHASE.UseVisualStyleBackColor = False
        '
        'ReconcileData
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(371, 276)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "ReconcileData"
        Me.Text = "ReconcileData"
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CHKRECOORDER As CheckBox
    Friend WithEvents CMDEXIT As Button
    Friend WithEvents CMDCLEAR As Button
    Friend WithEvents CHKRECOPENDINGDATA As CheckBox
    Friend WithEvents CMDOK As Button
    Friend WithEvents CHKRECOINV As CheckBox
    Friend WithEvents CHKRECONONPURCHASE As CheckBox
    Friend WithEvents CHKRECOPURCHASE As CheckBox
    Friend WithEvents CHKRECOJOBBATCH As CheckBox
End Class
