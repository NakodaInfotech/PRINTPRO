﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class YearDetails
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.CMDBACK = New System.Windows.Forms.Button
        Me.gridcmp = New System.Windows.Forms.DataGridView
        Me.Label2 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.cmddelete = New System.Windows.Forms.Button
        Me.cmdopen = New System.Windows.Forms.Button
        Me.cmdcreate = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridcmp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.SystemColors.InactiveCaptionText, System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMDBACK)
        Me.BlendPanel1.Controls.Add(Me.gridcmp)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.PictureBox2)
        Me.BlendPanel1.Controls.Add(Me.cmddelete)
        Me.BlendPanel1.Controls.Add(Me.cmdopen)
        Me.BlendPanel1.Controls.Add(Me.cmdcreate)
        Me.BlendPanel1.Controls.Add(Me.PictureBox1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(570, 401)
        Me.BlendPanel1.TabIndex = 1
        '
        'CMDBACK
        '
        Me.CMDBACK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDBACK.ForeColor = System.Drawing.Color.Black
        Me.CMDBACK.Location = New System.Drawing.Point(288, 321)
        Me.CMDBACK.Name = "CMDBACK"
        Me.CMDBACK.Size = New System.Drawing.Size(104, 71)
        Me.CMDBACK.TabIndex = 213
        Me.CMDBACK.Text = "&Back"
        Me.CMDBACK.UseVisualStyleBackColor = True
        '
        'gridcmp
        '
        Me.gridcmp.AllowUserToAddRows = False
        Me.gridcmp.AllowUserToDeleteRows = False
        Me.gridcmp.AllowUserToResizeColumns = False
        Me.gridcmp.AllowUserToResizeRows = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        Me.gridcmp.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.gridcmp.BackgroundColor = System.Drawing.Color.White
        Me.gridcmp.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.gridcmp.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.gridcmp.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridcmp.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.gridcmp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridcmp.DefaultCellStyle = DataGridViewCellStyle8
        Me.gridcmp.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.gridcmp.GridColor = System.Drawing.SystemColors.Control
        Me.gridcmp.Location = New System.Drawing.Point(51, 72)
        Me.gridcmp.MultiSelect = False
        Me.gridcmp.Name = "gridcmp"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridcmp.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.gridcmp.RowHeadersVisible = False
        Me.gridcmp.RowHeadersWidth = 30
        Me.gridcmp.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White
        Me.gridcmp.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.gridcmp.RowTemplate.Height = 20
        Me.gridcmp.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridcmp.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gridcmp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridcmp.Size = New System.Drawing.Size(334, 168)
        Me.gridcmp.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(166, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(238, 25)
        Me.Label2.TabIndex = 211
        Me.Label2.Text = "Select Accounting Year"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.Image = Global.PrintPro.My.Resources.Resources.Close
        Me.PictureBox2.Location = New System.Drawing.Point(543, 12)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(15, 16)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 210
        Me.PictureBox2.TabStop = False
        '
        'cmddelete
        '
        Me.cmddelete.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddelete.ForeColor = System.Drawing.Color.Black
        Me.cmddelete.Location = New System.Drawing.Point(398, 321)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(104, 71)
        Me.cmddelete.TabIndex = 5
        Me.cmddelete.Text = "&Delete Existing Accounting Year"
        Me.cmddelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmddelete.UseVisualStyleBackColor = True
        '
        'cmdopen
        '
        Me.cmdopen.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdopen.ForeColor = System.Drawing.Color.Black
        Me.cmdopen.Location = New System.Drawing.Point(178, 321)
        Me.cmdopen.Name = "cmdopen"
        Me.cmdopen.Size = New System.Drawing.Size(104, 71)
        Me.cmdopen.TabIndex = 2
        Me.cmdopen.Text = "&Open Acounting Year"
        Me.cmdopen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdopen.UseVisualStyleBackColor = True
        '
        'cmdcreate
        '
        Me.cmdcreate.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcreate.ForeColor = System.Drawing.Color.Black
        Me.cmdcreate.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdcreate.Location = New System.Drawing.Point(68, 321)
        Me.cmdcreate.Name = "cmdcreate"
        Me.cmdcreate.Size = New System.Drawing.Size(104, 71)
        Me.cmdcreate.TabIndex = 1
        Me.cmdcreate.Text = "Create &New Accounting Year"
        Me.cmdcreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdcreate.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Image = Global.PrintPro.My.Resources.Resources.SelectYear
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(570, 313)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 207
        Me.PictureBox1.TabStop = False
        '
        'YearDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ClientSize = New System.Drawing.Size(570, 401)
        Me.Controls.Add(Me.BlendPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "YearDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Year"
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridcmp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents gridcmp As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents cmddelete As System.Windows.Forms.Button
    Friend WithEvents cmdopen As System.Windows.Forms.Button
    Friend WithEvents cmdcreate As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents CMDBACK As System.Windows.Forms.Button
End Class
