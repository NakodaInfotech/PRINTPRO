
Imports BL
Imports System.Windows.Forms

Public Class CoordinatorDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub CoordinatorDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        End If
    End Sub

    Private Sub CoordinatorDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            fillgridname()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgridname()
        'Dim objClsCOORDINATOR As New ClsCoordinatorMaster
        'objClsCOORDINATOR.alParaval.Add("")
        'objClsCOORDINATOR.alParaval.Add(CmpId)
        'objClsCOORDINATOR.alParaval.Add(Locationid)
        'objClsCOORDINATOR.alParaval.Add(YearId)
        'Dim dttable As DataTable = objClsCOORDINATOR.getCOORDINATOR()
        'If dttable.Rows.Count > 0 Then
        '    gridname.DataSource = dttable
        'End If


        Try
            Dim objcmn As New ClsCommonMaster
            Dim dt As New DataTable
            dt = objcmn.search("COORDINATOR_ID AS ID,COORDINATOR_NAME AS NAME", "", "COORDINATORMASTER", " AND COORDINATORMASTER.COORDINATOR_yearid= " & YearId & " ORDER by COORDINATORMASTER.COORDINATOR_ID")
            gridname.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridledger.FocusedRowHandle = gridledger.RowCount - 1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getdetails(ByRef ID As Integer)

        Dim objClsCOORDINATOR As New ClsCoordinatorMaster
        objClsCOORDINATOR.alParaval.Add(ID)
        objClsCOORDINATOR.alParaval.Add(CmpId)
        objClsCOORDINATOR.alParaval.Add(Locationid)
        objClsCOORDINATOR.alParaval.Add(YearId)
        Dim dttable As DataTable = objClsCOORDINATOR.getCOORDINATOR

        cleartextbox()


        If dttable.Rows.Count > 0 Then
            For Each dr As DataRow In dttable.Rows
                TXTNAME.Text = Convert.ToString(dr("NAME"))
                txttel1.Text = Convert.ToString(dr("TELNO"))
                TXTEXT.Text = Convert.ToString(dr("EXTNO"))
                txtmobile.Text = Convert.ToString(dr("MOBILENO"))
                TXTAREA.Text = Convert.ToString(dr("AREA"))
                TXTEMAIL.Text = Convert.ToString(dr("EMAIL"))
                txtremarks.Text = Convert.ToString(dr("REMARKS"))
            Next
        End If

    End Sub

    Sub cleartextbox()
        TXTNAME.Clear()
        txttel1.Clear()
        TXTEXT.Clear()
        txtmobile.Clear()
        TXTAREA.Clear()
        TXTEMAIL.Clear()
        txtremarks.Clear()
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        Try
            showform(True, gridledger.GetFocusedRowCellValue("ID"), gridledger.GetFocusedRowCellValue("NAME"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal ID As Integer, ByVal name As String)
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            If (editval = False) Or (editval = True And gridledger.RowCount > 0) Then
                Dim objCOORDINATOR As New CoordinatorMaster
                objCOORDINATOR.MdiParent = MDIMain
                objCOORDINATOR.edit = editval
                objCOORDINATOR.TEMPCOORDINARTORId = ID
                objCOORDINATOR.TEMPCOORDINARTOR = name
                objCOORDINATOR.Show()
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Try
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            showform(False, 0, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridledger_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridledger.Click
        Try
            getdetails(gridledger.GetFocusedRowCellValue("ID"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridledger_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridledger.DoubleClick
        Try
            showform(True, gridledger.GetFocusedRowCellValue("ID"), gridledger.GetFocusedRowCellValue("NAME"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridledger_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles gridledger.FocusedRowChanged
        Try
            getdetails(gridledger.GetFocusedRowCellValue("ID"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    
End Class