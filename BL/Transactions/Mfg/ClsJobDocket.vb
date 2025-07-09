Imports DB

Public Class ClsJobDocket
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

    Public Function save() As DataTable
        Dim DTTBLE As DataTable
        Try
            Dim strcommand As String = "SP_TRANS_JOBDOCKET_SAVE"
            Dim alparameter As New ArrayList
            With alparameter
                Dim I As Integer

                .Add(New SqlClient.SqlParameter("@ORDERNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PARTYNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOBDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PERCENTAGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHADECARD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSHEETS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PCKTITEM1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PCKTITEM2", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PCKTITEM3", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PCKT1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PCKT2", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PCKT3", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALPCKTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIPPRITEM1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIPPRITEM2", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIPPRITEM3", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIPER1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIPER2", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIPER3", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSHIPERS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TEMPPROCESSNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FOLDV", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FOLDH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@shortqty1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PPRMFG", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRADE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TESTVAL", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@PROCESS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PLATECHKBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CODECHKBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UPSCHKBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CORECTAPLBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PLATEMADEBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MADEDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PLATEDESTROYBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESTROYDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PLATEREMADEBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REAMDEDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHEETSGIVEN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GIVENDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALSHEETS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RETURNDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHEETSDESTROY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLEANBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SAMPLEAPPBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALPACKETS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSHIPPERS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKETSIZE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHORTQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SUPERVISOR", alParaval(I)))
                I = I + 1

            End With

            DTTBLE = objDBOperation.execute(strcommand, alparameter).Tables(0)
        Catch ex As Exception
            Throw ex
        End Try
        Return DTTBLE

    End Function

    Public Function UPDATE() As Integer
        Dim intresult As Integer
        Try
            Dim strcommand As String = "SP_TRANS_JOBDOCKET_UPDATE"
            Dim alparameter As New ArrayList
            With alparameter
                Dim I As Integer
                
                .Add(New SqlClient.SqlParameter("@ORDERNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PARTYNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOBDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PERCENTAGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHADECARD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSHEETS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PCKTITEM1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PCKTITEM2", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PCKTITEM3", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PCKT1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PCKT2", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PCKT3", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALPCKTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIPPRITEM1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIPPRITEM2", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIPPRITEM3", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIPER1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIPER2", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIPER3", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSHIPERS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TEMPPROCESSNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FOLDV", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FOLDH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@shortqty1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PPRMFG", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRADE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TESTVAL", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@PROCESS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PLATECHKBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CODECHKBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UPSCHKBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CORECTAPLBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PLATEMADEBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MADEDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PLATEDESTROYBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESTROYDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PLATEREMADEBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REAMDEDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHEETSGIVEN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GIVENDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALSHEETS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RETURNDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHEETSDESTROY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLEANBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SAMPLEAPPBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALPACKETS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSHIPPERS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKETSIZE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHORTQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SUPERVISOR", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TEMPJOBNO", alParaval(I)))
                I = I + 1

            End With

            intresult = objDBOperation.executeNonQuery(strcommand, alparameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return intresult

    End Function

    Public Function selectNO(ByVal JOBNO As Integer, ByVal YearID As Integer) As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTJOBDOCKET_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@JOBNO", JOBNO))
                .Add(New SqlClient.SqlParameter("@YearID", YearID))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function delete() As Integer
        Dim intresult As Integer
        Try
            Dim STRCOMMAND As String = "SP_TRANS_JOBDOCKET_DELETE"
            Dim ALPARAMETER As New ArrayList
            With ALPARAMETER
                .Add(New SqlClient.SqlParameter("@JOBNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@TEMPPROCESSNO", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@userID", alParaval(3)))
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
            Dim STRCOMMAND As String = "SP_TRANS_JOBDOCKET_SAVEUPLOAD"
            Dim ALPARAMATER As New ArrayList
            With ALPARAMATER
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@JOBNO", alParaval(I)))
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
