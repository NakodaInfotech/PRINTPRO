Imports DB

Public Class ClsProduction
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
            'save  SCHEDULING
            Dim strCommand As String = "SP_TRANS_PRODUCTION_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@PRODNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRODUCTIONDONEBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRODUCTIONTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOPRODUCTIONTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MACHINE", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@TOTALWASTAGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALGOODQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OUTQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALEXTRASHEET", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UPS", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@JOBNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLIENT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@JOBCARDQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SCHDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STATUS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRINTEDQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRASHEET", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GOODQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WASTAGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMAININGQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CUTSHEET", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CUTSIZE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FULLSHEET", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STOCK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALANCE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NONINVITEM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR2", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR1PLATES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR2PLATES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR1TYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR2TYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SIDE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IMP", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FINALIMP", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@READYTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FINISHTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LAMINATIONDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LAMINATIONSHEETS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALDONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TODO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLIM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WIDTH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LENGTH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GSM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MAKEREADY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRINTINGDONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERTYPE", alParaval(I)))
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
            Dim strCommand As String = "SP_TRANS_PRODUCTION_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@PRODNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRODUCTIONDONEBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRODUCTIONTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOPRODUCTIONTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MACHINE", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@TOTALWASTAGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALGOODQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OUTQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALEXTRASHEET", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UPS", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@JOBNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLIENT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@JOBCARDQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SCHDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STATUS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRINTEDQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRASHEET", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GOODQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WASTAGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMAININGQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CUTSHEET", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CUTSIZE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FULLSHEET", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STOCK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALANCE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NONINVITEM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR2", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR1PLATES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR2PLATES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR1TYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR2TYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SIDE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IMP", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FINALIMP", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@READYTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FINISHTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LAMINATIONDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LAMINATIONSHEETS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALDONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TODO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLIM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WIDTH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LENGTH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GSM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MAKEREADY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRINTINGDONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERTYPE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TEMPPRODNO", alParaval(I)))
                I = I + 1


            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function SELECTSPRODUCTION(ByVal TEMPRODNO As Integer, ByVal Cmpid As Integer, ByVal YearID As Integer) As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTPRODUCTION_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@PRODNO", TEMPRODNO))
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
            Dim strCommand As String = "SP_TRANS_PRODUCTION_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@PRODNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@YearID", alParaval(1)))

            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class
