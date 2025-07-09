
Imports BL

Public Class TaxFilter

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TaxFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.OemQuotes Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.Escape Then
                Me.Close()
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.S) Then
                cmdshow_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshow.Click
        Try

            If RDTAX.Checked = True Then

                If MsgBox("Wish To Mail Directly?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Dim OBJRPT As New clsReportDesigner("Tax Summary", System.AppDomain.CurrentDomain.BaseDirectory & "Tax Summary.xls", 2)
                    If chkdate.CheckState = CheckState.Checked Then
                        OBJRPT.TAXREPORT_EXCEL(" WHERE T.DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND T.DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "' AND T.YEARID = " & YearId, "", CmpId, YearId)
                    Else
                        OBJRPT.TAXREPORT_EXCEL(" WHERE T.DATE >= '" & Format(AccFrom.Date, "MM/dd/yyyy") & "' AND T.DATE <= '" & Format(AccTo.Date, "MM/dd/yyyy") & "' AND T.YEARID = " & YearId, "", CmpId, YearId)
                    End If
                    Exit Sub
                Else
                    Dim OBJRPT As New clsReportDesigner("Tax Summary", System.AppDomain.CurrentDomain.BaseDirectory & "Tax Summary.xls", 0)
                    If chkdate.CheckState = CheckState.Checked Then
                        OBJRPT.TAXREPORT_EXCEL(" WHERE T.DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND T.DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "' AND T.YEARID = " & YearId, "", CmpId, YearId)
                    Else
                        OBJRPT.TAXREPORT_EXCEL(" WHERE T.DATE >= '" & Format(AccFrom.Date, "MM/dd/yyyy") & "' AND T.DATE <= '" & Format(AccTo.Date, "MM/dd/yyyy") & "' AND T.YEARID = " & YearId, "", CmpId, YearId)
                    End If

                    'MAIL EXCEL AS ATTACHMENTS
                    Dim TEMPATTACHMENT As String = System.AppDomain.CurrentDomain.BaseDirectory & "Tax Summary.xls"
                    Dim objmail As New SendMail
                    objmail.attachment = TEMPATTACHMENT
                    objmail.Show()
                    objmail.BringToFront()
                    Windows.Forms.Cursor.Current = Cursors.Arrow

                    Exit Sub
                End If

            ElseIf RBJ1.Checked = True Then

                If MsgBox("Wish To Mail Directly?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Dim OBJRPT As New clsReportDesigner("J1 Annexure", System.AppDomain.CurrentDomain.BaseDirectory & "J1 Annexure.xls", 2)
                    If chkdate.CheckState = CheckState.Checked Then
                        OBJRPT.J1REPORT_EXCEL(" AND INVOICEMASTER.INVOICE_DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND INVOICEMASTER.INVOICE_DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'", dtfrom.Value.Date, dtto.Value.Date, CmpId, YearId)
                    Else
                        OBJRPT.J1REPORT_EXCEL(" AND INVOICEMASTER.INVOICE_DATE >= '" & Format(AccFrom.Date, "MM/dd/yyyy") & "' AND INVOICEMASTER.INVOICE_DATE <= '" & Format(AccTo.Date, "MM/dd/yyyy") & "'", AccFrom.Date, AccTo.Date, CmpId, YearId)
                    End If
                    Exit Sub
                Else
                    Dim OBJRPT As New clsReportDesigner("J1 Annexure", System.AppDomain.CurrentDomain.BaseDirectory & "J1 Annexure.xls", 0)
                    If chkdate.CheckState = CheckState.Checked Then
                        OBJRPT.J1REPORT_EXCEL(" AND INVOICEMASTER.INVOICE_DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND INVOICEMASTER.INVOICE_DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'", dtfrom.Value.Date, dtto.Value.Date, CmpId, YearId)
                    Else
                        OBJRPT.J1REPORT_EXCEL(" AND INVOICEMASTER.INVOICE_DATE >= '" & Format(AccFrom.Date, "MM/dd/yyyy") & "' AND INVOICEMASTER.INVOICE_DATE <= '" & Format(AccTo.Date, "MM/dd/yyyy") & "'", AccFrom.Date, AccTo.Date, CmpId, YearId)
                    End If

                    'MAIL EXCEL AS ATTACHMENTS
                    Dim TEMPATTACHMENT As String = System.AppDomain.CurrentDomain.BaseDirectory & "J1 Annexure.xls"
                    Dim objmail As New SendMail
                    objmail.attachment = TEMPATTACHMENT
                    objmail.Show()
                    objmail.BringToFront()
                    Windows.Forms.Cursor.Current = Cursors.Arrow

                    Exit Sub
                End If

            ElseIf RBJ2.Checked = True Then

                If MsgBox("Wish To Mail Directly?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Dim OBJRPT As New clsReportDesigner("J2 Annexure", System.AppDomain.CurrentDomain.BaseDirectory & "J2 Annexure.xls", 2)
                    If chkdate.CheckState = CheckState.Checked Then
                        OBJRPT.J2REPORT_EXCEL(" AND PURCHASEMASTER.BILL_PARTYBILLDATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND PURCHASEMASTER.BILL_PARTYBILLDATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'", dtfrom.Value.Date, dtto.Value.Date, CmpId, YearId)
                    Else
                        OBJRPT.J2REPORT_EXCEL(" AND PURCHASEMASTER.BILL_PARTYBILLDATE >= '" & Format(AccFrom.Date, "MM/dd/yyyy") & "' AND PURCHASEMASTER.BILL_PARTYBILLDATE <= '" & Format(AccTo.Date, "MM/dd/yyyy") & "'", AccFrom.Date, AccTo.Date, CmpId, YearId)
                    End If
                    Exit Sub
                Else
                    Dim OBJRPT As New clsReportDesigner("J2 Annexure", System.AppDomain.CurrentDomain.BaseDirectory & "J2 Annexure.xls", 0)
                    If chkdate.CheckState = CheckState.Checked Then
                        OBJRPT.J2REPORT_EXCEL(" AND PURCHASEMASTER.BILL_PARTYBILLDATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND PURCHASEMASTER.BILL_PARTYBILLDATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'", dtfrom.Value.Date, dtto.Value.Date, CmpId, YearId)
                    Else
                        OBJRPT.J2REPORT_EXCEL(" AND PURCHASEMASTER.BILL_PARTYBILLDATE >= '" & Format(AccFrom.Date, "MM/dd/yyyy") & "' AND PURCHASEMASTER.BILL_PARTYBILLDATE <= '" & Format(AccTo.Date, "MM/dd/yyyy") & "'", AccFrom.Date, AccTo.Date, CmpId, YearId)
                    End If

                    'MAIL EXCEL AS ATTACHMENTS
                    Dim TEMPATTACHMENT As String = System.AppDomain.CurrentDomain.BaseDirectory & "J2 Annexure.xls"
                    Dim objmail As New SendMail
                    objmail.attachment = TEMPATTACHMENT
                    objmail.Show()
                    objmail.BringToFront()
                    Windows.Forms.Cursor.Current = Cursors.Arrow

                    Exit Sub
                End If

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class