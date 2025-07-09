
Imports DB

Public Class ClsSupervisorProcessConfig

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

    Public Function SAVE() As DataTable


        Try

            'save CategoryMaster
            Dim strcommand As String = "SP_CONFIG_SUPERVISORPROCESSCONFIG_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@SRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SUPERVISOR", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PROCESS", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I += 1


            End With

            Dim DT As DataTable = objDBOperation.execute(strcommand, alParameter).Tables(0)
            Return DT
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function UPDATE() As Integer

        Dim intResult As Integer
        Dim strcommand As String = ""

        Try

            'Update AccountsMaster
            strcommand = "SP_CONFIG_SUPERVISORPROCESSCONFIG_UPDATE"

            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@SRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SUPERVISOR", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PROCESS", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TEMPNO", alParaval(I)))
                I += 1
            End With

            intResult = objDBOperation.executeNonQuery(strcommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function


    Public Function SAVEUTILITY() As Integer
        'Dim intResult As Integer
        'Dim strcommand As String = ""

        'Try

        '    'save CategoryMaster
        '    strcommand = "SP_UTILITY_ITEMSALERATE_SAVE"
        '    Dim alParameter As New ArrayList
        '    With alParameter

        '        Dim I As Integer = 0
        '        .Add(New SqlClient.SqlParameter("@ID", alParaval(I)))
        '        I += 1
        '        .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
        '        I += 1
        '        .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
        '        I += 1
        '        .Add(New SqlClient.SqlParameter("@SALERATE", alParaval(I)))
        '        I += 1

        '        .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
        '        I += 1
        '        .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
        '        I += 1
        '        .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
        '        I += 1


        '    End With

        '    intResult = objDBOperation.executeNonQuery(strcommand, alParameter)

        'Catch ex As Exception
        '    Throw ex
        'End Try
        'Return 0

    End Function

    Public Function DELETE() As Integer
        Dim intResult As Integer

        Try
            Dim strcommand As String = "SP_CONFIG_SUPERVISORPROCESSCONFIG_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@TEMPNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(3)))

            End With
            intResult = objDBOperation.executeNonQuery(strcommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return intResult

    End Function

#End Region
End Class
