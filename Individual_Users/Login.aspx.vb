Imports System
Imports System.Net
Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Data.SqlClient
Partial Class Individual_Users_Login
    Inherits System.Web.UI.Page

    Sub message(ByVal temp As String)
        Dim strscript As String
        strscript = "<script>"
        strscript = strscript & "alert('" + temp + "');"
        strscript = strscript & "</script>"
        Page.RegisterStartupScript("ClientScript", strscript.ToString())
    End Sub
    Protected Sub Submit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Submit.Click

        Dim con As New Data.SqlClient.SqlConnection
        con.ConnectionString = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString

        If username_txt.Text = "" Then
            message("Please Enter BITS e-Mail Id")
        ElseIf password_txt.Text = "" Then
            message("Please Enter Password")
        Else

            Dim objreader As SqlDataReader
            Dim logincommand As New SqlCommand
            con.Open()
            logincommand.CommandText = "SELECT * FROM Login_Details_Individual WHERE Username = '" & username_txt.Text.ToString() & "'"
            logincommand.Connection = con
            objreader = logincommand.ExecuteReader
            If objreader.Read Then
                If (password_txt.Text.Trim.ToLower = CStr(objreader("Password")).ToLower) Then
                    Session("Email") = username_txt.Text.ToString()
                    Dim user_type As String = objreader("User_Type")
                    Dim account_status As String = objreader("Account_Status")
                    Session("approval_User_Type") = objreader("User_Type")

                    If user_type = "Admin" Then
                        con.Close()

                        If account_status = "Active" Then
                            Response.Redirect("Account_Login_Details_Entry_Individual.aspx")
                        Else
                            message("Account Disbaled By Administrator")
                        End If

                    ElseIf user_type = "User" Then
                        con.Close()

                        If account_status = "Active" Then
                            Response.Redirect("Account_Login_Details_Entry_Individual.aspx")
                        Else
                            message("Account Disbaled By Administrator")
                        End If

                    End If

                End If

            End If
        End If

    End Sub
    Protected Sub Reset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Reset.Click
        username_txt.Text = ""
        password_txt.Text = ""
    End Sub
End Class
