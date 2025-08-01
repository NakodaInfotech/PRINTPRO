﻿


Imports BL
Public Class BlockDateEntry

    Private Sub BlockDate_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("*", "", "BLOCKDATE", " AND YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                DTSALEDATE.Value = Format(Convert.ToDateTime(DT.Rows(0).Item("SALEDATE")).Date, "dd/MM/yyyy")
                DTPURDATE.Value = Format(Convert.ToDateTime(DT.Rows(0).Item("PURDATE")).Date, "dd/MM/yyyy")
                DTCNDATE.Value = Format(Convert.ToDateTime(DT.Rows(0).Item("CNDATE")).Date, "dd/MM/yyyy")
                DTDNDATE.Value = Format(Convert.ToDateTime(DT.Rows(0).Item("DNDATE")).Date, "dd/MM/yyyy")
                DTEXPDATE.Value = Format(Convert.ToDateTime(DT.Rows(0).Item("EXPDATE")).Date, "dd/MM/yyyy")
                DTGRN.Value = Format(Convert.ToDateTime(DT.Rows(0).Item("GRNDATE")).Date, "dd/MM/yyyy")
                DTSALERETCHL.Value = Format(Convert.ToDateTime(DT.Rows(0).Item("SRCHALLANDATE")).Date, "dd/MM/yyyy")
                DTPURRETCH.Value = Format(Convert.ToDateTime(DT.Rows(0).Item("PRCHALLANDATE")).Date, "dd/MM/yyyy")
                DTPO.Value = Format(Convert.ToDateTime(DT.Rows(0).Item("PODATE")).Date, "dd/MM/yyyy")
                DTSO.Value = Format(Convert.ToDateTime(DT.Rows(0).Item("SODATE")).Date, "dd/MM/yyyy")
                DTSTOCKADJ.Value = Format(Convert.ToDateTime(DT.Rows(0).Item("STOCKADJDATE")).Date, "dd/MM/yyyy")
                DTSTORESTOCKADJ.Value = Format(Convert.ToDateTime(DT.Rows(0).Item("STORESTOCKADJDATE")).Date, "dd/MM/yyyy")

            Else
                DTSALEDATE.Value = Now.Date
                DTPURDATE.Value = Now.Date
                DTCNDATE.Value = Now.Date
                DTDNDATE.Value = Now.Date
                DTEXPDATE.Value = Now.Date
                DTGRN.Value = Now.Date
                DTSALERETCHL.Value = Now.Date
                DTPURRETCH.Value = Now.Date
                DTPO.Value = Now.Date
                DTSO.Value = Now.Date
                DTSTOCKADJ.Value = Now.Date
                DTSTORESTOCKADJ.Value = Now.Date

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(sender As Object, e As EventArgs) Handles CMDOK.Click
        Try
            If Not datecheck(DTSALEDATE.Value.Date) Then
                MsgBox("Sale Date not in Accounting Year", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If Not datecheck(DTPURDATE.Value.Date) Then
                MsgBox("Purchase Date not in Accounting Year", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If Not datecheck(DTCNDATE.Value.Date) Then
                MsgBox("Credit Note Date not in Accounting Year", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If Not datecheck(DTDNDATE.Value.Date) Then
                MsgBox("Debit Note Date not in Accounting Year", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If Not datecheck(DTEXPDATE.Value.Date) Then
                MsgBox("Voucher Date not in Accounting Year", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If Not datecheck(DTGRN.Value.Date) Then
                MsgBox("GRN Date not in Accounting Year", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If Not datecheck(DTSALERETCHL.Value.Date) Then
                MsgBox("Sale Return Challan Date not in Accounting Year", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If Not datecheck(DTPURRETCH.Value.Date) Then
                MsgBox("Purchase Return Challan Date not in Accounting Year", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If Not datecheck(DTPO.Value.Date) Then
                MsgBox("PO Date not in Accounting Year", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If Not datecheck(DTSO.Value.Date) Then
                MsgBox("SO Date not in Accounting Year", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If Not datecheck(DTSTOCKADJ.Value.Date) Then
                MsgBox("STOCKABJUSTMENT Date not in Accounting Year", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If Not datecheck(DTSTORESTOCKADJ.Value.Date) Then
                MsgBox("STORESTOCKABJUSTMENT Date not in Accounting Year", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If MsgBox("Wish to Block the Dates?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.Execute_Any_String("DELETE FROM BLOCKDATE WHERE YEARID = " & YearId, "", "")
            DT = OBJCMN.Execute_Any_String("INSERT INTO BLOCKDATE VALUES ('" & Format(DTSALEDATE.Value.Date, "MM/dd/yyyy") & "','" & Format(DTPURDATE.Value.Date, "MM/dd/yyyy") & "','" & Format(DTCNDATE.Value.Date, "MM/dd/yyyy") & "','" & Format(DTDNDATE.Value.Date, "MM/dd/yyyy") & "','" & Format(DTEXPDATE.Value.Date, "MM/dd/yyyy") & "', '" & Format(DTGRN.Value.Date, "MM/dd/yyyy") & "', '" & Format(DTSALERETCHL.Value.Date, "MM/dd/yyyy") & "',  '" & Format(DTSALERETCHL.Value.Date, "MM/dd/yyyy") & "',  '" & Format(DTPO.Value.Date, "MM/dd/yyyy") & "', '" & Format(DTSO.Value.Date, "MM/dd/yyyy") & "', '" & Format(DTSTOCKADJ.Value.Date, "MM/dd/yyyy") & "', '" & Format(DTSTORESTOCKADJ.Value.Date, "MM/dd/yyyy") & "',   " & YearId & ")", "", "")
            SALEBLOCKDATE = DTSALEDATE.Value.Date
            PURBLOCKDATE = DTPURDATE.Value.Date
            CNBLOCKDATE = DTCNDATE.Value.Date
            DNBLOCKDATE = DTDNDATE.Value.Date
            EXPBLOCKDATE = DTEXPDATE.Value.Date
            GRNBLOCKDATE = DTGRN.Value.Date
            SALERETCHBLOCKDATE = DTSALERETCHL.Value.Date
            PURRETCHBLOCKDATE = DTPURRETCH.Value.Date
            POBLOCKDATE = DTPO.Value.Date
            SOBLOCKDATE = DTSO.Value.Date
            STOCKADJBLOCKDATE = DTSTOCKADJ.Value.Date
            STORESTOCKADJBLOCKDATE = DTSTORESTOCKADJ.Value.Date

            MsgBox("Block Date Added")
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDDELETE_Click(sender As Object, e As EventArgs) Handles CMDDELETE.Click
        Try
            If MsgBox("Wish to Delete Block Date?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.Execute_Any_String("DELETE FROM BLOCKDATE WHERE YEARID = " & YearId, "", "")
            MsgBox("Block Date Removed")
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class

