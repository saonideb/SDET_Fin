Imports System.Data
Imports System.IO
Imports System.Data.SqlClient
Partial Class Individual_Users_Institute_Approval_PreProcessing_Individual
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim financial_year As String = Request.QueryString("FY").ToString()
        Dim department_id As String = Request.QueryString("Department_Id").ToString()
        ''Dim budget_main_head As String = Request.QueryString("Main_Head").ToString()
        Dim budget_head As String = Request.QueryString("Head").ToString()
        Dim budget_sub_head As String = Request.QueryString("Sub_Head").ToString()

        Session("Form_A_Entry_Financial_Year") = financial_year
        Session("Form_A_Entry_Department_Id") = department_id
        Session("Form_A_Entry_Main_Head") = budget_head
        Session("Form_A_Entry_Head") = budget_head
        Session("Form_A_Entry_Sub_Head") = budget_sub_head

        Dim newGuid As Guid = Guid.NewGuid()
        Dim reference_No As String = newGuid.ToString()
        Session("Form_A_Reference_No") = reference_No.ToString()

        If budget_sub_head = "Equipment" Then
            Response.Redirect(String.Format("Individual_Approval_Equipment_New.aspx?Session_Id={0}", reference_No))
        ElseIf budget_sub_head = "Consumables" Then
            '//Response.Redirect(String.Format("Individual_Approval_Consumables.aspx?Session_Id={0}", reference_No))
            Response.Redirect(String.Format("Individual_Approval_Consumables_New.aspx?Session_Id={0}", reference_No))
        ElseIf budget_sub_head = "Contingencies" Then
            Response.Redirect(String.Format("Individual_Approval_Contingencies_New.aspx?Session_Id={0}", reference_No))
        ElseIf budget_sub_head = "Travel" Then
            ''Response.Redirect(String.Format("Individual_Approval_Travel.aspx?Session_Id={0}", reference_No))
            Response.Redirect(String.Format("Individual_Travel_Form.aspx?Session_Id={0}", reference_No))
        ElseIf budget_sub_head = "Overhead" Then
            Response.Redirect(String.Format("Individual_Approval_Overhead.aspx?Session_Id={0}", reference_No))
        ElseIf budget_sub_head = "Miscellaneous" Then
            Response.Redirect(String.Format("Individual_Approval_Miscellaneous.aspx?Session_Id={0}", reference_No))
        End If
    End Sub
End Class

