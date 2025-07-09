
Imports DB

Public Class ClsPlateIssue
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
            Dim strCommand As String = "SP_MFG_PLATEISSUE_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@ISSUEDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ISSUEBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DEPARTEMENT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ISSUEDTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BATCHNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOBDOCKETNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@GRIDOUTQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNIT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMOUNT", alParaval(I)))
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
            Dim strCommand As String = "SP_MFG_PLATEISSUE_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@ISSUEDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ISSUEBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DEPARTEMENT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ISSUEDTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BATCHNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOBDOCKETNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@GRIDOUTQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNIT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMOUNT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@ISSUENO", alParaval(I)))
                I = I + 1

            End With

            intresult = objDBOperation.executeNonQuery(strCommand, alParameter)


        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function SELECTPLATEISSUE() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_MFG_PLATEISSUE_SELECT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@ISSUENO", alParaval(0)))
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
            Dim STRCOMMAND As String = "SP_MFG_PLATEISSUE_DELETE"
            Dim ALPARAMETER As New ArrayList
            With ALPARAMETER
                .Add(New SqlClient.SqlParameter("@ISSUENO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(2)))
            End With

            intresult = objDBOperation.executeNonQuery(STRCOMMAND, ALPARAMETER)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function SAVEUPLOAD() As Integer
        Dim INTRESULT As Integer
        Try
            Dim STRCOMMAND As String = "SP_MFG_PLATEISSUE_SAVEUPLOAD"
            Dim ALPARAMATER As New ArrayList
            With ALPARAMATER
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@ISSUENO", alParaval(I)))
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

#End Region
End Class
