Imports System
Imports System.Net
Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Data.SqlClient
Partial Class Individual_Users_Approved_Budget_Individual
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim con As New Data.SqlClient.SqlConnection
        con.ConnectionString = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString

        Dim department_division_email_id As String = Session("Email").ToString()
        Dim department_division_id As String = Session("Department_Divison_Id").ToString()
        Dim current_financial_year As String = ""

        'Get Current Financial Year from the database
        Dim objreader1 As SqlDataReader
        Dim logincommand1 As New SqlCommand
        logincommand1.CommandText = "SELECT Current_Financial_Year FROM Current_Financial_Year"
        logincommand1.Connection = con
        con.Open()
        objreader1 = logincommand1.ExecuteReader
        If objreader1.Read Then
            Session("Current_Financial_Year") = objreader1("Current_Financial_Year").ToString()
            current_financial_year = objreader1("Current_Financial_Year").ToString()
        End If
        con.Close()


        lbl_current_financial_year.Text = "Financial Year" & " " & Session("Current_Financial_Year")

        'Get Department Budget Record from the database
        Dim command2 As SqlCommand
        Dim budget_record_count As Integer
        ' Dim str2 As String = "SELECT COUNT(*) FROM Budget_Master WHERE Financial_Year = '" & current_financial_year.ToString() & "' AND Department_Id = '" & department_division_id.ToString() & "'"
        'Dim str2 As String = "SELECT COUNT(*) FROM Budget_Master_Individual WHERE Financial_Year = '" & current_financial_year.ToString() & "' AND Email = '" & Session("Email").ToString() & "'"
        Dim str2 As String = "SELECT COUNT(*) FROM Budget_Master_Individual WHERE Financial_Year = '" & current_financial_year.ToString() & "' AND Email = '" & Session("Email").ToString() & "'"
        command2 = New SqlCommand(str2, con)
        con.Open()
        budget_record_count = command2.ExecuteScalar()
        con.Close()

        If budget_record_count = 0 Then
            Response.Redirect("No_Budget_Records_Found_Individual.aspx")
        Else

            BindGrid()

        End If

        'Get Department Name from the database
        Dim objreader3 As SqlDataReader
        Dim logincommand3 As New SqlCommand
        logincommand3.CommandText = "SELECT Department_Name FROM Department_Division_Master  WHERE Department_Id = '" & department_division_id.ToString() & "'"
        logincommand3.Connection = con
        con.Open()
        objreader3 = logincommand3.ExecuteReader
        If objreader3.Read Then
            lbl_department_name.Text = objreader3("Department_Name").ToString()
        End If



        'Get Faculty Name from the database
        Dim objreader4 As SqlDataReader
        Dim logincommand4 As New SqlCommand
        logincommand4.CommandText = "SELECT FullName FROM Login_Details_Individual WHERE  username = '" & Session("Email").ToString() & "'"
        logincommand4.Connection = con

        objreader4 = logincommand4.ExecuteReader
        If objreader4.Read Then
            lbl_faculty_name.Text = objreader4("FullName").ToString()
        End If



        con.Close()

    End Sub

    Sub message(ByVal temp As String)
        Dim strscript As String
        strscript = "<script>"
        strscript = strscript & "alert('" + temp + "');"
        strscript = strscript & "</script>"
        Page.RegisterStartupScript("ClientScript", strscript.ToString())

    End Sub

    Private Sub BindGrid()

        Dim current_financial_year As String = Session("Current_Financial_Year")
        Dim department_division_id As String = Session("Department_Divison_Id").ToString()


        Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
        Using con As New SqlConnection(constr)
            'Dim str1 As String = "SELECT * FROM Budget_Master WHERE  Financial_Year = '" & current_financial_year.ToString() & "' AND Department_Id = '" & department_division_id.ToString() & "'"
            ' Dim str1 As String = "SELECT * FROM Budget_Master_Individual WHERE  Financial_Year = '" & current_financial_year.ToString() & "' AND Email = '" & Session("Email").ToString() & "'"
            Dim str1 As String = "SELECT * FROM Budget_Master_Individual WHERE  Financial_Year = '" & current_financial_year.ToString() & "' and Head='" + Request.QueryString("Head").ToString() + "'"
            Using cmd As New SqlCommand(str1)
                Using sda As New SqlDataAdapter()
                    cmd.Connection = con
                    sda.SelectCommand = cmd
                    Using dt As New DataTable()
                        sda.Fill(dt)
                        DG1.DataSource = dt
                        DG1.DataBind()
                    End Using
                End Using
            End Using
        End Using
    End Sub
    Protected Sub GridView_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)

        Dim con As New Data.SqlClient.SqlConnection
        con.ConnectionString = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
        If e.Row.RowType = DataControlRowType.DataRow Then

            'For Each row As GridViewRow In DG1.Rows

            Dim spent_amount_estimated As Int64 = 0
            Dim spent_amount_estimated_USER As Int64 = 0
            Dim spent_amount_atual As Int64 = 0
            Dim balance_amount As Int64 = 0
            'dgAccriditation.DataKeys[e.RowIndex].Values["Comp_id"].ToString()
            Dim financial_year As String = DG1.DataKeys(e.Row.RowIndex).Values(0).ToString()
            Dim head As String = DG1.DataKeys(e.Row.RowIndex).Values(1).ToString()
            Dim sub_head As String = DG1.DataKeys(e.Row.RowIndex).Values(2).ToString()

            '  Dim main_head As String = DG1.DataKeys(row.RowIndex).Values(1).ToString()
            Dim Approved_Amount As String = DG1.DataKeys(e.Row.RowIndex).Values(3).ToString()
            Dim department_id As String = DG1.DataKeys(e.Row.RowIndex).Values(4).ToString()



            Dim lbl_spent_amount_estimated As Label = CType(e.Row.FindControl("lbl_spent_amount_estimated"), Label)
            Dim lbl_spent_amount_actual As Label = CType(e.Row.FindControl("lbl_spent_amount_actual"), Label)
            Dim lbl_available_amount As Label = CType(e.Row.FindControl("lbl_available_amount"), Label)

            'Check Budget Spent Record Count
            Dim command As SqlCommand
            Dim budget_record_count As Integer
            'Dim str As String = "SELECT COUNT(*) FROM Institute_Approval_Master_Individual WHERE Financial_Year = '" & financial_year.ToString() & "' AND Department_Id = '" & department_id.ToString() & "' AND Main_Head = '" & main_head.ToString() & "' AND Head = '" & head.ToString() & "' AND Sub_Head = '" & sub_head.ToString() & "' AND Approval_Status IN ('Approved') "
            Dim str As String = "SELECT COUNT(*) FROM tbl_Individual_Consumables_form WHERE Financial_Year = '" & financial_year.ToString() & "' AND Department_Id = '" & department_id.ToString() & "' AND   Head = '" & head.ToString() & "' AND Sub_Head = '" & sub_head.ToString() & "' AND Approval_Status ='Approved'" ''
            command = New SqlCommand(str, con)
            con.Open()
            budget_record_count = command.ExecuteScalar()
            con.Close()


            If budget_record_count = 0 Then
                lbl_spent_amount_estimated.Text = spent_amount_estimated & ".00" & ""
                lbl_spent_amount_actual.Text = spent_amount_atual & ".00" & ""
                lbl_available_amount.Text = Approved_Amount & ".00" & ""

            ElseIf budget_record_count > 0 Then

                Dim total_spent_amount_estimated As Int64 = 0
                Dim total_spent_amount_actual As Int64 = 0

                Dim total_balance_amount As Int64 = 0

                'If Record Exists in the database

                '-----Get Estimated Total Amount After Dean Approval AND Bill Amount Not Enetered By Accounts Team----
                Dim objreader1 As SqlDataReader
                Dim logincommand1 As New SqlCommand
                '  logincommand1.CommandText = "SELECT SUM(Estimated_Amount) as Estimated_Spent_Amount FROM Institute_Approval_Master_Individual WHERE Financial_Year = '" & financial_year.ToString() & "' AND Department_Id = '" & department_id.ToString() & "' AND Main_Head = '" & main_head.ToString() & "' AND Head = '" & head.ToString() & "' AND Sub_Head = '" & sub_head.ToString() & "' AND Dean_Approval_Status IN ('Approved') AND Bill_Amount_Submit_Status = 'Pending'"
                logincommand1.CommandText = "SELECT CASE WHEN SUM(cast(Estimated_Amount as decimal(10,2))) is null then '0' ELSE SUM(cast(Estimated_Amount as decimal(10,2))) END as Estimated_Spent_Amount FROM tbl_Individual_Consumables_form WHERE Financial_Year = '" & financial_year.ToString() & "' AND Department_Id = '" & department_id.ToString() & "'  AND Head = '" & head.ToString() & "' AND Sub_Head = '" & sub_head.ToString() & "' AND Approval_Status ='Approved' AND Bill_Amount_Submit_Status = 'Pending'"
                logincommand1.Connection = con
                con.Open()
                objreader1 = logincommand1.ExecuteReader
                If objreader1.Read Then
                    spent_amount_estimated = objreader1("Estimated_Spent_Amount")
                End If
                con.Close()


                '----Get Bill Total Amount After Bill Entry Done By Accounts Team : After Dean or Director Approval----
                Dim objreader2 As SqlDataReader
                Dim logincommand2 As New SqlCommand
                'logincommand2.CommandText = "SELECT SUM(Bill_Amount) as Bill_Amount FROM Institute_Approval_Master_Individual WHERE Financial_Year = '" & financial_year.ToString() & "' AND Department_Id = '" & department_id.ToString() & "' AND Main_Head = '" & main_head.ToString() & "' AND Head = '" & head.ToString() & "' AND Sub_Head = '" & sub_head.ToString() & "' AND Approval_Status IN ('Approved') AND Bill_Amount_Submit_Status = 'Processed' "
                logincommand2.CommandText = "SELECT CASE WHEN SUM(cast(Bill_Amount as decimal(10,2))) is null then '0' ELSE SUM(cast(Bill_Amount as decimal(10,2))) END as Bill_Amount FROM tbl_Individual_Consumables_form WHERE Financial_Year = '" & financial_year.ToString() & "' AND Department_Id = '" & department_id.ToString() & "'   AND Head = '" & head.ToString() & "' AND Sub_Head = '" & sub_head.ToString() & "' AND Approval_Status ='Approved' AND Bill_Amount_Submit_Status = 'Processed' "
                logincommand2.Connection = con
                con.Open()
                objreader2 = logincommand2.ExecuteReader
                If objreader2.Read Then
                    spent_amount_atual = objreader2("Bill_Amount")

                End If
                con.Close()


                'Get Estimated Total Amount For User Display
                Dim objreader3 As SqlDataReader
                Dim logincommand3 As New SqlCommand
                ' logincommand3.CommandText = "SELECT SUM(Estimated_Amount) as Estimated_Spent_Amount_For_User_Display FROM Institute_Approval_Master_Individual WHERE Financial_Year = '" & financial_year.ToString() & "' AND Department_Id = '" & department_id.ToString() & "' AND Main_Head = '" & main_head.ToString() & "' AND Head = '" & head.ToString() & "' AND Sub_Head = '" & sub_head.ToString() & "' AND Approval_Status IN ('Approved') "
                logincommand3.CommandText = "SELECT SUM(cast(Estimated_Amount as decimal(10,2))) as Estimated_Amount FROM tbl_Individual_Consumables_form WHERE Financial_Year = '" & financial_year.ToString() & "' AND Department_Id = '" & department_id.ToString() & "' AND  Head = '" & head.ToString() & "' AND Sub_Head = '" & sub_head.ToString() & "' AND Approval_Status  ='Approved' "
                logincommand3.Connection = con
                con.Open()
                objreader3 = logincommand3.ExecuteReader
                If objreader3.Read Then
                    lbl_spent_amount_estimated.Text = objreader3("Estimated_Amount").ToString().Replace(".00", "") & ".00" & ""
                    spent_amount_estimated_USER = objreader3("Estimated_Amount").ToString().Replace(".00", "") & ".00" & ""
                End If
                con.Close()

                'Get Estimated Total Amount For User Display
                Dim objreader32 As SqlDataReader
                Dim logincommand32 As New SqlCommand
                ' logincommand3.CommandText = "SELECT SUM(Estimated_Amount) as Estimated_Spent_Amount_For_User_Display FROM Institute_Approval_Master_Individual WHERE Financial_Year = '" & financial_year.ToString() & "' AND Department_Id = '" & department_id.ToString() & "' AND Main_Head = '" & main_head.ToString() & "' AND Head = '" & head.ToString() & "' AND Sub_Head = '" & sub_head.ToString() & "' AND Approval_Status IN ('Approved') "
                logincommand32.CommandText = "SELECT SUM(cast(Estimated_Amount as decimal(10,2))) as Estimated_Amount FROM tbl_Individual_Consumables_form WHERE Financial_Year = '" & financial_year.ToString() & "' AND Department_Id = '" & department_id.ToString() & "' AND  Head = '" & head.ToString() & "' AND Sub_Head = '" & sub_head.ToString() & "' AND Approval_Status  ='Approved'"
                logincommand32.Connection = con
                con.Open()
                objreader32 = logincommand32.ExecuteReader
                If objreader32.Read Then
                    lbl_spent_amount_estimated.Text = objreader32("Estimated_Amount").ToString().Replace(".00", "") & ".00" & ""
                    'spent_amount_estimated_USER = objreader3("Estimated_Amount").ToString().Replace(".00", "") & ".00" & ""
                End If
                con.Close()


                'Total Estimated Spent Amount
                If spent_amount_estimated = 0 Then
                    total_spent_amount_estimated = spent_amount_estimated_USER
                Else
                    total_spent_amount_estimated = spent_amount_estimated
                End If


                'Total Atual Spent Amount
                total_spent_amount_actual = spent_amount_atual
                lbl_spent_amount_actual.Text = total_spent_amount_actual & ".00" & ""


                'Total Balance Amount
                'total_balance_amount = Approved_Amount - (spent_amount_estimated + spent_amount_atual)

                If spent_amount_atual = 0 Then
                    total_balance_amount = Approved_Amount - (total_spent_amount_estimated + spent_amount_atual)
                    'total_balance_amount = Approved_Amount - (spent_amount_estimated + spent_amount_atual)
                    lbl_available_amount.Text = total_balance_amount & ".00" & ""
                Else
                    total_balance_amount = Approved_Amount - (spent_amount_estimated + spent_amount_atual)
                    lbl_available_amount.Text = total_balance_amount & ".00" & ""
                End If

            End If

            'Next




            'If e.Row.RowType = DataControlRowType.DataRow Then
            'For i = 0 To e.Row.Cells.Count - 1
            '    Dim rowcell As TableCell = e.Row.Cells(i)
            '    rowcell.BorderColor = Drawing.Color.008080
            'Next
        End If
    End Sub


    Public Function Get_SpendAmount(ByVal Head As String, ByVal Sub_Head As String, ByVal Project_Title As String) As String

        Dim con As New Data.SqlClient.SqlConnection
        con.ConnectionString = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString

        Dim Date1 As String
        Dim objreader2 As SqlDataReader
        Dim logincommand2 As New SqlCommand
        'logincommand2.CommandText = "SELECT SUM(Bill_Amount) as Bill_Amount FROM Institute_Approval_Master_Individual WHERE Financial_Year = '" & financial_year.ToString() & "' AND Department_Id = '" & department_id.ToString() & "' AND Main_Head = '" & main_head.ToString() & "' AND Head = '" & head.ToString() & "' AND Sub_Head = '" & sub_head.ToString() & "' AND Approval_Status IN ('Approved') AND Bill_Amount_Submit_Status = 'Processed' "
        logincommand2.CommandText = "SELECT SUM(cast(Estimated_Amount as decimal(10,2))) as Bill_Amount FROM tbl_Individual_Consumables_form WHERE Head = '" & Head.ToString() & "' AND Sub_Head = '" & Sub_Head.ToString() & "' AND ProjectTitle='" & Project_Title.ToString() & "' "
        logincommand2.Connection = con
        con.Open()
        objreader2 = logincommand2.ExecuteReader
        If objreader2.Read Then
            Date1 = objreader2("Bill_Amount").ToString

        End If
        con.Close()

        Return Date1
    End Function



End Class
