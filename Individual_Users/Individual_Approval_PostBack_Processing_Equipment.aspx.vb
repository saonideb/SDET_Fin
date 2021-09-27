
Partial Class Individual_Users_Individual_Approval_PostBack_Processing
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim reference_no As String = Request.QueryString("Session_Id").ToString()
        Response.Redirect(String.Format("Individual_Approval_Equipment.aspx?Session_Id={0}", reference_no))
    End Sub
End Class
