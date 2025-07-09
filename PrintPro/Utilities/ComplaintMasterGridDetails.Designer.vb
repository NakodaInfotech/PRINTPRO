<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ComplaintMasterGridDetails
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CMDADD = New System.Windows.Forms.Button()
        Me.CMDOK = New System.Windows.Forms.Button()
        Me.CMDEXIT = New System.Windows.Forms.Button()
        Me.GRIDCOMPLAINTMASTERDETAILS = New DevExpress.XtraGrid.GridControl()
        Me.GridComplaint = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCOMPNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOPERATORNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCOMPLAINDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREMARKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPROBLEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREASONNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGRIDREMARKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ToolEXCELSHEET = New System.Windows.Forms.ToolStrip()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.EXCELEXPORT = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Refresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.GRIDCOMPLAINTMASTERDETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridComplaint, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolEXCELSHEET.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.Color.White)
        Me.BlendPanel1.Controls.Add(Me.CMDADD)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel1.Controls.Add(Me.GRIDCOMPLAINTMASTERDETAILS)
        Me.BlendPanel1.Controls.Add(Me.ToolEXCELSHEET)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1108, 601)
        Me.BlendPanel1.TabIndex = 3
        '
        'CMDADD
        '
        Me.CMDADD.BackColor = System.Drawing.Color.Transparent
        Me.CMDADD.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDADD.FlatAppearance.BorderSize = 0
        Me.CMDADD.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDADD.ForeColor = System.Drawing.Color.Black
        Me.CMDADD.Location = New System.Drawing.Point(380, 542)
        Me.CMDADD.Name = "CMDADD"
        Me.CMDADD.Size = New System.Drawing.Size(80, 28)
        Me.CMDADD.TabIndex = 674
        Me.CMDADD.Text = "&Add New"
        Me.CMDADD.UseVisualStyleBackColor = False
        '
        'CMDOK
        '
        Me.CMDOK.BackColor = System.Drawing.Color.Transparent
        Me.CMDOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDOK.FlatAppearance.BorderSize = 0
        Me.CMDOK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.Black
        Me.CMDOK.Location = New System.Drawing.Point(466, 542)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(80, 28)
        Me.CMDOK.TabIndex = 2
        Me.CMDOK.Text = "&Ok"
        Me.CMDOK.UseVisualStyleBackColor = False
        '
        'CMDEXIT
        '
        Me.CMDEXIT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDEXIT.Location = New System.Drawing.Point(552, 542)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXIT.TabIndex = 3
        Me.CMDEXIT.Text = "E&xit"
        Me.CMDEXIT.UseVisualStyleBackColor = True
        '
        'GRIDCOMPLAINTMASTERDETAILS
        '
        Me.GRIDCOMPLAINTMASTERDETAILS.Location = New System.Drawing.Point(15, 43)
        Me.GRIDCOMPLAINTMASTERDETAILS.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GRIDCOMPLAINTMASTERDETAILS.MainView = Me.GridComplaint
        Me.GRIDCOMPLAINTMASTERDETAILS.Name = "GRIDCOMPLAINTMASTERDETAILS"
        Me.GRIDCOMPLAINTMASTERDETAILS.Size = New System.Drawing.Size(1058, 493)
        Me.GRIDCOMPLAINTMASTERDETAILS.TabIndex = 1
        Me.GRIDCOMPLAINTMASTERDETAILS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridComplaint})
        '
        'GridComplaint
        '
        Me.GridComplaint.AppearancePrint.Preview.BackColor = System.Drawing.Color.White
        Me.GridComplaint.AppearancePrint.Preview.Options.UseBackColor = True
        Me.GridComplaint.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCOMPNO, Me.GSRNO, Me.GOPERATORNAME, Me.GCOMPLAINDATE, Me.GREMARKS, Me.GPROBLEMNAME, Me.GREASONNAME, Me.GGRIDREMARKS})
        Me.GridComplaint.GridControl = Me.GRIDCOMPLAINTMASTERDETAILS
        Me.GridComplaint.Name = "GridComplaint"
        Me.GridComplaint.OptionsBehavior.Editable = False
        Me.GridComplaint.OptionsView.ColumnAutoWidth = False
        Me.GridComplaint.OptionsView.ShowAutoFilterRow = True
        Me.GridComplaint.OptionsView.ShowFooter = True
        Me.GridComplaint.PaintStyleName = "Skin"
        '
        'GCOMPNO
        '
        Me.GCOMPNO.Caption = "Comp No"
        Me.GCOMPNO.FieldName = "COMPNO"
        Me.GCOMPNO.Name = "GCOMPNO"
        Me.GCOMPNO.Visible = True
        Me.GCOMPNO.VisibleIndex = 0
        Me.GCOMPNO.Width = 68
        '
        'GSRNO
        '
        Me.GSRNO.Caption = "Grid Sr."
        Me.GSRNO.FieldName = "SRNO"
        Me.GSRNO.Name = "GSRNO"
        Me.GSRNO.Visible = True
        Me.GSRNO.VisibleIndex = 1
        Me.GSRNO.Width = 63
        '
        'GOPERATORNAME
        '
        Me.GOPERATORNAME.Caption = "Operator Nme"
        Me.GOPERATORNAME.FieldName = "OPERATO"
        Me.GOPERATORNAME.Name = "GOPERATORNAME"
        Me.GOPERATORNAME.Visible = True
        Me.GOPERATORNAME.VisibleIndex = 2
        Me.GOPERATORNAME.Width = 155
        '
        'GCOMPLAINDATE
        '
        Me.GCOMPLAINDATE.Caption = "Comp Date"
        Me.GCOMPLAINDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GCOMPLAINDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GCOMPLAINDATE.FieldName = "DATE"
        Me.GCOMPLAINDATE.Name = "GCOMPLAINDATE"
        Me.GCOMPLAINDATE.Visible = True
        Me.GCOMPLAINDATE.VisibleIndex = 3
        Me.GCOMPLAINDATE.Width = 111
        '
        'GREMARKS
        '
        Me.GREMARKS.Caption = "Remarks"
        Me.GREMARKS.FieldName = "REMARKS"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.Visible = True
        Me.GREMARKS.VisibleIndex = 4
        Me.GREMARKS.Width = 96
        '
        'GPROBLEMNAME
        '
        Me.GPROBLEMNAME.Caption = "Problem Name"
        Me.GPROBLEMNAME.FieldName = "PROBLEMNAME"
        Me.GPROBLEMNAME.Name = "GPROBLEMNAME"
        Me.GPROBLEMNAME.Visible = True
        Me.GPROBLEMNAME.VisibleIndex = 5
        Me.GPROBLEMNAME.Width = 166
        '
        'GREASONNAME
        '
        Me.GREASONNAME.Caption = "Reason Name"
        Me.GREASONNAME.FieldName = "REASONNAME"
        Me.GREASONNAME.Name = "GREASONNAME"
        Me.GREASONNAME.Visible = True
        Me.GREASONNAME.VisibleIndex = 6
        Me.GREASONNAME.Width = 137
        '
        'GGRIDREMARKS
        '
        Me.GGRIDREMARKS.Caption = "Grid Remarks"
        Me.GGRIDREMARKS.FieldName = "GRIDREMARKS"
        Me.GGRIDREMARKS.Name = "GGRIDREMARKS"
        Me.GGRIDREMARKS.Visible = True
        Me.GGRIDREMARKS.VisibleIndex = 7
        Me.GGRIDREMARKS.Width = 228
        '
        'ToolEXCELSHEET
        '
        Me.ToolEXCELSHEET.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripSeparator, Me.EXCELEXPORT, Me.ToolStripSeparator1, Me.Refresh, Me.ToolStripSeparator2})
        Me.ToolEXCELSHEET.Location = New System.Drawing.Point(0, 0)
        Me.ToolEXCELSHEET.Name = "ToolEXCELSHEET"
        Me.ToolEXCELSHEET.Size = New System.Drawing.Size(1108, 25)
        Me.ToolEXCELSHEET.TabIndex = 258
        Me.ToolEXCELSHEET.Text = "ToolStrip1"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'EXCELEXPORT
        '
        Me.EXCELEXPORT.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.EXCELEXPORT.Image = Global.PrintPro.My.Resources.Resources.Excel_icon
        Me.EXCELEXPORT.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EXCELEXPORT.Name = "EXCELEXPORT"
        Me.EXCELEXPORT.Size = New System.Drawing.Size(23, 22)
        Me.EXCELEXPORT.Text = "&Excel"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'Refresh
        '
        Me.Refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Refresh.Image = Global.PrintPro.My.Resources.Resources.refresh1
        Me.Refresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Refresh.Name = "Refresh"
        Me.Refresh.Size = New System.Drawing.Size(23, 22)
        Me.Refresh.Text = "ToolStripButton2"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ComplaintMasterGridDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1108, 601)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Name = "ComplaintMasterGridDetails"
        Me.Text = "ComplaintMasterGridDetails"
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.GRIDCOMPLAINTMASTERDETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridComplaint, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolEXCELSHEET.ResumeLayout(False)
        Me.ToolEXCELSHEET.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMDADD As Button
    Friend WithEvents CMDOK As Button
    Friend WithEvents CMDEXIT As Button
    Friend WithEvents GRIDCOMPLAINTMASTERDETAILS As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridComplaint As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCOMPNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOPERATORNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCOMPLAINDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREMARKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPROBLEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREASONNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGRIDREMARKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ToolEXCELSHEET As ToolStrip
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents EXCELEXPORT As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents Refresh As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
End Class
