Imports System.ComponentModel
Imports BL

Public Class MergeParameter
    Public EDIT As Boolean

    Private Sub cmbtype_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtype.Validated
        Try
            cmbOldName.DataSource = Nothing
            cmbReplace.DataSource = Nothing
            cmbOldName.Text = ""
            cmbReplace.Text = ""

            If cmbtype.Text.Trim = "AREA" Then
                FILLAREA(cmbOldName)
                FILLAREA(cmbReplace)
            ElseIf cmbtype.Text.Trim = "CATEGORY" Then
                fillCATEGORY(cmbOldName, EDIT)
                fillCATEGORY(cmbReplace, EDIT)
            ElseIf cmbtype.Text.Trim = "CITY" Then
                fillCITY(cmbOldName, EDIT)
                fillCITY(cmbReplace, EDIT)
            ElseIf cmbtype.Text.Trim = "COUNTRY" Then
                fillCOUNTRY(cmbOldName)
                fillCOUNTRY(cmbReplace)
            ElseIf cmbtype.Text.Trim = "STATE" Then
                fillSTATE(cmbOldName)
                fillSTATE(cmbReplace)
            ElseIf cmbtype.Text.Trim = "TAX" Then
                filltax(cmbOldName, EDIT)
                filltax(cmbReplace, EDIT)
            ElseIf cmbtype.Text.Trim = "NONINVITEMMASTER" Then
                FILLNONINVITEM(cmbOldName, EDIT)
                FILLNONINVITEM(cmbReplace, EDIT)
            ElseIf cmbtype.Text = "SUPERVISIOR" Then
                FILLSUPERVISOR(cmbOldName, EDIT)
                FILLSUPERVISOR(cmbReplace, EDIT)
            ElseIf cmbtype.Text.Trim = "REGISTER" Then
                fillregister(cmbOldName, EDIT)
                fillregister(cmbReplace, EDIT)
            ElseIf cmbtype.Text.Trim = "GSMMASTER" Then
                fillPAPERGSM(cmbOldName, EDIT)
                fillPAPERGSM(cmbReplace, EDIT)
            ElseIf cmbtype.Text.Trim = "TEARTAPEMASTER" Then
                fillTEARTAPE(cmbOldName, EDIT)
                fillTEARTAPE(cmbReplace, EDIT)
            ElseIf cmbtype.Text.Trim = "GRAINMASTER" Then
                fillGRAIN(cmbOldName, EDIT)
                fillGRAIN(cmbReplace, EDIT)
            ElseIf cmbtype.Text.Trim = "PAPERSIZEMASTER" Then
                FILLPAPERSIZE(cmbOldName, EDIT)
                FILLPAPERSIZE(cmbReplace, EDIT)
            ElseIf cmbtype.Text.Trim = "GODOWN" Then
                fillGODOWN(cmbOldName, EDIT)
                fillGODOWN(cmbReplace, EDIT)
            ElseIf cmbtype.Text.Trim = "UNIT" Then
                fillUNIT(cmbOldName)
                fillUNIT(cmbReplace)
            ElseIf cmbtype.Text.Trim = "COLOR" Then
                fillCOLOR(cmbOldName)
                fillCOLOR(cmbReplace)
            ElseIf cmbtype.Text.Trim = "PARTYBANKMASTER" Then
                fillPARTYBANK(cmbOldName, EDIT)
                fillPARTYBANK(cmbReplace, EDIT)
            ElseIf cmbtype.Text.Trim = "COORDINATORMASTER" Then
                fillCOORDINATOR(cmbOldName, EDIT)
                fillCOORDINATOR(cmbReplace, EDIT)
            ElseIf cmbtype.Text.Trim = "ITEMMASTER" Then
                fillITEMNAME(cmbOldName, EDIT)
                fillITEMNAME(cmbReplace, EDIT)
            ElseIf cmbtype.Text.Trim = "DESIGNMASTER" Then
                fillDESIGN(cmbOldName, EDIT)
                fillDESIGN(cmbReplace, EDIT)
            ElseIf cmbtype.Text.Trim = "SHELFMASTER" Then
                fillSHELF(cmbOldName, EDIT)
                fillSHELF(cmbReplace, EDIT)
            ElseIf cmbtype.Text.Trim = "REASONMASTER" Then
                fillREASON(cmbOldName)
                fillREASON(cmbReplace)
            ElseIf cmbtype.Text.Trim = "PROBLEMMASTER" Then
                fillPROBLEM(cmbOldName)
                fillPROBLEM(cmbReplace)
            ElseIf cmbtype.Text.Trim = "PAPERMILLMASTER" Then
                FILLPAPERMILL(cmbOldName, EDIT)
                FILLPAPERMILL(cmbReplace, EDIT)
            ElseIf cmbtype.Text.Trim = "PAPERMATERIAL" Then
                fillMATERIAL(cmbOldName, EDIT)
                fillMATERIAL(cmbReplace, EDIT)
            ElseIf cmbtype.Text.Trim = "OPERATOR" Then
                fillOPERATOR(cmbOldName)
                fillOPERATOR(cmbReplace)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Function errorvalid() As Boolean
        Try
            Dim bln As Boolean = True

            If UCase(cmbOldName.Text.Trim) = UCase(cmbReplace.Text.Trim) Then
                EP.SetError(cmbReplace, " Please Fill Diff. Value!")
                bln = False
            End If

            Return bln
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If


            Cursor.Current = Cursors.WaitCursor
            Dim alParaval As New ArrayList
            Dim intresult As Integer

            alParaval.Add(cmbtype.Text)
            alParaval.Add(cmbOldName.Text)
            alParaval.Add(cmbReplace.Text)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(YearId)

            Dim OBJMFG As New ClsCommon()
            OBJMFG.alParaval = alParaval
            intresult = OBJMFG.mergeparameter()
            MsgBox("Item Merge Successfully")
            cmbtype.Text = ""
            cmbOldName.Text = ""
            cmbReplace.Text = ""

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub cmbOldName_Validating(sender As Object, e As CancelEventArgs) Handles cmbOldName.Validating
        Try
            If cmbOldName.Text.Trim = "" Then Exit Sub

            If cmbtype.Text.Trim = "AREA" Then
                AREAVALIDATE(cmbOldName, e, Me)
            ElseIf cmbtype.Text.Trim = "GODOWN" Then
                GODOWNVALIDATE(cmbOldName, e, Me)
            ElseIf cmbtype.Text.Trim = "CATEGORY" Then
                Categoryvalidate(cmbOldName, e, Me)
            ElseIf cmbtype.Text.Trim = "COUNTRY" Then
                COUNTRYVALIDATE(cmbOldName, e, Me)
            ElseIf cmbtype.Text.Trim = "CITY" Then
                CITYVALIDATE(cmbOldName, e, Me)
            ElseIf cmbtype.Text.Trim = "UNIT" Then
                unitvalidate(cmbOldName, e, Me)
            ElseIf cmbtype.Text.Trim = "ITEMMASTER" Then
                ITEMNAMEVALIDATE(cmbOldName, e, Me)
            ElseIf cmbtype.Text.Trim = "TAX" Then
                TAXvalidate(cmbOldName, e, Me)
            ElseIf cmbtype.Text.Trim = "STATE" Then
                STATEVALIDATE(cmbOldName, e, Me)
            ElseIf cmbtype.Text.Trim = "COLOR" Then
                COLORvalidate(cmbOldName, e, Me)
            ElseIf cmbtype.Text.Trim = "DESIGNMASTER" Then
                DESIGNVALIDATE(cmbOldName, e, Me)
            ElseIf cmbtype.Text.Trim = "NONINVITEMMASTER" Then
                NONINVITEMVALIDATE(cmbOldName, e, Me)
            ElseIf cmbtype.Text.Trim = "SHELFMASTER" Then
                SHELFVALIDATE(cmbOldName, e, Me)
            ElseIf cmbtype.Text.Trim = "REASONMASTER" Then
                REASONVALIDATE(cmbOldName, e, Me)
            ElseIf cmbtype.Text.Trim = "PROBLEMMASTER" Then
                PROBLEMVALIDATE(cmbOldName, e, Me)
            ElseIf cmbtype.Text.Trim = "PAPERMILLMASTER" Then
                PAPERMILLVALIDATE(cmbOldName, e, Me)
            ElseIf cmbtype.Text.Trim = "COORDINATORMASTER" Then
                COORDINATORVALIDAT(cmbOldName, e, Me)
            ElseIf cmbtype.Text.Trim = "TEARTAPEMASTER" Then
                TEARTAPEVALIDATE(cmbOldName, e, Me)
            ElseIf cmbtype.Text.Trim = "GSMMASTER" Then
                PAPERGSMVALIDATE(cmbOldName, e, Me)
            ElseIf cmbtype.Text.Trim = "PAPERSIZEMASTER" Then
                PAPERSIZEVALIDATE(cmbOldName, e, Me)
            ElseIf cmbtype.Text.Trim = "GRAINMASTER" Then
                GRAINVALIDATE(cmbOldName, e, Me)
            ElseIf cmbtype.Text.Trim = "PAPERMATERIAL" Then
                MATERIALVALIDATE(cmbOldName, e, Me)
            ElseIf cmbtype.Text.Trim = "PARTYBANKMASTER" Then
                PARTYBANKvalidate(cmbOldName, e, Me)
            ElseIf cmbtype.Text.Trim = "OPERATOR" Then
                OPERATORVALIDATE(cmbOldName, e, Me)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbReplace_Validating(sender As Object, e As CancelEventArgs) Handles cmbReplace.Validating
        Try
            If cmbReplace.Text.Trim = "" Then Exit Sub

            If cmbtype.Text.Trim = "AREA" Then
                AREAVALIDATE(cmbReplace, e, Me)
            ElseIf cmbtype.Text.Trim = "GODOWN" Then
                GODOWNVALIDATE(cmbReplace, e, Me)
            ElseIf cmbtype.Text.Trim = "CATEGORY" Then
                Categoryvalidate(cmbReplace, e, Me)
            ElseIf cmbtype.Text.Trim = "COUNTRY" Then
                COUNTRYVALIDATE(cmbReplace, e, Me)
            ElseIf cmbtype.Text.Trim = "CITY" Then
                CITYVALIDATE(cmbReplace, e, Me)
            ElseIf cmbtype.Text.Trim = "UNIT" Then
                unitvalidate(cmbReplace, e, Me)
            ElseIf cmbtype.Text.Trim = "ITEMMASTER" Then
                ITEMNAMEVALIDATE(cmbReplace, e, Me)
            ElseIf cmbtype.Text.Trim = "TAX" Then
                TAXvalidate(cmbReplace, e, Me)
            ElseIf cmbtype.Text.Trim = "STATE" Then
                STATEVALIDATE(cmbReplace, e, Me)
            ElseIf cmbtype.Text.Trim = "COLOR" Then
                COLORvalidate(cmbReplace, e, Me)
            ElseIf cmbtype.Text.Trim = "DESIGNMASTER" Then
                DESIGNVALIDATE(cmbReplace, e, Me)
            ElseIf cmbtype.Text.Trim = "NONINVITEMMASTER" Then
                NONINVITEMVALIDATE(cmbReplace, e, Me)
            ElseIf cmbtype.Text.Trim = "SHELFMASTER" Then
                SHELFVALIDATE(cmbReplace, e, Me)
            ElseIf cmbtype.Text.Trim = "REASONMASTER" Then
                REASONVALIDATE(cmbReplace, e, Me)
            ElseIf cmbtype.Text.Trim = "PROBLEMMASTER" Then
                PROBLEMVALIDATE(cmbReplace, e, Me)
            ElseIf cmbtype.Text.Trim = "PAPERMILLMASTER" Then
                PAPERMILLVALIDATE(cmbReplace, e, Me)
            ElseIf cmbtype.Text.Trim = "COORDINATORMASTER" Then
                COORDINATORVALIDAT(cmbReplace, e, Me)
            ElseIf cmbtype.Text.Trim = "TEARTAPEMASTER" Then
                TEARTAPEVALIDATE(cmbReplace, e, Me)
            ElseIf cmbtype.Text.Trim = "GSMMASTER" Then
                PAPERGSMVALIDATE(cmbReplace, e, Me)
            ElseIf cmbtype.Text.Trim = "PAPERSIZEMASTER" Then
                PAPERSIZEVALIDATE(cmbReplace, e, Me)
            ElseIf cmbtype.Text.Trim = "GRAINMASTER" Then
                GRAINVALIDATE(cmbReplace, e, Me)
            ElseIf cmbtype.Text.Trim = "PAPERMATERIAL" Then
                MATERIALVALIDATE(cmbReplace, e, Me)
            ElseIf cmbtype.Text.Trim = "PARTYBANKMASTER" Then
                PARTYBANKvalidate(cmbReplace, e, Me)
            ElseIf cmbtype.Text.Trim = "OPERATOR" Then
                OPERATORVALIDATE(cmbReplace, e, Me)

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class