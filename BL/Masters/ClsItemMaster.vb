Imports DB

Public Class clsItemmaster

    Private objDBOperation As DBOperation
    Public alParaval As New ArrayList
    Dim intResult As Integer

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

    Public Function save() As Integer
        Dim INTRESULT As Integer
        Try

            'save itemdetails
            Dim strCommand As String = "SP_MASTER_ITEMMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter
                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@ITEMCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FILENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HSNCODE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROOFSEND", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROOFSENDDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROOFOK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROOFOKDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PERFORATION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHADECARD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHADESENDDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHADEAPPROVE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHADEAPPDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHADEDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COORDINATOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ARTIST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LINKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FONTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SOFTWARE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PPRGSM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SCREEN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACTUALSIZEwidth", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACTUALSIZEheight", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESIGN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PHARMACODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SIZEFOLDINGwidth", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SIZEFOLDINGheight", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@VARNISH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MATERIAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CUTSIZE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@VERTICAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HORIZONTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UPS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PPRSIZE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LENGTH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRAIN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@KNIFE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MATERIALCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TEARTAPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SIDEPRINT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ARTWORKDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ARTWORK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@POSITIVESENTDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@POSITIVERECDDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FOLDED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@2DCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MATERIALTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BLOCKED", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I += 1


                'GRID PARAMETERS
                .Add(New SqlClient.SqlParameter("@BOMSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SUBITEM", alParaval(I)))
                I = I + 1

            End With

            INTRESULT = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function update() As Integer

        Dim strcommand As String = ""

        Try

            'Update AccountsMaster
            strcommand = "SP_MASTER_ITEMMASTER_UPDATE"
            
            Dim alParameter As New ArrayList
            With alParameter
                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@ITEMCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FILENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HSNCODE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROOFSEND", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROOFSENDDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROOFOK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROOFOKDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PERFORATION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHADECARD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHADESENDDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHADEAPPROVE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHADEAPPDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHADEDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COORDINATOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ARTIST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LINKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FONTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SOFTWARE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PPRGSM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SCREEN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACTUALSIZEwidth", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACTUALSIZEheight", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESIGN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PHARMACODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SIZEFOLDINGwidth", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SIZEFOLDINGheight", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@VARNISH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MATERIAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CUTSIZE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@VERTICAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HORIZONTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UPS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PPRSIZE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LENGTH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRAIN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@KNIFE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MATERIALCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TEARTAPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SIDEPRINT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ARTWORKDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ARTWORK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@POSITIVESENTDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@POSITIVERECDDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FOLDED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@2DCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MATERIALTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BLOCKED", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I += 1

                'GRID PARAMETERS
                .Add(New SqlClient.SqlParameter("@BOMSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SUBITEM", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@TEMPITEMID", alParaval(I)))
                I = I + 1

            End With

            intResult = objDBOperation.executeNonQuery(strcommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function GETITEM() As DataTable
        Dim dtTable As New DataTable
        Dim strcommand As String = ""
        Try
            strcommand = "SP_SELECTITEM_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@ITEMID", alParaval(0)))
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
            strcommand = "SP_MASTER_ITEMMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@ITEMID", alParaval(0)))
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

    Public Function SAVEUPLOAD() As Integer
        Dim INTRESULT As Integer
        Try
            Dim STRCOMMAND As String = "SP_MASTER_ITEMMASTER_SAVEUPLOAD"
            Dim ALPARAMATER As New ArrayList
            With ALPARAMATER
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
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
