Imports DB

Public Class ClsAssembly
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
            Dim STRCOMMAND As String = "SP_TRANS_SALE_ASSEMBLYMASTER_SAVE"
            Dim ALPARAMETER As New ArrayList
            With ALPARAMETER
                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@ASSEMBLYNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ASSEMBLYDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOBDOCKETNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BATCHNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PERCENTAGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSHEET", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALQTY", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@ORDERNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERTYPE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PACKETITEM1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKETITEM2", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKETITEM3", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKET1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKET2", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKET3", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALPACKETS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIPPERITEM1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIPPERITEM2", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIPPERITEM3", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIPPER1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIPPER2", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIPPER3", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSHIPPERS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKINGNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIPPERNAME", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PACKETTOTAL1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKETTOTAL2", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKETTOTAL3", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PTOTAL", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@SHIPPERTOTAL1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIPPERTOTAL2", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIPPERTOTAL3", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STOTAL", alParaval(I)))
                I = I + 1



                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1

                ''GRID PARAMATERS

                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDITEMCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDBATCHNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDJOBDOCKETNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKETS", alParaval(I)))
                I = I + 1


                ''GRIDSUM PARAMATERS

                .Add(New SqlClient.SqlParameter("@GRIDSUMJOBDOCKETNO", alParaval(I)))
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
            Dim STRCOMMAND As String = "SP_TRANS_SALE_ASSEMBLYMASTER_UPDATE"
            Dim ALPARAMETER As New ArrayList
            With ALPARAMETER
                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@ASSEMBLYNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ASSEMBLYDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOBDOCKETNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BATCHNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PERCENTAGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSHEET", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALQTY", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@ORDERNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERTYPE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PACKETITEM1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKETITEM2", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKETITEM3", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKET1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKET2", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKET3", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALPACKETS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIPPERITEM1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIPPERITEM2", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIPPERITEM3", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIPPER1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIPPER2", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIPPER3", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSHIPPERS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKINGNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIPPERNAME", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PACKETTOTAL1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKETTOTAL2", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKETTOTAL3", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PTOTAL", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@SHIPPERTOTAL1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIPPERTOTAL2", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIPPERTOTAL3", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STOTAL", alParaval(I)))
                I = I + 1




                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1

                ''GRID PARAMATERS

                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDITEMCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDBATCHNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDJOBDOCKETNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKETS", alParaval(I)))
                I = I + 1


                ''GRIDSUM PARAMATERS

                .Add(New SqlClient.SqlParameter("@GRIDSUMJOBDOCKETNO", alParaval(I)))
                I = I + 1
                '.Add(New SqlClient.SqlParameter("@GRIDSUMQTY", alParaval(I)))
                'I = I + 1

                .Add(New SqlClient.SqlParameter("@TEMPASSEMBLYNO", alParaval(I)))
                I = I + 1

            End With
            INTRESULT = objDBOperation.executeNonQuery(STRCOMMAND, ALPARAMETER)
            Return INTRESULT
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function SELELECTASSEMBLY(ByVal ASSEMBLYNO As Integer, ByVal YearID As Integer) As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTASSEMBLY_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@ASSEMBLYNO", ASSEMBLYNO))
                .Add(New SqlClient.SqlParameter("@Yearid", YearID))
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
            Dim STRCOMMAND As String = "SP_TRANS_SALE_ASSEMBLYMASTER_DELETE"
            Dim ALPARAMETER As New ArrayList
            With ALPARAMETER
                .Add(New SqlClient.SqlParameter("@ASSEMBLYNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(1)))
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
            Dim STRCOMMAND As String = "SP_TRANS_SALE_ASSEMBLYMASTER_SAVEUPLOAD"
            Dim ALPARAMATER As New ArrayList
            With ALPARAMATER
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@ASSEMBLYNO", alParaval(I)))
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
            Dim strCommand As String = "SP_TRANS_SALE_ASSEMBLYMASTER_QRCODE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@ASSEMBLYNO", alParaval(I)))
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
