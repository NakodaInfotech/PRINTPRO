﻿
Imports BL

Public Class LedgerFilter

    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String
    Public FRMSTRING As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub FILLGROUP(ByVal WHERECLAUSE As String)
        Try
            If CMBGROUP.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("group_name", "", "GroupMaster", " and group_cmpid = " & CmpId & " and group_Locationid = " & Locationid & " and group_Yearid = " & YearId & WHERECLAUSE)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "Group_name"
                    CMBGROUP.DataSource = dt
                    CMBGROUP.DisplayMember = "group_name"
                    CMBGROUP.Text = ""
                End If
                CMBGROUP.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub FILLCMB()
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, False, "")
            If CMBGROUP.Text.Trim = "" Then FILLGROUP("")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LedgerFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LedgerFilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            FILLCMB()
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

    Private Sub RBACCOUNT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBACCOUNT.CheckedChanged
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" CAST (0 AS BIT) AS CHK,LEDGERS.Acc_cmpname AS NAME, GROUPMASTER.group_secondary AS UNDER, ISNULL(CITYMASTER.city_name, '') AS CITY  ", " ", " LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_groupid = GROUPMASTER.group_id AND LEDGERS.Acc_cmpid = GROUPMASTER.group_cmpid AND LEDGERS.Acc_locationid = GROUPMASTER.group_locationid AND LEDGERS.Acc_yearid = GROUPMASTER.group_yearid LEFT OUTER JOIN CITYMASTER ON LEDGERS.Acc_yearid = CITYMASTER.city_yearid AND LEDGERS.Acc_locationid = CITYMASTER.city_locationid AND LEDGERS.Acc_cmpid = CITYMASTER.city_cmpid AND LEDGERS.Acc_cityid = CITYMASTER.city_id ", " AND (LEDGERS.ACC_CMPID = '" & CmpId & "') AND (LEDGERS.ACC_LOCATIONID = '" & Locationid & "') AND (LEDGERS.ACC_YEARID = '" & YearId & "') ORDER BY LEDGERS.Acc_cmpname")
            gridbilldetails.DataSource = dt
           

            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RBGROUP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBGROUP.CheckedChanged
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" CAST (0 AS BIT) AS CHK, group_name AS NAME, group_under AS UNDER, group_secondary AS CITY ", " ", " GROUPMASTER ", " AND (GROUPMASTER.GROUP_CMPID = '" & CmpId & "') AND (GROUPMASTER.GROUP_LOCATIONID = '" & Locationid & "') AND (GROUPMASTER.GROUP_YEARID = '" & YearId & "') ORDER BY group_name")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RBSELECTED_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBSELECTED.CheckedChanged
        gridbilldetails.Visible = True
    End Sub

    Private Sub RBALL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBALL.CheckedChanged
        gridbilldetails.Visible = False
    End Sub

    Private Sub cmdshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshow.Click
        Try
            Dim objreg As New registerdesign
            Dim tempmsg As Integer = vbNo

            If RBSUMMARY.Checked = True Then
                objreg.frmstring = "LedgerBook"
            ElseIf RBDETAILS.Checked = True Then
                objreg.frmstring = "LedgerBookDetails"
            ElseIf RBTFORMAT.Checked = True Then
                objreg.frmstring = "LedgerBookTFormat"
            End If

            objreg.strsearch = "{LEDGERBOOK.ACC_Type} <> 'OPENING' AND {LEDGERBOOK.Yearid} = " & YearId
            If cmbname.Text.Trim <> "" Then objreg.strsearch = objreg.strsearch & " AND {LEDGERBOOK.Name} = '" & cmbname.Text.Trim & "'"

            getFromToDate()

            objreg.CLOSINGDRCR = lbldrcrclosing.Text

            If chkdate.Checked = True Then
                objreg.FROMDATE = dtfrom.Value.Date
                objreg.TODATE = dtto.Value.Date
                objreg.PERIOD = "LEDGER BOOK (" & Format(dtfrom.Value.Date, "dd/MM/yyyy") & " - " & Format(dtto.Value.Date, "dd/MM/yyyy") & ")"
            Else
                objreg.FROMDATE = AccFrom
                objreg.TODATE = AccTo
                objreg.PERIOD = "LEDGER BOOK (" & Format(AccFrom.Date, "dd/MM/yyyy") & " - " & Format(AccTo.Date, "dd/MM/yyyy") & ")"
            End If


            gridbill.ClearColumnsFilter()
            Dim NAMECLAUSE As String = ""
            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    If NAMECLAUSE = "" Then
                        NAMECLAUSE = " AND ({LEDGERBOOK.Name} = '" & dtrow("NAME") & "'"
                    Else
                        NAMECLAUSE = NAMECLAUSE & " OR {LEDGERBOOK.Name} = '" & dtrow("NAME") & "'"
                    End If
                End If
            Next

            If NAMECLAUSE <> "" Then
                NAMECLAUSE = NAMECLAUSE & ")"
                objreg.strsearch = objreg.strsearch & NAMECLAUSE
            End If
            objreg.NEWPAGE = CHKGROUPONNEWPG.CheckState
            objreg.INDEX = CHKINDEX.CheckState
            If CHKADDRESS.Checked = True Then objreg.ADDRESS = 1 Else objreg.ADDRESS = 0

            objreg.PARTYNAME = cmbname.Text.Trim
            objreg.MdiParent = MDIMain
            objreg.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class