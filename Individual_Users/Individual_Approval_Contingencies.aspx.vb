Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Security.Cryptography
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Net.Mail
Imports System.IO
Imports System.Web.Configuration
Imports System.Collections.Specialized
Imports System.Net
Imports System.Security.Cryptography.X509Certificates
Imports System.Globalization
Partial Class Individual_Users_Individual_Approval_Contingencies
    Inherits System.Web.UI.Page

    Protected available_balance_amount As Int64 = 0
    Protected items_total_amount As Decimal
    Protected items_total_amount_p As Decimal
    Private random As New Random()

    Public Email_User_ID As String = System.Configuration.ConfigurationManager.AppSettings("EmailID")
    Public Email_Password As String = System.Configuration.ConfigurationManager.AppSettings("EmailPassword")

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim con As New Data.SqlClient.SqlConnection
        con.ConnectionString = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString


        'Disable Submit Button
        Me.btn_submit.Attributes.Add("onclick", DisableTheButton(Me.Page, Me.btn_submit))

        Dim reference_no As String = ""

        Try
            reference_no = Request.QueryString("Session_Id").ToString()
        Catch ex As Exception
            Response.Redirect("Invalid_Request.aspx")
        End Try

        If Session("Form_A_Reference_No") <> reference_no Then
            Response.Redirect("Invalid_Request.aspx")
        End If

        Dim financial_year As String = Session("Form_A_Entry_Financial_Year")
        Dim department_division_id As String = Session("Department_Divison_Id").ToString()
        ' Dim budget_main_head As String = Session("Form_A_Entry_Main_Head")
        Dim budget_head As String = Session("Form_A_Entry_Head")
        Dim budget_sub_head As String = Session("Form_A_Entry_Sub_Head")

        Dim budget_main_head_for_balance As String = Session("Form_A_Entry_Main_Head")
        Dim budget_head_for_balance As String = Session("Form_A_Entry_Head")
        Dim budget_sub_head_for_balance As String = Session("Form_A_Entry_Sub_Head")


        lbl_current_date.Text = DateTime.Now.ToString("dd/MMM/yyyy")


        'Get Department Name from the database
        Dim objreader1 As SqlDataReader
        Dim logincommand1 As New SqlCommand
        logincommand1.CommandText = "SELECT Department_Name FROM Department_Division_Master  WHERE Department_Id = '" & department_division_id.ToString() & "'"
        logincommand1.Connection = con
        con.Open()
        objreader1 = logincommand1.ExecuteReader
        If objreader1.Read Then
            lbl_department_name.Text = objreader1("Department_Name").ToString()
        End If
        con.Close()

        'Get Budget Head Description
        Dim budget_head_description As String = ""
        Dim objreader2 As SqlDataReader
        Dim logincommand2 As New SqlCommand
        'logincommand2.CommandText = "SELECT Budget_Description FROM Budget_Master WHERE Financial_Year = '" & financial_year.ToString() & "' AND Department_Id = '" & department_division_id.ToString() & "' AND Main_Head = '" & budget_main_head.ToString() & "' AND Head = '" & budget_head.ToString() & "' AND Sub_Head = '" & budget_sub_head.ToString() & "'"
        logincommand2.CommandText = "SELECT Project_Title FROM Budget_Master_Individual WHERE Financial_Year = '" & financial_year.ToString() & "' AND Email = '" & Session("Email") & "' AND  Head = '" & budget_head.ToString() & "' AND Sub_Head = '" & budget_sub_head.ToString() & "'"
        logincommand2.Connection = con
        con.Open()
        objreader2 = logincommand2.ExecuteReader
        If objreader2.Read Then
            budget_head_description = objreader2("Project_Title").ToString()
        End If
        con.Close()

        'If CInt(budget_main_head) < 10 Then
        '    budget_main_head = "0" & "" & budget_main_head
        'End If

        'If CInt(budget_head) < 10 Then
        '    budget_head = "0" & "" & budget_head
        'End If

        'If CInt(budget_sub_head) < 10 Then
        '    budget_sub_head = "0" & "" & budget_sub_head
        'End If

        ' lbl_budget_head_details.Text = budget_main_head.ToString() & "/" & budget_head.ToString & "/" & budget_sub_head.ToString & "/" & budget_head_description.ToString

        lbl_budget_head_details.Text = budget_head.ToString & "/" & budget_sub_head.ToString
        lbl_Project_head_Title.Text = budget_head_description.ToString

        '-----------https://codepen.io/robcopeland/pen/rjXZra?__cf_chl_jschl_tk__=af32e380d626086c690ac7340f03e47c798f7f9d-1599682543-0-AZ2X4ypxiXMzho9p5nRt6GUKdD7KAF5jJlta_sdv7SFFzH_D0gu9EqjZoxPjl9I0UQ2D2j2r801hDIBSGSjTuExviK1DhHtRI_lmaJ_LycBNmYJwurFT-e05CVRV5bn3VTJUSUs02V3URR6m7sILHw-u2H8kn_eSQZgD48DZoQa5skErwSCdR6T3WVqvk-gCyXKSQfZGOvP1lGwaf4X3fzf8N6Tt2ahBuDUBFT_t83gzFPTAi_ZvtjBAxE0VKgM4xC5xIukBlSZoSsrAb72hb2Xt_PyAS7PX2FV-95jI2i-GS7EFQQahjJh5a6HAGKb294R88MIDN9zQfByuSJAYthpnY5AAt-mtol0lnF-KYPAR

        If Page.IsPostBack = False Then

            'Get Justification Record Count
            Dim command5 As SqlCommand
            Dim approval_justification_record_count As Integer
            ' Dim str5 As String = "SELECT COUNT(*) FROM Form_A_Justification_Details_Draft WHERE Reference_No = '" & reference_no.ToString() & "' "
            Dim str5 As String = "SELECT COUNT(*) FROM Form_A_Equipment_Justification_Details_Draft WHERE Reference_No = '" & reference_no.ToString() & "' "
            command5 = New SqlCommand(str5, con)
            con.Open()
            approval_justification_record_count = command5.ExecuteScalar()
            con.Close()

            'Get Justification details from the database
            If approval_justification_record_count > 0 Then

                Dim objreader6 As SqlDataReader
                Dim logincommand6 As New SqlCommand
                'logincommand6.CommandText = "SELECT Justification_Details FROM Form_A_Justification_Details_Draft WHERE Reference_No = '" & reference_no.ToString() & "' "
                logincommand6.CommandText = "SELECT Justification_Details FROM Form_A_Equipment_Justification_Details_Draft WHERE Reference_No = '" & reference_no.ToString() & "' "
                logincommand6.Connection = con
                con.Open()
                objreader6 = logincommand6.ExecuteReader
                If objreader6.Read Then
                    txt_justification.Text = objreader6("Justification_Details").ToString()
                End If
                con.Close()
            End If


            'Get Items Record Count
            Dim command7 As SqlCommand
            Dim approval_items_record_count As Integer
            ' Dim str7 As String = "SELECT COUNT(*) FROM Form_A_Item_Details_Draft WHERE Reference_No = '" & reference_no.ToString() & "' "
            Dim str7 As String = "SELECT COUNT(*) FROM Form_A_Equipment_Item_Details_Draft WHERE Reference_No = '" & reference_no.ToString() & "' "
            command7 = New SqlCommand(str7, con)
            con.Open()
            approval_items_record_count = command7.ExecuteScalar()
            con.Close()

            If approval_items_record_count > 0 Then

                'Bind Data to Gridview
                Bind_Item_Details()
                div_item_details.Visible = True
            End If

        End If


        '----------------Get Avalaible Balance-----
        Dim command8 As SqlCommand
        Dim institute_approval_record_count As Integer
        'Dim str8 As String = "SELECT COUNT(*) FROM Institute_Approval_Master WHERE Financial_Year = '" & financial_year.ToString() & "' AND Department_Id = '" & department_division_id.ToString() & "' AND Main_Head = '" & budget_main_head_for_balance.ToString() & "' AND Head = '" & budget_head_for_balance.ToString() & "' AND Sub_Head = '" & budget_sub_head_for_balance.ToString() & "' AND Approval_Status IN ('Approved') "
        Dim str8 As String = "SELECT COUNT(*) FROM Institute_Approval_Master_Individual WHERE Financial_Year = '" & financial_year.ToString() & "' AND Department_Id = '" & department_division_id.ToString() & "' AND   Head = '" & budget_head_for_balance.ToString() & "' AND Sub_Head = '" & budget_sub_head_for_balance.ToString() & "' AND Approval_Status IN ('Approved') "
        command8 = New SqlCommand(str8, con)
        con.Open()
        institute_approval_record_count = command8.ExecuteScalar()
        con.Close()



        Dim approved_amount As Int64 = 0
        Dim spent_amount As Int64 = 0
        Dim balance_amount As Int64 = 0

        If institute_approval_record_count = 0 Then

            'If No Approval is Submitted then Get the Approved Budget Head Amount from the database
            Dim objreader9 As SqlDataReader
            Dim logincommand9 As New SqlCommand
            'logincommand9.CommandText = "SELECT Approved_Amount FROM Budget_Master WHERE Financial_Year = '" & financial_year.ToString() & "' AND Department_Id = '" & department_division_id.ToString() & "' AND Main_Head = '" & budget_main_head_for_balance.ToString() & "' AND Head = '" & budget_head_for_balance.ToString() & "' AND Sub_Head = '" & budget_sub_head_for_balance.ToString() & "' "
            logincommand9.CommandText = "SELECT Approved_Amount FROM Budget_Master_Individual WHERE Financial_Year = '" & financial_year.ToString() & "' AND Department_Id = '" & department_division_id.ToString() & "' AND   Head = '" & budget_head_for_balance.ToString() & "' AND Sub_Head = '" & budget_sub_head_for_balance.ToString() & "' "
            logincommand9.Connection = con
            con.Open()
            objreader9 = logincommand9.ExecuteReader
            If objreader9.Read Then
                balance_amount = objreader9("Approved_Amount")
                available_balance_amount = balance_amount


                'lbl_budget_head_balance_amount.Text = String.Format("{0:C}", balance_amount)
                lbl_budget_head_balance_amount.Text = "Rs." & " " & balance_amount & ".00" & ""
            End If
            con.Close()

        ElseIf institute_approval_record_count > 0 Then

            Dim estimated_amount As Int64 = 0
            Dim bill_amount As Int64 = 0

            Dim objreader9 As SqlDataReader
            Dim logincommand9 As New SqlCommand
            'logincommand9.CommandText = "SELECT Approved_Amount FROM Budget_Master WHERE Financial_Year = '" & financial_year.ToString() & "' AND Department_Id = '" & department_division_id.ToString() & "' AND Main_Head = '" & budget_main_head_for_balance.ToString() & "' AND Head = '" & budget_head_for_balance.ToString() & "' AND Sub_Head = '" & budget_sub_head_for_balance.ToString() & "' "
            logincommand9.CommandText = "SELECT Approved_Amount FROM Budget_Master_Individual WHERE Financial_Year = '" & financial_year.ToString() & "' AND Department_Id = '" & department_division_id.ToString() & "' AND Head = '" & budget_head_for_balance.ToString() & "' AND Sub_Head = '" & budget_sub_head_for_balance.ToString() & "' "
            logincommand9.Connection = con
            con.Open()
            objreader9 = logincommand9.ExecuteReader
            If objreader9.Read Then
                approved_amount = objreader9("Approved_Amount")
            End If
            con.Close()


            'Estimated Amount
            Dim objreader10 As SqlDataReader
            Dim logincommand10 As New SqlCommand
            ' logincommand10.CommandText = "SELECT SUM(Estimated_Amount) as Estimated_Amount FROM Institute_Approval_Master WHERE Financial_Year = '" & financial_year.ToString() & "' AND Department_Id = '" & department_division_id.ToString() & "' AND Main_Head = '" & budget_main_head_for_balance.ToString() & "' AND Head = '" & budget_head_for_balance.ToString() & "' AND Sub_Head = '" & budget_sub_head_for_balance.ToString() & "' AND Dean_Approval_Status IN ('Approved') AND Bill_Amount_Submit_Status = 'Pending'"
            logincommand10.CommandText = "SELECT SUM(Estimated_Amount) as Estimated_Amount FROM Institute_Approval_Master_Individual WHERE Financial_Year = '" & financial_year.ToString() & "' AND Department_Id = '" & department_division_id.ToString() & "' AND  Head = '" & budget_head_for_balance.ToString() & "' AND Sub_Head = '" & budget_sub_head_for_balance.ToString() & "' AND Dean_Approval_Status IN ('Approved') AND Bill_Amount_Submit_Status = 'Pending'"
            logincommand10.Connection = con
            con.Open()
            objreader10 = logincommand10.ExecuteReader
            If objreader10.Read Then
                estimated_amount = objreader10("Estimated_Amount").ToString()
            End If
            con.Close()


            'Get Bill Amount/Actual Amount
            Dim objreader11 As SqlDataReader
            Dim logincommand11 As New SqlCommand
            ' logincommand11.CommandText = "SELECT SUM(Bill_Amount) as Billed_Amount FROM Institute_Approval_Master WHERE Financial_Year = '" & financial_year.ToString() & "' AND Department_Id = '" & department_division_id.ToString() & "' AND Main_Head = '" & budget_main_head_for_balance.ToString() & "' AND Head = '" & budget_head_for_balance.ToString() & "' AND Sub_Head = '" & budget_sub_head_for_balance.ToString() & "' AND Approval_Status IN ('Approved') AND Bill_Amount_Submit_Status = 'Processed' "
            logincommand11.CommandText = "SELECT SUM(Bill_Amount) as Billed_Amount FROM Institute_Approval_Master_Individual WHERE Financial_Year = '" & financial_year.ToString() & "' AND Department_Id = '" & department_division_id.ToString() & "' AND   Head = '" & budget_head_for_balance.ToString() & "' AND Sub_Head = '" & budget_sub_head_for_balance.ToString() & "' AND Approval_Status IN ('Approved') AND Bill_Amount_Submit_Status = 'Processed' "
            logincommand11.Connection = con
            con.Open()
            objreader11 = logincommand11.ExecuteReader
            If objreader11.Read Then
                bill_amount = objreader11("Billed_Amount").ToString()
            End If
            con.Close()

            balance_amount = approved_amount - (estimated_amount + bill_amount)
            available_balance_amount = balance_amount
            lbl_budget_head_balance_amount.Text = "Rs." & " " & balance_amount & ".00" & ""

        End If


        'Get Head Name from the database
        Dim faculty_name As String = ""
        Dim Faculty_Salutation As String = ""

        Dim objreader12 As SqlDataReader
        Dim logincommand12 As New SqlCommand
        'logincommand12.CommandText = "SELECT Department_Head_Incharge_Name,Department_Head_Incharge_Salutation FROM Department_Division_Master WHERE Department_Id = '" & department_division_id.ToString() & "'"

        logincommand12.CommandText = "SELECT  Faculty_Salutation, Faculty_Name FROM Faculty_Master WHERE Department_Id = '" & department_division_id.ToString() & "'"
        logincommand12.Connection = con
        con.Open()
        objreader12 = logincommand12.ExecuteReader
        If objreader12.Read Then
            Faculty_Salutation = objreader12("Faculty_Salutation").ToString()
            faculty_name = objreader12("Faculty_Name").ToString()

            Session("Head_FullName") = faculty_name.ToString()

            lbl_user_name.Text = faculty_name.ToString() & ", " & Faculty_Salutation.ToString()
        End If
        con.Close()


        'Get Intitute Approval Creation Permission Details from the database

        Dim institute_approval_creation_permission_status As String = ""
        Dim objreader13 As SqlDataReader
        Dim logincommand13 As New SqlCommand
        logincommand13.CommandText = "SELECT Institute_Approval_Permission_Status FROM Institute_Approval_Permission_Details"
        logincommand13.Connection = con
        con.Open()
        objreader13 = logincommand13.ExecuteReader
        If objreader13.Read Then
            institute_approval_creation_permission_status = objreader13("Institute_Approval_Permission_Status").ToString()

            If institute_approval_creation_permission_status = "No" Then
                Response.Redirect("Institute_Approval_Creation_Permission_Denied.aspx")
            End If
        End If
        con.Close()


        If Page.IsPostBack = False Then
            FillCapctha()
        End If

    End Sub

    Private Function DisableTheButton(pge As Control, btn As Control) As String
        Dim sb As New System.Text.StringBuilder()
        sb.Append("if (typeof(Page_ClientValidate) == 'function') {")
        sb.Append("if (Page_ClientValidate() == false) { return false; }} ")
        sb.Append("if (confirm('Are you sure to proceed?') == false) { return false; } ")
        sb.Append("this.value = 'Please wait ...';")
        sb.Append("this.disabled = true;")
        sb.Append(pge.Page.GetPostBackEventReference(btn))
        sb.Append(";")
        Return sb.ToString()
    End Function


    ' --------------Function to generate only numbers--------------
    Private Function GenerateRandomCode() As String
        Dim s As String = ""
        For i As Integer = 0 To 5
            s = [String].Concat(s, Me.random.[Next](10).ToString())
        Next
        Return s
    End Function
    Sub message(ByVal temp As String)
        Dim strscript As String
        strscript = "<script>"
        strscript = strscript & "alert('" + temp + "');"
        strscript = strscript & "</script>"
        Page.RegisterStartupScript("ClientScript", strscript.ToString())
    End Sub

    Private Sub Bind_Item_Details()
        Dim reference_no As String
        reference_no = Request.QueryString("Session_Id").ToString()

        Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
        Using con As New SqlConnection(constr)
            ' Dim str1 As String = "SELECT * FROM Form_A_Item_Details_Draft WHERE Reference_No = '" & reference_no.ToString() & "' "
            Dim str1 As String = "SELECT * FROM Form_A_Equipment_Item_Details_Draft WHERE Reference_No = '" & reference_no.ToString() & "' "
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

    Private Sub Bind_Item_Details_For_Preview()
        Dim reference_no As String
        reference_no = Request.QueryString("Session_Id").ToString()

        Dim constr As String = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString
        Using con As New SqlConnection(constr)
            ' Dim str1 As String = "SELECT * FROM Form_A_Item_Details_Draft WHERE Reference_No = '" & reference_no.ToString() & "' "
            Dim str1 As String = "SELECT * FROM Form_A_Equipment_Item_Details_Draft WHERE Reference_No = '" & reference_no.ToString() & "' "
            Using cmd1 As New SqlCommand(str1)
                Using sda1 As New SqlDataAdapter()
                    cmd1.Connection = con
                    sda1.SelectCommand = cmd1
                    Using dt1 As New DataTable()
                        sda1.Fill(dt1)
                        DG2.DataSource = dt1
                        DG2.DataBind()
                    End Using
                End Using
            End Using
        End Using
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)

        Dim con As New Data.SqlClient.SqlConnection
        con.ConnectionString = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString

        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lbl_b_amount As Label = DirectCast(e.Row.FindControl("lbl_items_total_amount"), Label)
            items_total_amount += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Item_Cost"))
        End If

        If e.Row.RowType = DataControlRowType.Footer Then
            Dim lbl_b_amount As Label = DirectCast(e.Row.FindControl("lbl_items_total_amount"), Label)
            lbl_b_amount.Text = "Rs." & " " & items_total_amount.ToString() & ".00" & ""
        End If


        For Each row As GridViewRow In DG1.Rows

            Dim record_id As String = DG1.DataKeys(row.RowIndex).Values(0).ToString()
            Dim reference_no As String = DG1.DataKeys(row.RowIndex).Values(1).ToString()

            Dim lbl_item_amount As Label = CType(row.FindControl("lbl_item_amount"), Label)

            Dim objreader1 As SqlDataReader
            Dim logincommand1 As New SqlCommand
            'logincommand1.CommandText = "SELECT Item_Cost FROM Form_A_Item_Details_Draft WHERE Record_Id = '" & record_id.ToString() & "'  AND Reference_No = '" & reference_no.ToString() & "' "
            logincommand1.CommandText = "SELECT Item_Cost FROM Form_A_Equipment_Item_Details_Draft WHERE Record_Id = '" & record_id.ToString() & "'  AND Reference_No = '" & reference_no.ToString() & "' "
            logincommand1.Connection = con
            con.Open()
            objreader1 = logincommand1.ExecuteReader
            If objreader1.Read Then
                lbl_item_amount.Text = "Rs." & " " & objreader1("Item_Cost").ToString() & ".00" & ""
            End If
            con.Close()
        Next


    End Sub

    Protected Sub GrdView1_RowCreated(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.Header Then
        End If
    End Sub

    Protected Sub GridView2_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)

        Dim con As New Data.SqlClient.SqlConnection
        con.ConnectionString = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString

        If e.Row.RowType = DataControlRowType.DataRow Then
            items_total_amount_p += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Item_Cost"))
        End If

        If e.Row.RowType = DataControlRowType.Footer Then
            Dim lbl_items_total_amount_p As Label = DirectCast(e.Row.FindControl("lbl_items_total_amount_p"), Label)
            lbl_items_total_amount_p.Text = "Rs." & " " & items_total_amount_p.ToString() & ".00" & ""
        End If


        For Each row As GridViewRow In DG2.Rows

            Dim record_id As String = DG2.DataKeys(row.RowIndex).Values(0).ToString()
            Dim reference_no As String = DG2.DataKeys(row.RowIndex).Values(1).ToString()

            Dim lbl_item_amount_p As Label = CType(row.FindControl("lbl_item_amount_p"), Label)

            Dim objreader1 As SqlDataReader
            Dim logincommand1 As New SqlCommand
            logincommand1.CommandText = "SELECT Item_Cost FROM Form_A_Item_Details_Draft WHERE Record_Id = '" & record_id.ToString() & "'  AND Reference_No = '" & reference_no.ToString() & "' "
            logincommand1.Connection = con
            con.Open()
            objreader1 = logincommand1.ExecuteReader
            If objreader1.Read Then
                lbl_item_amount_p.Text = "Rs." & " " & objreader1("Item_Cost").ToString() & ".00" & ""
            End If
            con.Close()

        Next


    End Sub


    Protected Sub GrdView2_RowCreated(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.Header Then
        End If
    End Sub

    Private Sub FillCapctha()
        Try
            Dim random As New Random()
            'Dim combination As String = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
            Dim combination As String = "123456789"
            Dim captcha As New StringBuilder()
            For i As Integer = 0 To 3
                captcha.Append(combination(random.[Next](combination.Length)))
            Next
            Session("captcha") = captcha.ToString()
            imgCaptcha.ImageUrl = "Captcha/Captcha.aspx?" + DateTime.Now.Ticks.ToString()
        Catch
            Throw
        End Try
    End Sub
    Protected Sub btn_add_items_Click(sender As Object, e As EventArgs) Handles btn_add_items.Click

        Dim con As New Data.SqlClient.SqlConnection
        con.ConnectionString = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString

        Dim item_cost_amount As Int64 = Convert.ToInt32(txt_item_cost.Text)

        Dim reference_no As String = ""

        Try
            reference_no = Request.QueryString("Session_Id").ToString()
        Catch ex As Exception
            Response.Redirect("Invalid_Request.aspx")
        End Try

        If Session("Form_A_Reference_No") <> reference_no Then
            Response.Redirect("Invalid_Request.aspx")
        End If

        If txt_item_description.Text = "" Then
            message("Please Enter Item Description")
            txt_item_description.Focus()

        ElseIf txt_item_quantity.Text = "" Then
            message("Please Enter Item Quantity")
            txt_item_quantity.Focus()

        ElseIf txt_item_quantity.Text = "0" Then
            message("Quantity Should Be Greater Than Zero")
            txt_item_quantity.Text = ""
            txt_item_quantity.Focus()

        ElseIf txt_item_quantity.Text = "00" Then
            message("Quantity Should Be Greater Than Zero")
            txt_item_quantity.Text = ""
            txt_item_quantity.Focus()

        ElseIf txt_item_quantity.Text = "000" Then
            message("Quantity Should Be Greater Than Zero")
            txt_item_quantity.Text = ""
            txt_item_quantity.Focus()

        ElseIf txt_item_quantity.Text = "0000" Then
            message("Quantity Should Be Greater Than Zero")
            txt_item_quantity.Text = ""
            txt_item_quantity.Focus()

        ElseIf txt_item_quantity.Text = "00000" Then
            message("Quantity Should Be Greater Than Zero")
            txt_item_quantity.Text = ""
            txt_item_quantity.Focus()

        ElseIf txt_item_cost.Text = "" Then
            message("Please Enter Item Cost")
            txt_item_cost.Focus()

        ElseIf txt_item_cost.Text = "0" Then
            message("Amount Should Be Greater Than Zero")
            txt_item_cost.Text = ""
            txt_item_cost.Focus()

        ElseIf txt_item_cost.Text = "00" Then
            message("Amount Should Be Greater Than Zero")
            txt_item_cost.Text = ""
            txt_item_cost.Focus()

        ElseIf txt_item_cost.Text = "000" Then
            message("Amount Should Be Greater Than Zero")
            txt_item_cost.Text = ""
            txt_item_cost.Focus()

        ElseIf txt_item_cost.Text = "0000" Then
            message("Amount Should Be Greater Than Zero")
            txt_item_cost.Text = ""
            txt_item_cost.Focus()

        ElseIf txt_item_cost.Text = "00000" Then
            message("Amount Should Be Greater Than Zero")
            txt_item_cost.Text = ""
            txt_item_cost.Focus()

        ElseIf txt_item_cost.Text = "000000" Then
            message("Amount Should Be Greater Than Zero")
            txt_item_cost.Text = ""
            txt_item_cost.Focus()

        ElseIf txt_item_cost.Text = "0000000" Then
            message("Amount Should Be Greater Than Zero")
            txt_item_cost.Text = ""
            txt_item_cost.Focus()

        ElseIf txt_item_cost.Text = "00000000" Then
            message("Amount Should Be Greater Than Zero")
            txt_item_cost.Text = ""
            txt_item_cost.Focus()

        ElseIf txt_item_cost.Text = "000000000" Then
            message("Amount Should Be Greater Than Zero")
            txt_item_cost.Text = ""
            txt_item_cost.Focus()

        ElseIf txt_item_cost.Text = "0000000000" Then
            message("Amount Should Be Greater Than Zero")
            txt_item_cost.Text = ""
            txt_item_cost.Focus()


        Else

            Dim financial_year As String = Session("Form_A_Entry_Financial_Year")
            Dim department_division_id As String = Session("Department_Divison_Id").ToString()
            ' Dim budget_main_head As String = Session("Form_A_Entry_Main_Head")
            Dim budget_head As String = Session("Form_A_Entry_Head")
            Dim budget_sub_head As String = Session("Form_A_Entry_Sub_Head")

            Dim submitted_on As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

            'Delete Name of User from the database
            Dim cmd1 As New SqlCommand
            cmd1.CommandType = Data.CommandType.Text
            cmd1.CommandText = "DELETE FROM Form_A_Equipment_User_Name_Details_Draft WHERE Reference_No = '" & reference_no.ToString() & "' "
            cmd1.Connection = con
            con.Open()
            cmd1.ExecuteNonQuery()
            con.Close()


            'Insert Item details in the database
            Dim commandstr3 As String
            Dim logincommand3 As New SqlCommand
            'commandstr3 = "INSERT INTO Form_A_Item_Details_Draft(Department_Id,Reference_No,Item_Description,Item_Quantity,Item_Cost,Submitted_On) values ( '" & department_division_id.ToString() & "','" & reference_no.ToString() & "','" & txt_item_description.Text.ToString() & "','" & txt_item_quantity.Text.ToString() & "','" & txt_item_cost.Text.ToString() & "','" & submitted_on.ToString() & "')"
            commandstr3 = "INSERT INTO Form_A_Equipment_Item_Details_Draft(Department_Id,Reference_No,Item_Description,Item_Quantity,Item_Cost,Submitted_On) values ( '" & department_division_id.ToString() & "','" & reference_no.ToString() & "','" & txt_item_description.Text.ToString() & "','" & txt_item_quantity.Text.ToString() & "','" & txt_item_cost.Text.ToString() & "','" & submitted_on.ToString() & "')"
            logincommand3.CommandText = commandstr3
            logincommand3.Connection = con
            con.Open()
            logincommand3.ExecuteNonQuery()
            con.Close()


            'Delete Justification details  from the database
            Dim cmd4 As New SqlCommand
            cmd4.CommandType = Data.CommandType.Text
            'cmd4.CommandText = "DELETE FROM Form_A_Justification_Details_Draft WHERE Reference_No = '" & reference_no.ToString() & "' "
            cmd4.CommandText = "DELETE FROM Form_A_Equipment_Justification_Details_Draft WHERE Reference_No = '" & reference_no.ToString() & "' "
            cmd4.Connection = con
            con.Open()
            cmd4.ExecuteNonQuery()
            con.Close()

            'Insert Justification details in the database
            Dim commandstr5 As String
            Dim logincommand5 As New SqlCommand
            'commandstr5 = "INSERT INTO Form_A_Justification_Details_Draft(Department_Id,Reference_No,Justification_Details,Submitted_On) values ( '" & department_division_id.ToString() & "','" & reference_no.ToString() & "','" & txt_justification.Text.ToString() & "','" & submitted_on.ToString() & "')"
            commandstr5 = "INSERT INTO Form_A_Equipment_Justification_Details_Draft(Department_Id,Reference_No,Justification_Details,Submitted_On) values ( '" & department_division_id.ToString() & "','" & reference_no.ToString() & "','" & txt_justification.Text.ToString() & "','" & submitted_on.ToString() & "')"
            logincommand5.CommandText = commandstr5
            logincommand5.Connection = con
            con.Open()
            logincommand5.ExecuteNonQuery()
            con.Close()

            Response.Redirect(String.Format("Individual_Approval_PostBack_Processing_Equipment.aspx?Session_Id={0}", reference_no))
        End If


    End Sub

    Protected Sub btn_preview_Click(sender As Object, e As EventArgs) Handles btn_preview.Click

        Dim con As New Data.SqlClient.SqlConnection
        con.ConnectionString = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString


        Dim financial_year As String = Session("Form_A_Entry_Financial_Year")
        Dim department_division_id As String = Session("Department_Divison_Id").ToString()
        Dim budget_main_head As String = Session("Form_A_Entry_Main_Head")
        Dim budget_head As String = Session("Form_A_Entry_Head")
        Dim budget_sub_head As String = Session("Form_A_Entry_Sub_Head")

        Dim submitted_on As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

        Dim reference_no As String = ""

        Try
            reference_no = Request.QueryString("Session_Id").ToString()
        Catch ex As Exception
            Response.Redirect("Invalid_Request.aspx")
        End Try

        If Session("Form_A_Reference_No") <> reference_no Then
            Response.Redirect("Invalid_Request.aspx")
        End If

        'Get Items Count from the database
        Dim command1 As SqlCommand
        Dim items_record_count As Integer
        Dim str1 As String = "SELECT COUNT(*) FROM Form_A_Item_Details_Draft WHERE Reference_No = '" & reference_no.ToString() & "' "
        command1 = New SqlCommand(str1, con)
        con.Open()
        items_record_count = command1.ExecuteScalar()
        con.Close()

        'Get Form-A Justification Record Count from the database
        Dim command2 As SqlCommand
        Dim justification_record_count As Integer
        Dim str2 As String = "SELECT COUNT(*) FROM Form_A_Justification_Details_Draft WHERE Reference_No = '" & reference_no.ToString() & "' "
        command2 = New SqlCommand(str2, con)
        con.Open()
        justification_record_count = command2.ExecuteScalar()
        con.Close()

        If items_record_count = 0 Then
            message("Please Enter atleast one item for Form-A")
            txt_item_description.Focus()

        ElseIf txt_justification.Text = "" Then
            message("Please Enter Your Justification")
            txt_justification.Focus()

        Else

            'If Item details are full entered by the user then only allow to insert in the database
            If txt_item_description.Text <> "" And txt_item_quantity.Text <> "" And txt_item_cost.Text <> "" Then

                'Insert Item details in the database
                Dim commandstr3 As String
                Dim logincommand3 As New SqlCommand
                commandstr3 = "INSERT INTO Form_A_Item_Details_Draft(Department_Id,Reference_No,Item_Description,Item_Quantity,Item_Cost,Submitted_On) values ( '" & department_division_id.ToString() & "','" & reference_no.ToString() & "','" & txt_item_description.Text.ToString() & "','" & txt_item_quantity.Text.ToString() & "','" & txt_item_cost.Text.ToString() & "','" & submitted_on.ToString() & "')"
                logincommand3.CommandText = commandstr3
                logincommand3.Connection = con
                con.Open()
                logincommand3.ExecuteNonQuery()
                con.Close()

            End If


            lbl_current_date_p.Text = DateTime.Now.ToString("dd/MMM/yyyy")
            lbl_department_name_p.Text = lbl_department_name.Text
            lbl_name_of_user.Text = lbl_user_name.Text.ToString()
            lbl_budget_head_details_p.Text = lbl_budget_head_details.Text
            lbl_justification_p.Text = txt_justification.Text.ToString()


            Bind_Item_Details_For_Preview()

            Panel1.Visible = False
            Panel2.Visible = True

        End If
    End Sub


    Protected Sub btn_edit_Click(sender As Object, e As EventArgs) Handles btn_edit.Click

        Panel1.Visible = True
        Panel2.Visible = False
    End Sub

    Protected Sub btn_submit_Click(sender As Object, e As EventArgs) Handles btn_submit.Click

        Dim con As New Data.SqlClient.SqlConnection
        con.ConnectionString = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString

        'Get Client IP Address
        Dim ipaddress As String
        ipaddress = Request.ServerVariables("HTTP_X_FORWARDED_FOR")
        If ipaddress = "" Or ipaddress Is Nothing Then
            ipaddress = Request.ServerVariables("REMOTE_ADDR")
        End If
        Session("User_IP_Address") = ipaddress


        Dim financial_year As String = Session("Form_A_Entry_Financial_Year")
        Dim department_division_id As String = Session("Department_Divison_Id").ToString()
        Dim budget_main_head As String = Session("Form_A_Entry_Main_Head")
        Dim budget_head As String = Session("Form_A_Entry_Head")
        Dim budget_sub_head As String = Session("Form_A_Entry_Sub_Head")

        Dim reference_no As String = Request.QueryString("Session_Id").ToString()

        'Try
        '    reference_no = Request.QueryString("Session_Id").ToString()
        'Catch ex As Exception
        '    Response.Redirect("Invalid_Request.aspx")
        'End Try

        'If Session("Form_A_Reference_No") <> reference_no Then
        '    Response.Redirect("Invalid_Request.aspx")
        'End If

        'Get Items Count from the database
        Dim command1 As SqlCommand
        Dim items_record_count As Integer
        Dim str1 As String = "SELECT COUNT(*) FROM Form_A_Item_Details_Draft WHERE Reference_No = '" & reference_no.ToString() & "' "
        command1 = New SqlCommand(str1, con)
        con.Open()
        items_record_count = command1.ExecuteScalar()
        con.Close()

        'Get Form-A Justification Record Count from the database
        Dim command2 As SqlCommand
        Dim justification_record_count As Integer
        Dim str2 As String = "SELECT COUNT(*) FROM Form_A_Justification_Details_Draft WHERE Reference_No = '" & reference_no.ToString() & "' "
        command2 = New SqlCommand(str2, con)
        con.Open()
        justification_record_count = command2.ExecuteScalar()
        con.Close()



        If items_record_count = 0 Then
            message("Please Enter atleast one item for Form-A")
            txt_item_description.Focus()

        ElseIf justification_record_count = 0 Then
            message("Please Enter Your Justification")
            txt_justification.Focus()

        ElseIf txt_captcha_code.Text = "" Then
            message("Please Enter Security Code")
            txt_captcha_code.Focus()

        ElseIf txt_captcha_code.Text.Length < 4 Then
            message("Please Enter Four Digit Security Code")

        ElseIf Session("captcha").ToString() <> txt_captcha_code.Text Then
            message("You Have Entered Wrong Security Code")
            txt_captcha_code.Text = ""
            txt_captcha_code.Focus()

        Else

            Dim submitted_on As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

            'Get Added Items Total Amount from the database
            Dim form_A_total_amount As Int64
            Dim objreader6 As SqlDataReader
            Dim logincommand6 As New SqlCommand
            logincommand6.CommandText = "SELECT SUM(Item_Cost) as Form_A_Items_Total_Amount FROM Form_A_Item_Details_Draft WHERE Reference_No = '" & reference_no.ToString() & "' AND Department_Id = '" & department_division_id.ToString() & "' "
            logincommand6.Connection = con
            con.Open()
            objreader6 = logincommand6.ExecuteReader
            If objreader6.Read Then
                form_A_total_amount = objreader6("Form_A_Items_Total_Amount")
            End If
            con.Close()


            If form_A_total_amount > available_balance_amount Then
                message("Items total cost is more than available balance")

                lbl_error_message.Visible = True
                Dim user_message As String = "Approval total cost is more than available balance. Current available balance is Rs."
                lbl_error_message.Text = user_message & " " & available_balance_amount & ".00" & ""

            ElseIf form_A_total_amount <= available_balance_amount Then

                lbl_error_message.Visible = False

                'Insert Form-A Justification Details in the database
                Dim commandstr7 As String
                Dim logincommand7 As New SqlCommand
                commandstr7 = "INSERT INTO Form_A_Justification_Details(Department_Id,Reference_No,Justification_Details,Submitted_On) values ( '" & department_division_id.ToString() & "','" & reference_no.ToString() & "','" & txt_justification.Text.ToString() & "','" & submitted_on.ToString() & "')"
                logincommand7.CommandText = commandstr7
                logincommand7.Connection = con
                con.Open()
                logincommand7.ExecuteNonQuery()
                con.Close()

                'Insert Form-A Item Details in the database
                Dim item_description As String = ""
                Dim item_quantity As String = ""
                Dim item_cost As String = ""

                Dim objreader8 As SqlDataReader
                Dim logincommand8 As New SqlCommand
                logincommand8.CommandText = "SELECT * FROM Form_A_Item_Details_Draft WHERE Reference_No = '" & reference_no.ToString() & "' "
                logincommand8.Connection = con
                con.Open()
                objreader8 = logincommand8.ExecuteReader
                While objreader8.Read()
                    item_description = objreader8("Item_Description").ToString()
                    item_quantity = objreader8("Item_Quantity").ToString()
                    item_cost = objreader8("Item_Cost").ToString()

                    '------Insert Item Details in the database----
                    Dim commandstr9 As String
                    Dim logincommand9 As New SqlCommand
                    commandstr9 = "INSERT INTO Form_A_Item_Details(Department_Id,Reference_No,Item_Description,Item_Quantity,Item_Cost,Submitted_On) values ( '" & department_division_id.ToString() & "','" & reference_no.ToString() & "','" & item_description.ToString() & "','" & item_quantity.ToString() & "','" & item_cost.ToString() & "','" & submitted_on.ToString() & "')"
                    logincommand9.CommandText = commandstr9
                    logincommand9.Connection = con
                    logincommand9.ExecuteNonQuery()
                End While
                con.Close()


                Dim form_A_submitted_on As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

                '-------------Generate Approval Number---------

                '---Get Approval Record Count----
                Dim approval_sequence_no As Integer = 0

                Dim command11 As SqlCommand
                Dim approval_record_count As Integer
                Dim str11 As String = "SELECT COUNT(*) FROM Approval_Numbers WHERE Financial_Year = '" & financial_year.ToString() & "' "
                command11 = New SqlCommand(str11, con)
                con.Open()
                approval_record_count = command11.ExecuteScalar()
                con.Close()

                If approval_record_count > 0 Then

                    Dim objreader12 As SqlDataReader
                    Dim logincommand12 As New SqlCommand
                    logincommand12.CommandText = "SELECT MAX(Approval_Sequence_No) AS Last_Sequence_No FROM Approval_Numbers WHERE Financial_Year = '" & financial_year.ToString() & "' "
                    logincommand12.Connection = con
                    con.Open()
                    objreader12 = logincommand12.ExecuteReader()
                    If objreader12.Read Then
                        approval_sequence_no = objreader12("Last_Sequence_No").ToString()
                        approval_sequence_no = approval_sequence_no + 1
                    End If
                    con.Close()

                ElseIf approval_record_count = 0 Then
                    approval_sequence_no = 0
                End If

                '----------Approval Number----------
                Dim approval_number As String = "BITS/INST/" & "" & CStr(approval_sequence_no).ToString()

                Dim approval_no_generated_on As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")


                'Insert Approval Details in the database
                Dim approval_type As String = "Institute Approval"
                Dim commandstr13 As String
                Dim logincommand13 As New SqlCommand
                commandstr13 = "INSERT INTO Approval_Numbers(Financial_Year,Approval_Type,Approval_No,Approval_Sequence_No,Created_On) values ('" & financial_year.ToString() & "','" & approval_type.ToString() & "' ,'" & approval_number.ToString() & "','" & approval_sequence_no & "','" & approval_no_generated_on.ToString() & "')"
                logincommand13.CommandText = commandstr13
                logincommand13.Connection = con
                con.Open()
                logincommand13.ExecuteNonQuery()
                con.Close()



                '---For Dean Admin Only---
                If form_A_total_amount <= 100000 Then
                    Dim commandstr14 As String
                    Dim logincommand14 As New SqlCommand
                    commandstr14 = "INSERT INTO Institute_Approval_Master(Approval_Id,Approval_No,Financial_Year,Department_Id,Main_Head,Head,Sub_Head,Approval_User,Estimated_Amount,Estimated_Billing_Amount,Amount_Approved_By_Dean_Director,Bill_Amount,Bill_Amount_Submit_Status,Approval_Status,Submitted_On,Submitted_By,Submit_IP_Address,Dean_Approval_Status,Director_Approval_Required,Director_Approval_Status) values ('" & reference_no.ToString() & "','" & approval_number.ToString() & "','" & financial_year.ToString() & "','" & department_division_id.ToString() & "' ,'" & budget_main_head.ToString() & "','" & budget_head.ToString() & "','" & budget_sub_head.ToString() & "','" & lbl_user_name.Text.ToString() & "','" & form_A_total_amount & "','0','0','0','Pending','Pending','" & form_A_submitted_on.ToString() & "','" & Session("Head_FullName").ToString() & "','" & ipaddress.ToString() & "','Pending','No','Approval Not Required')"
                    logincommand14.CommandText = commandstr14
                    logincommand14.Connection = con
                    con.Open()
                    logincommand14.ExecuteNonQuery()
                    con.Close()

                    '---For Dean Admin and Director---
                ElseIf form_A_total_amount > 100000 Then
                    Dim commandstr14 As String
                    Dim logincommand14 As New SqlCommand
                    commandstr14 = "INSERT INTO Institute_Approval_Master(Approval_Id,Approval_No,Financial_Year,Department_Id,Main_Head,Head,Sub_Head,Approval_User,Estimated_Amount,Estimated_Billing_Amount,Amount_Approved_By_Dean_Director,Bill_Amount,Bill_Amount_Submit_Status,Approval_Status,Submitted_On,Submitted_By,Submit_IP_Address,Dean_Approval_Status,Director_Approval_Required,Director_Approval_Status) values ('" & reference_no.ToString() & "','" & approval_number.ToString() & "','" & financial_year.ToString() & "','" & department_division_id.ToString() & "' ,'" & budget_main_head.ToString() & "','" & budget_head.ToString() & "','" & budget_sub_head.ToString() & "','" & lbl_user_name.Text.ToString() & "','" & form_A_total_amount & "','0','0','0','Pending','Pending','" & form_A_submitted_on.ToString() & "','" & Session("Head_FullName").ToString() & "','" & ipaddress.ToString() & "','Pending','Yes','Pending')"
                    logincommand14.CommandText = commandstr14
                    logincommand14.Connection = con
                    con.Open()
                    logincommand14.ExecuteNonQuery()
                    con.Close()
                End If

                'Delete From Draft Tables
                Dim cmd13 As New SqlCommand
                cmd13.CommandType = Data.CommandType.Text
                cmd13.CommandText = "DELETE FROM Form_A_User_Name_Details_Draft WHERE Reference_No = '" & reference_no.ToString() & "' "
                cmd13.Connection = con
                con.Open()
                cmd13.ExecuteNonQuery()
                con.Close()

                Dim cmd14 As New SqlCommand
                cmd14.CommandType = Data.CommandType.Text
                cmd14.CommandText = "DELETE FROM Form_A_Item_Details_Draft WHERE Reference_No = '" & reference_no.ToString() & "' "
                cmd14.Connection = con
                con.Open()
                cmd14.ExecuteNonQuery()
                con.Close()

                Dim cmd15 As New SqlCommand
                cmd15.CommandType = Data.CommandType.Text
                cmd15.CommandText = "DELETE FROM Form_A_Justification_Details_Draft WHERE Reference_No = '" & reference_no.ToString() & "' "
                cmd15.Connection = con
                con.Open()
                cmd15.ExecuteNonQuery()
                con.Close()

                'Get Approval User Details from the database
                Dim department_id As String = Session("Department_Divison_Id").ToString()

                Dim dept_name As String = ""
                Dim dept_email_id As String = ""
                Dim dept_incharge_head_name As String = ""

                Dim objreader16 As SqlDataReader
                Dim logincommand16 As New SqlCommand
                logincommand16.CommandText = "SELECT Department_Name,Department_Email_Id,Department_Head_Incharge_Name FROM Department_Division_Master WHERE Department_Id = '" & department_id.ToString() & "' "
                logincommand16.Connection = con
                con.Open()
                objreader16 = logincommand16.ExecuteReader()
                If objreader16.Read Then
                    dept_name = objreader16("Department_Name").ToString()
                    dept_email_id = objreader16("Department_Email_Id").ToString()
                    dept_incharge_head_name = objreader16("Department_Head_Incharge_Name").ToString()
                End If
                con.Close()

                'Get Dean Admin Email Id for Approval Notifications
                Dim dean_admin_email_id As String = ""
                Dim objreader17 As SqlDataReader
                Dim logincommand17 As New SqlCommand
                logincommand17.CommandText = "SELECT Email_Id FROM Dean_Admin_Mail_Id_For_Approval_Notifications"
                logincommand17.Connection = con
                con.Open()
                objreader17 = logincommand17.ExecuteReader()
                If objreader17.Read Then
                    dean_admin_email_id = objreader17("Email_Id").ToString()
                End If
                con.Close()



                '----Send Mail to Dean Admin-----
                Dim mail As MailMessage = New MailMessage()
                Dim mail_to As String = String.Empty
                Dim cc As String = String.Empty
                Dim from_address As String = String.Empty
                Dim body As String = String.Empty
                Dim subject As String = String.Empty


                mail_to = dean_admin_email_id.ToString()
                from_address = "deanadmin.approvals@pilani.bits-pilani.ac.in"
                subject = "Form-A Approval Request (Approval No.:" & " " & approval_number.ToUpper.ToString() & ")" & ""

                Dim approval_status As String = "Pending"
                Session("Mail_Processed_On") = DateTime.Now.ToString("dd-MMM-yyyy hh:mm tt")

                Dim htmlBuilder As New StringBuilder
                mail.From = New MailAddress(from_address, "BITS Pilani, Pilani Campus")
                mail.To.Add(New MailAddress(mail_to))
                mail.Subject = subject

                Dim user_name As String = "Sir"

                Try
                    mail.Body = "<html><body><p><b>Dear " & user_name.ToString() & ",</b></p><br>"
                    mail.Body = mail.Body & "One of the approval request requires your approval.The approval details are as follows:<br><br>"
                    mail.Body = mail.Body & "<strong>Approval No.:&nbsp;&nbsp;</strong>" & approval_number.ToUpper.ToString() & "<br><br>"
                    mail.Body = mail.Body & "<strong>Name of the User:&nbsp;&nbsp;</strong>" & lbl_name_of_user.Text.ToString() & "<br><br>"
                    mail.Body = mail.Body & "<strong>Department/Division/Unit/Centre:&nbsp;&nbsp;</strong>" & lbl_department_name_p.Text.ToString() & "<br><br>"
                    mail.Body = mail.Body & "<strong>Approval Date :&nbsp;&nbsp;</strong>" & lbl_current_date_p.Text.ToString() & "<br><br>"
                    mail.Body = mail.Body & "<strong>Request Status:&nbsp;&nbsp;</strong>" & approval_status.ToString() & "<br><br>"
                    mail.Body = mail.Body & "<strong>Request Date & Time:&nbsp;&nbsp;</strong>" & Session("Mail_Processed_On").ToString() & "<br><br>"
                    mail.Body = mail.Body & "<strong>Please visit Budget Information System Portal to view/approve the request.</strong>"

                    mail.Body = mail.Body & "<br><br>"
                    mail.Body = mail.Body & "<strong>BITS Pilani, Pilani Campus<strong>"
                    mail.Body = mail.Body & "<p>-----------------------------------------------------------------------------------------------------------</p>"
                    mail.Body = mail.Body & "<strong><u>Note:</u>&nbsp;&nbsp;</strong>This is an autogenerated e-mail. Please do not reply to this e-mail."

                    mail.IsBodyHtml = True
                    mail.Priority = MailPriority.High
                    Dim mSmtpClient As SmtpClient = New SmtpClient()
                    mSmtpClient.Host = "smtp.gmail.com"
                    mSmtpClient.Port = 587
                    mSmtpClient.EnableSsl = True
                    mSmtpClient.UseDefaultCredentials = False
                    mSmtpClient.Credentials = New System.Net.NetworkCredential(Email_User_ID, Email_Password)
                    ServicePointManager.ServerCertificateValidationCallback = AddressOf AcceptAllCertifications
                    mSmtpClient.Send(mail)


                Catch ex As Exception
                    Response.Write(ex.ToString())
                End Try

                Response.Redirect("Institute_Approval_Confirmation.aspx")

            End If

        End If

    End Sub

    Public Function AcceptAllCertifications(ByVal sender As Object, ByVal certification As System.Security.Cryptography.X509Certificates.X509Certificate, ByVal chain As System.Security.Cryptography.X509Certificates.X509Chain, ByVal sslPolicyErrors As System.Net.Security.SslPolicyErrors) As Boolean
        Return True
    End Function
End Class
