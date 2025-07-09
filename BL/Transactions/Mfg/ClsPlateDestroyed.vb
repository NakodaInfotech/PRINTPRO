
Imports DB

Public Class ClsPlateDestroyed

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
    Public Function save() As DataTable
        Dim DTTABLE As DataTable
        Try
            'save ENQUIRY 
            Dim I As Integer = 0
            Dim strCommand As String = "SP_MFG_PLATEDESTROYED_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@DESTROYEDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESTROYEBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@APPROVEDBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANNO", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@GRIDPLATENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDUNIT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDAMOUNT", alParaval(I)))
                I = I + 1

            End With

            DTTABLE = objDBOperation.execute(strCommand, alParameter).Tables(0)
            Return DTTABLE

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function update() As Integer
        Dim intresult As Integer
        Try
            'update ENQUIRY 
            Dim I As Integer = 0
            Dim strCommand As String = "SP_MFG_PLATEDESTROYED_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@DESTROYEDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESTROYEBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@APPROVEDBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANNO", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@GRIDPLATENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDUNIT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDAMOUNT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@DESTROYEDNO", alParaval(I)))
                I = I + 1

            End With

            intresult = objDBOperation.executeNonQuery(strCommand, alParameter)


        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function SELECTPLATEDESTROYED() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_MFG_PLATEDESTROYED_SELECT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@DESTROYEDNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@Yearid", alParaval(2)))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function delete() As Integer
        Try
            Dim intresult As Integer
            Dim STRCOMMAND As String = "SP_MFG_PLATEDESTROYED_DELETE"
            Dim ALPARAMETER As New ArrayList
            With ALPARAMETER
                .Add(New SqlClient.SqlParameter("@DESTROYEDNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(2)))
            End With

            intresult = objDBOperation.executeNonQuery(STRCOMMAND, ALPARAMETER)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

  
#End Region
End Class



