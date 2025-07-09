Imports DB

Public Class ClsInvoicemaster
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
            Dim STRCOMMAND As String = "SP_TRANS_SALE_INVOICEMASTER_SAVE"
            Dim ALPARAMETER As New ArrayList
            With ALPARAMETER
                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@INVOICENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REGISTERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INVOICEDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MANUALGST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOCATIONNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MULTICHALLANNO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@EWAYBILLNO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MULTIPONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PODATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CRDAYS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DUEDATE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TOTALQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALAMT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TOTALOTHERAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALTAXABLEAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALCGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALIGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALGRIDAMT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@APPLYTCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TCSPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TCSAMT", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@PROCHARGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OTHERCHGSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OTHERCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PCKCHARGE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@SUBTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRACHGSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRACHGS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@ROUNDOFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GTOTAL", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@AMTREC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRAAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RETURN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALANCE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@INWORDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STATENAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOBNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERSRNO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@BILLCHK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLDISPUTE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PAPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GSM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRAIN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TEXT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PHARMA", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UPSNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@VISUAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@VARNISH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PERFORATION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESIGN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SIZE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STICKER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADHESIVE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FINAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKET", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIPPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LABEL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BATCH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QCHEAD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QCDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QCREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INKDETAILS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1
                
                ' FORMTYPE PARAMETERS

                .Add(New SqlClient.SqlParameter("@FORMTYPE", alParaval(I)))
                I = I + 1

                ''GRID PARAMATERS
               
                .Add(New SqlClient.SqlParameter("@ITEMCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HSNCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BATCHNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@OTHERAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXABLEAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CGSTPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SGSTPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IGSTPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDCHALLANNO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@VEHICLENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LRDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMCITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOCITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IRNNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ACKNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ACKDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@QRCODE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@HSNCODE1", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@EXPGST", alParaval(I)))
                I += 1

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
            Dim STRCOMMAND As String = "SP_TRANS_SALE_INVOICEMASTER_UPDATE"
            Dim ALPARAMETER As New ArrayList
            With ALPARAMETER
                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@INVOICENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REGISTERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INVOICEDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MANUALGST", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOCATIONNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MULTICHALLANNO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@EWAYBILLNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MULTIPONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PODATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CRDAYS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DUEDATE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TOTALQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALAMT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TOTALOTHERAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALTAXABLEAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALCGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALIGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALGRIDAMT", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@APPLYTCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TCSPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TCSAMT", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@PROCHARGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OTHERCHGSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OTHERCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PCKCHARGE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@SUBTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRACHGSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRACHGS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@ROUNDOFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GTOTAL", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@AMTREC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRAAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RETURN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALANCE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@INWORDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STATENAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOBNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERSRNO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@BILLCHK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLDISPUTE", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@PAPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GSM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRAIN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TEXT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PHARMA", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UPSNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@VISUAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@VARNISH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PERFORATION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESIGN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SIZE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STICKER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADHESIVE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FINAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKET", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIPPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LABEL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BATCH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QCHEAD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QCDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QCREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INKDETAILS", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@DONE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1

                ' FORMTYPE PARAMETERS

                .Add(New SqlClient.SqlParameter("@FORMTYPE", alParaval(I)))
                I = I + 1

                ''GRID PARAMATERS

                .Add(New SqlClient.SqlParameter("@ITEMCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HSNCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BATCHNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@OTHERAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXABLEAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CGSTPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SGSTPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IGSTPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDCHALLANNO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@VEHICLENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LRDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMCITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOCITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IRNNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACKNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ACKDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@QRCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HSNCODE1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXPGST", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@TEMPINVOICENO", alParaval(I)))
                I = I + 1

            End With
            INTRESULT = objDBOperation.executeNonQuery(STRCOMMAND, ALPARAMETER)
            Return INTRESULT
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function SELELECTINVOICE() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTINVOICE_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@INVOICENO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@REGISTERNAME", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@Yearid", alParaval(2)))
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
            Dim STRCOMMAND As String = "SP_TRANS_SALE_INVOICEMASTER_DELETE"
            Dim ALPARAMETER As New ArrayList
            With ALPARAMETER
                .Add(New SqlClient.SqlParameter("@INVNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@REGISTERNAME", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(3)))
            End With

            INTRESULT = objDBOperation.executeNonQuery(STRCOMMAND, ALPARAMETER)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function SAVEUPLOAD() As Integer
        Dim INTRESULT As Integer
        Try
            Dim STRCOMMAND As String = "SP_TRANS_SALE_INVOICEMASTER_SAVEUPLOAD"
            Dim ALPARAMATER As New ArrayList
            With ALPARAMATER
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@INVNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REGNAME", alParaval(I)))
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

    Public Function SAVEQRCODE() As Integer
        Dim intResult As Integer
        Try
            'save SALE order
            Dim strCommand As String = "SP_TRANS_SALE_INVOICEMASTER_QRCODE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@INVOICENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REGISTERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QRCODE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I += 1

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function


End Class
