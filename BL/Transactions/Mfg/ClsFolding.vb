Imports DB
Public Class ClsFolding


    Private objDBOperation As DBOperation
    Public alParaval As New ArrayList

#Region "Constructor"
    Public Sub New()
        Try
            objDBOperation = New DBOperation
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Functions"
    Public Function SAVE() As DataTable
        Dim DT As DataTable
        Try
            'save  PUNCHING
            Dim strCommand As String = "SP_TRANS_FOLDING_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@FOLDNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SCHEDULINGDONEBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIFT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALJOBCARDQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALPRINTEDQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALREMAININGQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSHEETS", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1

                'grid parameters********************************

                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FOLDINGDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STATUS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOBNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLIENTNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOBCARDQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FOLDQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMAININGQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOBNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHEETS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALDONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TODO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PAGES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FOLD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALANCE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STARTTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FINISHTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WASTAGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDREMARKS", alParaval(I)))
                I = I + 1


            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

    Public Function UPDATE() As Integer
        Dim intResult As Integer
        Try
            'Update SALE order
            Dim strCommand As String = "SP_TRANS_FOLDING_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@FOLDNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SCHEDULINGDONEBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIFT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALJOBCARDQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALPRINTEDQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALREMAININGQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSHEETS", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1

                'grid parameters********************************

                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FOLDINGDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STATUS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOBNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLIENTNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOBCARDQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FOLDQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMAININGQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOBNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHEETS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALDONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TODO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PAGES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FOLD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALANCE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STARTTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FINISHTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WASTAGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDREMARKS", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@TEMPFOLDNO", alParaval(I)))
                I = I + 1


            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function SELECTPUNCHING(ByVal TEMPPUNCHNO As Integer, ByVal Cmpid As Integer, ByVal YearID As Integer) As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTFOLDING_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@PNCHNO", TEMPPUNCHNO))
                .Add(New SqlClient.SqlParameter("@CmpID", Cmpid))
                .Add(New SqlClient.SqlParameter("@YearID", YearID))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function Delete() As Integer
        Dim intResult As Integer
        Try
            Dim strCommand As String = "SP_TRANS_FOLDING_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@PNCHNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@YearID", alParaval(1)))

            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region


End Class
