Imports BL

Public Class CategoryDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public frmstring As String      'Used for form Category or GRade

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub CategoryDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.E Then       'for Saving
            Call cmdedit_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf (e.Control = True And e.KeyCode = Windows.Forms.Keys.N) Or (e.KeyCode = Windows.Forms.Keys.A) Then   'for Exit
            showform(False, "", 0)
        End If
    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        Try
            showform(True, gridgroup.Item(0, gridgroup.CurrentRow.Index).Value.ToString, gridgroup.Item(1, gridgroup.CurrentRow.Index).Value.ToString)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CategoryDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ACCOUNTS MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If frmstring = "NARRATION" Then
                Me.Text = "Narration Details"
            ElseIf frmstring = "PARTYBANK" Then
                Me.Text = "Party Bank Details"
            ElseIf frmstring = "REASONMASTER" Then
                Me.Text = "Reason Details"
            ElseIf frmstring = "PROBLEMMASTER" Then
                Me.Text = "Problem Details"
            ElseIf frmstring = "OPERATORMASTER" Then
                Me.Text = "Opeartor Details"
            End If
            fillgrid()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()

        If USEREDIT = False And USERVIEW = False Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        Dim dttable As New DataTable
        Dim objClsCommon As New ClsCommonMaster

        If frmstring = "NARRATION" Then
            dttable = objClsCommon.search(" NARRATION_name, NARRATION_id", "", "NARRATIONmaster", " and NARRATION_cmpid = " & CmpId & " and NARRATION_Locationid = " & Locationid & " and NARRATION_Yearid = " & YearId)
        ElseIf frmstring = "PARTYBANK" Then
            dttable = objClsCommon.search(" PARTYBANK_name, PARTYBANK_id", "", "PARTYBANKmaster", " and PARTYBANK_cmpid = " & CmpId & " and PARTYBANK_Locationid = " & Locationid & " and PARTYBANK_Yearid = " & YearId)
        ElseIf frmstring = "PROBLEMMASTER" Then
            dttable = objClsCommon.search(" PROBLEM_name, PROBLEM_id ", "", "PROBLEMMASTER", " and PROBLEM_cmpid = " & CmpId & " and PROBLEM_Locationid = " & Locationid & " and PROBLEM_Yearid = " & YearId)
        ElseIf frmstring = "REASONMASTER" Then
            dttable = objClsCommon.search(" REASON_name, REASON_id", "", "REASONMASTER", " and REASON_cmpid = " & CmpId & " and REASON_Locationid = " & Locationid & " and REASON_Yearid = " & YearId)
        ElseIf frmstring = "OPERATORMASTER" Then
            dttable = objClsCommon.search(" OPERATOR_name, OPERATOR_id", "", "OPERATORMASTER", " and OPERATOR_cmpid = " & CmpId & " and OPERATOR_Locationid = " & Locationid & " and OPERATOR_Yearid = " & YearId)
        End If

        gridgroup.DataSource = dttable
        gridgroup.Columns(0).HeaderText = "Name"

        gridgroup.Columns(0).Width = 250
        gridgroup.Columns(1).Visible = False
        gridgroup.Columns(0).SortMode = Windows.Forms.DataGridViewColumnSortMode.Automatic
        If gridgroup.RowCount > 0 Then gridgroup.FirstDisplayedScrollingRowIndex = gridgroup.RowCount - 1

    End Sub

    Private Sub gridgroup_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridgroup.CellDoubleClick
        Try
            showform(True, gridgroup.Item(0, gridgroup.CurrentRow.Index).Value.ToString, gridgroup.Item(1, gridgroup.CurrentRow.Index).Value.ToString)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal name As String, ByVal id As Integer)
        Try

            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim objCategorymaster As New CategoryMaster
            objCategorymaster.edit = editval
            objCategorymaster.MdiParent = MDIMain
            objCategorymaster.frmString = frmstring
            objCategorymaster.TempName = name
            objCategorymaster.TempID = id
            objCategorymaster.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Try
            showform(False, "", 0)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
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
End Class