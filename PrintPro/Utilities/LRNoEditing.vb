Imports BL

Public Class LRNoEditing
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            'If USEREDIT = False And USERVIEW = False Then
            '    MsgBox("Insufficient Rights")
            '    Exit Sub
            'End If
            If TXTCHALLANNO.Text.Trim <> "" And TXTNAME.Text.Trim <> "" And TXTTRANSANAME.Text.Trim <> "" And TXTLRNO.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As New DataTable
                DT = OBJCMN.Execute_Any_String(" UPDATE CHALLANMASTER SET CHALLAN_LRNO = " & Val(TXTLRNO.Text.Trim) & " WHERE CHALLANMASTER.CHALLAN_NO = " & Val(TXTCHALLANNO.Text.Trim) & " AND CHALLANMASTER.CHALLAN_YEARID = " & YearId, "", "")
                MsgBox("LR No Updated Successfully")
                CLEAR()
                TXTCHALLANNO.Focus()
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical)
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCHALLANNO_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCHALLANNO.Validating
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" CHALLANMASTER.challan_no AS CHALLANNO, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(TRANSID.Acc_cmpname, '') AS TRANSPORTNAME, ISNULL(CHALLANMASTER.challan_lrno, '') AS LRNO, CHALLANMASTER.challan_lrdate AS LRDATE ", " ", " CHALLANMASTER LEFT OUTER JOIN LEDGERS ON CHALLANMASTER.challan_ledgerid = LEDGERS.Acc_id AND CHALLANMASTER.challan_yearid = LEDGERS.Acc_yearid LEFT OUTER JOIN LEDGERS AS TRANSID ON CHALLANMASTER.challan_transid = TRANSID.Acc_id AND CHALLANMASTER.challan_yearid = TRANSID.Acc_yearid ", "  AND challanmaster.challan_no = '" & TXTCHALLANNO.Text.Trim & "' AND challanmaster.challan_yearid = " & YearId)

            If DT.Rows.Count > 0 Then
                For Each DR As DataRow In DT.Rows
                    TXTNAME.Text = Convert.ToString(DR("NAME"))
                    TXTTRANSANAME.Text = Convert.ToString(DR("TRANSPORTNAME"))
                    TXTLRNO.Text = Convert.ToString(DR("LRNO"))
                    DTLR.Value = Format(Convert.ToDateTime(DR("LRDATE")).Date, "dd/MM/yyyy")
                Next
            Else
                MsgBox("Invalid Challan No", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CLEAR()
        Try
            TXTCHALLANNO.Clear()
            TXTNAME.Clear()
            TXTTRANSANAME.Clear()
            TXTLRNO.Clear()
            DTLR.Value = Mydate
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LRNoEditing_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LRNoEditing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            CLEAR()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LRNoEditing_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            If UserName <> "Admin" Then Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class