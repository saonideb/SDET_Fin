Imports System
Imports System.Net
Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Data.SqlClient
Partial Class Individual_Users_No_Budget_Records_Found_Individual
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim con As New Data.SqlClient.SqlConnection
        con.ConnectionString = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString

       Dim department_division_email_id As String = Session("Email").ToString()



        'Get Department/Division Id
        Dim objreader As SqlDataReader
        Dim logincommand As New SqlCommand
        logincommand.CommandText = "SELECT Assigned_Department FROM Login_Details_Individual WHERE Username = '" & department_division_email_id.ToString() & "'"
        logincommand.Connection = con
        con.Open()
        objreader = logincommand.ExecuteReader
        If objreader.Read Then
            Session("Department_Divison_Id") = objreader("Assigned_Department").ToString()
        End If
        con.Close()

        ' Response.Redirect("Approved_Budget_Individual.aspx")

    End Sub
End Class

