Imports System
Imports System.Net
Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Data.SqlClient
Partial Class Individual_Users_Account_Last_Login_Entry_Individual
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim con As New Data.SqlClient.SqlConnection
        con.ConnectionString = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString

        Dim user_email_id As String = Session("Email").ToString()

        'Check User Record Count
        Dim command1 As SqlCommand
        Dim user_record_count As Integer
        Dim str1 As String = "SELECT COUNT(*) FROM User_Account_Last_Login_Details_Individual WHERE Email_Id = '" & user_email_id.ToString() & "' "
        command1 = New SqlCommand(str1, con)
        con.Open()
        user_record_count = command1.ExecuteScalar()
        con.Close()

        If user_record_count = 0 Then

            Session("User_Last_Login_Date_Time") = ""
            Session("User_Last_Login_IP_Address") = ""

            'Get Client IP Address
            Dim ipaddress As String
            ipaddress = Request.ServerVariables("HTTP_X_FORWARDED_FOR")
            If ipaddress = "" Or ipaddress Is Nothing Then
                ipaddress = Request.ServerVariables("REMOTE_ADDR")
            End If

            Dim login_date_time As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

            'Insert Last Login Details in the database
            Dim commandstr1 As String
            Dim logincommand1 As New SqlCommand
            commandstr1 = "INSERT INTO User_Account_Last_Login_Details_Individual(Email_Id,Last_Login_Date_Time,IP_Address) values ( '" & user_email_id.ToString() & "','" & login_date_time.ToString() & "','" & ipaddress.ToString() & "')"
            logincommand1.CommandText = commandstr1
            logincommand1.Connection = con
            con.Open()
            logincommand1.ExecuteNonQuery()
            con.Close()

            'Response.Redirect("DashBoard.aspx")
            Response.Redirect("Processing_Individual.aspx")


        ElseIf user_record_count > 0 Then


            'Get Client IP Address
            Dim ipaddress As String
            ipaddress = Request.ServerVariables("HTTP_X_FORWARDED_FOR")
            If ipaddress = "" Or ipaddress Is Nothing Then
                ipaddress = Request.ServerVariables("REMOTE_ADDR")
            End If

            Dim login_date_time As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

            Dim user_last_login_date_time As String = ""
            Dim user_last_login_ip_address As String = ""

            'Get Last Login Details 
            Dim objreader1 As SqlDataReader
            Dim logincommand1 As New SqlCommand
            logincommand1.CommandText = "SELECT Last_Login_Date_Time,IP_Address FROM User_Account_Last_Login_Details_Individual WHERE Email_Id = '" & user_email_id.ToString() & "'"
            logincommand1.Connection = con
            con.Open()
            objreader1 = logincommand1.ExecuteReader()
            If objreader1.Read Then
                Dim last_login_datetime As DateTime = objreader1("Last_Login_Date_Time")
                user_last_login_date_time = last_login_datetime.ToString("dd-MMM-yyyy hh:mm:ss tt")
                user_last_login_ip_address = objreader1("IP_Address")
            End If
            con.Close()

            Session("User_Last_Login_Date_Time") = user_last_login_date_time.ToString()
            Session("User_Last_Login_IP_Address") = user_last_login_ip_address.ToString()


            '----Now Update Current Login details in the Last Login Table---
            Dim logincommand2 As New SqlCommand
            Dim commandstr2 As String
            con.Open()
            commandstr2 = "UPDATE User_Account_Last_Login_Details_Individual SET Last_Login_Date_Time = '" & login_date_time & "' , IP_Address ='" & ipaddress.ToString() & "' WHERE Email_Id = '" & user_email_id.ToString() & "'"
            logincommand2.CommandText = commandstr2
            logincommand2.Connection = con
            logincommand2.ExecuteNonQuery()
            con.Close()

            Response.Redirect("Processing_Individual.aspx")
        End If

    End Sub
End Class
