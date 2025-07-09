
Imports BL
Imports System.Windows.Forms

Public Class CoordinatorMaster

    Public edit As Boolean
    Public TEMPCOORDINARTOR As String
    Public TEMPCOORDINARTORId As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub CoordinatorMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Sub FILLCMPNAME()
        Try
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable = objclscommon.search("COORDINATOR_NAME", "", " COORDINATORMASTER ", " and COORDINATOR_cmpid = " & CmpId & " and COORDINATOR_locationid = " & Locationid & " and COORDINATOR_yearid = " & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "COORDINATOR_name"
                CMBNAME.DataSource = dt
                CMBNAME.DisplayMember = "COORDINATOR_name"
                CMBNAME.Text = TEMPCOORDINARTOR
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillcmb()

        Dim objclscommon As New ClsCommonMaster
        Dim dt As DataTable = objclscommon.search("AREA_name", "", "AREAMaster", "")
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "AREA_name"
            cmbarea.DataSource = dt
            cmbarea.DisplayMember = "AREA_name"
            cmbarea.Text = ""
        End If

    End Sub

    Private Sub CoordinatorMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillcmb()
            FILLCMPNAME()
            CMBNAME.Text = TEMPCOORDINARTOR

            If edit = True Then
                Dim objCommon As New ClsCommonMaster
                Dim dttable As DataTable = objCommon.search(" COORDINATORMASTER.COORDINATOR_ID, COORDINATORMASTER.COORDINATOR_NAME, COORDINATORMASTER.COORDINATOR_TELNO, COORDINATORMASTER.COORDINATOR_EXTNO, COORDINATORMASTER.COORDINATOR_MOBILENO, AREAMASTER.AREA_Name, COORDINATORMASTER.COORDINATOR_EMAIL, CoordinatorMaster.COORDINATOR_REMARKS ", "", " COORDINATORMASTER LEFT OUTER JOIN AREAMASTER ON COORDINATORMASTER.COORDINATOR_AREAID = AREAMASTER.AREA_Id", " and COORDINATOR_name = '" & TEMPCOORDINARTOR & "' and COORDINATOR_cmpid = " & CmpId & " and COORDINATOR_Locationid = " & Locationid & " and COORDINATOR_yearid = " & YearId)
                If dttable.Rows.Count > 0 Then
                    TEMPCOORDINARTORId = Val(dttable.Rows(0).Item(0))
                    CMBNAME.Text = dttable.Rows(0).Item(1).ToString
                    txttel1.Text = dttable.Rows(0).Item(2).ToString
                    TXTEXT.Text = dttable.Rows(0).Item(3).ToString
                    txtmobile.Text = Val(dttable.Rows(0).Item(4).ToString)
                    cmbarea.Text = dttable.Rows(0).Item(5).ToString
                    TXTEMAIL.Text = dttable.Rows(0).Item(6).ToString
                    txtremarks.Text = dttable.Rows(0).Item(7).ToString
                End If

            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            Ep.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(txttel1.Text.Trim)
            alParaval.Add(TXTEXT.Text.Trim)
            alParaval.Add(txtmobile.Text.Trim)
            alParaval.Add(cmbarea.Text.Trim)
            alParaval.Add(TXTEMAIL.Text.Trim)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim objCoordinatorMaster As New ClsCoordinatorMaster
            objCoordinatorMaster.alParaval = alParaval

            If edit = False Then
                IntResult = objCoordinatorMaster.save()
                MsgBox("Details Added")
            Else
                alParaval.Add(TEMPCOORDINARTORId)
                IntResult = objCoordinatorMaster.update()
                MsgBox("Details Updated")
            End If

            clear()
            CMBNAME.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub clear()

        CMBNAME.Text = ""
        txttel1.Clear()
        TXTEXT.Clear()
        txtmobile.Clear()
        cmbarea.Text = ""
        TXTEMAIL.Clear()
        txtremarks.Clear()
        TEMPCOORDINARTOR = ""
        Ep.Clear()
        edit = False

    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If CMBNAME.Text.Trim.Length = 0 Then
            Ep.SetError(CMBNAME, "Fill Company Name")
            bln = False
        End If

        Return bln
    End Function

    'Private Sub cmbarea_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbarea.GotFocus
    '    Try
    '        If cmbarea.Text.Trim = "" Then FILLAREA(cmbarea)
    '        If cmbarea.Text.Trim = "" Then
    '            Dim objclscommon As New ClsCommonMaster
    '            Dim dt As DataTable
    '            dt = objclscommon.search("area_name", "", "AreaMaster", " and area_cmpid = " & CmpId & " and area_Locationid = " & Locationid & " and area_Yearid = " & YearId)
    '            If dt.Rows.Count > 0 Then
    '                dt.DefaultView.Sort = "area_name"
    '                cmbarea.DataSource = dt
    '                cmbarea.DisplayMember = "area_name"
    '                cmbarea.Text = ""
    '            End If
    '            cmbarea.SelectAll()
    '        End If
    '    Catch ex As Exception
    '        If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
    '    End Try
    'End Sub

    Private Sub cmbarea_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbarea.Validating
        Try
            If cmbarea.Text.Trim <> "" Then AREAVALIDATE(cmbarea, e, Me)

            '            If cmbarea.Text.Trim <> "" Then
            '                pcase(cmbarea)
            '                Dim objClsCommon As New ClsCommonMaster
            '                Dim objyearmaster As New ClsYearMaster
            '                Dim dt As DataTable
            '                dt = objClsCommon.search("area_name", "", "areaMaster", " and area_name = '" & cmbarea.Text.Trim & "' and area_cmpid = " & CmpId & " and area_Locationid = " & Locationid & " and area_Yearid = " & YearId)
            '                If dt.Rows.Count = 0 Then
            '                    Dim a As String = cmbarea.Text.Trim
            '                    Dim tempmsg As Integer = MsgBox("area not present, Add New?", MsgBoxStyle.YesNo, "Printex Pro")
            '                    If tempmsg = vbYes Then
            '                        cmbarea.Text = a
            '                        objyearmaster.savearea(cmbarea.Text.Trim, CmpId, Locationid, Userid, YearId, " and area_name = '" & cmbarea.Text.Trim & "' and area_cmpid = " & CmpId & " and area_Locationid = " & Locationid & " and area_Yearid = " & YearId)
            '                        Dim dt1 As New DataTable
            '                        dt1 = cmbarea.DataSource
            '                        If cmbarea.DataSource <> Nothing Then
            'line1:
            '                            If dt1.Rows.Count > 0 Then
            '                                dt1.Rows.Add(cmbarea.Text)
            '                                cmbarea.Text = a
            '                            End If
            '                        End If
            '                    Else
            '                        e.Cancel = True
            '                    End If
            '                End If
            '            End If
        Catch ex As Exception
            'GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then
                FILLCMPNAME()
                CMBNAME.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then
                pcase(CMBNAME)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If (edit = False) Or (edit = True And LCase(CMBNAME.Text) <> LCase(TEMPCOORDINARTOR)) Then
                    dt = objclscommon.search("COORDINATOR_name", "", "COORDINATORMaster", " and COORDINATOR_name = '" & CMBNAME.Text.Trim & "' And  COORDINATOR_yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Name Already Exists", MsgBoxStyle.Critical, "PrintPro")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbarea_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbarea.Enter
        Try
            If cmbarea.Text.Trim = "" Then FILLAREA(cmbarea)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False
        CMBNAME.Focus()
    End Sub
End Class