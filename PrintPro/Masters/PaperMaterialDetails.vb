
Imports BL
Imports System.Windows.Forms

Public Class PaperMaterialDetails

    Public FRMSTRING As String
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub PaperMaterialDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.N) Then               'FOR new
            showform(False, "", "")
        End If
    End Sub

    Private Sub cmdedit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        Try
            showform(True, gridgroup.Item(0, gridgroup.CurrentRow.Index).Value.ToString, gridgroup.Item(1, gridgroup.CurrentRow.Index).Value.ToString)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UnitDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()

        Dim dttable As DataTable
        Dim objClsCommon As New ClsCommonMaster

        If FRMSTRING = "PAPERMATERIAL" Then

            dttable = objClsCommon.search(" PAPERMATERIAL_name, PAPERMATERIAL_id", "", "PAPERMATERIALmaster", " and PAPERMATERIAL_YEARID = " & YearId)

            gridgroup.DataSource = dttable
            gridgroup.Columns(0).HeaderText = "PAPER MATERIAL"
            
            gridgroup.Columns(0).Width = 360
            gridgroup.Columns(1).Visible = False

        ElseIf FRMSTRING = "PAPERDESIGN" Then

            dttable = objClsCommon.search(" DESIGN_name, DESIGN_id", "", "DESIGNmaster", " and  DESIGN_YEARID = " & YearId)

            gridgroup.DataSource = dttable
            gridgroup.Columns(0).HeaderText = "PAPER DESIGN"

            gridgroup.Columns(0).Width = 360
            gridgroup.Columns(1).Visible = False

        ElseIf FRMSTRING = "PAPERSIZE" Then

            dttable = objClsCommon.search(" PAPERSIZE_name, PAPERSIZE_id", "", "PAPERSIZEmaster", " and PAPERSIZE_YEARID = " & YearId)

            gridgroup.DataSource = dttable
            gridgroup.Columns(0).HeaderText = "PAPER SIZE"

            gridgroup.Columns(0).Width = 360
            gridgroup.Columns(1).Visible = False

        ElseIf FRMSTRING = "PAPERGSM" Then

            dttable = objClsCommon.search(" PAPERGSM_name, PAPERGSM_id", "", "PAPERGSMmaster", " and PAPERGSM_YEARID = " & YearId)

            gridgroup.DataSource = dttable
            gridgroup.Columns(0).HeaderText = "PAPER GSM"

            gridgroup.Columns(0).Width = 360
            gridgroup.Columns(1).Visible = False


        ElseIf FRMSTRING = "GRAINDIRECTION" Then

            dttable = objClsCommon.search(" GRAIN_name, GRAIN_id", "", "GRAINMASTER", " and GRAIN_YEARID = " & YearId)

            gridgroup.DataSource = dttable
            gridgroup.Columns(0).HeaderText = "GRAIN DIRECTION"

            gridgroup.Columns(0).Width = 360
            gridgroup.Columns(1).Visible = False

        ElseIf FRMSTRING = "COLOR" Then

            dttable = objClsCommon.search(" COLOR_name, COLOR_id", "", "COLORmaster", " and COLOR_YEARID = " & YearId)

            gridgroup.DataSource = dttable
            gridgroup.Columns(0).HeaderText = "COLOR"

            gridgroup.Columns(0).Width = 360
            gridgroup.Columns(1).Visible = False

        ElseIf FRMSTRING = "TEARTAPE" Then

            dttable = objClsCommon.search(" TEARTAPE_name, TEARTAPE_id", "", "TEARTAPEmaster", " and TEARTAPE_YEARID = " & YearId)

            gridgroup.DataSource = dttable
            gridgroup.Columns(0).HeaderText = "TEARTAPE"

            gridgroup.Columns(0).Width = 360
            gridgroup.Columns(1).Visible = False

        ElseIf FRMSTRING = "CATEGORY" Then

            dttable = objClsCommon.search(" CATEGORY_name, CATEGORY_id", "", "CATEGORYmaster", " and CATEGORY_YEARID = " & YearId)

            gridgroup.DataSource = dttable
            gridgroup.Columns(0).HeaderText = "CATEGORY"

            gridgroup.Columns(0).Width = 360
            gridgroup.Columns(1).Visible = False


        ElseIf FRMSTRING = "SHELF" Then

            dttable = objClsCommon.search(" SHELF_name, SHELF_id", "", "SHELFmaster", " and SHELF_YEARID = " & YearId)

            gridgroup.DataSource = dttable
            gridgroup.Columns(0).HeaderText = "SHELF"

            gridgroup.Columns(0).Width = 360
            gridgroup.Columns(1).Visible = False


        ElseIf FRMSTRING = "GODOWN" Then

            dttable = objClsCommon.search(" GODOWN_name, GODOWN_id", "", "GODOWNmaster", " and GODOWN_YEARID = " & YearId)

            gridgroup.DataSource = dttable
            gridgroup.Columns(0).HeaderText = "GODOWN"

            gridgroup.Columns(0).Width = 360
            gridgroup.Columns(1).Visible = False
        End If

        gridgroup.Columns(0).SortMode = Windows.Forms.DataGridViewColumnSortMode.Automatic
        If gridgroup.RowCount > 0 Then gridgroup.FirstDisplayedScrollingRowIndex = gridgroup.RowCount - 1

    End Sub

    Sub showform(ByVal editval As Boolean, ByVal name As String, ByVal id As Integer)
        Try

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim objPAPERMAT As New PaperMaterialMaster
            objPAPERMAT.edit = editval
            objPAPERMAT.frmString = FRMSTRING
            objPAPERMAT.MdiParent = MDIMain
            objPAPERMAT.Tempname = name
            objPAPERMAT.tempid = id
            objPAPERMAT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridgroup_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridgroup.CellDoubleClick
        Try
            showform(True, gridgroup.Item(0, gridgroup.CurrentRow.Index).Value.ToString, gridgroup.Item(1, gridgroup.CurrentRow.Index).Value.ToString)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtcmp_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcmp.Validated
        Dim rowno, b As Integer

        fillgrid()
        rowno = 0
        For b = 1 To gridgroup.RowCount
            txttempname.Text = gridgroup.Item(0, rowno).Value.ToString()
            txttempname.SelectionStart = 0
            txttempname.SelectionLength = txtcmp.TextLength
            If LCase(txtcmp.Text.Trim) <> LCase(txttempname.SelectedText.Trim) Then
                gridgroup.Rows.RemoveAt(rowno)
            Else
                rowno = rowno + 1
            End If
        Next
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Try
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            showform(False, "", 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class