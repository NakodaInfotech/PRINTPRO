<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ItemExpiryDetailsReport
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
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GITEMCODE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GFILENO = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GPROOFSEND = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GPROOFSENDDATE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GPROOFOK = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GPROOFOKDATE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GPERFORATION = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GSHADESEND = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GSHADESENDDATE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GSHADEAPP = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GSHADEAPPDATE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GVALIDTILLDATE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCOORDINATOR = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GFONTS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GSCREEN = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GDESIGN = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GVARNISH = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GPARALLEL = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCROSS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GKNIFE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GSIDETOPRINT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GARTWORKRECDONDATE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GARTIST = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GSOFTWARE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCOLOR = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GACTUALSIZEHEIGHT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GPHARMACODE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GMATERIAL = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GNOOFUPS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GMATERIALCODE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GPRINTREPEATLENGTH = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GLINKS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GPAPERGSM = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GACTUALSIZEWIDTH = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GAFTERFOLDINGWIDTH = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GAFTERFOLDINGHEIGHT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GPAPERCUTSIZE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GPAPERSIZENAME = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTAPETYPE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GGRAINDIRECTION = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GARTWORKREMARKS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GREMARKS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.CMDSAVE = New System.Windows.Forms.Button
        Me.CMDPRINT = New System.Windows.Forms.Button
        Me.cmdcancel = New System.Windows.Forms.Button
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(13, 32)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(962, 493)
        Me.gridbilldetails.TabIndex = 504
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GITEMNAME, Me.GITEMCODE, Me.GFILENO, Me.GPROOFSEND, Me.GPROOFSENDDATE, Me.GPROOFOK, Me.GPROOFOKDATE, Me.GPERFORATION, Me.GSHADESEND, Me.GSHADESENDDATE, Me.GSHADEAPP, Me.GSHADEAPPDATE, Me.GVALIDTILLDATE, Me.GCOORDINATOR, Me.GFONTS, Me.GSCREEN, Me.GDESIGN, Me.GVARNISH, Me.GPARALLEL, Me.GCROSS, Me.GKNIFE, Me.GSIDETOPRINT, Me.GARTWORKRECDONDATE, Me.GARTIST, Me.GSOFTWARE, Me.GCOLOR, Me.GACTUALSIZEHEIGHT, Me.GPHARMACODE, Me.GMATERIAL, Me.GNOOFUPS, Me.GMATERIALCODE, Me.GPRINTREPEATLENGTH, Me.GLINKS, Me.GPAPERGSM, Me.GACTUALSIZEWIDTH, Me.GAFTERFOLDINGWIDTH, Me.GAFTERFOLDINGHEIGHT, Me.GPAPERCUTSIZE, Me.GPAPERSIZENAME, Me.GTAPETYPE, Me.GGRAINDIRECTION, Me.GARTWORKREMARKS, Me.GREMARKS})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        '
        'GITEMNAME
        '
        Me.GITEMNAME.Caption = "Item Name"
        Me.GITEMNAME.FieldName = "ITEMNAME"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.Visible = True
        Me.GITEMNAME.VisibleIndex = 0
        Me.GITEMNAME.Width = 150
        '
        'GITEMCODE
        '
        Me.GITEMCODE.Caption = "Item Code"
        Me.GITEMCODE.FieldName = "ITEMCODE"
        Me.GITEMCODE.Name = "GITEMCODE"
        Me.GITEMCODE.Visible = True
        Me.GITEMCODE.VisibleIndex = 2
        Me.GITEMCODE.Width = 100
        '
        'GFILENO
        '
        Me.GFILENO.Caption = "File No."
        Me.GFILENO.FieldName = "FILENO"
        Me.GFILENO.Name = "GFILENO"
        Me.GFILENO.Visible = True
        Me.GFILENO.VisibleIndex = 3
        Me.GFILENO.Width = 100
        '
        'GPROOFSEND
        '
        Me.GPROOFSEND.Caption = "Proof Send"
        Me.GPROOFSEND.FieldName = "PROOFSEND"
        Me.GPROOFSEND.Name = "GPROOFSEND"
        Me.GPROOFSEND.Visible = True
        Me.GPROOFSEND.VisibleIndex = 4
        '
        'GPROOFSENDDATE
        '
        Me.GPROOFSENDDATE.Caption = "Proof Send Dt."
        Me.GPROOFSENDDATE.FieldName = "PROOFSENDDATE"
        Me.GPROOFSENDDATE.Name = "GPROOFSENDDATE"
        Me.GPROOFSENDDATE.Visible = True
        Me.GPROOFSENDDATE.VisibleIndex = 5
        Me.GPROOFSENDDATE.Width = 83
        '
        'GPROOFOK
        '
        Me.GPROOFOK.Caption = "Proof Ok"
        Me.GPROOFOK.FieldName = "PROOFOK"
        Me.GPROOFOK.Name = "GPROOFOK"
        Me.GPROOFOK.Visible = True
        Me.GPROOFOK.VisibleIndex = 6
        '
        'GPROOFOKDATE
        '
        Me.GPROOFOKDATE.Caption = "Proof Ok Dt."
        Me.GPROOFOKDATE.FieldName = "PROOFOKDATE"
        Me.GPROOFOKDATE.Name = "GPROOFOKDATE"
        Me.GPROOFOKDATE.Visible = True
        Me.GPROOFOKDATE.VisibleIndex = 7
        '
        'GPERFORATION
        '
        Me.GPERFORATION.Caption = "Perforation"
        Me.GPERFORATION.FieldName = "PERFORATION"
        Me.GPERFORATION.Name = "GPERFORATION"
        Me.GPERFORATION.Visible = True
        Me.GPERFORATION.VisibleIndex = 9
        '
        'GSHADESEND
        '
        Me.GSHADESEND.Caption = "Shade Send"
        Me.GSHADESEND.FieldName = "SHADECARD"
        Me.GSHADESEND.Name = "GSHADESEND"
        Me.GSHADESEND.Visible = True
        Me.GSHADESEND.VisibleIndex = 8
        '
        'GSHADESENDDATE
        '
        Me.GSHADESENDDATE.Caption = "Shade Send Dt."
        Me.GSHADESENDDATE.FieldName = "SHADESENDDATE"
        Me.GSHADESENDDATE.Name = "GSHADESENDDATE"
        Me.GSHADESENDDATE.Visible = True
        Me.GSHADESENDDATE.VisibleIndex = 11
        '
        'GSHADEAPP
        '
        Me.GSHADEAPP.Caption = "Shade Approve"
        Me.GSHADEAPP.FieldName = "SHADEAPPROVE"
        Me.GSHADEAPP.Name = "GSHADEAPP"
        Me.GSHADEAPP.Visible = True
        Me.GSHADEAPP.VisibleIndex = 10
        '
        'GSHADEAPPDATE
        '
        Me.GSHADEAPPDATE.Caption = "Shade App. Dt."
        Me.GSHADEAPPDATE.FieldName = "SHADEAPPDATE"
        Me.GSHADEAPPDATE.Name = "GSHADEAPPDATE"
        Me.GSHADEAPPDATE.Visible = True
        Me.GSHADEAPPDATE.VisibleIndex = 12
        '
        'GVALIDTILLDATE
        '
        Me.GVALIDTILLDATE.Caption = "Valid Till Dt."
        Me.GVALIDTILLDATE.FieldName = "SHADEDATE"
        Me.GVALIDTILLDATE.Name = "GVALIDTILLDATE"
        Me.GVALIDTILLDATE.Visible = True
        Me.GVALIDTILLDATE.VisibleIndex = 13
        '
        'GCOORDINATOR
        '
        Me.GCOORDINATOR.Caption = "Coordinator"
        Me.GCOORDINATOR.FieldName = "COORDINATORNAME"
        Me.GCOORDINATOR.Name = "GCOORDINATOR"
        Me.GCOORDINATOR.Visible = True
        Me.GCOORDINATOR.VisibleIndex = 14
        '
        'GFONTS
        '
        Me.GFONTS.Caption = "Fonts"
        Me.GFONTS.FieldName = "FONTS"
        Me.GFONTS.Name = "GFONTS"
        Me.GFONTS.Visible = True
        Me.GFONTS.VisibleIndex = 15
        '
        'GSCREEN
        '
        Me.GSCREEN.Caption = "Screen"
        Me.GSCREEN.FieldName = "SCREEN"
        Me.GSCREEN.Name = "GSCREEN"
        Me.GSCREEN.Visible = True
        Me.GSCREEN.VisibleIndex = 16
        '
        'GDESIGN
        '
        Me.GDESIGN.Caption = "Design"
        Me.GDESIGN.FieldName = "DESIGN"
        Me.GDESIGN.Name = "GDESIGN"
        Me.GDESIGN.Visible = True
        Me.GDESIGN.VisibleIndex = 17
        '
        'GVARNISH
        '
        Me.GVARNISH.Caption = "Varnish"
        Me.GVARNISH.FieldName = "VARNISH"
        Me.GVARNISH.Name = "GVARNISH"
        Me.GVARNISH.Visible = True
        Me.GVARNISH.VisibleIndex = 18
        '
        'GPARALLEL
        '
        Me.GPARALLEL.Caption = "Parallel"
        Me.GPARALLEL.FieldName = "VERTICAL"
        Me.GPARALLEL.Name = "GPARALLEL"
        Me.GPARALLEL.Visible = True
        Me.GPARALLEL.VisibleIndex = 19
        '
        'GCROSS
        '
        Me.GCROSS.Caption = "Cross"
        Me.GCROSS.FieldName = "HORIZONTAL"
        Me.GCROSS.Name = "GCROSS"
        Me.GCROSS.Visible = True
        Me.GCROSS.VisibleIndex = 20
        '
        'GKNIFE
        '
        Me.GKNIFE.Caption = "Knife"
        Me.GKNIFE.FieldName = "KNIFES"
        Me.GKNIFE.Name = "GKNIFE"
        Me.GKNIFE.Visible = True
        Me.GKNIFE.VisibleIndex = 21
        '
        'GSIDETOPRINT
        '
        Me.GSIDETOPRINT.Caption = "Side To Print"
        Me.GSIDETOPRINT.FieldName = "SIDEPRINT"
        Me.GSIDETOPRINT.Name = "GSIDETOPRINT"
        Me.GSIDETOPRINT.Visible = True
        Me.GSIDETOPRINT.VisibleIndex = 22
        '
        'GARTWORKRECDONDATE
        '
        Me.GARTWORKRECDONDATE.Caption = "ArtWork Recd. On Dt."
        Me.GARTWORKRECDONDATE.FieldName = "ARTWORKDATE"
        Me.GARTWORKRECDONDATE.Name = "GARTWORKRECDONDATE"
        Me.GARTWORKRECDONDATE.Visible = True
        Me.GARTWORKRECDONDATE.VisibleIndex = 23
        '
        'GARTIST
        '
        Me.GARTIST.Caption = "Artist"
        Me.GARTIST.FieldName = "ARTIST"
        Me.GARTIST.Name = "GARTIST"
        Me.GARTIST.Visible = True
        Me.GARTIST.VisibleIndex = 24
        '
        'GSOFTWARE
        '
        Me.GSOFTWARE.Caption = "Software"
        Me.GSOFTWARE.FieldName = "SOFTWARE"
        Me.GSOFTWARE.Name = "GSOFTWARE"
        Me.GSOFTWARE.Visible = True
        Me.GSOFTWARE.VisibleIndex = 25
        '
        'GCOLOR
        '
        Me.GCOLOR.Caption = "Color"
        Me.GCOLOR.FieldName = "COLOR"
        Me.GCOLOR.Name = "GCOLOR"
        Me.GCOLOR.Visible = True
        Me.GCOLOR.VisibleIndex = 26
        '
        'GACTUALSIZEHEIGHT
        '
        Me.GACTUALSIZEHEIGHT.Caption = "Actual Size Height"
        Me.GACTUALSIZEHEIGHT.FieldName = "ACTUALHEIGHT"
        Me.GACTUALSIZEHEIGHT.Name = "GACTUALSIZEHEIGHT"
        Me.GACTUALSIZEHEIGHT.Visible = True
        Me.GACTUALSIZEHEIGHT.VisibleIndex = 27
        '
        'GPHARMACODE
        '
        Me.GPHARMACODE.Caption = "Pharmacode"
        Me.GPHARMACODE.FieldName = "PHARMACODE"
        Me.GPHARMACODE.Name = "GPHARMACODE"
        Me.GPHARMACODE.Visible = True
        Me.GPHARMACODE.VisibleIndex = 28
        '
        'GMATERIAL
        '
        Me.GMATERIAL.Caption = "Material"
        Me.GMATERIAL.FieldName = "PAPERMATERIALNAME"
        Me.GMATERIAL.Name = "GMATERIAL"
        Me.GMATERIAL.Visible = True
        Me.GMATERIAL.VisibleIndex = 29
        '
        'GNOOFUPS
        '
        Me.GNOOFUPS.Caption = "No. Of Ups"
        Me.GNOOFUPS.FieldName = "UPS"
        Me.GNOOFUPS.Name = "GNOOFUPS"
        Me.GNOOFUPS.Visible = True
        Me.GNOOFUPS.VisibleIndex = 30
        '
        'GMATERIALCODE
        '
        Me.GMATERIALCODE.Caption = "Material Code"
        Me.GMATERIALCODE.FieldName = "MATERIALCODE"
        Me.GMATERIALCODE.Name = "GMATERIALCODE"
        Me.GMATERIALCODE.Visible = True
        Me.GMATERIALCODE.VisibleIndex = 31
        '
        'GPRINTREPEATLENGTH
        '
        Me.GPRINTREPEATLENGTH.Caption = "Print Repeat Length"
        Me.GPRINTREPEATLENGTH.FieldName = "REPEATLENGTH"
        Me.GPRINTREPEATLENGTH.Name = "GPRINTREPEATLENGTH"
        Me.GPRINTREPEATLENGTH.Visible = True
        Me.GPRINTREPEATLENGTH.VisibleIndex = 32
        '
        'GLINKS
        '
        Me.GLINKS.Caption = "Links"
        Me.GLINKS.FieldName = "LINKS"
        Me.GLINKS.Name = "GLINKS"
        Me.GLINKS.Visible = True
        Me.GLINKS.VisibleIndex = 1
        '
        'GPAPERGSM
        '
        Me.GPAPERGSM.Caption = "Paper GSM"
        Me.GPAPERGSM.FieldName = "PAPERGSM"
        Me.GPAPERGSM.Name = "GPAPERGSM"
        Me.GPAPERGSM.Visible = True
        Me.GPAPERGSM.VisibleIndex = 33
        '
        'GACTUALSIZEWIDTH
        '
        Me.GACTUALSIZEWIDTH.Caption = "Actual Size Width"
        Me.GACTUALSIZEWIDTH.FieldName = "ACTUALWIDTH"
        Me.GACTUALSIZEWIDTH.Name = "GACTUALSIZEWIDTH"
        Me.GACTUALSIZEWIDTH.Visible = True
        Me.GACTUALSIZEWIDTH.VisibleIndex = 34
        '
        'GAFTERFOLDINGWIDTH
        '
        Me.GAFTERFOLDINGWIDTH.Caption = "After Folding Width"
        Me.GAFTERFOLDINGWIDTH.FieldName = "FOLDWIDTH"
        Me.GAFTERFOLDINGWIDTH.Name = "GAFTERFOLDINGWIDTH"
        Me.GAFTERFOLDINGWIDTH.Visible = True
        Me.GAFTERFOLDINGWIDTH.VisibleIndex = 35
        '
        'GAFTERFOLDINGHEIGHT
        '
        Me.GAFTERFOLDINGHEIGHT.Caption = "After Folding Height"
        Me.GAFTERFOLDINGHEIGHT.FieldName = "FOLDHEIGHT"
        Me.GAFTERFOLDINGHEIGHT.Name = "GAFTERFOLDINGHEIGHT"
        Me.GAFTERFOLDINGHEIGHT.Visible = True
        Me.GAFTERFOLDINGHEIGHT.VisibleIndex = 36
        '
        'GPAPERCUTSIZE
        '
        Me.GPAPERCUTSIZE.Caption = "Paper Cut Size"
        Me.GPAPERCUTSIZE.FieldName = "CUTSIZE"
        Me.GPAPERCUTSIZE.Name = "GPAPERCUTSIZE"
        Me.GPAPERCUTSIZE.Visible = True
        Me.GPAPERCUTSIZE.VisibleIndex = 37
        '
        'GPAPERSIZENAME
        '
        Me.GPAPERSIZENAME.Caption = "Paper Size "
        Me.GPAPERSIZENAME.FieldName = "PAPERSIZENAME"
        Me.GPAPERSIZENAME.Name = "GPAPERSIZENAME"
        Me.GPAPERSIZENAME.Visible = True
        Me.GPAPERSIZENAME.VisibleIndex = 38
        '
        'GTAPETYPE
        '
        Me.GTAPETYPE.Caption = "Tape Type"
        Me.GTAPETYPE.FieldName = "TEARTYPE"
        Me.GTAPETYPE.Name = "GTAPETYPE"
        Me.GTAPETYPE.Visible = True
        Me.GTAPETYPE.VisibleIndex = 39
        '
        'GGRAINDIRECTION
        '
        Me.GGRAINDIRECTION.Caption = "Grain Direction"
        Me.GGRAINDIRECTION.FieldName = "GRAIN"
        Me.GGRAINDIRECTION.Name = "GGRAINDIRECTION"
        Me.GGRAINDIRECTION.Visible = True
        Me.GGRAINDIRECTION.VisibleIndex = 40
        '
        'GARTWORKREMARKS
        '
        Me.GARTWORKREMARKS.Caption = "Artwork Remarks"
        Me.GARTWORKREMARKS.FieldName = "ARTWORK"
        Me.GARTWORKREMARKS.Name = "GARTWORKREMARKS"
        Me.GARTWORKREMARKS.Visible = True
        Me.GARTWORKREMARKS.VisibleIndex = 41
        '
        'GREMARKS
        '
        Me.GREMARKS.Caption = "Remarks"
        Me.GREMARKS.FieldName = "REMARKS"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.Visible = True
        Me.GREMARKS.VisibleIndex = 42
        '
        'CMDSAVE
        '
        Me.CMDSAVE.Location = New System.Drawing.Point(59, 3)
        Me.CMDSAVE.Name = "CMDSAVE"
        Me.CMDSAVE.Size = New System.Drawing.Size(75, 23)
        Me.CMDSAVE.TabIndex = 507
        Me.CMDSAVE.Text = "&Refresh"
        Me.CMDSAVE.UseVisualStyleBackColor = True
        '
        'CMDPRINT
        '
        Me.CMDPRINT.BackColor = System.Drawing.Color.Transparent
        Me.CMDPRINT.BackgroundImage = Global.PrintPro.My.Resources.Resources.Excel_icon
        Me.CMDPRINT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CMDPRINT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDPRINT.FlatAppearance.BorderSize = 0
        Me.CMDPRINT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDPRINT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDPRINT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDPRINT.Location = New System.Drawing.Point(17, 5)
        Me.CMDPRINT.Name = "CMDPRINT"
        Me.CMDPRINT.Size = New System.Drawing.Size(25, 21)
        Me.CMDPRINT.TabIndex = 506
        Me.CMDPRINT.UseVisualStyleBackColor = False
        '
        'cmdcancel
        '
        Me.cmdcancel.BackColor = System.Drawing.Color.Transparent
        Me.cmdcancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdcancel.FlatAppearance.BorderSize = 0
        Me.cmdcancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdcancel.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdcancel.Image = Global.PrintPro.My.Resources.Resources._Exit
        Me.cmdcancel.Location = New System.Drawing.Point(458, 529)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(72, 24)
        Me.cmdcancel.TabIndex = 505
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'ItemExpiryDetailsReport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(985, 553)
        Me.Controls.Add(Me.CMDSAVE)
        Me.Controls.Add(Me.CMDPRINT)
        Me.Controls.Add(Me.cmdcancel)
        Me.Controls.Add(Me.gridbilldetails)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "ItemExpiryDetailsReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Item Expiry Details Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GITEMCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFILENO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPROOFSEND As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPROOFSENDDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPROOFOK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPROOFOKDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPERFORATION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSHADESEND As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSHADESENDDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSHADEAPP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSHADEAPPDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GVALIDTILLDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCOORDINATOR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFONTS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSCREEN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDESIGN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GVARNISH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPARALLEL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCROSS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GKNIFE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSIDETOPRINT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GARTWORKRECDONDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GARTIST As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSOFTWARE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCOLOR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GACTUALSIZEHEIGHT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPHARMACODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMATERIAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNOOFUPS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMATERIALCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPRINTREPEATLENGTH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLINKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPAPERGSM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GACTUALSIZEWIDTH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAFTERFOLDINGWIDTH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAFTERFOLDINGHEIGHT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPAPERCUTSIZE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPAPERSIZENAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTAPETYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGRAINDIRECTION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GARTWORKREMARKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREMARKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMDSAVE As System.Windows.Forms.Button
    Friend WithEvents CMDPRINT As System.Windows.Forms.Button
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
End Class
