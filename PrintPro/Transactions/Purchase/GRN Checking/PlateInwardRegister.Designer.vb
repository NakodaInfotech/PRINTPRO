<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PlateInwardregister
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
        Me.PLATEINWARD = New DevExpress.XtraGrid.GridControl()
        Me.GRIDPLATEINWARD = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCHECKINGNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCMPNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GINSPECTEDBY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPLATENAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTEXTMATTER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGRIPPER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREGISTRATIONMARK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GACCEPTED = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPRODUCTCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFILENO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREMARKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ToolEXCELSHEET = New System.Windows.Forms.ToolStrip()
        Me.ADDNEW = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.EXCELEXPORT = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.TOOLREFRESH = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.CMDOK = New System.Windows.Forms.Button()
        Me.CMDEXIT = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.GLOTNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSIZE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCHKQTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GACCEPTQTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREJQTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.PLATEINWARD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDPLATEINWARD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolEXCELSHEET.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.Color.White)
        Me.BlendPanel1.Controls.Add(Me.PLATEINWARD)
        Me.BlendPanel1.Controls.Add(Me.ToolEXCELSHEET)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1317, 582)
        Me.BlendPanel1.TabIndex = 2
        '
        'PLATEINWARD
        '
        Me.PLATEINWARD.Location = New System.Drawing.Point(15, 28)
        Me.PLATEINWARD.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PLATEINWARD.MainView = Me.GRIDPLATEINWARD
        Me.PLATEINWARD.Name = "PLATEINWARD"
        Me.PLATEINWARD.Size = New System.Drawing.Size(1299, 515)
        Me.PLATEINWARD.TabIndex = 675
        Me.PLATEINWARD.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDPLATEINWARD})
        '
        'GRIDPLATEINWARD
        '
        Me.GRIDPLATEINWARD.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDPLATEINWARD.Appearance.HeaderPanel.Options.UseFont = True
        Me.GRIDPLATEINWARD.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDPLATEINWARD.Appearance.Row.Options.UseFont = True
        Me.GRIDPLATEINWARD.AppearancePrint.Preview.BackColor = System.Drawing.Color.White
        Me.GRIDPLATEINWARD.AppearancePrint.Preview.Options.UseBackColor = True
        Me.GRIDPLATEINWARD.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCHECKINGNO, Me.GCMPNAME, Me.GDATE, Me.GPLATENAME, Me.GNAME, Me.GINSPECTEDBY, Me.GPRODUCTCODE, Me.GFILENO, Me.GLOTNO, Me.GSIZE, Me.GWT, Me.GCHKQTY, Me.GACCEPTQTY, Me.GREJQTY, Me.GTEXTMATTER, Me.GREGISTRATIONMARK, Me.GGRIPPER, Me.GACCEPTED, Me.GREMARKS})
        Me.GRIDPLATEINWARD.GridControl = Me.PLATEINWARD
        Me.GRIDPLATEINWARD.Name = "GRIDPLATEINWARD"
        Me.GRIDPLATEINWARD.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GRIDPLATEINWARD.OptionsBehavior.Editable = False
        Me.GRIDPLATEINWARD.OptionsCustomization.AllowRowSizing = True
        Me.GRIDPLATEINWARD.OptionsView.ColumnAutoWidth = False
        Me.GRIDPLATEINWARD.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GRIDPLATEINWARD.OptionsView.ShowAutoFilterRow = True
        Me.GRIDPLATEINWARD.OptionsView.ShowFooter = True
        '
        'GCHECKINGNO
        '
        Me.GCHECKINGNO.Caption = "Checking No"
        Me.GCHECKINGNO.FieldName = "CHKNO"
        Me.GCHECKINGNO.Name = "GCHECKINGNO"
        Me.GCHECKINGNO.OptionsColumn.AllowEdit = False
        Me.GCHECKINGNO.Visible = True
        Me.GCHECKINGNO.VisibleIndex = 0
        Me.GCHECKINGNO.Width = 88
        '
        'GCMPNAME
        '
        Me.GCMPNAME.Caption = "Cmp Name"
        Me.GCMPNAME.FieldName = "CMPNAME"
        Me.GCMPNAME.Name = "GCMPNAME"
        Me.GCMPNAME.Visible = True
        Me.GCMPNAME.VisibleIndex = 1
        '
        'GDATE
        '
        Me.GDATE.Caption = "Date"
        Me.GDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDATE.FieldName = "DATE"
        Me.GDATE.Name = "GDATE"
        Me.GDATE.Visible = True
        Me.GDATE.VisibleIndex = 2
        Me.GDATE.Width = 102
        '
        'GINSPECTEDBY
        '
        Me.GINSPECTEDBY.Caption = "Inspected BY"
        Me.GINSPECTEDBY.FieldName = "CHECKEDBY"
        Me.GINSPECTEDBY.Name = "GINSPECTEDBY"
        Me.GINSPECTEDBY.Visible = True
        Me.GINSPECTEDBY.VisibleIndex = 5
        Me.GINSPECTEDBY.Width = 116
        '
        'GPLATENAME
        '
        Me.GPLATENAME.Caption = "Platename"
        Me.GPLATENAME.FieldName = "ITEMNAME"
        Me.GPLATENAME.Name = "GPLATENAME"
        Me.GPLATENAME.Visible = True
        Me.GPLATENAME.VisibleIndex = 3
        Me.GPLATENAME.Width = 200
        '
        'GTEXTMATTER
        '
        Me.GTEXTMATTER.Caption = "Text Matter"
        Me.GTEXTMATTER.FieldName = "TEXTMATTER"
        Me.GTEXTMATTER.Name = "GTEXTMATTER"
        Me.GTEXTMATTER.OptionsColumn.AllowEdit = False
        Me.GTEXTMATTER.Visible = True
        Me.GTEXTMATTER.VisibleIndex = 14
        Me.GTEXTMATTER.Width = 86
        '
        'GGRIPPER
        '
        Me.GGRIPPER.Caption = "Gripper"
        Me.GGRIPPER.FieldName = "GRIPPER"
        Me.GGRIPPER.Name = "GGRIPPER"
        Me.GGRIPPER.OptionsColumn.AllowEdit = False
        Me.GGRIPPER.Visible = True
        Me.GGRIPPER.VisibleIndex = 16
        Me.GGRIPPER.Width = 86
        '
        'GREGISTRATIONMARK
        '
        Me.GREGISTRATIONMARK.Caption = "Registration Mark"
        Me.GREGISTRATIONMARK.FieldName = "REGISTRATIONMARK"
        Me.GREGISTRATIONMARK.Name = "GREGISTRATIONMARK"
        Me.GREGISTRATIONMARK.OptionsColumn.AllowEdit = False
        Me.GREGISTRATIONMARK.Visible = True
        Me.GREGISTRATIONMARK.VisibleIndex = 15
        Me.GREGISTRATIONMARK.Width = 127
        '
        'GACCEPTED
        '
        Me.GACCEPTED.Caption = "Accepted"
        Me.GACCEPTED.FieldName = "ACCEPTED"
        Me.GACCEPTED.Name = "GACCEPTED"
        Me.GACCEPTED.OptionsColumn.AllowEdit = False
        Me.GACCEPTED.Visible = True
        Me.GACCEPTED.VisibleIndex = 17
        Me.GACCEPTED.Width = 80
        '
        'GPRODUCTCODE
        '
        Me.GPRODUCTCODE.Caption = "Product Code"
        Me.GPRODUCTCODE.FieldName = "ITEMCODE"
        Me.GPRODUCTCODE.Name = "GPRODUCTCODE"
        Me.GPRODUCTCODE.Visible = True
        Me.GPRODUCTCODE.VisibleIndex = 6
        Me.GPRODUCTCODE.Width = 103
        '
        'GFILENO
        '
        Me.GFILENO.Caption = "File No"
        Me.GFILENO.FieldName = "FILENO"
        Me.GFILENO.Name = "GFILENO"
        Me.GFILENO.Visible = True
        Me.GFILENO.VisibleIndex = 7
        Me.GFILENO.Width = 80
        '
        'GREMARKS
        '
        Me.GREMARKS.Caption = "Remarks"
        Me.GREMARKS.FieldName = "GRIDREMARKS"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.Visible = True
        Me.GREMARKS.VisibleIndex = 18
        Me.GREMARKS.Width = 100
        '
        'ToolEXCELSHEET
        '
        Me.ToolEXCELSHEET.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ADDNEW, Me.ToolStripSeparator3, Me.EXCELEXPORT, Me.ToolStripSeparator4, Me.TOOLREFRESH, Me.ToolStripSeparator5, Me.ToolStripSeparator6})
        Me.ToolEXCELSHEET.Location = New System.Drawing.Point(0, 0)
        Me.ToolEXCELSHEET.Name = "ToolEXCELSHEET"
        Me.ToolEXCELSHEET.Size = New System.Drawing.Size(1317, 25)
        Me.ToolEXCELSHEET.TabIndex = 656
        Me.ToolEXCELSHEET.Text = "ToolStrip1"
        '
        'ADDNEW
        '
        Me.ADDNEW.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ADDNEW.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ADDNEW.Name = "ADDNEW"
        Me.ADDNEW.Size = New System.Drawing.Size(62, 22)
        Me.ADDNEW.Text = "Add New"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
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
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'TOOLREFRESH
        '
        Me.TOOLREFRESH.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLREFRESH.Image = Global.PrintPro.My.Resources.Resources.refresh1
        Me.TOOLREFRESH.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLREFRESH.Name = "TOOLREFRESH"
        Me.TOOLREFRESH.Size = New System.Drawing.Size(23, 22)
        Me.TOOLREFRESH.Text = "REFRESH"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'CMDOK
        '
        Me.CMDOK.BackColor = System.Drawing.Color.Transparent
        Me.CMDOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDOK.FlatAppearance.BorderSize = 0
        Me.CMDOK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.Black
        Me.CMDOK.Location = New System.Drawing.Point(534, 551)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(80, 28)
        Me.CMDOK.TabIndex = 259
        Me.CMDOK.Text = "&Ok"
        Me.CMDOK.UseVisualStyleBackColor = False
        '
        'CMDEXIT
        '
        Me.CMDEXIT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDEXIT.Location = New System.Drawing.Point(620, 551)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXIT.TabIndex = 260
        Me.CMDEXIT.Text = "E&xit"
        Me.CMDEXIT.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.toolStripSeparator, Me.PrintToolStripButton, Me.ToolStripSeparator1, Me.ToolStripRefresh, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1234, 25)
        Me.ToolStrip1.TabIndex = 257
        Me.ToolStrip1.Text = "ToolStrip1"
        Me.ToolStrip1.Visible = False
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(62, 22)
        Me.ToolStripButton1.Text = "Add New"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = Global.PrintPro.My.Resources.Resources.Excel_icon
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PrintToolStripButton.Text = "&Print"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripRefresh
        '
        Me.ToolStripRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripRefresh.Image = Global.PrintPro.My.Resources.Resources.refresh1
        Me.ToolStripRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripRefresh.Name = "ToolStripRefresh"
        Me.ToolStripRefresh.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripRefresh.Text = "ToolStripButton2"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'GLOTNO
        '
        Me.GLOTNO.Caption = "Lot No"
        Me.GLOTNO.FieldName = "LOTNO"
        Me.GLOTNO.Name = "GLOTNO"
        Me.GLOTNO.Visible = True
        Me.GLOTNO.VisibleIndex = 8
        Me.GLOTNO.Width = 80
        '
        'GNAME
        '
        Me.GNAME.Caption = "Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 4
        Me.GNAME.Width = 200
        '
        'GSIZE
        '
        Me.GSIZE.Caption = "Size"
        Me.GSIZE.FieldName = "SIZE"
        Me.GSIZE.Name = "GSIZE"
        Me.GSIZE.Visible = True
        Me.GSIZE.VisibleIndex = 9
        Me.GSIZE.Width = 80
        '
        'GWT
        '
        Me.GWT.Caption = "Wt"
        Me.GWT.FieldName = "WT"
        Me.GWT.Name = "GWT"
        Me.GWT.Visible = True
        Me.GWT.VisibleIndex = 10
        Me.GWT.Width = 80
        '
        'GCHKQTY
        '
        Me.GCHKQTY.Caption = "Check Qty"
        Me.GCHKQTY.FieldName = "CHECKQTY"
        Me.GCHKQTY.Name = "GCHKQTY"
        Me.GCHKQTY.Visible = True
        Me.GCHKQTY.VisibleIndex = 11
        Me.GCHKQTY.Width = 80
        '
        'GACCEPTQTY
        '
        Me.GACCEPTQTY.Caption = "Acc Qty"
        Me.GACCEPTQTY.FieldName = "ACCQTY"
        Me.GACCEPTQTY.Name = "GACCEPTQTY"
        Me.GACCEPTQTY.Visible = True
        Me.GACCEPTQTY.VisibleIndex = 12
        Me.GACCEPTQTY.Width = 80
        '
        'GREJQTY
        '
        Me.GREJQTY.Caption = "Rej Qty"
        Me.GREJQTY.FieldName = "REJQTY"
        Me.GREJQTY.Name = "GREJQTY"
        Me.GREJQTY.Visible = True
        Me.GREJQTY.VisibleIndex = 13
        Me.GREJQTY.Width = 80
        '
        'PlateInwardregister
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1317, 582)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Name = "PlateInwardregister"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "PlateInwardRegister"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.PLATEINWARD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDPLATEINWARD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolEXCELSHEET.ResumeLayout(False)
        Me.ToolEXCELSHEET.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents PLATEINWARD As DevExpress.XtraGrid.GridControl
    Friend WithEvents GRIDPLATEINWARD As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ToolEXCELSHEET As ToolStrip
    Friend WithEvents ADDNEW As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents EXCELEXPORT As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents TOOLREFRESH As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents CMDOK As Button
    Friend WithEvents CMDEXIT As Button
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents PrintToolStripButton As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripRefresh As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents GCHECKINGNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFILENO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPRODUCTCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPLATENAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTEXTMATTER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGRIPPER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREGISTRATIONMARK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GACCEPTED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GINSPECTEDBY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREMARKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCMPNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLOTNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSIZE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHKQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GACCEPTQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREJQTY As DevExpress.XtraGrid.Columns.GridColumn
End Class
