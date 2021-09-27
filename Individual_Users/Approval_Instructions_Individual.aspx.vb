
Partial Class Individual_Users_Approval_Instructions_Individual
    Inherits System.Web.UI.Page
    Sub message(ByVal temp As String)
        Dim strscript As String
        strscript = "<script>"
        strscript = strscript & "alert('" + temp + "');"
        strscript = strscript & "</script>"
        Page.RegisterStartupScript("ClientScript", strscript.ToString())
    End Sub
    Protected Sub chk_agree_CheckedChanged(sender As Object, e As EventArgs) Handles chk_agree.CheckedChanged
        If chk_agree.Checked Then
            btn_submit.Enabled = True
        Else
            btn_submit.Enabled = False
        End If
    End Sub
    Protected Sub btn_submit_Click(sender As Object, e As EventArgs) Handles btn_submit.Click
        If chk_agree.Checked = False Then
            message("Please Check the Instructions Acceptance Option to Procced")
        Else
            ''Response.Redirect("Institue_Approval_Step1_Individual.aspx")
            Response.Redirect("Institue_Approval_All.aspx")
        End If
    End Sub
End Class

