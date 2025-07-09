
Imports BL
Imports System.ComponentModel

Public Class NonInvItemMaster
    Public edit As Boolean              'Used for edit
    Public tempITEMname As String           'Used for edit name
    Public tempINVITEMname As String
    Public tempid, TEMPNONINVId As Integer            'Used for edit id
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub NonInvItemMaster_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLCMB()
        If CMBNONINVITEM.Text.Trim = "" Then FILLNONINVITEM(CMBNONINVITEM, edit)
        If CMBCATEGORY.Text.Trim = "" Then fillCATEGORY(CMBCATEGORY, edit)
        If CMBINVITEMCODE.Text.Trim = "" Then fillITEMCODE(CMBINVITEMCODE, edit)
        If CMBHSNCODE.Text.Trim = "" Then FILLHSNITEMDESC(CMBHSNCODE)
        If CMBPAPERMATERIAL.Text.Trim = "" Then fillMATERIAL(CMBPAPERMATERIAL, edit)
        If CMBPAPERMILL.Text.Trim = "" Then FILLPAPERMILL(CMBPAPERMILL, edit)
    End Sub

    Sub FILLHSNITEMDESC(ByRef CMBHSNCODE As ComboBox)
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            dt = objclscommon.search(" ISNULL(HSN_CODE, '') AS HSNCODE ", "", " HSNMASTER ", " AND HSN_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "HSNCODE"
                CMBHSNCODE.DataSource = dt
                CMBHSNCODE.DisplayMember = "HSNCODE"
            End If
            CMBHSNCODE.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHSNCODE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBHSNCODE.Enter
        Try
            If CMBHSNCODE.Text.Trim = "" Then FILLHSNITEMDESC(CMBHSNCODE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub NonInvItemMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            FILLCMB()
            'CMBNONINVITEM.Text = tempITEMname
            CMBNONINVITEM.Text = tempINVITEMname

            If edit = True Then
                Dim objCommon As New ClsCommonMaster
                Dim dttable As DataTable = objCommon.search(" NONINVITEMMASTER.NONINV_ID AS ID, ISNULL(NONINVITEMMASTER.NONINV_NAME, '') AS NAME, ISNULL(CATEGORYMASTER.category_name, '') AS CATEGORY, ISNULL(NONINVITEMMASTER.NONINV_LENGTH, 0) AS LENGTH, ISNULL(NONINVITEMMASTER.NONINV_WIDTH, 0) AS WIDTH, ISNULL(ITEMMASTER.ITEM_CODE, '') AS INVITEM, ISNULL(NONINVITEMMASTER.NONINV_GSM, 0) AS GSM, ISNULL(NONINVITEMMASTER.NONINV_REMARKS, '') AS REMARKS, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(NONINVITEMMASTER.NONINV_ISPLATE,0) AS ISPLATE, ISNULL(NONINVITEMMASTER.NONINV_ISPAPER,0) AS ISPAPER, ISNULL(PAPERMATERIALMASTER.PAPERMATERIAL_NAME,'') AS PAPERMATERIAL, ISNULL(PAPERMILLMASTER.PAPERMILL_NAME,'') AS PAPERMILL ", "", " NONINVITEMMASTER INNER JOIN CATEGORYMASTER ON NONINVITEMMASTER.NONINV_CATEGORYID = CATEGORYMASTER.category_id LEFT OUTER JOIN HSNMASTER ON NONINVITEMMASTER.NONINV_HSNCODEID = HSNMASTER.HSN_ID LEFT OUTER JOIN PAPERMATERIALMASTER ON NONINVITEMMASTER.NONINV_PAPERMATERIALID = PAPERMATERIALMASTER.PAPERMATERIAL_ID LEFT OUTER JOIN PAPERMILLMASTER ON NONINVITEMMASTER.NONINV_PAPERMILLID = PAPERMILLMASTER.PAPERMILL_ID LEFT OUTER JOIN ITEMMASTER ON NONINVITEMMASTER.NONINV_INVITEMID = ITEMMASTER.ITEM_ID", " and noninv_name = '" & tempITEMname & "' and NONINV_cmpid = " & CmpId & " and NONINV_Locationid = " & Locationid & " and NONINV_yearid = " & YearId)
                If dttable.Rows.Count > 0 Then
                    TEMPNONINVId = Val(dttable.Rows(0).Item("ID"))
                    CMBNONINVITEM.Text = dttable.Rows(0).Item("NAME").ToString
                    CMBHSNCODE.Text = dttable.Rows(0).Item("HSNCODE").ToString
                    CMBCATEGORY.Text = dttable.Rows(0).Item("CATEGORY").ToString
                    TXTLENGTH.Text = Val(dttable.Rows(0).Item("LENGTH"))
                    TXTWIDTH.Text = Val(dttable.Rows(0).Item("WIDTH"))
                    TXTGSM.Text = Val(dttable.Rows(0).Item("GSM"))
                    CMBINVITEMCODE.Text = dttable.Rows(0).Item("INVITEM").ToString
                    TXTREMARKS.Text = dttable.Rows(0).Item("REMARKS").ToString
                    CHKPLATEITEM.Checked = dttable.Rows(0).Item("ISPLATE")
                    CHKPAPERITEM.Checked = dttable.Rows(0).Item("ISPAPER")
                    CMBPAPERMATERIAL.Text = dttable.Rows(0).Item("PAPERMATERIAL")
                    CMBPAPERMILL.Text = dttable.Rows(0).Item("PAPERMILL")

                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            Ep.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            alParaval.Add(UCase(CMBNONINVITEM.Text.Trim))
            alParaval.Add(CMBHSNCODE.Text.Trim)
            alParaval.Add(CMBCATEGORY.Text.Trim)
            alParaval.Add(Val(TXTLENGTH.Text.Trim))
            alParaval.Add(Val(TXTWIDTH.Text.Trim))
            alParaval.Add(Val(TXTGSM.Text.Trim))
            alParaval.Add(CMBINVITEMCODE.Text.Trim)
            alParaval.Add(TXTREMARKS.Text.Trim)

            If CHKPLATEITEM.Checked = True Then
                alParaval.Add(1)
            Else
                alParaval.Add(0)
            End If

            If CHKPAPERITEM.Checked = True Then
                alParaval.Add(1)
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(CMBPAPERMATERIAL.Text.Trim)
            alParaval.Add(CMBPAPERMILL.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)

            Dim objNONINVMaster As New ClsNoninvItemmaster
            objNONINVMaster.alParaval = alParaval

            If edit = False Then
                IntResult = objNONINVMaster.SAVE()
                MsgBox("Details Added")
            Else
                alParaval.Add(TEMPNONINVId)
                IntResult = objNONINVMaster.UPDATE()
                MsgBox("Details Updated")
            End If
            CLEAR()
            CMBNONINVITEM.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub CLEAR()
        Try
            CMBCATEGORY.Text = ""
            CMBNONINVITEM.Text = ""
            CMBHSNCODE.Text = ""
            TXTLENGTH.Clear()
            TXTWIDTH.Clear()
            TXTGSM.Clear()
            CMBINVITEMCODE.Text = ""
            TXTREMARKS.Clear()
            CHKPLATEITEM.Checked = False
            CHKPAPERITEM.Checked = False
            CMBPAPERMATERIAL.Text = ""
            CMBPAPERMILL.Text = ""
            edit = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If CMBNONINVITEM.Text.Trim.Length = 0 Then
            Ep.SetError(CMBNONINVITEM, "Fill Item Name")
            bln = False
        End If

        If CMBCATEGORY.Text.Trim.Length = 0 Then
            Ep.SetError(CMBCATEGORY, "Fill Category Name")
            bln = False
        End If

        If CMBHSNCODE.Text.Trim.Length = 0 Then
            Ep.SetError(CMBHSNCODE, "Fill HSN Code")
            bln = False
        End If

        If CMBINVITEMCODE.Text.Trim.Length = 0 And CHKPLATEITEM.Checked = True Then
            Ep.SetError(CMBINVITEMCODE, "Fill Item Name")
            bln = False
        End If

        If TXTLENGTH.Text.Trim.Length = 0 And CHKPAPERITEM.Checked = True Then
            Ep.SetError(TXTLENGTH, "Fill Length")
            bln = False
        End If

        If TXTGSM.Text.Trim.Length = 0 And CHKPAPERITEM.Checked = True Then
            Ep.SetError(TXTGSM, "Fill Gsm")
            bln = False
        End If

        If TXTWIDTH.Text.Trim.Length = 0 And CHKPAPERITEM.Checked = True Then
            Ep.SetError(TXTWIDTH, "Fill Width")
            bln = False
        End If

        Return bln
    End Function

    Private Sub CMBCATEGORY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCATEGORY.Validating
        Try
            If CMBCATEGORY.Text.Trim <> "" Then Categoryvalidate(CMBCATEGORY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCATEGORY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBCATEGORY.Enter
        Try
            If CMBCATEGORY.Text.Trim = "" Then fillCATEGORY(CMBCATEGORY, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNONINVITEM_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBNONINVITEM.Enter
        Try
            If CMBNONINVITEM.Text.Trim = "" Then FILLNONINVITEM(CMBNONINVITEM, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBINVITEMNAME_Enter(sender As Object, e As EventArgs) Handles CMBINVITEMCODE.Enter
        Try
            If CMBINVITEMCODE.Text.Trim = "" Then fillITEMCODE(CMBINVITEMCODE, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNONINVITEM_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNONINVITEM.Validating
        Try
            If CMBNONINVITEM.Text.Trim <> "" Then
                pcase(CMBNONINVITEM)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If (edit = False) Or (edit = True And LCase(CMBNONINVITEM.Text) <> LCase(tempITEMname)) Then
                    dt = objclscommon.search("NONINV_name", "", "NONINVITEMMASTER", " and NONINV_name = '" & CMBNONINVITEM.Text.Trim & "' And  NONINV_yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox(" Item Name Already Exists", MsgBoxStyle.Critical, "PrintPro")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBINVITEMNAME_Validating(sender As Object, e As CancelEventArgs) Handles CMBINVITEMCODE.Validating
        Try
            If CMBINVITEMCODE.Text.Trim <> "" Then ITEMCODEvalidate(CMBINVITEMCODE, CMBITEMNAME, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        Try
            CLEAR()
            edit = False
            CMBNONINVITEM.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTGSM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTGSM.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTLENGTH_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTLENGTH.KeyPress, TXTWIDTH.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTHSNCODE_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectHSN
                OBJLEDGER.STRSEARCH = " AND HSN_TYPE='GOODS'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBHSNCODE.Text = OBJLEDGER.TEMPCODE
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHSNCODE_Validating(sender As Object, e As CancelEventArgs) Handles CMBHSNCODE.Validating
        Try
            If CMBHSNCODE.Text.Trim <> "" Then HSNITEMDESCVALIDATE(CMBHSNCODE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPAPERMATERIAL_Enter(sender As Object, e As EventArgs) Handles CMBPAPERMATERIAL.Enter
        Try
            If CMBPAPERMATERIAL.Text.Trim = "" Then fillMATERIAL(CMBPAPERMATERIAL, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPAPERMILL_Enter(sender As Object, e As EventArgs) Handles CMBPAPERMILL.Enter
        Try
            If CMBPAPERMILL.Text.Trim = "" Then FILLPAPERMILL(CMBPAPERMILL, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPAPERMATERIAL_Validating(sender As Object, e As CancelEventArgs) Handles CMBPAPERMATERIAL.Validating
        Try
            If CMBPAPERMATERIAL.Text.Trim <> "" Then MATERIALVALIDATE(CMBPAPERMATERIAL, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPAPERMILL_Validating(sender As Object, e As CancelEventArgs) Handles CMBPAPERMILL.Validating
        Try
            If CMBPAPERMILL.Text.Trim <> "" Then PAPERMILLVALIDATE(CMBPAPERMILL, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class