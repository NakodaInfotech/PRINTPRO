
Imports BL
Imports System.Windows.Forms

Public Class PaperMaterialMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public frmString As String      'Used for all Unit form
    Public Tempname As String       'Used for edit name
    Public tempid As Integer        'Used for id
    Public edit As Boolean          'Used for edit

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub



    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If CMBNAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBNAME, "Fill Name")
            bln = False
        End If

        If Not CHECKDUPLICATE() Then
            EP.SetError(CMBNAME, "Name Already Exists")
            bln = False
        End If

        Return bln
    End Function

    Private Function CHECKDUPLICATE() As Boolean
        Try
            Dim BLN As Boolean = True
            pcase(CMBNAME)

            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            If (edit = False) Or (edit = True And LCase(CMBNAME.Text) <> LCase(Tempname)) Then
                If frmString = "PAPERMATERIAL" Then
                    dt = objclscommon.search("PAPERMATERIAL_NAME", "", "PAPERMATERIALMASTER", "AND PAPERMATERIAL_NAME = '" & CMBNAME.Text.Trim & "' and PAPERMATERIAL_CMPID = " & CmpId & " AND PAPERMATERIAL_YEARID = " & YearId)
                ElseIf frmString = "PAPERMILL" Then
                    dt = objclscommon.search("PAPERMILL_NAME", "", "PAPERMILLMASTER", "AND PAPERMILL_NAME = '" & CMBNAME.Text.Trim & "' and PAPERMILL_CMPID = " & CmpId & " AND PAPERMILL_YEARID = " & YearId)
                ElseIf frmString = "PAPERDESIGN" Then
                    dt = objclscommon.search("DESIGN_NAME", "", "DESIGNMASTER", "AND DESIGN_NAME = '" & CMBNAME.Text.Trim & "' and DESIGN_CMPID = " & CmpId & " AND DESIGN_YEARID = " & YearId)
                ElseIf frmString = "SHELF" Then
                    dt = objclscommon.search("SHELF_NAME", "", "SHELFMASTER", "AND SHELF_NAME = '" & CMBNAME.Text.Trim & "' and SHELF_CMPID = " & CmpId & " AND SHELF_YEARID = " & YearId)
                ElseIf frmString = "GODOWN" Then
                    dt = objclscommon.search("GODOWN_NAME", "", "GODOWNMASTER", "AND GODOWN_NAME = '" & CMBNAME.Text.Trim & "' and GODOWN_CMPID = " & CmpId & " AND GODOWN_YEARID = " & YearId)
                ElseIf frmString = "PAPERGSM" Then
                    dt = objclscommon.search("PAPERGSM_NAME", "", "PAPERGSMMASTER", "AND PAPERGSM_NAME = '" & CMBNAME.Text.Trim & "' and PAPERGSM_CMPID = " & CmpId & " AND PAPERGSM_YEARID = " & YearId)
                ElseIf frmString = "PAPERSIZE" Then
                    dt = objclscommon.search("PAPERSIZE_NAME", "", "PAPERSIZEMASTER", "AND PAPERSIZE_NAME = '" & CMBNAME.Text.Trim & "' and PAPERSIZE_CMPID = " & CmpId & " AND PAPERSIZE_YEARID = " & YearId)
                ElseIf frmString = "GRAINDIRECTION" Then
                    dt = objclscommon.search("GRAIN_NAME", "", "GRAINMASTER", "AND GRAIN_NAME = '" & CMBNAME.Text.Trim & "' and GRAIN_CMPID = " & CmpId & " AND GRAIN_YEARID = " & YearId)
                ElseIf frmString = "TEARTAPE" Then
                    dt = objclscommon.search("TEARTAPE_NAME", "", "TEARTAPEMASTER", "AND TEARTAPE_NAME = '" & CMBNAME.Text.Trim & "' and TEARTAPE_CMPID = " & CmpId & " AND TEARTAPE_YEARID = " & YearId)
                ElseIf frmString = "CATEGORY" Then
                    dt = objclscommon.search("CATEGORY_NAME", "", "CATEGORYMASTER", "AND CATEGORY_NAME = '" & CMBNAME.Text.Trim & "' and CATEGORY_CMPID = " & CmpId & " AND CATEGORY_YEARID = " & YearId)
                End If

                If dt.Rows.Count > 0 Then
                    MsgBox("Name Already Exists", MsgBoxStyle.Critical, "PRINTPRO")
                    BLN = False
                End If
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub cmdok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            alParaval.Add(UCase(CMBNAME.Text.Trim))
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            If frmString = "PAPERMATERIAL" Then

                Dim objclspapermat As New ClsPaperMaterial
                alParaval.Add("PAPERMATERIAL")
                objclspapermat.alParaval = alParaval
                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = objclspapermat.save()
                    MsgBox("Details Added")

                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(tempid)
                    IntResult = objclspapermat.update()
                    MsgBox("Details Updated")
                End If

            ElseIf frmString = "PAPERMILL" Then

                Dim objclspapermat As New ClsPaperMaterial
                alParaval.Add("PAPERMILL")
                objclspapermat.alParaval = alParaval
                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = objclspapermat.save()
                    MsgBox("Details Added")

                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(tempid)
                    IntResult = objclspapermat.update()
                    MsgBox("Details Updated")
                End If


            ElseIf frmString = "PAPERDESIGN" Then

                Dim objclspapermat As New ClsPaperMaterial
                alParaval.Add("PAPERDESIGN")
                objclspapermat.alParaval = alParaval
                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = objclspapermat.save()
                    MsgBox("Details Added")

                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(tempid)
                    IntResult = objclspapermat.update()
                    MsgBox("Details Updated")
                End If

            ElseIf frmString = "SHELF" Then

                Dim objclspapermat As New ClsPaperMaterial
                alParaval.Add("SHELF")
                objclspapermat.alParaval = alParaval
                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = objclspapermat.save()
                    MsgBox("Details Added")

                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(tempid)
                    IntResult = objclspapermat.update()
                    MsgBox("Details Updated")
                End If


            ElseIf frmString = "GODOWN" Then

                Dim objclspapermat As New ClsPaperMaterial
                alParaval.Add("GODOWN")
                objclspapermat.alParaval = alParaval
                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = objclspapermat.save()
                    MsgBox("Details Added")

                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(tempid)
                    IntResult = objclspapermat.update()
                    MsgBox("Details Updated")
                End If

            ElseIf frmString = "PAPERSIZE" Then

                Dim objclspapermat As New ClsPaperMaterial
                alParaval.Add("PAPERSIZE")
                objclspapermat.alParaval = alParaval
                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = objclspapermat.save()
                    MsgBox("Details Added")

                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(tempid)
                    IntResult = objclspapermat.update()
                    MsgBox("Details Updated")
                End If

            ElseIf frmString = "PAPERGSM" Then

                Dim objclspapermat As New ClsPaperMaterial
                alParaval.Add("PAPERGSM")
                objclspapermat.alParaval = alParaval
                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = objclspapermat.save()
                    MsgBox("Details Added")

                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(tempid)
                    IntResult = objclspapermat.update()
                    MsgBox("Details Updated")
                End If

            ElseIf frmString = "TEARTAPE" Then

                Dim objclspapermat As New ClsPaperMaterial
                alParaval.Add("TEARTAPE")
                objclspapermat.alParaval = alParaval
                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = objclspapermat.save()
                    MsgBox("Details Added")

                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(tempid)
                    IntResult = objclspapermat.update()
                    MsgBox("Details Updated")
                End If

            ElseIf frmString = "GRAINDIRECTION" Then

                Dim objclspapermat As New ClsPaperMaterial
                alParaval.Add("GRAINDIRECTION")
                objclspapermat.alParaval = alParaval
                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = objclspapermat.save()
                    MsgBox("Details Added")

                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(tempid)
                    IntResult = objclspapermat.update()
                    MsgBox("Details Updated")
                End If

            ElseIf frmString = "LONGGRAIN" Then

                Dim objclspapermat As New ClsPaperMaterial
                alParaval.Add("LONGGRAIN")
                objclspapermat.alParaval = alParaval
                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = objclspapermat.save()
                    MsgBox("Details Added")

                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(tempid)
                    IntResult = objclspapermat.update()
                    MsgBox("Details Updated")
                End If

            ElseIf frmString = "CARTONTYPE" Then

                Dim objclspapermat As New ClsPaperMaterial
                alParaval.Add("CARTONTYPE")
                objclspapermat.alParaval = alParaval
                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = objclspapermat.save()
                    MsgBox("Details Added")

                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(tempid)
                    IntResult = objclspapermat.update()
                    MsgBox("Details Updated")
                End If

            ElseIf frmString = "PUNCHSPEC" Then

                Dim objclspapermat As New ClsPaperMaterial
                alParaval.Add("PUNCHSPEC")
                objclspapermat.alParaval = alParaval
                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = objclspapermat.save()
                    MsgBox("Details Added")

                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(tempid)
                    IntResult = objclspapermat.update()
                    MsgBox("Details Updated")
                End If

            ElseIf frmString = "COLOR" Then

                Dim objclspapermat As New ClsPaperMaterial
                alParaval.Add("COLOR")
                objclspapermat.alParaval = alParaval
                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = objclspapermat.save()
                    MsgBox("Details Added")

                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(tempid)
                    IntResult = objclspapermat.update()
                    MsgBox("Details Updated")
                End If

            ElseIf frmString = "DEPARTMENT" Then

                Dim objclspapermat As New ClsPaperMaterial
                alParaval.Add("DEPARTMENT")
                objclspapermat.alParaval = alParaval
                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = objclspapermat.save()
                    MsgBox("Details Added")

                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(tempid)
                    IntResult = objclspapermat.update()
                    MsgBox("Details Updated")
                End If

            ElseIf frmString = "CATEGORY" Then

                Dim objclspapermat As New ClsPaperMaterial
                alParaval.Add("CATEGORY")
                objclspapermat.alParaval = alParaval
                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = objclspapermat.save()
                    MsgBox("Details Added")

                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(tempid)
                    IntResult = objclspapermat.update()
                    MsgBox("Details Updated")
                End If

            End If
            clear()
            CMBNAME.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub clear()
        CMBNAME.Text = ""
        txtremarks.Clear()
    End Sub

    Private Sub txtname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Try
            'for search
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable

            If (edit = False) Or (edit = True And LCase(Tempname) <> LCase(CMBNAME.Text.Trim)) Then
                If frmString = "PAPERMATERIAL" Then
                    dt = objclscommon.search("PAPERMATERIAL_name", "", "PAPERMATERIALMaster", " And PAPERMATERIAL_name = '" & CMBNAME.Text.Trim & "' And PAPERMATERIAL_cmpid = " & CmpId & " AND PAPERMATERIAL_LOCATIONID = " & Locationid & " AND PAPERMATERIAL_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Material Name Already Exists", MsgBoxStyle.Critical, "PrintPro")
                        e.Cancel = True
                    End If

                ElseIf frmString = "PAPERMILL" Then
                    dt = objclscommon.search("PAPERMILL_name", "", "PAPERMILLMaster", " and PAPERMILL_name = '" & CMBNAME.Text.Trim & "' And PAPERMILL_cmpid = " & CmpId & " AND PAPERMILL_LOCATIONID = " & Locationid & " AND PAPERMILL_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Mill Name Name Already Exists", MsgBoxStyle.Critical, "PrintPro")
                        e.Cancel = True
                    End If

                ElseIf frmString = "PAPERDESIGN" Then
                    dt = objclscommon.search("PAPERDESIGN_name", "", "PAPERDESIGNMaster", " and PAPERDESIGN_name = '" & CMBNAME.Text.Trim & "' And PAPERDESIGN_cmpid = " & CmpId & " AND PAPERDESIGN_LOCATIONID = " & Locationid & " AND PAPERDESIGN_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Design Name Already Exists", MsgBoxStyle.Critical, "PrintPro")
                        e.Cancel = True
                    End If

                ElseIf frmString = "SHELF" Then
                    dt = objclscommon.search("SHELF_name", "", "SHELFMaster", " and SHELF_name = '" & CMBNAME.Text.Trim & "' And SHELF_cmpid = " & CmpId & " AND SHELF_LOCATIONID = " & Locationid & " AND SHELF_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Shelf Name Already Exists", MsgBoxStyle.Critical, "PrintPro")
                        e.Cancel = True
                    End If

                ElseIf frmString = "GODOWN" Then
                    dt = objclscommon.search("GODOWN_name", "", "GODOWNMaster", " and GODOWN_name = '" & CMBNAME.Text.Trim & "' And GODOWN_cmpid = " & CmpId & "  AND GODOWN_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("GODOWN Name Already Exists", MsgBoxStyle.Critical, "PrinTPro")
                        e.Cancel = True
                    End If

                ElseIf frmString = "PAPERGSM" Then
                    dt = objclscommon.search("PAPERGSM_name", "", "PAPERGSMMaster", " and PAPERGSM_name = '" & CMBNAME.Text.Trim & "' And PAPERGSM_cmpid = " & CmpId & " AND PAPERGSM_LOCATIONID = " & Locationid & " AND PAPERGSM_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Paper GSM Already Exists", MsgBoxStyle.Critical, "PrintPro")
                        e.Cancel = True
                    End If

                ElseIf frmString = "PAPERSIZE" Then
                    dt = objclscommon.search("PAPERSIZE_name", "", "PAPERSIZEMaster", " and PAPERSIZE_name = '" & CMBNAME.Text.Trim & "' And PAPERSIZE_cmpid = " & CmpId & " AND PAPERSIZE_LOCATIONID = " & Locationid & " AND PAPERSIZE_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Paper Size Already Exists", MsgBoxStyle.Critical, "PrintPro")
                        e.Cancel = True
                    End If

                ElseIf frmString = "TEARTAPE" Then
                    dt = objclscommon.search("TEARTAPE_name", "", "TEARTAPEMaster", " and TEARTAPE_name = '" & CMBNAME.Text.Trim & "' And TEARTAPE_cmpid = " & CmpId & " AND TEARTAPE_LOCATIONID = " & Locationid & " AND TEARTAPE_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("TearTape Already Exists", MsgBoxStyle.Critical, "PrintPro")
                        e.Cancel = True
                    End If

                ElseIf frmString = "GRAINDIRECTION" Then
                    dt = objclscommon.search("GRAIN_name", "", "GRAINMaster", " and GRAIN_name = '" & CMBNAME.Text.Trim & "' And GRAIN_cmpid = " & CmpId & " AND GRAIN_LOCATIONID = " & Locationid & " AND GRAIN_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Grain Direction Already Exists", MsgBoxStyle.Critical, "PrintPro")
                        e.Cancel = True
                    End If

                ElseIf frmString = "LONGGRAIN" Then
                    dt = objclscommon.search("LONGGRAIN_name", "", "LONGGRAINMaster", " and LONGGRAIN_name = '" & CMBNAME.Text.Trim & "' And LONGGRAIN_cmpid = " & CmpId & " AND LONGGRAIN_LOCATIONID = " & Locationid & " AND LONGGRAIN_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Long/Short Grain Already Exists", MsgBoxStyle.Critical, "PrintPro")
                        e.Cancel = True
                    End If

                ElseIf frmString = "CARTONTYPE" Then
                    dt = objclscommon.search("CARTONTYPE_name", "", "CARTONTYPEMaster", " and CARTONTYPE_name = '" & CMBNAME.Text.Trim & "' And CARTONTYPE_cmpid = " & CmpId & " AND CARTONTYPE_LOCATIONID = " & Locationid & " AND CARTONTYPE_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Carton Type Already Exists", MsgBoxStyle.Critical, "PrintPro")
                        e.Cancel = True
                    End If

                ElseIf frmString = "PUNCHSPEC" Then
                    dt = objclscommon.search("PUNCHSPEC_name", "", "PUNCHSPECMaster", " and PUNCHSPEC_name = '" & CMBNAME.Text.Trim & "' And PUNCHSPEC_cmpid = " & CmpId & " AND PUNCHSPEC_LOCATIONID = " & Locationid & " AND PUNCHSPEC_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Punch Spec. Already Exists", MsgBoxStyle.Critical, "PrintPro")
                        e.Cancel = True
                    End If

                ElseIf frmString = "COLOR" Then
                    dt = objclscommon.search("COLOR_name", "", "COLORMaster", " and COLOR_name = '" & CMBNAME.Text.Trim & "' And COLOR_cmpid = " & CmpId & " AND COLOR_LOCATIONID = " & Locationid & " AND COLOR_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Color Already Exists", MsgBoxStyle.Critical, "PrintPro")
                        e.Cancel = True
                    End If

                ElseIf frmString = "DEPARTMENT" Then
                    dt = objclscommon.search("DEPARTMENT_name", "", "DEPARTMENTMaster", " and DEPARTMENT_name = '" & CMBNAME.Text.Trim & "' And DEPARTMENT_cmpid = " & CmpId & " AND DEPARTMENT_LOCATIONID = " & Locationid & " AND DEPARTMENT_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("DEPARTMENT Already Exists", MsgBoxStyle.Critical, "PrintPro")
                        e.Cancel = True
                    End If

                ElseIf frmString = "CATEGORY" Then
                    dt = objclscommon.search("CATEGORY_name", "", "CATEGORYMaster", " and CATEGORY_name = '" & CMBNAME.Text.Trim & "' And CATEGORY_cmpid = " & CmpId & " AND CATEGORY_LOCATIONID = " & Locationid & " AND CATEGORY_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("CATEGORY Already Exists", MsgBoxStyle.Critical, "PrintPro")
                        e.Cancel = True
                    End If
                End If
            End If
            pcase(CMBNAME)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PaperMaterialMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If (e.KeyCode = Windows.Forms.Keys.Escape) Then               'FOR EXIT
            If errorvalid() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub PaperMaterialMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim dttable As New DataTable
            Dim objCommon As New ClsCommonMaster

            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If CMBNAME.Text.Trim = "" Then CMBNAME.Items.Clear()
            Dim objclscommon As New ClsCommonMaster
            Dim dt As New DataTable

            If frmString = "PAPERMATERIAL" Then

                Me.Text = "Paper Material Master"
                lblgroup.Text = "Paper Material"
                lbl.Text = "Enter Material (e.g. Maplitho, Plain,..., etc.)"
                If edit = True Then dttable = objCommon.search(" papermaterial_name, papermaterial_remarks", "", "papermaterialMaster", " and papermaterial_id = " & tempid & " and  papermaterial_yearid = " & YearId)

                If CMBNAME.Text.Trim = "" Then dt = objclscommon.search("PAPERMATERIAL_name", "", "PAPERMATERIALMaster", " and PAPERMATERIAL_yearid = " & YearId)


            ElseIf frmString = "PAPERMILL" Then

                Me.Text = "Paper Mill Master"
                lblgroup.Text = "Paper Mill"
                lbl.Text = "Enter Mill (e.g. SHAH PAPER MILLS,..., etc.)"
                If edit = True Then dttable = objCommon.search(" PAPERMILL_name, PAPERMILL_remarks", "", "PAPERMILLMaster", " and PAPERMILL_id = " & tempid & " and  PAPERMILL_yearid = " & YearId)

                If CMBNAME.Text.Trim = "" Then dt = objclscommon.search("PAPERMILL_name", "", "PAPERMILLMaster", " and PAPERMILL_yearid = " & YearId)


            ElseIf frmString = "PAPERDESIGN" Then

                Me.Text = "Paper Design Master"
                lblgroup.Text = "Paper Design"
                lbl.Text = "Enter Paper Design (e.g. Folded, Unfolded,..., etc.)"
                If edit = True Then dttable = objCommon.search(" DESIGN_name, DESIGN_remarks", "", "DESIGNMaster", " and DESIGN_id = " & tempid & " and DESIGN_YEARID = " & YearId)

                If CMBNAME.Text.Trim = "" Then dt = objclscommon.search("DESIGN_name", "", "DESIGNMaster", " and DESIGN_yearid = " & YearId)

            ElseIf frmString = "SHELF" Then

                Me.Text = "Shelf Master"
                lblgroup.Text = "Shelf "
                lbl.Text = "Enter Shelf Name "
                If edit = True Then dttable = objCommon.search("SHELF_name, SHELF_remarks", "", "SHELFMaster", " and SHELF_id = " & tempid & " and SHELF_YEARID = " & YearId)

                If CMBNAME.Text.Trim = "" Then dt = objclscommon.search("SHELF_name", "", "SHELFMaster", " and SHELF_yearid = " & YearId)

            ElseIf frmString = "GODOWN" Then

                Me.Text = "Godown Master"
                lblgroup.Text = "Godown "
                lbl.Text = "Enter Godown Name "
                If edit = True Then dttable = objCommon.search("Godown_name, Godown_remarks", "", "GodownMaster", " and Godown_id = " & tempid & " and Godown_YEARID = " & YearId)

                If CMBNAME.Text.Trim = "" Then dt = objclscommon.search("Godown_name", "", "GodownMaster", " and Godown_yearid = " & YearId)

            ElseIf frmString = "PAPERSIZE" Then

                Me.Text = "Paper Size Master"
                lblgroup.Text = "Paper Size"
                lbl.Text = "Enter Paper Size (e.g. A4, A3,..., etc.)"
                If edit = True Then dttable = objCommon.search(" PAPERSIZE_name, PAPERSIZE_remarks", "", "PAPERSIZEMaster", " and PAPERSIZE_id = " & tempid & " and PAPERSIZE_YEARID = " & YearId)

                If CMBNAME.Text.Trim = "" Then dt = objclscommon.search("PAPERSIZE_name", "", "PAPERSIZEMaster", " and PAPERSIZE_yearid = " & YearId)

            ElseIf frmString = "PAPERGSM" Then

                Me.Text = "Paper GSM Master"
                lblgroup.Text = "Paper GSM"
                lbl.Text = "Enter Paper GSM (e.g. 56Gsm, 50Gsm,..., etc.)"
                If edit = True Then dttable = objCommon.search(" PAPERGSM_name, PAPERGSM_remarks", "", "PAPERGSMMaster", " and PAPERGSM_id = " & tempid & " and PAPERGSM_YEARID = " & YearId)

                If CMBNAME.Text.Trim = "" Then dt = objclscommon.search("PAPERGSM_name", "", "PAPERGSMMaster", " and PAPERGSM_yearid = " & YearId)


            ElseIf frmString = "GRAINDIRECTION" Then

                Me.Text = "Grain Direction Master"
                lblgroup.Text = "Grain Direction"
                lbl.Text = "Enter Grain Direction (e.g. Parallel, Perpendicular,..., etc.)"
                If edit = True Then dttable = objCommon.search(" GRAIN_name, GRAIN_remarks", "", "GRAINMaster", " and GRAIN_id = " & tempid & " and GRAIN_YEARID = " & YearId)

                If CMBNAME.Text.Trim = "" Then dt = objclscommon.search("GRAIN_name", "", "GRAINMaster", " and GRAIN_yearid = " & YearId)


            ElseIf frmString = "COLOR" Then

                Me.Text = "Color Master"
                lblgroup.Text = "Color"
                lbl.Text = "Enter Color (e.g. Black, Red,..., etc.)"
                If edit = True Then dttable = objCommon.search(" COLOR_name, COLOR_remarks", "", "COLORMaster", " and COLOR_id = " & tempid & " and COLOR_CMPID = " & CmpId & " AND COLOR_LOCATIONID = " & Locationid & " AND COLOR_YEARID = " & YearId)

                If CMBNAME.Text.Trim = "" Then dt = objclscommon.search("COLOR_name", "", "COLORMaster", " and COLOR_cmpid = " & CmpId & " and COLOR_locationid = " & Locationid & " and COLOR_yearid = " & YearId)

            ElseIf frmString = "TEARTAPE" Then

                Me.Text = "TERATAPE Master"
                lblgroup.Text = "TAPE TYPE"
                lbl.Text = "Enter TAPE TYPE (e.g. TEAR TAPE, ..., etc.)"
                If edit = True Then dttable = objCommon.search(" TEARTAPE_name, TEARTAPE_remarks", "", "TEARTAPEMaster", " and TEARTAPE_id = " & tempid & " and TEARTAPE_CMPID = " & CmpId & " AND TEARTAPE_LOCATIONID = " & Locationid & " AND TEARTAPE_YEARID = " & YearId)

                If CMBNAME.Text.Trim = "" Then dt = objclscommon.search("TEARTAPE_name", "", "TEARTAPEMaster", " and TEARTAPE_cmpid = " & CmpId & " and TEARTAPE_locationid = " & Locationid & " and TEARTAPE_yearid = " & YearId)

            ElseIf frmString = "CATEGORY" Then

                Me.Text = "CATEGORY Master"
                lblgroup.Text = "CATEGORY "
                lbl.Text = "Enter Category Name "
                If edit = True Then dttable = objCommon.search("CATEGORY_name, CATEGORY_remarks", "", "CATEGORYMaster", " and CATEGORY_id = " & tempid & " and CATEGORY_YEARID = " & YearId)

                If CMBNAME.Text.Trim = "" Then dt = objclscommon.search("CATEGORY_name", "", "CATEGORYMaster", " and CATEGORY_yearid = " & YearId)

            End If

            If dt.Rows.Count > 0 Then
                Dim i As Integer
                For i = 0 To dt.Rows.Count - 1
                    CMBNAME.Items.Add(dt.Rows(i).Item(0).ToString)
                Next
            End If

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If dttable.Rows.Count > 0 Then
                    CMBNAME.Text = dttable.Rows(0).Item(0).ToString
                    Tempname = dttable.Rows(0).Item(0).ToString
                    txtremarks.Text = dttable.Rows(0).Item(1).ToString
                End If
            End If
            CMBNAME.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            'for search
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable

            If (edit = False) Or (edit = True And LCase(Tempname) <> LCase(CMBNAME.Text.Trim)) Then


                If frmString = "PAPERMATERIAL" Then


                    dt = objclscommon.search("PAPERMATERIAL_name", "", "PAPERMATERIALMaster", " and PAPERMATERIAL_name = '" & CMBNAME.Text.Trim & "' And PAPERMATERIAL_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Material Name Already Exists", MsgBoxStyle.Critical, "PRINTPRO")
                        e.Cancel = True
                    End If

                ElseIf frmString = "PAPERMILL" Then
                    dt = objclscommon.search("PAPERMILL_name", "", "PAPERMILLMaster", " and PAPERMILL_name = '" & CMBNAME.Text.Trim & "' And PAPERMILL_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Material Name Already Exists", MsgBoxStyle.Critical, "PRINTPRO")
                        e.Cancel = True
                    End If

                ElseIf frmString = "PAPERDESIGN" Then
                    dt = objclscommon.search("DESIGN_name", "", "DESIGNMaster", " and DESIGN_name = '" & CMBNAME.Text.Trim & "' And DESIGN_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Design Name Already Exists", MsgBoxStyle.Critical, "PRINTPRO")
                        e.Cancel = True
                    End If

                ElseIf frmString = "SHELF" Then
                    dt = objclscommon.search("SHELF_name", "", "SHELFMaster", " and SHELF_name = '" & CMBNAME.Text.Trim & "' And SHELF_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Shelf Name Already Exists", MsgBoxStyle.Critical, "PRINTPRO")
                        e.Cancel = True
                    End If

                ElseIf frmString = "Godown" Then
                    dt = objclscommon.search("Godown_name", "", "GodownMaster", " and Godown_name = '" & CMBNAME.Text.Trim & "' And Godown_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Godown Name Already Exists", MsgBoxStyle.Critical, "PRINTPRO")
                        e.Cancel = True
                    End If

                ElseIf frmString = "PAPERGSM" Then
                    dt = objclscommon.search("PAPERGSM_name", "", "PAPERGSMMaster", " and PAPERGSM_name = '" & CMBNAME.Text.Trim & "' And  PAPERGSM_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Paper GSM Already Exists", MsgBoxStyle.Critical, "PRINTPRO")
                        e.Cancel = True
                    End If

                ElseIf frmString = "PAPERSIZE" Then
                    dt = objclscommon.search("PAPERSIZE_name", "", "PAPERSIZEMaster", " and PAPERSIZE_name = '" & CMBNAME.Text.Trim & "' And PAPERSIZE_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Paper Size Already Exists", MsgBoxStyle.Critical, "PRINTPRO")
                        e.Cancel = True
                    End If
                ElseIf frmString = "GRAINDIRECTION" Then
                    dt = objclscommon.search("GRAIN_name", "", "GRAINMASTER", " and GRAIN_name = '" & CMBNAME.Text.Trim & "' And GRAIN_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Grain Direction Already Exists", MsgBoxStyle.Critical, "PRINTPRO")
                        e.Cancel = True
                    End If
                ElseIf frmString = "COLOR" Then
                    dt = objclscommon.search("COLOR_name", "", "COLORMaster", " and COLOR_name = '" & CMBNAME.Text.Trim & "' And COLOR_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Color Already Exists", MsgBoxStyle.Critical, "PRINTPRO")
                        e.Cancel = True
                    End If

                ElseIf frmString = "TEARTAPE" Then
                    dt = objclscommon.search("TEARTAPE_name", "", "TEARTAPEMaster", " and TEARTAPE_name = '" & CMBNAME.Text.Trim & "' And TEARTAPE_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("TEARTAPE Already Exists", MsgBoxStyle.Critical, "PRINTPRO")
                        e.Cancel = True
                    End If

                ElseIf frmString = "CATEGORY" Then
                    dt = objclscommon.search("CATEGORY_name", "", "CATEGORYMaster", " and CATEGORY_name = '" & CMBNAME.Text.Trim & "' And CATEGORY_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("CATEGORY Already Exists", MsgBoxStyle.Critical, "PRINTPRO")
                        e.Cancel = True
                    End If

                ElseIf frmString = "GODOWN" Then
                    dt = objclscommon.search("GODOWN_name", "", "GODOWNMASTER", " and GODOWN_name = '" & CMBNAME.Text.Trim & "' And GODOWN_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("GODOWN Already Exists", MsgBoxStyle.Critical, "PRINTPRO")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If frmString = "PAPERMATERIAL" Then
                If CMBNAME.Text.Trim = "" Then fillMATERIAL(CMBNAME, edit)
            ElseIf frmString = "PAPERMILL" Then
                If CMBNAME.Text.Trim = "" Then FILLPAPERMILL(CMBNAME, edit)
            ElseIf frmString = "PAPERDESIGN" Then
                If CMBNAME.Text.Trim = "" Then fillDESIGN(CMBNAME, edit)
            ElseIf frmString = "SHELF" Then
                If CMBNAME.Text.Trim = "" Then fillSHELF(CMBNAME, edit)
            ElseIf frmString = "GODOWN" Then
                If CMBNAME.Text.Trim = "" Then fillGODOWN(CMBNAME, edit)
            ElseIf frmString = "PAPERGSM" Then
                If CMBNAME.Text.Trim = "" Then fillPAPERGSM(CMBNAME, edit)
            ElseIf frmString = "PAPERSIZE" Then
                If CMBNAME.Text.Trim = "" Then FILLPAPERSIZE(CMBNAME, edit)
            ElseIf frmString = "GRAINDIRECTION" Then
                If CMBNAME.Text.Trim = "" Then fillGRAIN(CMBNAME, edit)
            ElseIf frmString = "TEARTAPE" Then
                If CMBNAME.Text.Trim = "" Then fillTEARTAPE(CMBNAME, edit)
            ElseIf frmString = "CATEGORY" Then
                If CMBNAME.Text.Trim = "" Then fillCATEGORY(CMBNAME, edit)
            ElseIf frmString = "GODOWN" Then
                If CMBNAME.Text.Trim = "" Then fillGODOWN(CMBNAME, edit)

            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If edit = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If MsgBox("Wish to Delete Item ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    If MsgBox("Are you Sure?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        Dim INTRESULT As Integer
                        Dim ALPARAVAL As New ArrayList
                        ALPARAVAL.Add(tempid)
                        ALPARAVAL.Add(YearId)

                        Dim OBJPPR As New ClsPaperMaterial
                        OBJPPR.alParaval = ALPARAVAL
                        INTRESULT = OBJPPR.DELETE()
                        MsgBox("Paper Material Deleted!")

                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class