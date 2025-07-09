Imports DB

Public Class ClsOrder
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

    Public Function save() As Integer
        Dim INTRESULT As Integer
        Try
            'save  order
            Dim strCommand As String = "SP_TRANS_SALE_ORDER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PODATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHADECARD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MULTIUPS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@POSNEG", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@refNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADDRESS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CRDAYS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DELDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BUYERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@totalqty", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@totalamt", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIPTO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(I)))
                I = I + 1

                'grid parameters
                .Add(New SqlClient.SqlParameter("@srno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@grade", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SCHDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@quantity", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@unit", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@brate", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@procharge", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@amount", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OUTQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLOSE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOBQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DELOUTQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ASSEMBLYOUTQTY", alParaval(I)))
                I = I + 1

            End With

            INTRESULT = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function update() As Integer
        Dim intResult As Integer
        Try
            'update order
            Dim strCommand As String = "SP_TRANS_SALE_ORDER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
               
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PODATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHADECARD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MULTIUPS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@POSNEG", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@refNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADDRESS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CRDAYS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DELDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BUYERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@totalqty", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@totalamt", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIPTO", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(I)))
                I = I + 1

                'grid parameters
                .Add(New SqlClient.SqlParameter("@srno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@grade", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SCHDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@quantity", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@unit", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@brate", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@procharge", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@amount", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OUTQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLOSE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOBQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DELOUTQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ASSEMBLYOUTQTY", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@ORDERNO", alParaval(I)))
                I = I + 1

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function selectNO(ByVal ORDERNO As Integer, ByVal YearID As Integer) As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTORDER_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@ORDERNO", ORDERNO))
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
            Dim strCommand As String = "SP_TRANS_SALE_ORDER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@ORDERNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@YearID", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@UserID", alParaval(1)))

            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function closepo() As Integer
        Dim intResult As Integer
        Try
            'CLOSE purchase order
            Dim strCommand As String = "SP_TRANS_ORDER_CLOSEPO"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@ORDERNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@done", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(2)))
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return intResult
    End Function


    Public Function SAVEUPLOAD() As Integer
        Dim INTRESULT As Integer
        Try
            Dim STRCOMMAND As String = "SP_TRANS_SALE_ORDER_SAVEUPLOAD"
            Dim ALPARAMATER As New ArrayList
            With ALPARAMATER
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@ORDERNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IMGPATH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I = I + 1
            End With

            INTRESULT = objDBOperation.executeNonQuery(STRCOMMAND, ALPARAMATER)

        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
