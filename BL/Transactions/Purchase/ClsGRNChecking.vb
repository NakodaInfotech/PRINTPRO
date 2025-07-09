Imports DB

Public Class ClsGRNChecking
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
            Dim strCommand As String = "SP_PURCHASE_GRNCHECKING_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@GRNCHKDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHKBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@GRNNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRNDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALACCQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALREJQTY", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@CHALLANNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHEETSPERREAM", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@CHKCHALLANNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHKCHALLANDATE", alParaval(I)))
               I = I + 1
                .Add(New SqlClient.SqlParameter("@MATERIALNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SUPPLIER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NOOFREAM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DATEOFRECEIPT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKINGOFPAPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LABELLINGONCONSIGNMENT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PHYSICALCOC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAMEOFMFG", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TEXTMATTER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIPPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REGISTRATIONMARK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACCEPTED", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@NONINVITEM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GSM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SIZE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACCQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REJQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNIT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHEETS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMOUNT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDGRNNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRNSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OUTQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I = I + 1


                'OBSERVATION
                .Add(New SqlClient.SqlParameter("@OBSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OBGSM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OBSIZE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PONO", alParaval(I)))
                I = I + 1

            End With

            DTTABLE = objDBOperation.execute(strCommand, alParameter).Tables(0)
            Return DTTABLE

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function UPDATE() As Integer
        Dim intresult As Integer
        Try
            'update ENQUIRY 
            Dim I As Integer = 0
            Dim strCommand As String = "SP_PURCHASE_GRNCHECKING_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@GRNCHKDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHKBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@GRNNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRNDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALACCQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALREJQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHEETSPERREAM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHKCHALLANNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHKCHALLANDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MATERIALNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SUPPLIER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NOOFREAM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DATEOFRECEIPT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKINGOFPAPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LABELLINGONCONSIGNMENT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PHYSICALCOC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAMEOFMFG", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TEXTMATTER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIPPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REGISTRATIONMARK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACCEPTED", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@NONINVITEM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GSM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SIZE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACCQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REJQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNIT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHEETS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMOUNT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDGRNNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRNSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OUTQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I = I + 1


                'OBSERVATION
                .Add(New SqlClient.SqlParameter("@OBSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OBGSM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OBSIZE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PONO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@GRNCHKNO", alParaval(I)))
                I = I + 1

            End With

            intresult = objDBOperation.executeNonQuery(strCommand, alParameter)


        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function selectGRNCHK() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTGRNCHECKING_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@CHKNO", alParaval(0)))
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
            Dim STRCOMMAND As String = "SP_PURCHASE_GRNCHECKING_DELETE"
            Dim ALPARAMETER As New ArrayList
            With ALPARAMETER
                .Add(New SqlClient.SqlParameter("@GRNCHKNO", alParaval(0)))
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
            Dim STRCOMMAND As String = "SP_PURCHASE_GRNCHECKING_SAVEUPLOAD"
            Dim ALPARAMATER As New ArrayList
            With ALPARAMATER
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@GRNCHKNO", alParaval(I)))
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
