Imports System.Data.SqlClient
Partial Class SignIn
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        'Get Client IP Address
        Dim ipaddress As String
        ipaddress = Request.ServerVariables("HTTP_X_FORWARDED_FOR")
        If ipaddress = "" Or ipaddress Is Nothing Then
            ipaddress = Request.ServerVariables("REMOTE_ADDR")
        End If

        Session("IP") = ipaddress.ToString()

    End Sub
    Sub message(ByVal temp As String)
        Dim strscript As String
        strscript = "<script>"
        strscript = strscript & "alert('" + temp + "');"
        strscript = strscript & "</script>"
        Page.RegisterStartupScript("ClientScript", strscript.ToString())
    End Sub

    Protected Sub linkPage_Click(sender As Object, e As EventArgs) Handles linkPage.Click

        Dim con As New Data.SqlClient.SqlConnection
        con.ConnectionString = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString


        Session("Name") = HiddenField1.Value
        Session("Email") = HiddenField2.Value

        Session("User_Email_Id") = HiddenField2.Value

        Dim objreader As SqlDataReader
        Dim logincommand As New SqlCommand
        con.Open()
        logincommand.CommandText = "SELECT * FROM Login_Details_Individual WHERE Username = '" & Session("Email").Trim().ToString() & " '"
        logincommand.Connection = con
        objreader = logincommand.ExecuteReader
        If objreader.Read Then

            Session("Email") = Session("Email").ToString().Trim()
            Dim user_type As String = objreader("User_Type")
            Dim account_status As String = objreader("Account_Status")
            Session("approval_User_Type") = objreader("User_Type")
            ' Session("Department_Divsion_Head_Email_Id") = objreader("UserName")

            '-------Admin Account----d
            If user_type = "Admin" Then
                con.Close()

                If account_status = "Active" Then
                    'Response.Redirect("Individual_Users/Account_Login_Details_Entry.aspx")
                    'Response.Redirect("Individual_Users/Account_Login_Details_Entry_Individual.aspx")
                    Response.Redirect("Account_Login_Details_Entry_Individual.aspx")
                Else
                    message("Account Disbaled By Administrator")
                End If

                '----User Account-------
            ElseIf user_type = "User" Then
                con.Close()

                If account_status = "Active" Then
                    'Response.Redirect("Individual_Users/Account_Login_Details_Entry.aspx")
                    'Response.Redirect("Individual_Users/Account_Login_Details_Entry_Individual.aspx")
                    Response.Redirect("Account_Login_Details_Entry_Individual.aspx")
                Else
                    message("Account Disbaled By Administrator")
                End If

            End If

        Else
            '--------Invalid Login----------
            con.Close()
            Response.Redirect("https://ipcservices.bits-pilani.ac.in/BAS/Invalid_Login.aspx")
        End If

    End Sub
   
End Class



