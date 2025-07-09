
Imports BL
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid

Public Class ChallanDetails

    Public edit As Boolean
    'Dim temppreqno As Integer
    Dim USERADD, USEREDIT, USERDELETE, USERVIEW As Boolean

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub ChDetails_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.E And e.Alt = True Then
                Call PrintToolStripButton_Click(sender, e)
            ElseIf e.KeyCode = Keys.R And e.Alt = True Then
                Call ToolStripRefresh_Click(sender, e)
            ElseIf e.KeyCode = Keys.N And e.Control = True Then
                SHOWFORM(False, 0)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ChDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'CHALLAN'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            FILLGRID(" and dbo.CHALLANMASTER.CHALLAN_yearid=" & YearId & " order by dbo.CHALLANMASTER.CHALLAN_NO ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID(ByVal TEMPCONDITION)
        Try
            Dim OBJCMN As New ClsCommonMaster
            Dim DT As DataTable = OBJCMN.search("ISNULL(challanmaster.challan_no, 0) AS SRNO, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, challanmaster.challan_date AS DATE, ISNULL(challanmaster.challan_pono, '') AS PONO, challanmaster.challan_podate AS PODATE, ISNULL(challanmaster.challan_jobno, 0) AS JOBNO,  ISNULL(itemmaster.item_code, '') AS ITEMCODE, ISNULL(challanmaster.CHALLAN_ORDERNO, 0) AS ORDERNO, ISNULL(challanmaster.CHALLAN_ORDERSRNO, 0)  AS ORDERSRNO, CHALLANMASTER.CHALLAN_DONE AS DONE, ISNULL(CHALLAN_LRNO,'') AS LRNO, ISNULL(TRANSLEDGERS.ACC_CMPNAME ,'') AS TRANSPORT", "", "  challanmaster INNER JOIN CHALLANMASTER_DESC ON challanmaster.challan_no = CHALLANMASTER_DESC.CHALLAN_NO AND challanmaster.challan_yearid = CHALLANMASTER_DESC.CHALLAN_YEARID INNER JOIN LEDGERS ON challanmaster.challan_ledgerid = LEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS TRANSLEDGERS ON challanmaster.challan_transid = TRANSLEDGERS.Acc_id INNER JOIN itemmaster ON CHALLANMASTER_DESC.CHALLAN_ITEMID = itemmaster.item_id AND CHALLANMASTER_DESC.CHALLAN_YEARID = itemmaster.item_yearid", TEMPCONDITION)
            GridChallanDetails.DataSource = DT
            If DT.Rows.Count > 0 Then
                GridChallan.FocusedRowHandle = GridChallan.RowCount - 1
                GridChallan.TopRowIndex = GridChallan.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SHOWFORM(ByVal EDITVAL As Boolean, ByVal CHALLANNO As Integer)
        Try
            If (EDITVAL = True And USEREDIT = False And USERVIEW = False) Or (EDITVAL = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (EDITVAL = False) Or (EDITVAL = True And GridChallan.RowCount > 0) Then
                Dim OBJCMN As New Challan
                OBJCMN.MdiParent = MDIMain
                OBJCMN.edit = EDITVAL
                OBJCMN.TEMPCHALLANNO = CHALLANNO
                OBJCMN.Show()
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Try
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            SHOWFORM(False, 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            SHOWFORM(True, GridChallan.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GridChallan_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridChallan.DoubleClick
        Try
            SHOWFORM(True, GridChallan.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXCELEXPORT.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Sale Challan Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Sale Challan Details"
            GridChallan.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Sale Challan Details", GridChallan.VisibleColumns.Count + GridChallan.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            FILLGRID(" and dbo.CHALLANMASTER.CHALLAN_yearid=" & YearId & " order by dbo.CHALLANMASTER.CHALLAN_NO ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GridChallan_RowStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GridChallan.RowStyle
        Try
            Dim DT As DataTable = GridChallanDetails.DataSource
            If e.RowHandle >= 0 Then
                Dim ROW As DataRow = DT.Rows(e.RowHandle)
                Dim View As GridView = sender
                If View.GetRowCellDisplayText(e.RowHandle, View.Columns("DONE")) = "Checked" Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 10.0F, System.Drawing.FontStyle.Regular)
                    e.Appearance.BackColor = Color.Yellow
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPRINTLIST_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        'Try
        '    Dim OBJCHALLAN As New ChallanDesign
        '    OBJCHALLAN.MdiParent = MDIMain
        '    If CMBPRINTLIST.Text = "Challan Print" Then
        '        OBJCHALLAN.FRMSTRING = "CHALLAN"
        '        OBJCHALLAN.strsearch = "{CHALLANMASTER.CHALLAN_NO} = " & GridChallan.GetFocusedRowCellValue("SRNO") & "AND {CHALLANMASTER.CHALLAN.YEARID} =" & YearId
        '    End If

        '    Dim OBJPACKET As New PacketDesign
        '    OBJPACKET.MdiParent = MDIMain
        '    If CMBPRINTLIST.Text = "Packet Print" Then
        '        OBJPACKET.FRMSTRING = "PACKET"
        '        OBJPACKET.strsearch = "{TEMPSHIPPER.CHALLAN_NO}=" & GridChallan.GetFocusedRowCellValue("SRNO") & "  and {TEMPSHIPPER.CHALLAN_yearid}=" & YearId
        '    End If

        '    Dim OBJSHIPPER As New ShipperDesign
        '    OBJSHIPPER.MdiParent = MDIMain
        '    If CMBPRINTLIST.Text = "Shipper Print" Then
        '        OBJSHIPPER.FRMSTRING = "SHIPPER"
        '        OBJSHIPPER.strsearch = "{TEMPPACKETS.CHALLAN_NO}=" & GridChallan.GetFocusedRowCellValue("SRNO") & "  and {TEMPPACKETS.CHALLAN_yearid}=" & YearId
        '    End If
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub

    Private Sub PRINTTOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRINTTOOL.Click
        Try
            'If CMBPRINTLIST.Text = "Challan Report" Then
            '    Dim OBJCHALLAN As New ChallanDesign
            '    OBJCHALLAN.MdiParent = MDIMain
            '    OBJCHALLAN.FRMSTRING = "Challan"
            '    OBJCHALLAN.strsearch = "{CHALLANMASTER.CHALLAN_NO}=" & GridChallan.GetFocusedRowCellValue("SRNO") & "  and {CHALLANMASTER.CHALLAN_yearid}=" & YearId
            '    OBJCHALLAN.Show()
            'End If

            'If CMBPRINTLIST.Text = "Packets Report" Then
            '    Dim OBJPACKET As New PacketDesign
            '    OBJPACKET.CHNO = Val(GridChallan.GetFocusedRowCellValue("SRNO"))
            '    OBJPACKET.MdiParent = MDIMain
            '    OBJPACKET.FRMSTRING = "PACKET"
            '    OBJPACKET.strsearch = "{TEMPPACKETS.CHALLAN_NO}=" & GridChallan.GetFocusedRowCellValue("SRNO") & "  and {TEMPPACKETS.CHALLAN_yearid}=" & YearId
            '    OBJPACKET.Show()
            'End If

            'If CMBPRINTLIST.Text = "Shipper Report" Then
            '    Dim OBJSHIPPER As New ShipperDesign
            '    OBJSHIPPER.CHNO = Val(GridChallan.GetFocusedRowCellValue("SRNO"))
            '    OBJSHIPPER.MdiParent = MDIMain

            '    If MsgBox("Print Biocon Shipper?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            '        OBJSHIPPER.FRMSTRING = "BIOCON_SHIPPER"
            '    ElseIf MsgBox("Print Sandoz Shipper?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            '        OBJSHIPPER.FRMSTRING = "SANDOZ_SHIPPER"
            '    Else
            '        OBJSHIPPER.FRMSTRING = "SHIPPER"
            '    End If
            '    OBJSHIPPER.strsearch = "{TEMPSHIPPER.CHALLAN_NO}=" & GridChallan.GetFocusedRowCellValue("SRNO") & "  and {TEMPSHIPPER.CHALLAN_yearid}=" & YearId
            '    OBJSHIPPER.Show()
            'End If

            If ClientName = "IYMP" Then
                If CMBPRINTLIST.Text = "Challan Report" Then
                    Dim OBJGDN As New ChallanDesign
                    OBJGDN.MdiParent = MDIMain
                    OBJGDN.FRMSTRING = "Challan"
                    OBJGDN.WHERECLAUSE = "{CHALLANMASTER.CHALLAN_NO}=" & Val(GridChallan.GetFocusedRowCellValue("SRNO")) & "  and {CHALLANMASTER.CHALLAN_yearid}=" & YearId
                    OBJGDN.Show()
                End If

                If CMBPRINTLIST.Text = "Shipper Report" Then
                    Dim OBJSHPER As New ShipperDesign
                    OBJSHPER.CHNO = Val(GridChallan.GetFocusedRowCellValue("SRNO"))
                    OBJSHPER.JOBNO = Val(GridChallan.GetFocusedRowCellValue("JOBNO"))
                    OBJSHPER.MdiParent = MDIMain
                    If MsgBox("Print Biocon Shipper?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        OBJSHPER.FRMSTRING = "BIOCON_SHIPPER"
                    ElseIf MsgBox("Print Sandoz Shipper?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        OBJSHPER.FRMSTRING = "SANDOZ_SHIPPER"
                    Else
                        OBJSHPER.FRMSTRING = "SHIPPER"
                    End If
                    OBJSHPER.WHERECLAUSE = "{TEMPSHIPPER.CHALLAN_NO}=" & Val(GridChallan.GetFocusedRowCellValue("SRNO")) & "  and {TEMPSHIPPER.CHALLAN_yearid}=" & YearId
                    OBJSHPER.Show()
                End If

                If CMBPRINTLIST.Text = "Packets Report" Then
                    Dim OBJPACKET As New PacketDesign
                    OBJPACKET.CHNO = Val(GridChallan.GetFocusedRowCellValue("SRNO"))
                    OBJPACKET.JOBNO = Val(GridChallan.GetFocusedRowCellValue("JOBNO"))
                    OBJPACKET.MdiParent = MDIMain
                    OBJPACKET.FRMSTRING = "PACKET"
                    OBJPACKET.WHERECLAUSE = "{TEMPPACKETS.CHALLAN_NO}=" & Val(GridChallan.GetFocusedRowCellValue("SRNO")) & "  and {TEMPPACKETS.CHALLAN_yearid}=" & YearId
                    OBJPACKET.Show()
                End If

            Else

                'MILAN COA
                If ClientName = "AMR" Then
                    If MsgBox("Wish to Print COA-MILAN Report?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then GoTo NEXTPRINT
                    Dim OBJINVOICE As New SaleInvoiceDesign
                    OBJINVOICE.MdiParent = MDIMain
                    OBJINVOICE.FRMSTRING = "MILAN_COA"
                    OBJINVOICE.WHERECLAUSE = "{CHALLANMASTER.CHALLAN_NO}=" & Val(GridChallan.GetFocusedRowCellValue("SRNO")) & " and {CHALLANMASTER.CHALLAN_yearid}=" & YearId
                    OBJINVOICE.Show()
                End If

NEXTPRINT:

                If CMBPRINTLIST.Text = "Challan Report" Then
                    Dim OBJGDN As New ChallanDesign
                    OBJGDN.MdiParent = MDIMain
                    OBJGDN.FRMSTRING = "Challan"
                    OBJGDN.WHERECLAUSE = "{CHALLANMASTER.CHALLAN_NO}=" & Val(GridChallan.GetFocusedRowCellValue("SRNO")) & "  and {CHALLANMASTER.CHALLAN_yearid}=" & YearId
                    OBJGDN.Show()
                End If

                If CMBPRINTLIST.Text = "Shipper Report" Then
                    Dim OBJSHPER As New ShipperDesign
                    OBJSHPER.CHNO = Val(GridChallan.GetFocusedRowCellValue("SRNO"))
                    Dim OBJCMN As New ClsCommon
                    Dim DTBATCH As DataTable = OBJCMN.search("CHALLAN_BATCHNO AS CBATCHNO", "", "CHALLANMASTER_DESC", "AND CHALLANMASTER_DESC.CHALLAN_NO = " & Val(GridChallan.GetFocusedRowCellValue("SRNO")) & " AND CHALLANMASTER_DESC.CHALLAN_YEARID = " & YearId)
                    OBJSHPER.DTBATCH = DTBATCH
                    OBJSHPER.MdiParent = MDIMain
                    If MsgBox("Print Biocon Shipper?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        OBJSHPER.FRMSTRING = "BIOCON_SHIPPER"
                    ElseIf MsgBox("Print Sandoz Shipper?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        OBJSHPER.FRMSTRING = "SANDOZ_SHIPPER"
                    Else
                        OBJSHPER.FRMSTRING = "SHIPPER"
                    End If
                    OBJSHPER.WHERECLAUSE = "{TEMPSHIPPER.CHALLAN_NO}=" & Val(GridChallan.GetFocusedRowCellValue("SRNO")) & "  and {TEMPSHIPPER.CHALLAN_yearid}=" & YearId
                    OBJSHPER.Show()
                End If

                If CMBPRINTLIST.Text = "Packets Report" Then
                    Dim OBJPACKET As New PacketDesign
                    OBJPACKET.CHNO = Val(GridChallan.GetFocusedRowCellValue("SRNO"))
                    Dim OBJCMN As New ClsCommon
                    Dim DTBATCH As DataTable = OBJCMN.search("CHALLAN_BATCHNO AS CBATCHNO", "", "CHALLANMASTER_DESC", "AND CHALLANMASTER_DESC.CHALLAN_NO = " & Val(GridChallan.GetFocusedRowCellValue("SRNO")) & " AND CHALLANMASTER_DESC.CHALLAN_YEARID = " & YearId)
                    OBJPACKET.DTBATCH = DTBATCH
                    OBJPACKET.MdiParent = MDIMain
                    OBJPACKET.FRMSTRING = "PACKET"
                    OBJPACKET.WHERECLAUSE = "{TEMPPACKETS.CHALLAN_NO}=" & Val(GridChallan.GetFocusedRowCellValue("SRNO")) & "  and {TEMPPACKETS.CHALLAN_yearid}=" & YearId
                    OBJPACKET.Show()
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class