Imports DB
Public Class ClsDelivery
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
            'save  DELIVERY
            Dim strCommand As String = "SP_TRANS_DELIVERY_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@CHALLANNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PARTYNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIPTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALEACH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALNOOFBOXES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@READYQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MORDERNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MORDERSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MORDERTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DELIVERYQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DELIVERDQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALREADYQTY", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1

                'GRID
                .Add(New SqlClient.SqlParameter("@GSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDITEMCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNIT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NOOFBOXES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EACH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOBDOCKETNO", alParaval(I)))
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
            Dim strCommand As String = "SP_TRANS_DELIVERY_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@CHALLANNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PARTYNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIPTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALEACH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALNOOFBOXES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@READYQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MORDERNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MORDERSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MORDERTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DELIVERYQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DELIVERDQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALREADYQTY", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1

                'GRID
                .Add(New SqlClient.SqlParameter("@GSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDITEMCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNIT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NOOFBOXES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EACH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOBDOCKETNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERTYPE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TEMPCHALLANNO", alParaval(I)))
                I = I + 1


            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function SELECTDELIVERY(ByVal TEMPCHALLANNO As Integer, ByVal Cmpid As Integer, ByVal YearID As Integer) As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECT_DELIVERY_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@CHALLANNO", TEMPCHALLANNO))
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
            Dim strCommand As String = "SP_TRANS_DELIVERY_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@CHALLANNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@YearID", alParaval(1)))


            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region


End Class
