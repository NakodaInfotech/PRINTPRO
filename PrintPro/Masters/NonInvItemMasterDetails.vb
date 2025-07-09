Imports BL
Imports System.Windows.Forms

Public Class NonInvItemMasterDetails
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub NonInvItemMasterDetails_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        End If
    End Sub

    Private Sub NonInvItemMasterDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            fillgridname()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRIDNAME()
        Try
            Dim objcmn As New ClsCommonMaster
            Dim dt As New DataTable
            dt = objcmn.search("NONINV_ID AS ITEMID,NONINV_NAME AS NAME", "", "NONINVITEMMASTER", " AND NONINVITEMMASTER.NONINV_yearid= " & YearId & " ORDER by NONINVITEMMASTER.NONINV_ID")
            gridname.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridledger.FocusedRowHandle = gridledger.RowCount - 1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getdetails(ByVal ID As Integer)

        Dim objClsITEM As New ClsNoninvItemmaster
        objClsITEM.alParaval.Add(ID)
        objClsITEM.alParaval.Add(CmpId)
        objClsITEM.alParaval.Add(Locationid)
        objClsITEM.alParaval.Add(YearId)
        Dim dttable As DataTable = objClsITEM.GETITEM

        cleartextbox()
        If dttable.Rows.Count > 0 Then
            For Each dr As DataRow In dttable.Rows
                TXTHSNCODE.Text = Val(dr("HSNCODE"))
                TXTCATEGORY.Text = Convert.ToString(dr("CATEGORY"))
                TXTLENGTH.Text = Val(dr("LENGTH"))
                TXTWIDTH.Text = Val(dr("WIDTH"))
                TXTGSM.Text = Val(dr("GSM"))
                CMBINVITEMNAME.Text = Convert.ToString(dr("ITEMNAME"))
                CMBPAPERMATERIAL.Text = Convert.ToString(dr("PAPERMATERIAL"))
                CMBPAPERMILL.Text = Convert.ToString(dr("PAPERMILL"))
                CMBINVITEMCODE.Text = Convert.ToString(dr("ITEMCODE"))
                txtremarks.Text = Convert.ToString(dr("REMARKS"))
            Next
        End If
    End Sub

    Sub cleartextbox()
        TXTHSNCODE.Clear()
        TXTLENGTH.Clear()
        TXTWIDTH.Clear()
        TXTGSM.Clear()
        TXTCATEGORY.Clear()
        txtremarks.Clear()

    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        Try
            showform(True, gridledger.GetFocusedRowCellValue("ITEMID"), gridledger.GetFocusedRowCellValue("NAME"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal ID As Integer, ByVal name As String)
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            If (editval = False) Or (gridledger.RowCount > 0 And editval = True) Then
                Dim objItemmaster As New NonInvItemMaster
                objItemmaster.MdiParent = MDIMain
                objItemmaster.EDIT = editval
                objItemmaster.TEMPNONINVId = ID
                objItemmaster.TEMPITEMNAME = name
                objItemmaster.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Try
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            showform(False, 0, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridledger_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridledger.Click
        Try
            getdetails(gridledger.GetFocusedRowCellValue("ITEMID"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PBEXCEL_Click(sender As Object, e As EventArgs) Handles PBEXCEL.Click
        Try
            Dim OBJACC As New NonInvItemMasterDetailReport
            OBJACC.MdiParent = MDIMain
            OBJACC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridledger_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridledger.DoubleClick
        Try
            showform(True, gridledger.GetFocusedRowCellValue("ITEMID"), gridledger.GetFocusedRowCellValue("NAME"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            FILLGRIDNAME()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub


End Class
