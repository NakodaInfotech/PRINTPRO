Imports DB
Public Class ClsBatch

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
            Dim strcommand As String = "SP_TRANS_BATCHMASTER_SAVE"
            Dim alparameter As New ArrayList
            With alparameter
                Dim I As Integer
                .Add(New SqlClient.SqlParameter("@BATCHNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOBDOCKETNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOBDOCKETDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PARTYNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PERCENTAGE", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@NEW", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SUBITEMCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@2DCODESTART", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@2DCODEEND", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UPS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERTYPE", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BUNDEL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOXSIZE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOXREQ", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRAYREQ", alParaval(I)))
                I = I + 1


                ''GRID PARAMETER
                .Add(New SqlClient.SqlParameter("@PROCESS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@NOOFPLATES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PLATETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PLATESIZE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PLATEQC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PLATEREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PLATEINTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PLATEOUTTIME", alParaval(I)))
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

                .Add(New SqlClient.SqlParameter("@PLTCHKBY", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@MACHINENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TABLECLR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MACHINEPTFCLR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DUSTBINCLR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MACHINESURRAREACLR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AREABELOWMACHINE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REJSHEETS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@UNFOLDREMOVEJOBDOCKET", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNFOLDALLTRAY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNFOLDSORTINGBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNFOLDCOUNTING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNFOLDPACKETBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNFOLDLABELLEDBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNFOLDSAMPLEAPPBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNFOLDSHEETGIVEN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNFOLDBALANCESHEET", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNFOLDDESTROYEDSHEET", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNFOLDGIVENDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNFOLDREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNFOLDINTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNFOLDOUTTIME", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PAPERGRNNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PAPERTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PAPERREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PAPERINTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PAPEROUTTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PAPERGSMQC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PAPERQUALITYQC", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@CUTPREJOBSHEET", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CUTLEAFLETSIZE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@SORTFLOORAREA", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SORTPREJOBSHEET", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SORTREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SORTINTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SORTOUTTIME", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PLATEREMOVED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INKPOT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRINTSHEETS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@POSITIVE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NEGATIVE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@APPSHADECARD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@APPSAMPLE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REGISTERSHEETS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FEEDERAREA", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DELIVERAREA", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PRINTPLATETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRINTREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRINTINTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRINTOUTTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRINTVARNISH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRINTPERFORATION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRINTTEXTMATTER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRINTSIZE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRINTJOBREG", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRINTCOLOR", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@CROSSUNITAREA", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FSTKNIFEAREA", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SECONDKNIFEAREA", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAPPINGUNITAREA", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STACKERAREA", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SAMPLEAPPBY", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@FOLDBUNDLEDBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FOLDPACKETBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FOLDLABELLEDBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FOLDREMOVEDOCKET", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FOLDALLTHETRAY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FOLDBARCODECAMERA", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FOLDREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FOLDINTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FOLDOUTTIME", alParaval(I)))
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
            Dim strcommand As String = "SP_TRANS_BATCHMASTER_UPDATE"
            Dim alparameter As New ArrayList
            With alparameter
                Dim I As Integer

                .Add(New SqlClient.SqlParameter("@BATCHNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOBDOCKETNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOBDOCKETDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PARTYNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PERCENTAGE", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@NEW", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SUBITEMCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@2DCODESTART", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@2DCODEEND", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UPS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@ORDERNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERTYPE", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@BUNDEL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOXSIZE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BOXREQ", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRAYREQ", alParaval(I)))
                I = I + 1

                ''GRID PARAMETER
                .Add(New SqlClient.SqlParameter("@PROCESS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@NOOFPLATES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PLATETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PLATESIZE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PLATEQC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PLATEREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PLATEINTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PLATEOUTTIME", alParaval(I)))
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

                .Add(New SqlClient.SqlParameter("@PLTCHKBY", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@MACHINENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TABLECLR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MACHINEPTFCLR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DUSTBINCLR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MACHINESURRAREACLR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AREABELOWMACHINE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REJSHEETS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@UNFOLDREMOVEJOBDOCKET", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNFOLDALLTRAY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNFOLDSORTINGBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNFOLDCOUNTING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNFOLDPACKETBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNFOLDLABELLEDBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNFOLDSAMPLEAPPBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNFOLDSHEETGIVEN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNFOLDBALANCESHEET", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNFOLDDESTROYEDSHEET", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNFOLDGIVENDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNFOLDREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNFOLDINTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNFOLDOUTTIME", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PAPERGRNNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PAPERTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PAPERREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PAPERINTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PAPEROUTTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PAPERGSMQC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PAPERQUALITYQC", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@CUTPREJOBSHEET", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CUTLEAFLETSIZE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SORTFLOORAREA", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SORTPREJOBSHEET", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SORTREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SORTINTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SORTOUTTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PLATEREMOVED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INKPOT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRINTSHEETS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@POSITIVE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NEGATIVE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@APPSHADECARD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@APPSAMPLE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REGISTERSHEETS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FEEDERAREA", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DELIVERAREA", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PRINTPLATETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRINTREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRINTINTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRINTOUTTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRINTVARNISH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRINTPERFORATION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRINTTEXTMATTER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRINTSIZE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRINTJOBREG", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRINTCOLOR", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@CROSSUNITAREA", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FSTKNIFEAREA", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SECONDKNIFEAREA", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAPPINGUNITAREA", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STACKERAREA", alParaval(I)))
                I = I + 1


                '.Add(New SqlClient.SqlParameter("@CLEANBY", alParaval(I)))
                'I = I + 1
                .Add(New SqlClient.SqlParameter("@SAMPLEAPPBY", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@FOLDBUNDLEDBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FOLDPACKETBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FOLDLABELLEDBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FOLDREMOVEDOCKET", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FOLDALLTHETRAY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FOLDBARCODECAMERA", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FOLDREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FOLDINTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FOLDOUTTIME", alParaval(I)))
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

                .Add(New SqlClient.SqlParameter("@TEMPBATCHNO", alParaval(I)))
                I = I + 1

            End With

            intresult = objDBOperation.executeNonQuery(strcommand, alparameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return intresult

    End Function

    Public Function selectNO() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTBATCH_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@BATCHNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@Yearid", alParaval(1)))
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
            Dim STRCOMMAND As String = "SP_TRANS_BATCHMASTER_DELETE"
            Dim ALPARAMETER As New ArrayList
            With ALPARAMETER
                .Add(New SqlClient.SqlParameter("@BATCHNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@TEMPPROCESSNO", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(3)))
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
            Dim STRCOMMAND As String = "SP_TRANS_BATCH_SAVEUPLOAD"
            Dim ALPARAMATER As New ArrayList
            With ALPARAMATER
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@BATCHNO", alParaval(I)))
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
