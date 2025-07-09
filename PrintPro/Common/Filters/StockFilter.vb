Imports System.ComponentModel
Imports BL

Public Class StockFilter
    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String

    Private Sub StockFilter_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshowreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowreport.Click
        Try

            Dim OBJSTOCK As New StockDesign
            OBJSTOCK.MdiParent = MDIMain
            OBJSTOCK.WHERECLAUSE = " {STOCKVIEW.YEARID} = " & YearId
            If CMBGODOWN.Text.Trim <> "" Then OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " AND {STOCKVIEW.GODOWN}= '" & CMBGODOWN.Text.Trim & "'"
            If CMBITEM.Text.Trim <> "" Then OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " AND {STOCKVIEW.ITEMNAME}= '" & CMBITEM.Text.Trim & "'"
            If CMBCATEGORY.Text.Trim <> "" Then OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " AND {STOCKVIEW.CATEGORY} = '" & CMBCATEGORY.Text.Trim & "' "
            If CMBPAPERMATERIAL.Text.Trim <> "" Then OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " AND {STOCKVIEW.PAPERMATERIAL} = '" & CMBPAPERMATERIAL.Text.Trim & "' "
            If TXTGSM.Text.Trim <> "" Then OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " AND {STOCKVIEW.PAPERGSM} = " & Val(TXTGSM.Text.Trim)
            If CMBPAPERMILL.Text.Trim <> "" Then OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " AND {STOCKVIEW.PAPERMILL} = '" & CMBPAPERMILL.Text.Trim & "' "
            If CHKPLATEITEM.Checked = True Then OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " AND {STOCKVIEW.ISPLATE} = TRUE "
            If CHKPAPERITEM.Checked = True Then OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " AND {STOCKVIEW.ISPAPER} = TRUE "

            If RDBDETAILS.Checked = True Then
                OBJSTOCK.FRMSTRING = "STOCKREG"
            ElseIf RDBSUMM.Checked = True Then
                OBJSTOCK.FRMSTRING = "STOCKINHAND"
                OBJSTOCK.SHOWALL = CHKSHOWALL.Checked
            ElseIf RDBRATEWISE.Checked = True Then
                OBJSTOCK.FRMSTRING = "STOCKRATEWISE"
            End If


            If chkdate.Checked = True Then
                getFromToDate()
                OBJSTOCK.FROMDATE = dtfrom.Value.Date
                OBJSTOCK.TODATE = dtto.Value.Date
                OBJSTOCK.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & "-" & Format(dtto.Value, "dd/MM/yyyy")
                OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " AND {@DATE} IN DATE " & fromD & " TO DATE" & toD & ""
            Else
                OBJSTOCK.FROMDATE = AccFrom.Date
                OBJSTOCK.TODATE = AccTo.Date
                OBJSTOCK.PERIOD = Format(AccFrom, "dd/MM/yyyy") & "-" & Format(AccTo, "dd/MM/yyyy")
            End If
            OBJSTOCK.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getFromToDate()
        a1 = DatePart(DateInterval.Day, dtfrom.Value)
        a2 = DatePart(DateInterval.Month, dtfrom.Value)
        a3 = DatePart(DateInterval.Year, dtfrom.Value)
        fromD = "(" & a3 & "," & a2 & "," & a1 & ")"

        a11 = DatePart(DateInterval.Day, dtto.Value)
        a12 = DatePart(DateInterval.Month, dtto.Value)
        a13 = DatePart(DateInterval.Year, dtto.Value)
        toD = "(" & a13 & "," & a12 & "," & a11 & ")"
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub StockFilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            FILLCMB()
            chkdate.Checked = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLCMB()
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, False)
            If CMBITEM.Text.Trim = "" Then FILLNONINVITEM(CMBITEM, False)
            'If cmbshelf.Text.Trim = "" Then fillSHELF(cmbshelf, False)
            If CMBCATEGORY.Text.Trim = "" Then fillCATEGORY(CMBCATEGORY, False)
            If CMBPAPERMATERIAL.Text.Trim = "" Then fillMATERIAL(CMBPAPERMATERIAL, False)
            If CMBPAPERMILL.Text.Trim = "" Then FILLPAPERMILL(CMBPAPERMILL, False)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBGODOWN.Enter
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, False)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPAPERMATERIAL_Enter(sender As Object, e As EventArgs) Handles CMBPAPERMATERIAL.Enter
        Try
            If CMBPAPERMATERIAL.Text.Trim = "" Then fillMATERIAL(CMBPAPERMATERIAL, False)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPAPERMILL_Enter(sender As Object, e As EventArgs) Handles CMBPAPERMILL.Enter
        Try
            If CMBPAPERMILL.Text.Trim = "" Then FILLPAPERMILL(CMBPAPERMILL, False)
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