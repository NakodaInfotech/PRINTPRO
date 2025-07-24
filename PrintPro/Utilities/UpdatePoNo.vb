Imports System.ComponentModel
Imports BL
Public Class UpdatePoNo
    Private Sub CMDCLEAR_Click(sender As Object, e As EventArgs) Handles CMDCLEAR.Click
        Try
            CLEAR()
            TXTSRNO.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub CLEAR()
        Try
            EP.Clear()
            TXTSRNO.Clear()
            TXTNAME.Clear()
            TXTOLDPONO.Clear()
            TXTNEWPONO.Clear()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDEXIT_Click(sender As Object, e As EventArgs) Handles CMDEXIT.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDUPDATE_Click(sender As Object, e As EventArgs) Handles CMDUPDATE.Click
        Try
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("ISNULL(ORDERMASTER.ORDER_NO, '') AS ORDERNO, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME", "", " ORDERMASTER INNER JOIN LEDGERS ON ORDERMASTER.ORDER_LEDGERID = LEDGERS.Acc_id AND ORDERMASTER.ORDER_YEARID = LEDGERS.Acc_yearid", " AND ORDERMASTER.ORDER_NO = '" & TXTSRNO.Text.Trim & "' AND ORDERMASTER.ORDER_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                DT = OBJCMN.Execute_Any_String(" UPDATE ORDERMASTER SET ORDER_PONO = '" & TXTNEWPONO.Text.Trim & "' , ORDER_PODATE = '" & NEWPODATE.Text & "' WHERE ORDER_NO = " & Val(TXTSRNO.Text.Trim) & " AND ORDER_YEARID = " & YearId, "", "")
                DT = OBJCMN.Execute_Any_String(" UPDATE JOBBATCHMASTER SET job_pono = '" & TXTNEWPONO.Text.Trim & "' WHERE job_orderno = " & Val(TXTSRNO.Text.Trim) & " AND JOB_YEARID = " & YearId, "", "")
                DT = OBJCMN.Execute_Any_String(" UPDATE BATCHMASTER SET JOBBATCH_PONO = '" & TXTNEWPONO.Text.Trim & "' WHERE JOBBATCH_ORDERNO = " & Val(TXTSRNO.Text.Trim) & " AND JOBBATCH_YEARID = " & YearId, "", "")
            End If
            MsgBox("PO.No Updated Successfully")
            CLEAR()
            TXTSRNO.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If TXTSRNO.Text.Trim.Length = 0 Then
            EP.SetError(TXTSRNO, "Enter Order No")
            bln = False
        End If

        Dim OBJCMN As New ClsCommon
        Dim DTTABLE As New DataTable

        'CHECK WHETHER MTRS ARE RECD FROM JOBBER OR NOT, IF RECD THEN DONT ALLOW TO UPDATE
        DTTABLE = OBJCMN.search("ISNULL(ORDERMASTER_DESC.ORDER_DELOUTQTY, 0) AS DELQTY ", "", "ORDERMASTER INNER JOIN ORDERMASTER_DESC ON ORDERMASTER.ORDER_NO = ORDERMASTER_DESC.ORDER_NO AND ORDERMASTER.ORDER_YEARID = ORDERMASTER_DESC.ORDER_YEARID", " AND ORDERMASTER.ORDER_NO = " & Val(TXTSRNO.Text.Trim) & "  AND ORDERMASTER.ORDER_YEARID = " & YearId)
        If DTTABLE.Rows.Count > 0 AndAlso Val(DTTABLE.Rows(0).Item("DELQTY")) > 0 Then
            EP.SetError(TXTSRNO, "Unable to Update Challan Done !!")
            bln = False
        End If

        If TXTNEWPONO.Text.Trim = "" Then
            EP.SetError(TXTNEWPONO, " Please Enter New PO.No")
            bln = False
        End If

        Return bln
    End Function


    Private Sub UpdatePoNo_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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

    Private Sub TXTSRNO_Validated(sender As Object, e As EventArgs) Handles TXTSRNO.Validated
        Try
            If TXTSRNO.Text.Trim.Length > 0 Then

                'GET ORDER DETAILS W.R.T ORDER NO
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" ISNULL(ORDERMASTER.ORDER_PONO, '') AS PONO, ORDERMASTER.ORDER_PODATE AS PODATE , ISNULL(LEDGERS.Acc_cmpname, '') AS NAME ", "", " ORDERMASTER INNER JOIN LEDGERS ON ORDERMASTER.ORDER_LEDGERID = LEDGERS.Acc_id AND ORDERMASTER.ORDER_YEARID = LEDGERS.Acc_yearid", " AND ORDERMASTER.ORDER_NO = " & Val(TXTSRNO.Text.Trim) & " AND ORDERMASTER.ORDER_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    TXTNAME.Text = DT.Rows(0).Item("NAME")
                    TXTOLDPONO.Text = DT.Rows(0).Item("PONO")
                    PODATE.Value = DT.Rows(0).Item("PODATE")
                    NEWPODATE.Value = DT.Rows(0).Item("PODATE")

                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UpdatePoNo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            CLEAR()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub





    'Private Sub TXTPONO_Validating(sender As Object, e As CancelEventArgs)
    '    Try
    '        If TXTOLDPONO.Text.Trim <> "" Then
    '            Dim OBJCMN As New ClsCommon
    '            Dim DT As New DataTable

    '            DT = OBJCMN.search(" ORDER_NO AS ORDERNO ", "", " ORDERMASTER INNER JOIN LEDGERS ON ORDER_LEDGERID = ACC_ID ", " AND ORDER_PONO = '" & TXTOLDPONO.Text.Trim & "' AND ORDER_YEARID = " & YearId)
    '            If DT.Rows.Count > 0 Then
    '                If Val(DT.Rows(0).Item(0)) <> Val(TXTSRNO.Text.Trim) Then
    '                    MsgBox("PO No Already Exists in Order " & DT.Rows(0).Item(0), MsgBoxStyle.Critical)
    '                    e.Cancel = True
    '                    Exit Sub
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub
End Class