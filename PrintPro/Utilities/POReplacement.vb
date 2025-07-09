Imports BL

Public Class POReplacement
    Private Sub CMDEXIT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub clear()
        Try
            TXTOLDPONO.Clear()
            TXTNEWPONO.Clear()
            TXTNO.Clear()
            CMBREGISTER.DataSource = Nothing
            CMBTYPE.SelectedItem = Nothing
            CMBTYPE.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Private Sub TXTNEWPONO_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTNEWPONO.KeyPress
    '    'Try
    '    '    numkeypress(e, sender, Me)
    '    'Catch ex As Exception
    '    '    Throw ex
    '    'End Try
    'End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable
            If CMBTYPE.Text.Trim <> "" And TXTNEWPONO.Text.Trim <> "" And Val(TXTNO.Text.Trim) > 0 Then
                If CMBTYPE.Text.Trim = "Order" Then
                    'ordermaster
                    DT = OBJCMN.Execute_Any_String(" UPDATE ORDERMASTER SET ORDER_PONO = '" & TXTNEWPONO.Text.Trim & "' WHERE ORDER_NO = " & Val(TXTNO.Text.Trim) & " AND ORDER_YEARID = " & YearId, "", "")
                    MsgBox("PO No Updated Successfully")
                    clear()
                End If
                If CMBTYPE.Text.Trim = "Job Docket" Then
                    'JOBMASTER
                    DT = OBJCMN.Execute_Any_String(" UPDATE JOBMASTER SET JOB_PONO = '" & TXTNEWPONO.Text.Trim & "' WHERE JOB_NO = " & Val(TXTNO.Text.Trim) & " AND JOB_YEARID = " & YearId, "", "")
                    MsgBox("PO No Updated Successfully")
                    clear()

                End If
                If CMBTYPE.Text.Trim = "Batch" Then
                    'JOBBATCHMASTER
                    DT = OBJCMN.Execute_Any_String(" UPDATE JOBBATCHMASTER SET JOB_PONO = '" & TXTNEWPONO.Text.Trim & "' WHERE JOB_NO = " & Val(TXTNO.Text.Trim) & " AND JOB_YEARID = " & YearId, "", "")
                    MsgBox("PO No Updated Successfully")
                    clear()
                End If
                If CMBTYPE.Text.Trim = "Challan" Then
                    'CHALLANMASTER
                    DT = OBJCMN.Execute_Any_String(" UPDATE CHALLANMASTER SET CHALLAN_PONO = '" & TXTNEWPONO.Text.Trim & "' WHERE CHALLANMASTER.CHALLAN_NO = " & Val(TXTNO.Text.Trim) & " AND CHALLAN_YEARID = " & YearId, "", "")
                    MsgBox("PO No Updated Successfully")
                    clear()
                End If
                If CMBTYPE.Text.Trim = "Invoice" And CMBREGISTER.Text.Trim <> "" Then
                    'INVOICEMASTER
                    DT = OBJCMN.Execute_Any_String(" UPDATE INVOICEMASTER SET INVOICE_PONO = '" & TXTNEWPONO.Text.Trim & "' WHERE INVOICE_REGISTERID  = (SELECT REGISTERMASTER.register_id FROM REGISTERMASTER WHERE register_name = '" & CMBREGISTER.Text.Trim & "' AND REGISTER_YEARID = " & YearId & ") AND INVOICE_NO = " & Val(TXTNO.Text.Trim) & " AND INVOICE_YEARID = " & YearId, "", "")
                    MsgBox("PO No Updated Successfully")
                    clear()
                Else
                    If CMBREGISTER.Text.Trim = "" Then
                        MsgBox("Select Register", MsgBoxStyle.Critical)
                        CMBREGISTER.Focus()
                        Exit Sub
                    End If
                End If
                Exit Sub
            End If


            If CMBTYPE.Text.Trim = "All" And CMBREGISTER.Text.Trim <> "" Then
                'ORDERMASTER
                DT = OBJCMN.Execute_Any_String(" UPDATE ORDERMASTER SET ORDER_PONO = '" & TXTNEWPONO.Text.Trim & "' WHERE ORDER_NO = " & Val(TXTNO.Text.Trim) & " AND ORDER_YEARID = " & YearId, "", "")

                'JOBMASTER
                DT = OBJCMN.Execute_Any_String(" UPDATE JOBMASTER SET JOB_PONO = '" & TXTNEWPONO.Text.Trim & "' WHERE JOB_NO = " & Val(TXTNO.Text.Trim) & " AND JOB_YEARID = " & YearId, "", "")

                'JOBBATCHMASTER
                DT = OBJCMN.Execute_Any_String(" UPDATE JOBBATCHMASTER SET JOB_PONO = '" & TXTNEWPONO.Text.Trim & "' WHERE JOB_NO = " & Val(TXTNO.Text.Trim) & " AND JOB_YEARID = " & YearId, "", "")

                'CHALLANMASTER
                DT = OBJCMN.Execute_Any_String(" UPDATE CHALLANMASTER SET CHALLAN_PONO = '" & TXTNEWPONO.Text.Trim & "' WHERE CHALLANMASTER.CHALLAN_NO = " & Val(TXTNO.Text.Trim) & " AND CHALLAN_YEARID = " & YearId, "", "")

                'INVOICEMASTER
                DT = OBJCMN.Execute_Any_String(" UPDATE INVOICEMASTER SET INVOICE_PONO = '" & TXTNEWPONO.Text.Trim & "' WHERE INVOICE_REGISTERID = (SELECT REGISTERMASTER.register_id FROM REGISTERMASTER WHERE register_name = '" & CMBREGISTER.Text.Trim & "' AND REGISTER_YEARID = " & YearId & ") AND INVOICE_NO = " & Val(TXTNO.Text.Trim) & " AND INVOICE_YEARID = " & YearId, "", "")

                MsgBox("PO No Updated for all Successfully")
                clear()
            Else
                If CMBREGISTER.Text.Trim = "" Then
                    MsgBox("Select Register", MsgBoxStyle.Critical)
                    CMBREGISTER.Focus()
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub POReplacement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTNO_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTNO.Validating
        Try
            TXTOLDPONO.Clear()
            TXTNEWPONO.Clear()

            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable

            If CMBTYPE.Text = "Order" Then DT = OBJCMN.search(" ORDER_PONO AS PONO ", " ", " ORDERMASTER ", " AND ORDER_NO = '" & TXTNO.Text.Trim & "' AND ORDER_YEARID = " & YearId)
            If CMBTYPE.Text = "Job Docket" Then DT = OBJCMN.search(" JOB_PONO AS PONO ", " ", " JOBMASTER ", "  AND JOB_NO = '" & TXTNO.Text.Trim & "' AND JOB_YEARID = " & YearId)
            If CMBTYPE.Text = "Batch" Then DT = OBJCMN.search(" JOB_PONO AS PONO ", " ", " JOBBATCHMASTER ", "  AND JOB_NO = '" & TXTNO.Text.Trim & "' AND JOB_YEARID = " & YearId)
            If CMBTYPE.Text = "Challan" Then DT = OBJCMN.search(" CHALLAN_PONO AS PONO ", " ", " CHALLANMASTER ", "  AND CHALLAN_NO = '" & TXTNO.Text.Trim & "' AND challanmaster.challan_yearid = " & YearId)

            If DT.Rows.Count > 0 Then
                For Each DR As DataRow In DT.Rows
                    TXTOLDPONO.Text = Convert.ToString(DR("PONO"))
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTYPE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTYPE.Validating
        Try
            CMBREGISTER.DataSource = Nothing
            TXTNO.Clear()
            TXTOLDPONO.Clear()
            TXTNEWPONO.Clear()
            If CMBTYPE.Text.Trim = "Invoice" Or CMBTYPE.Text.Trim = "All" Then
                fillregister(CMBREGISTER, " and register_type='SALE' ")
            Else
                TXTNO.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub POReplacement_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub POReplacement_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            If UserName <> "Admin" Then Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class