Imports SAPbobsCOM

Public Class ParametrosDIAPI
    Public Property Server As String
    Public Property LicenseServer As String
    Public Property Database As String
    Public Property DbServerType As String
    Public Property CompanyDB As String
    Public Property DbUsername As String
    Public Property DbPassword As String
    Public Property Username As String
    Public Property Password As String

    Public ReadOnly Property ClaveServer As String = "DIAPI_Server_"
    Public ReadOnly Property ClaveLicenseServer As String = "DIAPI_LicenseServer_"
    Public ReadOnly Property ClaveDatabase As String = "DIAPI_Database_"
    Public ReadOnly Property ClaveDbServerType As String = "DIAPI_DbServerType_"
    Public ReadOnly Property ClaveCompanyDB As String = "DIAPI_CompanyDB_"
    Public ReadOnly Property ClaveDbUsername As String = "DIAPI_DbUsername_"
    Public ReadOnly Property ClaveDbPassword As String = "DIAPI_DbPassword_"
    Public ReadOnly Property ClaveUsername As String = "DIAPI_Username_"
    Public ReadOnly Property ClavePassword As String = "DIAPI_Password_"

    Public Sub New()
        Server = ""
        LicenseServer = ""
        Database = ""
        DbServerType = ""
        CompanyDB = ""
        DbUsername = ""
        DbPassword = ""
        Username = ""
        Password = ""
    End Sub
End Class
