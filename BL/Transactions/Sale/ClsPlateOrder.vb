Imports DB

Public Class ClsPlateOrder
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

    Public Function SAVE() As DataTable
        Dim DTTBL As DataTable
        Try
            Dim STRCOMMAND As String = "SP_TRANS_SALE_PLATEORDER_SAVE"
            Dim ALPARAMETER As New ArrayList
            With ALPARAMETER
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@PLATENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PLATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NOOFPLATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RECDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1



            End With
            DTTBL = objDBOperation.execute(STRCOMMAND, ALPARAMETER).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DTTBL
    End Function

    Public Function UPDATE() As Integer
        Dim INTRESULT As Integer
        Try
            Dim STRCOMMAND As String = "SP_TRANS_SALE_PLATEORDER_UPDATE"
            Dim ALPARAMETER As New ArrayList
            With ALPARAMETER
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@PLATENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PLATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NOOFPLATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RECDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@TEMPID", alParaval(I)))
                I = I + 1

            End With
            INTRESULT = objDBOperation.executeNonQuery(STRCOMMAND, ALPARAMETER)
            Return INTRESULT
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function SELECTPLATE() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTPLATEORDER_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@TEMPID", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@Yearid", alParaval(1)))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function delete() As Integer
        Dim INTRESULT As Integer
        Try
            Dim STRCOMMAND As String = "SP_TRANS_SALE_PLATEORDER_DELETE"
            Dim ALPARAMETER As New ArrayList
            With ALPARAMETER
                .Add(New SqlClient.SqlParameter("@TEMPID", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@Yearid", alParaval(1)))
            End With

            INTRESULT = objDBOperation.executeNonQuery(STRCOMMAND, ALPARAMETER)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function
End Class


