Imports DB

Public Class ClsAccountsMaster

    Private objDBOperation As DBOperation
    Public alParaval As New ArrayList
    Public frmstring As String        'Used from Displaying Customer, Vendor, Employee Master

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

    Public Function SAVE() As Integer
        Try
            Dim strcommand As String = "SP_MASTER_ACCOUNTSMASTER_SAVE"

            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@cmpname", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@name", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@groupname", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@opbal", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@drcr", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@add1", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@add2", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@LANDMARK", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@areaname", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@std", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@cityname", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@zipcode", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@statename", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@countryname", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@crdays", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@crlimit", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ADDLESS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@resino", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@altno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@tel1", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@mobileno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@faxno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@website", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@email", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@BANK", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ACCTYPE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ACCOUNTNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@IFSC", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BRANCH", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BANKCITY", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@TRANS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@AGENT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@AGENTCOMM", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DISC", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CDPER", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@panno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@exciseno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@range", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@division", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@tinno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@cstno", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@vatno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GSTIN", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@stno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@REGISTER", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SIZETOLERANCE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GSMTOLERANCE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PATTERNTOLERANCE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ACCESSQUANTITY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@add", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@shippingadd", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@code", alParaval(I)))
                I += 1

                'For SHADE GRID
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ITEMCODE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SUBMITDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@APPROVEDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@EXPIRYDATE", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@ISTDS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DEDUCTEETYPE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ISLOWER", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SECTION", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TDSRATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TDSPER", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SURCHARGE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@LIMIT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TDSAC", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NATURE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@RCM", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BLOCKED", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@KMS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DELIVERYPINCODE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SEZTYPE", alParaval(I)))
                I += 1


                .Add(New SqlClient.SqlParameter("@TDSDEDUCTEDAC", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CALC", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TCS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PARTYTDS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TDSONGTOTAL", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GSTINVERIFIED", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TDSFORM", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TDSCOMPANY", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@GOCNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@MSMENO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@MSMETYPE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@INTPER", alParaval(I)))
                I += 1

            End With

            Dim intResult As Integer = objDBOperation.executeNonQuery(strcommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function UPDATE() As Integer
        Try
            Dim strcommand As String = "SP_MASTER_ACCOUNTSMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter


                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@cmpname", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@name", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@groupname", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@opbal", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@drcr", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@add1", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@add2", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@LANDMARK", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@areaname", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@std", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@cityname", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@zipcode", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@statename", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@countryname", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@crdays", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@crlimit", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ADDLESS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@resino", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@altno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@tel1", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@mobileno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@faxno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@website", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@email", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@BANK", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ACCTYPE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ACCOUNTNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@IFSC", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BRANCH", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BANKCITY", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@TRANS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@AGENT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@AGENTCOMM", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DISC", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CDPER", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@panno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@exciseno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@range", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@division", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@tinno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@cstno", alParaval(I)))
                I += 1

                '.Add(New SqlClient.SqlParameter("@district", alParaval(I)))
                'I += 1
                '.Add(New SqlClient.SqlParameter("@via", alParaval(I)))
                'I += 1
                .Add(New SqlClient.SqlParameter("@vatno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GSTIN", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@stno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@REGISTER", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SIZETOLERANCE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GSMTOLERANCE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PATTERNTOLERANCE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ACCESSQUANTITY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@add", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@shippingadd", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@code", alParaval(I)))
                I += 1

                'For SHADE GRID
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ITEMCODE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SUBMITDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@APPROVEDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@EXPIRYDATE", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@ISTDS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DEDUCTEETYPE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ISLOWER", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SECTION", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TDSRATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TDSPER", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SURCHARGE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@LIMIT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TDSAC", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NATURE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@RCM", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BLOCKED", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@KMS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DELIVERYPINCODE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SEZTYPE", alParaval(I)))
                I += 1


                .Add(New SqlClient.SqlParameter("@TDSDEDUCTEDAC", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CALC", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TCS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PARTYTDS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TDSONGTOTAL", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GSTINVERIFIED", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TDSFORM", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TDSCOMPANY", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@GOCNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@MSMENO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@MSMETYPE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@INTPER", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@AccountId", alParaval(I)))
                I += 1

            End With

            Dim intResult As Integer = objDBOperation.executeNonQuery(strcommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function DELETE() As DataTable
        Try
            Dim strcommand As String = "SP_MASTER_ACCOUNTSMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@cmpname", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(3)))
            End With
            Dim DTTABLE As DataTable = objDBOperation.execute(strcommand, alParameter).Tables(0)
            Return DTTABLE
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GETACCOUNTS() As DataTable
        Try
            Dim strcommand As String = "SP_MASTER_SELECT_ACCOUNTS"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(3)))
            End With
            Dim DT As DataTable = objDBOperation.execute(strcommand, alParameter).Tables(0)
            Return DT
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region


End Class
