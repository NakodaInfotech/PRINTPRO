
Imports DB

Public Class ClsCoordinatorMaster

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

#Region "Function"

    Public Function save() As Integer
        Dim intResult As Integer
        Dim strcommand As String = ""

        Try

            'save CategoryMaster
            strcommand = "SP_MASTER_COORDINATORMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@name", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@TEL", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@EXT", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@MOBILENO", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@AREA", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@EMAIL", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(8)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(9)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(10)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(11)))

            End With

            intResult = objDBOperation.executeNonQuery(strcommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function update() As Integer

        Dim intResult As Integer
        Dim strcommand As String = ""

        Try

            'Update AccountsMaster
            strcommand = "SP_MASTER_COORDINATORMASTER_UPDATE"
            
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@name", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@TEL", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@EXT", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@MOBILENO", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@AREA", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@EMAIL", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(8)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(9)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(10)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(11)))
                .Add(New SqlClient.SqlParameter("@COORDINATORId", alParaval(12)))

            End With

            intResult = objDBOperation.executeNonQuery(strcommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function getCOORDINATOR() As DataTable
        Dim dtTable As DataTable
        Dim strcommand As String = ""
        Try
            strcommand = "SP_MASTER_SELECT_COORDINATOR"

            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@ID", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(3)))
            End With
            dtTable = objDBOperation.execute(strcommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function DELETE() As DataTable
        Dim dtTable As New DataTable
        Dim strcommand As String = ""
        Try
            strcommand = "SP_MASTER_COORDINATORMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(3)))
            End With
            dtTable = objDBOperation.execute(strcommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

#End Region

End Class
