
Imports BL

Public Class SupervisorProcessConfig

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim GRIDDOUBLECLICK As Boolean
    Dim TEMPROW As Integer
    Public edit As Boolean
    Dim CLEAR As Boolean = False

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True


        If CMBSUPERVISOR.Text.Trim.Length = 0 Then
            EP.SetError(CMBSUPERVISOR, "Select Supervisor Name")
            bln = False
        End If

        If CMBPROCESS.Text.Trim.Length = 0 Then
            EP.SetError(CMBPROCESS, "Select Processor Name")
            bln = False
        End If

        If GRIDSUP.RowCount = 0 Then
            EP.SetError(CMBSUPERVISOR, "Enter Proper Details")
            bln = False
        End If

        Return bln
    End Function

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Sub FILLGCCCRID()

    '    Try
    '        GRIDSUP.RowCount = 0
    '        Dim OBJCMN As New ClsCommon
    '        Dim dttable As DataTable = OBJCMN.search(" ISNULL(SUPERVISORPROCESSORCONFIG.SUPCONF_SRNO, 0) AS SRNO, ISNULL(SUPERVISORMASTER.SUP_NAME, '') AS SUPERVISOR, ISNULL(SUPERVISORPROCESSORCONFIG.SUPCONF_PROCESSNAME, '') AS PROCESS, ISNULL(SUPERVISORPROCESSORCONFIG.SUPCONF_NO, 0) AS NO", "", " SUPERVISORPROCESSORCONFIG INNER JOIN SUPERVISORMASTER ON SUPERVISORPROCESSORCONFIG.SUPCONF_SUPID = SUPERVISORMASTER.SUP_ID", " AND SUPCONF_YEARID = " & YearId)
    '        If dttable.Rows.Count > 0 Then
    '            For Each ROW As DataRow In dttable.Rows
    '                GRIDSUP.Rows.Add(ROW("NO"), ROW("SRNO"), ROW("SUPERVISOR"), ROW("PROCESS"))
    '            Next
    '            GRIDSUP.FirstDisplayedScrollingRowIndex = GRIDSUP.RowCount - 1
    '        End If
    '        getsrno(GRIDSUP)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Sub

    Sub fillgrid()

        GRIDSUP.Enabled = True

        If GRIDDOUBLECLICK = False Then
            GRIDSUP.Rows.Add(Val(TXTSRNO.Text.Trim), Val(TXTNO.Text.Trim), CMBSUPERVISOR.Text.Trim, CMBPROCESS.Text.Trim)
            getsrno(GRIDSUP)
            GRIDSUP.FirstDisplayedScrollingRowIndex = GRIDSUP.RowCount - 1
        ElseIf GRIDDOUBLECLICK = True Then
            GRIDSUP.Item(gsrno.Index, temprow).Value = Val(TXTSRNO.Text.Trim)
            GRIDSUP.Item(GSUPERVISOR.Index, TEMPROW).Value = CMBSUPERVISOR.Text.Trim
            GRIDSUP.Item(GPROCESS.Index, TEMPROW).Value = CMBPROCESS.Text.Trim

            GRIDDOUBLECLICK = False
        End If

        'GRIDSUP.FirstDisplayedScrollingRowIndex = GRIDSUP.RowCount - 1
        If CLEAR = True Then
            CMBSUPERVISOR.Text = ""
            CMBPROCESS.SelectedIndex = 0

            TXTSRNO.Focus()
        End If

        If GRIDSUP.RowCount > 0 Then
            TXTSRNO.Text = Val(GRIDSUP.Rows(GRIDSUP.RowCount - 1).Cells(0).Value) + 1
        Else
            TXTSRNO.Text = 1
        End If

    End Sub


    Private Sub ItemSaleRateConfig_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLCMB()
        Try
            Try
                If CMBSUPERVISOR.Text.Trim = "" Then FILLSUPERVISOR(CMBSUPERVISOR, edit)

            Catch ex As Exception
                Throw ex
            End Try
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Sub CLEAR()
    '    Try
    '        EP.Clear()
    '        CMBSUPERVISOR.Text = ""
    '        CMBPROCESS.Text = ""

    '        GRIDSUP.RowCount = 0
    '        GRIDDOUBLECLICK = False
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub SupervisorProcessConfig_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'OPENING'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            FILLCMB()
            'TXTSRNO.Focus()
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJCMN As New ClsCommon
            Dim dttable As New DataTable

            dttable = OBJCMN.search(" ISNULL(SUPERVISORPROCESSCONFIG.SUPCONF_SRNO, 0) AS SRNO, ISNULL(SUPERVISORPROCESSCONFIG.SUPCONF_NO, 0) AS NO, ISNULL(SUPERVISORMASTER.SUP_NAME, '') AS SUPERVISOR, ISNULL(SUPERVISORPROCESSCONFIG.SUPCONF_PROCESS, '') AS PROCESS  ", "", "SUPERVISORPROCESSCONFIG INNER JOIN SUPERVISORMASTER ON SUPERVISORPROCESSCONFIG.SUPCONF_SUPID = SUPERVISORMASTER.SUP_ID ", " AND SUPERVISORPROCESSCONFIG.SUPCONF_CMPID = " & CmpId & " AND SUPERVISORPROCESSCONFIG.SUPCONF_YEARID = " & YearId & " ORDER BY SUPCONF_NO")
            If dttable.Rows.Count > 0 Then
                For Each DR As DataRow In dttable.Rows
                    GRIDSUP.Rows.Add(DR("SRNO"), DR("NO"), DR("SUPERVISOR"), DR("PROCESS"))
                    'If Convert.ToBoolean(DR("DONE")) = True Then GRIDSUP.Rows(GRIDSUP.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                Next
                GRIDSUP.FirstDisplayedScrollingRowIndex = GRIDSUP.RowCount - 1
            End If

            If GRIDSUP.RowCount > 0 Then
                TXTSRNO.Text = Val(GRIDSUP.Rows(GRIDSUP.RowCount - 1).Cells(0).Value) + 1
            Else
                TXTSRNO.Text = 1
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function CHECKGRID() As Boolean
        Try
            Dim BLN As Boolean = True
            For Each ROW As Windows.Forms.DataGridViewRow In GRIDSUP.Rows
                If (GRIDDOUBLECLICK = False) Or (GRIDDOUBLECLICK = True And TEMPROW <> ROW.Index) Then
                    If CMBPROCESS.Text.Trim = ROW.Cells(GPROCESS.Index).Value.ToString Then
                        BLN = False
                    End If
                End If
            Next
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub CMBSUPERVISOR_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBSUPERVISOR.Enter
        Try
            If CMBSUPERVISOR.Text.Trim = "" Then FILLSUPERVISOR(CMBSUPERVISOR, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSUPERVISOR_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSUPERVISOR.Validating
        Try
            If CMBSUPERVISOR.Text.Trim <> "" Then SUPERVISORVALIDATE(CMBSUPERVISOR, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDSUP_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDSUP.CellDoubleClick
        Try
            EDITROW()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub EDITROW()
        Try
            If GRIDSUP.CurrentRow.Index >= 0 And GRIDSUP.Item(gsrno.Index, GRIDSUP.CurrentRow.Index).Value <> Nothing Then

                GRIDDOUBLECLICK = True

                TXTSRNO.Text = GRIDSUP.Item(gsrno.Index, GRIDSUP.CurrentRow.Index).Value.ToString
                TXTNO.Text = GRIDSUP.Item(GNO.Index, GRIDSUP.CurrentRow.Index).Value.ToString
                CMBSUPERVISOR.Text = GRIDSUP.Item(GSUPERVISOR.Index, GRIDSUP.CurrentRow.Index).Value.ToString
                CMBPROCESS.Text = GRIDSUP.Item(GPROCESS.Index, GRIDSUP.CurrentRow.Index).Value.ToString

                TEMPROW = GRIDSUP.CurrentRow.Index
                TXTSRNO.Focus()

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDSUP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDSUP.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDSUP.RowCount > 0 Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                Dim TEMPMSG As Integer = MsgBox("Wish To Delete?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbNo Then Exit Sub

                'DELETE FROM SUPERVISORPROCESSCONFIG
                Dim OBJSM As New ClsSupervisorProcessConfig
                Dim ALPARAVAL As New ArrayList
                ALPARAVAL.Add(GRIDSUP.Rows(GRIDSUP.CurrentRow.Index).Cells(GNO.Index).Value)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Userid)
                ALPARAVAL.Add(YearId)

                OBJSM.alParaval = ALPARAVAL
                Dim INTRES As Integer = OBJSM.DELETE()

                GRIDSUP.Rows.RemoveAt(GRIDSUP.CurrentRow.Index)
                getsrno(GRIDSUP)
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPROCESS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPROCESS.Validating
        Try
            If Not CHECKGRID() Then
                MsgBox("Process already Assigned Below", )
                Exit Sub
            End If

            If CMBSUPERVISOR.Text.Trim <> "" And CMBPROCESS.Text.Trim <> "" Then
                SAVE()
                CLEAR = True
                fillgrid()
            Else
                If CMBSUPERVISOR.Text.Trim = "" Then
                    MsgBox("Please Enter Supervisor Name")
                    CMBSUPERVISOR.Focus()
                End If

                If CMBPROCESS.Text.Trim = "" Then
                    MsgBox("Please Enter Process Name")
                    CMBPROCESS.Focus()
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SAVE()
        Try
            Dim ALPARAVAL As New ArrayList
            ALPARAVAL.Add(TXTSRNO.Text.Trim)
            ALPARAVAL.Add(CMBSUPERVISOR.Text.Trim)
            ALPARAVAL.Add(CMBPROCESS.Text.Trim)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)


            Dim OBJOPENSTOCK As New ClsSupervisorProcessConfig
            OBJOPENSTOCK.alParaval = ALPARAVAL

            If GRIDDOUBLECLICK = False Then
                Dim DT As DataTable = OBJOPENSTOCK.SAVE()
                If DT.Rows.Count > 0 Then TXTNO.Text = DT.Rows(0).Item(0)
            Else
                ALPARAVAL.Add(TXTNO.Text.Trim)
                Dim INTRES As Integer = OBJOPENSTOCK.UPDATE()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class