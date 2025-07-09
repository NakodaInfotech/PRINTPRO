Imports DB
Public Class ClsJobDocketBatch

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
        Dim DTTBLE As DataTable
        Try
            Dim strcommand As String = "SP_TRANS_JOBDOCKETBATCH_SAVE"
            Dim alparameter As New ArrayList
            With alparameter
                Dim I As Integer

                .Add(New SqlClient.SqlParameter("@JOBDOCKETNO", alParaval(I)))
                I = I + 1
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
                .Add(New SqlClient.SqlParameter("@POSITIVENEGATIVE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSHEETS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DONE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@SHIPTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MAINITEM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERTYPE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@JOBQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COL2", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COL1PLATES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COL2PLATES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COL1PLATETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COL2PLATETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OPENUPS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CUTSHEET", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRA", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRODUCEQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CUTSIZE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLOSEUPS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLORSHEET", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FULLSIZE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SUBITEMCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LAMINATIONON", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YIELD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHEETS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FILMSIZE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FILMSIZE2", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@KGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LAMINATION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UV", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PUNCHING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ENVELOPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GUMMING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BINDING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NUMBERING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FABRICATION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NONINVITEM", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@PREVJOBNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PREVDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MACHINE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OUTVENDORNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OPENSIZE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLOSESIZE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LAMMODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LAM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LUV", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LPUNCHING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LENVELOPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LGUM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LBINDING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LNUMBERING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LFABRICATION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LAMINATION1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LAMINATION2", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@VENDOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@VENDOR1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LPACKING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LAM1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LAM2", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UPS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRODFINISHQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRODPRINTINGQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LAMINATIONUPS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PUNCHINGUPS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FINALUPS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FOLDINGUPS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NUMBERINGUPS", alParaval(I)))
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
            Dim strcommand As String = "SP_TRANS_JOBDOCKETBATCH_UPDATE"
            Dim alparameter As New ArrayList
            With alparameter
                Dim I As Integer

                .Add(New SqlClient.SqlParameter("@JOBDOCKETNO", alParaval(I)))
                I = I + 1
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
                .Add(New SqlClient.SqlParameter("@POSITIVENEGATIVE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSHEETS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DONE", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@SHIPTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MAINITEM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOBQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COL2", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COL1PLATES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COL2PLATES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COL1PLATETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COL2PLATETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OPENUPS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CUTSHEET", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRA", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRODUCEQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CUTSIZE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLOSEUPS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLORSHEET", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FULLSIZE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SUBITEMCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LAMINATIONON", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YIELD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHEETS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FILMSIZE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FILMSIZE2", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@KGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LAMINATION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UV", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PUNCHING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ENVELOPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GUMMING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BINDING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NUMBERING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FABRICATION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NONINVITEM", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PREVJOBNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PREVDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MACHINE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OUTVENDORNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OPENSIZE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLOSESIZE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LAMMODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LAM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LUV", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LPUNCHING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LENVELOPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LGUM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LBINDING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LNUMBERING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LFABRICATION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LAMINATION1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LAMINATION2", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@VENDOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@VENDOR1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LPACKING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LAM1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LAM2", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UPS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRODFINISHQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRODPRINTINGQTY", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@LAMINATIONUPS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PUNCHINGUPS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FINALUPS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FOLDINGUPS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NUMBERINGUPS", alParaval(I)))
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

    Public Function selectNO(ByVal TEMPJOBNO As Integer, ByVal Cmpid As Integer, ByVal YearID As Integer) As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTJOBDOCKETBATCH_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@JOBNO", TEMPJOBNO))
                .Add(New SqlClient.SqlParameter("@CmpID", Cmpid))
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
            Dim STRCOMMAND As String = "SP_TRANS_JOBDOCKETBATCH_DELETE"
            Dim ALPARAMETER As New ArrayList
            With ALPARAMETER
                .Add(New SqlClient.SqlParameter("@JOBBATCHNO", alParaval(0)))
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
