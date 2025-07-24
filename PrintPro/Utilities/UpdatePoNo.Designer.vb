<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdatePoNo
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
        Me.Label6 = New System.Windows.Forms.Label()
        Me.NEWPODATE = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PODATE = New System.Windows.Forms.DateTimePicker()
        Me.TXTNEWPONO = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TXTOLDPONO = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXTNAME = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXTSRNO = New System.Windows.Forms.TextBox()
        Me.CMDEXIT = New System.Windows.Forms.Button()
        Me.CMDCLEAR = New System.Windows.Forms.Button()
        Me.CMDUPDATE = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.NEWPODATE)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.PODATE)
        Me.BlendPanel1.Controls.Add(Me.TXTNEWPONO)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.TXTOLDPONO)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.TXTNAME)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.TXTSRNO)
        Me.BlendPanel1.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel1.Controls.Add(Me.CMDCLEAR)
        Me.BlendPanel1.Controls.Add(Me.CMDUPDATE)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(393, 262)
        Me.BlendPanel1.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(28, 178)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 15)
        Me.Label6.TabIndex = 841
        Me.Label6.Text = "New PO Date"
        '
        'NEWPODATE
        '
        Me.NEWPODATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.NEWPODATE.Location = New System.Drawing.Point(105, 174)
        Me.NEWPODATE.Name = "NEWPODATE"
        Me.NEWPODATE.Size = New System.Drawing.Size(87, 23)
        Me.NEWPODATE.TabIndex = 840
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(28, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 15)
        Me.Label5.TabIndex = 839
        Me.Label5.Text = "Old PO Date"
        '
        'PODATE
        '
        Me.PODATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.PODATE.Location = New System.Drawing.Point(105, 116)
        Me.PODATE.Name = "PODATE"
        Me.PODATE.Size = New System.Drawing.Size(87, 23)
        Me.PODATE.TabIndex = 838
        '
        'TXTNEWPONO
        '
        Me.TXTNEWPONO.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTNEWPONO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNEWPONO.Location = New System.Drawing.Point(105, 145)
        Me.TXTNEWPONO.Name = "TXTNEWPONO"
        Me.TXTNEWPONO.Size = New System.Drawing.Size(250, 23)
        Me.TXTNEWPONO.TabIndex = 835
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(35, 148)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 15)
        Me.Label3.TabIndex = 837
        Me.Label3.Text = "New PO No"
        '
        'TXTOLDPONO
        '
        Me.TXTOLDPONO.BackColor = System.Drawing.Color.Linen
        Me.TXTOLDPONO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTOLDPONO.Location = New System.Drawing.Point(105, 87)
        Me.TXTOLDPONO.Name = "TXTOLDPONO"
        Me.TXTOLDPONO.ReadOnly = True
        Me.TXTOLDPONO.Size = New System.Drawing.Size(250, 23)
        Me.TXTOLDPONO.TabIndex = 834
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(38, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 15)
        Me.Label4.TabIndex = 836
        Me.Label4.Text = "Old PO No"
        '
        'TXTNAME
        '
        Me.TXTNAME.BackColor = System.Drawing.Color.Linen
        Me.TXTNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNAME.Location = New System.Drawing.Point(105, 58)
        Me.TXTNAME.Name = "TXTNAME"
        Me.TXTNAME.ReadOnly = True
        Me.TXTNAME.Size = New System.Drawing.Size(250, 23)
        Me.TXTNAME.TabIndex = 667
        Me.TXTNAME.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(33, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 15)
        Me.Label2.TabIndex = 668
        Me.Label2.Text = "Party Name"
        '
        'TXTSRNO
        '
        Me.TXTSRNO.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTSRNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSRNO.Location = New System.Drawing.Point(105, 24)
        Me.TXTSRNO.Name = "TXTSRNO"
        Me.TXTSRNO.Size = New System.Drawing.Size(100, 23)
        Me.TXTSRNO.TabIndex = 0
        Me.TXTSRNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMDEXIT
        '
        Me.CMDEXIT.Location = New System.Drawing.Point(263, 216)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(93, 32)
        Me.CMDEXIT.TabIndex = 6
        Me.CMDEXIT.Text = "&Exit"
        Me.CMDEXIT.UseVisualStyleBackColor = True
        '
        'CMDCLEAR
        '
        Me.CMDCLEAR.Location = New System.Drawing.Point(163, 216)
        Me.CMDCLEAR.Name = "CMDCLEAR"
        Me.CMDCLEAR.Size = New System.Drawing.Size(93, 32)
        Me.CMDCLEAR.TabIndex = 5
        Me.CMDCLEAR.Text = "&Clear"
        Me.CMDCLEAR.UseVisualStyleBackColor = True
        '
        'CMDUPDATE
        '
        Me.CMDUPDATE.Location = New System.Drawing.Point(62, 216)
        Me.CMDUPDATE.Name = "CMDUPDATE"
        Me.CMDUPDATE.Size = New System.Drawing.Size(93, 32)
        Me.CMDUPDATE.TabIndex = 4
        Me.CMDUPDATE.Text = "&Update"
        Me.CMDUPDATE.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(45, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Order No"
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'UpdatePoNo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(393, 262)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "UpdatePoNo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "UpdatePoNo"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents TXTNAME As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TXTSRNO As TextBox
    Friend WithEvents CMDEXIT As Button
    Friend WithEvents CMDCLEAR As Button
    Friend WithEvents CMDUPDATE As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents EP As ErrorProvider
    Friend WithEvents TXTNEWPONO As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TXTOLDPONO As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents PODATE As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents NEWPODATE As DateTimePicker
End Class
