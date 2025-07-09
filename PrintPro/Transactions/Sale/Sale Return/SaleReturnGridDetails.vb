

Imports BL
Imports System.Windows.Forms

Public Class SaleReturnGridDetails

        Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

        Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
            Me.Close()
        End Sub

        Private Sub SaleReturnGridDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
            Try
                If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                    Me.Close()
                ElseIf e.KeyCode = Keys.N And e.Control = True Then
                    showform(False, 0)
                ElseIf e.KeyCode = Keys.O And e.Alt = True Then
                    cmdok_Click(sender, e)
                End If
            Catch ex As Exception
                If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
            End Try
        End Sub

        Private Sub SaleReturnGridDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Try
                Dim DTROW() As DataRow
                DTROW = USERRIGHTS.Select("FormName = 'GRN'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                fillgrid(" and SALERETURN.SALRET_yearid=" & YearId & " order by SALERETURN.SALRET_no ")

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Sub fillgrid(ByVal TEMPCONDITION)
            Try
                Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" SALERETURN.SALRET_NO AS SRNO, SALERETURN.SALRET_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, ISNULL(SALERETURN_DESC.SALRET_ITEMCODE, '') AS ITEMCODE, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(SALERETURN_DESC.SALRET_MATERIALCODE, '') AS MATERIALCODE, ISNULL(SALERETURN_DESC.SALRET_QTY, 0) AS QTY, ISNULL(SALERETURN_DESC.SALRET_BATCHNO, 0) AS BATCHNO, ISNULL(SALERETURN_DESC.SALRET_SHIPPERS, 0) AS SHIPPERS, ISNULL(SALERETURN_DESC.SALRET_PACKETS, 0) AS PACKETS, ISNULL(SALERETURN_DESC.SALRET_RATE, 0) AS RATE, ISNULL(SALERETURN_DESC.SALRET_AMT, 0) AS AMT ", "", " HSNMASTER LEFT OUTER JOIN ITEMMASTER ON HSNMASTER.HSN_ID = ITEMMASTER.ITEM_HSNCODEID RIGHT OUTER JOIN SALERETURN INNER JOIN LEDGERS ON SALERETURN.SALRET_ledgerid = LEDGERS.Acc_id INNER JOIN SALERETURN_DESC ON SALERETURN.SALRET_NO = SALERETURN_DESC.SALRET_NO AND SALERETURN.SALRET_yearid = SALERETURN_DESC.SALRET_YEARID ON ITEMMASTER.item_id = SALERETURN_DESC.SALRET_ITEMID LEFT OUTER JOIN LEDGERS AS TRANSLEDGERS ON SALERETURN.SALRET_TRANSID = TRANSLEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS agentLEDGERS ON SALERETURN.SALRET_AGENTID = agentLEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS DEBITLEDGERS ON SALERETURN.SALRET_DEBITLEDGERID = DEBITLEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS PACKINGLEDGERS ON SALERETURN.SALRET_DELIVERYATID = PACKINGLEDGERS.Acc_id ", TEMPCONDITION)
            gridbilldetails.DataSource = dt
                If dt.Rows.Count > 0 Then
                    gridbill.FocusedRowHandle = gridbill.RowCount - 1
                    gridbill.TopRowIndex = gridbill.RowCount - 15
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Sub showform(ByVal editval As Boolean, ByVal SALRETNO As Integer)
            Try
                If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                    Dim OBJSALRET As New SaleReturn
                    OBJSALRET.MdiParent = MDIMain
                    OBJSALRET.EDIT = editval
                    OBJSALRET.TEMPSALRETNO = SALRETNO
                    OBJSALRET.Show()
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
            Try
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                showform(False, 0)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub TOOLREFRESH_Click(sender As Object, e As EventArgs) Handles TOOLREFRESH.Click
            Try
                fillgrid(" and SALERETURN.SALRET_yearid=" & YearId & " order by SALERETURN.SALRET_no ")
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub gridpayment_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
            Try
                showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
            Try
                showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
            Catch ex As Exception
                Throw ex
            End Try
        End Sub


        Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
            Try

                Dim PATH As String = Application.StartupPath & "\Sale Return Details.XLS"
                Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
                opti.ShowGridLines = True
                opti.SheetName = "Sale Return Details"
                gridbill.ExportToXls(PATH, opti)
                EXCELCMPHEADER(PATH, "Sale Return Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
            Catch ex As Exception
                MsgBox("Sale Return Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
            End Try
        End Sub

    End Class