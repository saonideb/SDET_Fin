
Partial Class Individual_Users_Individual
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblYear.Text = DateTime.Now.Year.ToString()
    End Sub
End Class

