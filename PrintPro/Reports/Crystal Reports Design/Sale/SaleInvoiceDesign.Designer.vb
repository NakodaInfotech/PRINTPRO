<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SaleInvoiceDesign
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.SendMail = New System.Windows.Forms.ToolStripButton()
        Me.TOOLDIGITALSIGN = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CRPO = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.lbCerts = New DevExpress.XtraEditors.ListBoxControl()
        Me.pdfViewer = New DevExpress.XtraPdfViewer.PdfViewer()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.lbCerts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SendMail, Me.TOOLDIGITALSIGN, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1208, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'SendMail
        '
        Me.SendMail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SendMail.Image = Global.PrintPro.My.Resources.Resources.sendforms
        Me.SendMail.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SendMail.Name = "SendMail"
        Me.SendMail.Size = New System.Drawing.Size(23, 22)
        Me.SendMail.Text = "Send Mail"
        '
        'TOOLDIGITALSIGN
        '
        Me.TOOLDIGITALSIGN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLDIGITALSIGN.Image = Global.PrintPro.My.Resources.Resources.DIGITAL_SIGN
        Me.TOOLDIGITALSIGN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLDIGITALSIGN.Name = "TOOLDIGITALSIGN"
        Me.TOOLDIGITALSIGN.Size = New System.Drawing.Size(23, 22)
        Me.TOOLDIGITALSIGN.Text = "Digital Signature"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'CRPO
        '
        Me.CRPO.ActiveViewIndex = -1
        Me.CRPO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRPO.Cursor = System.Windows.Forms.Cursors.Default
        Me.CRPO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRPO.Location = New System.Drawing.Point(0, 25)
        Me.CRPO.Name = "CRPO"
        Me.CRPO.SelectionFormula = ""
        Me.CRPO.Size = New System.Drawing.Size(1208, 473)
        Me.CRPO.TabIndex = 1
        Me.CRPO.ViewTimeSelectionFormula = ""
        '
        'lbCerts
        '
        Me.lbCerts.DisplayMember = "Name"
        Me.lbCerts.ItemAutoHeight = True
        Me.lbCerts.Location = New System.Drawing.Point(12, 348)
        Me.lbCerts.Name = "lbCerts"
        Me.lbCerts.Size = New System.Drawing.Size(152, 83)
        Me.lbCerts.TabIndex = 2
        Me.lbCerts.Visible = False
        '
        'pdfViewer
        '
        Me.pdfViewer.Location = New System.Drawing.Point(12, 83)
        Me.pdfViewer.Name = "pdfViewer"
        Me.pdfViewer.NavigationPaneInitialVisibility = DevExpress.XtraPdfViewer.PdfNavigationPaneVisibility.Hidden
        Me.pdfViewer.ReadOnly = True
        Me.pdfViewer.Size = New System.Drawing.Size(152, 259)
        Me.pdfViewer.TabIndex = 7
        Me.pdfViewer.TabStop = False
        Me.pdfViewer.Visible = False
        Me.pdfViewer.ZoomMode = DevExpress.XtraPdfViewer.PdfZoomMode.FitToWidth
        '
        'SaleInvoiceDesign
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1208, 498)
        Me.Controls.Add(Me.pdfViewer)
        Me.Controls.Add(Me.lbCerts)
        Me.Controls.Add(Me.CRPO)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "SaleInvoiceDesign"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Sale Invoice Design"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.lbCerts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents SendMail As System.Windows.Forms.ToolStripButton
    Friend WithEvents CRPO As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Private WithEvents lbCerts As DevExpress.XtraEditors.ListBoxControl
    Private WithEvents pdfViewer As DevExpress.XtraPdfViewer.PdfViewer
    Friend WithEvents TOOLDIGITALSIGN As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
End Class
