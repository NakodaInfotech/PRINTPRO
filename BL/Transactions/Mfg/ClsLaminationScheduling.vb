Imports DB
Public Class ClsLaminationScheduling

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
            'save  LABELING
            Dim strCommand As String = "SP_TRANS_LAMINATIONSCHEDULING_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@SCHNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SCHEDULINGDONEBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SCHEDULING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALJOBCARDQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALPRINTEDQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALREMAININGQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSTOCK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALORDER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALBALANCE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALPLATES", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@SCHDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STATUS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOBNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLIENT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOBCARDQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRINTEDQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMAININGQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CUTSHEET", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALIMP", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GTOTALDONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GDO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FILM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WIDTH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LENGTH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALANCE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@READYTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FINISHTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIFTREMARKS", alParaval(I)))
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
            Dim strCommand As String = "SP_TRANS_LAMINATIONSCHEDULING_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@SCHNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SCHEDULINGDONEBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SCHEDULING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALJOBCARDQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALPRINTEDQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALREMAININGQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSTOCK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALORDER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALBALANCE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALPLATES", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@SCHDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STATUS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOBNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLIENT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOBCARDQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRINTEDQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMAININGQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CUTSHEET", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALIMP", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALDONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GDO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FILM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WIDTH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LENGTH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALANCE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@READYTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FINISHTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIFTREMARKS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TEMPSCHNO", alParaval(I)))
                I = I + 1


            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function SELECTLAMINATIONSCHEDULING(ByVal TEMPSCHNO As Integer, ByVal Cmpid As Integer, ByVal YearID As Integer) As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTLAMINATIONSCHEDULING_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@SCHNO", TEMPSCHNO))
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
            Dim strCommand As String = "SP_TRANS_LAMINATIONSCHEDULING_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@SCHNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@YearID", alParaval(1)))

            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class
