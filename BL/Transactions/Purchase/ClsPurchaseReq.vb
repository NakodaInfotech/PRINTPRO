Imports DB
Public Class ClsPurchaseReq

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
            'save SALE order
            Dim strCommand As String = "SP_TRANS_PURCHASE_PURCHASEREQ_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@REQNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REQDONEBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALEXTRAQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALFINALQTY", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@JOBDOCKETNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PARTYNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MAINITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOMITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PAPERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DONE", alParaval(I)))
                I = I + 1


                'ISSUE GRID PARAMETERS ***************************


                .Add(New SqlClient.SqlParameter("@PURPAPERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REQQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STOCKQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRAQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FINALQTY", alParaval(I)))
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
            Dim strCommand As String = "SP_TRANS_PURCHASE_PURCHASEREQ_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@REQNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REQDONEBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALEXTRAQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALFINALQTY", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@JOBDOCKETNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PARTYNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MAINITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOMITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PAPERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DONE", alParaval(I)))
                I = I + 1


                'ISSUE GRID PARAMETERS ***************************


                .Add(New SqlClient.SqlParameter("@PURPAPERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REQQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STOCKQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRAQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FINALQTY", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@TEMPREQNO", alParaval(I)))
                I = I + 1

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function SELECTPURCHASEREQ(ByVal REQNO As Integer, ByVal Cmpid As Integer, ByVal YearID As Integer) As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTPURCHASEREQ_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@REQNO", REQNO))
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
            Dim strCommand As String = "SP_TRANS_PURCHASE_PURCHASEREQ_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@REQNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@YearID", alParaval(1)))

            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class
