Imports System
Imports System.Net
Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Data.SqlClient
Partial Class Individual_Users_Individual_Approval_Delete_Items_Equipment
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim con As New Data.SqlClient.SqlConnection
        con.ConnectionString = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString

        Dim record_id As String = Request.QueryString("Record_Id").ToString()
        Dim reference_no As String = Request.QueryString("Reference_No").ToString()

        Dim cmd1 As New SqlCommand
        cmd1.CommandType = Data.CommandType.Text
        'cmd1.CommandText = "DELETE FROM Form_A_Item_Details_Draft WHERE Record_Id = '" & record_id.ToString() & "' AND Reference_No = '" & reference_no.ToString() & "' "
        cmd1.CommandText = "DELETE FROM Form_A_Equipment_Item_Details_Draft WHERE Record_Id = '" & record_id.ToString() & "' AND Reference_No = '" & reference_no.ToString() & "' "
        cmd1.Connection = con
        con.Open()
        cmd1.ExecuteNonQuery()
        con.Close()

        Response.Redirect(String.Format("Individual_Approval_Equipment.aspx?Session_Id={0}", reference_no))

    End Sub
End Class
