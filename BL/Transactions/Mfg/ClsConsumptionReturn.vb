
Imports DB

Public Class ClsConsumptionReturn
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

    Public Function SAVE() As Integer
        Dim INTRESULT As Integer
        Try
            Dim strcommand As String = "SP_MFG_CONSUMPTIONRETURN_SAVE"
            Dim alparameter As New ArrayList
            With alparameter
                Dim I As Integer

                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MATERIALBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MATERIALTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DEPARTMENT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@lbltotal", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MACHINE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANNO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSFER", alParaval(I)))
                I = I + 1


                ''GRID PARAMETER
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
                I = I + 1
                '.Add(New SqlClient.SqlParameter("@SHELF", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@SIZE", alParaval(I)))
                'I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNIT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONSUMENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONSUMESRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMOUNT", alParaval(I)))
                I = I + 1
            End With

            INTRESULT = objDBOperation.executeNonQuery(strcommand, alparameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return INTRESULT
    End Function

    Public Function UPDATE() As Integer
        Dim INTRESULT As Integer
        Try
            Dim strcommand As String = "SP_MFG_CONSUMPTIONRETURN_UPDATE"
            Dim alparameter As New ArrayList
            With alparameter
                Dim I As Integer

                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MATERIALBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MATERIALTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DEPARTMENT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@lbltotal", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MACHINE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANNO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSFER", alParaval(I)))
                I = I + 1


                ''GRID PARAMETER
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
                I = I + 1
                '.Add(New SqlClient.SqlParameter("@SHELF", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@SIZE", alParaval(I)))
                'I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNIT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONSUMENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONSUMESRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMOUNT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@CONSUMERETURNNO", alParaval(I)))
                I = I + 1


            End With

            INTRESULT = objDBOperation.executeNonQuery(strcommand, alparameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return INTRESULT
    End Function

    Public Function selectconsume() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTCONSUMERETURN_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@CONSUMERETURNNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@CmpID", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@LocationID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@YearID", alParaval(3)))
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
            Dim strCommand As String = "SP_MFG_CONSUMPTIONRETURN_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@CONSUMERETURNNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@LocationID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@YearID", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(4)))

            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
