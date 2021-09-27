Imports System
Imports System.Net
Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Data.SqlClient
Partial Class Individual_Users_Account_Login_Details_Entry_Individual
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim con As New Data.SqlClient.SqlConnection
        con.ConnectionString = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString

        Dim user_email_id As String = Session("Email").ToString()

        'Get Client IP Address
        Dim ipaddress As String
        ipaddress = Request.ServerVariables("HTTP_X_FORWARDED_FOR")
        If ipaddress = "" Or ipaddress Is Nothing Then
            ipaddress = Request.ServerVariables("REMOTE_ADDR")
        End If
        Session("User_IP_Address") = ipaddress

        Dim login_date As String = DateTime.Now.ToString("yyyy-MM-dd")
        Dim login_date_time As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")


        'Insert Login Details in the database
        Dim commandstr1 As String
        Dim logincommand1 As New SqlCommand
        commandstr1 = "INSERT INTO User_Account_Login_History_Individual(Email_Id,Login_Date_Time,IP_Address) values ( '" & user_email_id.ToString() & "','" & login_date_time.ToString() & "','" & ipaddress.ToString() & "')"
        logincommand1.CommandText = commandstr1
        logincommand1.Connection = con
        con.Open()
        logincommand1.ExecuteNonQuery()
        con.Close()

        Response.Redirect("Account_Last_Login_Entry_Individual.aspx")


    End Sub
End Class
