
Imports DB

Public Class ClsPurchaseOrder

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

    Public Function SAVE() As DataTable
        Dim DTTABLE As DataTable
        Try
            'save ENQUIRY 
            Dim I As Integer = 0
            Dim strCommand As String = "SP_PURCHASE_PURCHASEORDER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@PODATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DELDAYS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DELDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHEETSPERREAM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REQNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@VERIFIED", alParaval(I)))
                I = I + 1

                ''GRID PARAMETER
                .Add(New SqlClient.SqlParameter("@ITEMSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GSM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SIZE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNIT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OUTQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLOSED", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1


            End With

            DTTABLE = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DTTABLE

    End Function

    Public Function UPDATE() As Integer
        Dim intresult As Integer
        Try
            'update ENQUIRY 
            Dim I As Integer = 0
            Dim strCommand As String = "SP_PURCHASE_PURCHASEORDER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@PODATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DELDAYS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DELDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHEETSPERREAM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REQNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@VERIFIED", alParaval(I)))
                I = I + 1


                ''GRID PARAMETER
                .Add(New SqlClient.SqlParameter("@ITEMSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GSM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SIZE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNIT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OUTQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLOSED", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@PONO", alParaval(I)))
                I = I + 1

            End With

            intresult = objDBOperation.executeNonQuery(strCommand, alParameter)


        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function selectpurchaseorder() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTPURCHASEORDER_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@PONO", alParaval(0)))
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
            Dim STRCOMMAND As String = "SP_PURCHASE_PURCHASEORDER_DELETE"
            Dim ALPARAMETER As New ArrayList
            With ALPARAMETER
                .Add(New SqlClient.SqlParameter("@PONO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@userID", alParaval(2)))
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
            Dim STRCOMMAND As String = "SP_PURCHASE_PURCHASEORDER_SAVEUPLOAD"
            Dim ALPARAMATER As New ArrayList
            With ALPARAMATER
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@PONO", alParaval(I)))
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
