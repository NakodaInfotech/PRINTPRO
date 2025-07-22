
Imports BL
Imports System.Windows.Forms

Public Class SelectStock
    Dim tempindex, i As Integer
    Dim SELECTIONFORMULA As String = ""
    Dim ADDCOL As Boolean = False
    Dim col As New DataGridViewCheckBoxColumn
    Public DT As New DataTable
    Public GODOWN As String = ""
    Public ITEMCODE As String = ""
    Dim TEMPMSG As Integer
    Public TYPE As String = ""


    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SelectStock_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub SelectStock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FILLGRID(" ")
    End Sub

    Sub FILLGRID(ByVal WHERE As String)
        Try
            Cursor.Current = Cursors.WaitCursor

            If GODOWN <> "" Then WHERE = WHERE & " AND GODOWN = '" & GODOWN & "'"
            If ITEMCODE <> "" Then WHERE = WHERE & " AND INVITEMCODE = '" & ITEMCODE & "'"

            Dim objcmn As New ClsCommon
            Dim dt As DataTable
            If TYPE = "PAPER" Then
                GITEMCODE.Visible = False
                dt = objcmn.search("CAST(0 AS BIT) AS CHK,ITEMNAME,PAPERGSM,LOTNO  ,CHALLANNO ,UNIT, ROUND(SUM(QTY),2) AS QTY, ROUND(SUM(WT),2) AS WT , RATE  ", "", "STOCKVIEW", " " & WHERE & " AND ISPAPER = 1 AND  CMPID = " & CmpId & " AND YEARID = " & YearId & " GROUP BY  ITEMNAME,PAPERGSM, UNIT,LOTNO ,CHALLANNO , RATE HAVING ROUND(SUM(QTY),2) >0")
            ElseIf TYPE = "OTHER" Then
                GITEMCODE.Visible = False
                dt = objcmn.search("CAST(0 AS BIT) AS CHK,ITEMNAME,PAPERGSM,LOTNO ,CHALLANNO ,UNIT, SUM(QTY) AS QTY, SUM(WT) AS WT ,RATE   ", "", "STOCKVIEW", " " & WHERE & " AND ISPLATE = 0 AND ISPAPER = 0 AND  CMPID = " & CmpId & " AND YEARID = " & YearId & " GROUP BY  ITEMNAME,PAPERGSM, UNIT,LOTNO ,CHALLANNO ,RATE  HAVING SUM(QTY)> 0")

            ElseIf TYPE = "MAINSTOCK" Then
                GPapergsm.Visible = False
                GWT.Visible = False
                GRATE.Visible = False
                GLOTNO.Visible = False
                GUNIT.Visible = False
                GAMOUNT.Visible = False

                dt = objcmn.search("CAST(0 AS BIT) AS CHK,ITEMCODE,ITEMNAME,SUM(QTY) AS QTY ", "", "MAINSTOCKVIEW", " AND  CMPID = " & CmpId & " AND YEARID = " & YearId & " GROUP BY ITEMCODE,ITEMNAME HAVING SUM(QTY)> 0")

            Else
                GITEMCODE.Visible = False
                dt = objcmn.search("CAST(0 AS BIT) AS CHK,ITEMNAME,PAPERGSM,LOTNO , CHALLANNO ,UNIT, SUM(QTY) AS QTY, SUM(WT) AS WT ,RATE ", "", "STOCKVIEW", " " & WHERE & " AND  CMPID = " & CmpId & " AND YEARID = " & YearId & " GROUP BY  ITEMNAME,PAPERGSM, UNIT,LOTNO ,CHALLANNO ,RATE  HAVING SUM(QTY)> 0")
            End If
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            If TYPE = "MAINSTOCK" Then
                DT.Columns.Add("ITEMCODE")
                DT.Columns.Add("ITEMNAME")
                DT.Columns.Add("QTY")

                For i As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        DT.Rows.Add(dtrow("ITEMCODE"), dtrow("ITEMNAME"), Val(dtrow("QTY")))
                    End If
                Next
                Me.Close()

            Else

                'Dim COUNT As Integer = 0
                'For i As Integer = 0 To gridbill.RowCount - 1
                '    Dim dtrow As DataRow = gridbill.GetDataRow(i)
                '    If Convert.ToBoolean(dtrow("CHK")) = True Then
                '        COUNT = COUNT + 1
                '    End If
                'Next

                'If COUNT > 1 Then
                '    MsgBox("You Can Select Only One Order")

                '    Exit Sub
                'End If


                Dim n As String = ""
                For i As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        If n <> "" Then
                            If n = (dtrow("CHALLANNO")) Then
                                GoTo Line1
                            Else
                                MsgBox("Pls select same Challan No Stocks !")
                                Exit Sub
                            End If
                        End If
Line1:
                        n = (dtrow("CHALLANNO"))
                    End If
                Next

                DT.Columns.Add("ITEMNAME")
                DT.Columns.Add("PAPERGSM")
                DT.Columns.Add("LOTNO")
                DT.Columns.Add("QTY")
                DT.Columns.Add("WT")
                DT.Columns.Add("UNIT")
                DT.Columns.Add("RATE")
                DT.Columns.Add("CHALLANNO")







                For i As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        DT.Rows.Add(dtrow("ITEMNAME"), dtrow("PAPERGSM"), dtrow("LOTNO"), Val(dtrow("QTY")), Val(dtrow("WT")), dtrow("UNIT"), dtrow("RATE"), dtrow("CHALLANNO"))
                    End If
                Next
                Me.Close()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class