Imports System.Data
Imports System.IO
Imports System.Data.SqlClient
Partial Class Director_View_Attendance_Report
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Sdate.Attributes.Add("readonly", False)
        Edate.Attributes.Add("readonly", False)
        Session("current_date") = DateTime.Now.ToString("yyyy-MM-dd")
        If Page.IsPostBack = False Then
            Dim con As New Data.SqlClient.SqlConnection
            con.ConnectionString = ConfigurationManager.ConnectionStrings("ConnectionStringName").ConnectionString
            Dim objreader As SqlDataReader
            Dim logincommand As New SqlCommand
            con.Open()
            logincommand.CommandText = "SELECT DISTINCT FullName,psrno FROM employee_records WHERE Reporting_Incharge_PsrNo = '" & Session("user_psrno") & "' ORDER BY fullname"
            logincommand.Connection = con
            objreader = logincommand.ExecuteReader
            ddl_emp_name.DataTextField = "FullName"
            ddl_emp_name.DataValueField = "Psrno"
            ddl_emp_name.DataSource = objreader
            ddl_emp_name.DataBind()
            objreader.Close()
            con.Close()

            Dim objreader1 As SqlDataReader
            Dim logincommand1 As New SqlCommand
            con.Open()
            logincommand1.CommandText = "SELECT DISTINCT Academic_Year FROM Attendance_Records WHERE Department_Name = '" & Session("Assigned_Departement") & "' ORDER BY Academic_Year"
            logincommand1.Connection = con
            objreader1 = logincommand1.ExecuteReader
            ddl_Year.DataTextField = "Academic_Year"
            ddl_Year.DataValueField = "Academic_Year"
            ddl_Year.DataSource = objreader1
            ddl_Year.DataBind()
            objreader1.Close()
            con.Close()


            Dim objreader2 As SqlDataReader
            Dim logincommand2 As New SqlCommand
            con.Open()
            logincommand2.CommandText = "SELECT DISTINCT FullName,psrno FROM employee_records WHERE Reporting_Incharge_PsrNo = '" & Session("user_psrno") & "' ORDER BY fullname"
            logincommand2.Connection = con
            objreader2 = logincommand2.ExecuteReader
            ddl_emp_name_month_view.DataTextField = "FullName"
            ddl_emp_name_month_view.DataValueField = "Psrno"
            ddl_emp_name_month_view.DataSource = objreader2
            ddl_emp_name_month_view.DataBind()
            objreader2.Close()
            con.Close()

        End If

        If Page.IsPostBack = True Then
            attendance_all_emp_results.Visible = False
            attendance_individual_emp_results.Visible = False
        End If
    End Sub
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
    End Sub 'VerifyRenderingInServerForm 
    Private Sub ExportGridView1()
        Session("Employee_List_Generated_date") = DateTime.Now.ToString("dd-MMM-yyyy")
        Dim attachment As String
        Dim sw As New StringWriter
        Dim htw As New HtmlTextWriter(sw)
        attachment = "attachment; filename=Attendance_Report_Generated_On_" & Session("Employee_List_Generated_date") & ".xls"
        Response.ClearContent()
        Response.AddHeader("content-disposition", attachment)
        Response.ContentType = "application/ms-excel"
        dg1.RenderControl(htw)
        Response.Write(sw.ToString())
        Response.End()
    End Sub
    Private Sub ExportGridView2()
        Session("Employee_List_Generated_date") = DateTime.Now.ToString("dd-MMM-yyyy")
        Dim attachment As String
        Dim sw As New StringWriter
        Dim htw As New HtmlTextWriter(sw)
        attachment = "attachment; filename=Attendance_Report_Generated_On_" & Session("Employee_List_Generated_date") & ".xls"
        Response.ClearContent()
        Response.AddHeader("content-disposition", attachment)
        Response.ContentType = "application/ms-excel"
        Dg2.RenderControl(htw)
        Response.Write(sw.ToString())
        Response.End()
    End Sub
    Private Sub ExportGridView3()
        Session("List_Generated_date") = DateTime.Now.ToString("dd-MMM-yyyy")
        Dim attachment As String
        Dim sw As New StringWriter
        Dim htw As New HtmlTextWriter(sw)
        attachment = "attachment; filename=Attendance_Report_Generated_On_" & Session("List_Generated_date") & ".xls"
        Response.ClearContent()
        Response.AddHeader("content-disposition", attachment)
        Response.ContentType = "application/ms-excel"
        DG_Month_Wise_All_Employee.RenderControl(htw)
        Response.Write(sw.ToString())
        Response.End()
    End Sub
    Protected Sub ddl_report_type_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_report_type.SelectedIndexChanged
        If ddl_report_type.SelectedValue = "0" Then
            div_month_Wise_Categogy.Visible = False
            ddl_month_report_category.SelectedIndex = "-1"
            tr_sdate.Visible = False
            tr_edate.Visible = False
            Sdate.Text = ""
            Edate.Text = ""
            tr_btn.Visible = False
            tr_emp_name.Visible = False
            ddl_emp_name.SelectedIndex = "-1"
            month_year_div.Visible = False
            ddl_MonthName.SelectedIndex = "-1"
            ddl_Year.SelectedIndex = "-1"
            div_report_category.Visible = False
            attendance_all_emp_results.Visible = False
            attendance_individual_emp_results.Visible = False


        ElseIf ddl_report_type.SelectedValue = "1" Then
            div_report_category.Visible = True
            ddl_MonthName.SelectedIndex = "-1"
            ddl_Year.SelectedIndex = "-1"
            div_month_Wise_Categogy.Visible = False
            month_year_div.Visible = False
            ddl_report_category.SelectedIndex = "-1"
            div_Month_Wise_All_Employess_Data.Visible = False

        ElseIf ddl_report_type.SelectedValue = "2" Then
            div_report_category.Visible = False
            div_month_Wise_Categogy.Visible = True
            month_year_div.Visible = True
            tr_sdate.Visible = False
            tr_edate.Visible = False
            tr_emp_name.Visible = False
            tr_btn.Visible = False
            Sdate.Text = ""
            Edate.Text = ""
            ddl_month_report_category.SelectedIndex = "-1"
            month_year_div.Visible = False
        End If
    End Sub
    Protected Sub ddl_report_category_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_report_category.SelectedIndexChanged
        If ddl_report_category.SelectedValue = "0" Then
            tr_sdate.Visible = False
            tr_edate.Visible = False
            tr_emp_name.Visible = False
            tr_btn.Visible = False
            Sdate.Text = ""
            Edate.Text = ""
            attendance_all_emp_results.Visible = False
            attendance_individual_emp_results.Visible = False
        ElseIf ddl_report_category.SelectedValue = "1" Then
            tr_sdate.Visible = True
            tr_edate.Visible = True
            tr_emp_name.Visible = False
            tr_btn.Visible = True
            Sdate.Text = ""
            Edate.Text = ""
            ddl_emp_name.SelectedIndex = "-1"
        ElseIf ddl_report_category.SelectedValue = "2" Then
            tr_sdate.Visible = True
            tr_edate.Visible = True
            tr_emp_name.Visible = True
            tr_btn.Visible = False
            Sdate.Text = ""
            Edate.Text = ""
            ddl_emp_name.SelectedIndex = "-1"

        End If
    End Sub
    Sub message(ByVal temp As String)
        Dim strscript As String
        strscript = "<script>"
        strscript = strscript & "alert('" + temp + "');"
        strscript = strscript & "</script>"
        Page.RegisterStartupScript("ClientScript", strscript.ToString())
    End Sub
    Protected Sub btn_search_all_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_search_all.Click
        Session("SDate") = Format(CDate(Sdate.Text), "yyyy-MM-dd")
        Session("Edate") = Format(CDate(Edate.Text), "yyyy-MM-dd")

        'Start Date and End Date Validation
        Dim dtStart As Date = DateTime.Parse(Me.Sdate.Text)
        Dim dtEnd As Date = DateTime.Parse(Me.Edate.Text)
        Dim system_current_date As Date = DateTime.Parse(Date.Now.Date)

        If dtStart > system_current_date Then
            message("Please check start date")
            attendance_all_emp_results.Visible = False
        ElseIf dtEnd > system_current_date Then
            message("Please check end date.End date is greater than current date")
            attendance_all_emp_results.Visible = False
        ElseIf dtEnd < dtStart Then
            message("Please check end date")
            attendance_all_emp_results.Visible = False
        Else
            attendance_all_emp_results.Visible = True
        End If

        lbl_startdate.Text = Sdate.Text
        lbl_enddate.Text = Edate.Text
        attendance_individual_emp_results.Visible = False

        Dim con As New Data.SqlClient.SqlConnection
        con.ConnectionString = ConfigurationManager.ConnectionStrings("ConnectionStringName").ConnectionString
        con.Open()
        Dim objreader As SqlDataReader
        Dim logincommand As New SqlCommand
        logincommand.CommandText = "SELECT * FROM Attendance_Records WHERE Reporting_Incharge_PsrNo='" & Session("user_psrno") & "' AND Attendance_Date BETWEEN  '" + Sdate.Text + "' AND '" + Edate.Text + "'"
        logincommand.Connection = con
        objreader = logincommand.ExecuteReader
        If objreader.Read Then
            btn_Export_Excel.Visible = True
        Else
            btn_Export_Excel.Visible = False
        End If
    End Sub
    Protected Sub btn_single_emp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_single_emp.Click
        Session("Start_date") = Format(CDate(Sdate.Text), "yyyy-MM-dd")
        Session("End_date") = Format(CDate(Edate.Text), "yyyy-MM-dd")


        'Start Date and End Date Validation
        Dim dtStart As Date = DateTime.Parse(Me.Sdate.Text)
        Dim dtEnd As Date = DateTime.Parse(Me.Edate.Text)
        Dim system_current_date As Date = DateTime.Parse(Date.Now.Date)

        If dtStart > system_current_date Then
            message("Please check start date")
            attendance_individual_emp_results.Visible = False
        ElseIf dtEnd > system_current_date Then
            message("Please check end date.End date is greater than current date")
            attendance_individual_emp_results.Visible = False
        ElseIf dtEnd < dtStart Then
            message("Please check end date")
            attendance_individual_emp_results.Visible = False
        Else
            attendance_individual_emp_results.Visible = True
        End If

        Dim emp_psrno As String = ddl_emp_name.SelectedItem.Value
        Session("Employee_Psrno") = emp_psrno
        lbl_start_date.Text = Sdate.Text
        lbl_end_date.Text = Edate.Text
        'attendance_individual_emp_results.Visible = True
        attendance_all_emp_results.Visible = False

        Session("Todays_attendance_date") = DateTime.Now.ToString("yyyy-MM-dd")
        Dim con As New Data.SqlClient.SqlConnection
        con.ConnectionString = ConfigurationManager.ConnectionStrings("ConnectionStringName").ConnectionString
        con.Open()
        Dim objreader As SqlDataReader
        Dim logincommand As New SqlCommand
        logincommand.CommandText = "SELECT *  FROM Attendance_Records WHERE PSRNo='" & Session("Employee_Psrno") & "' AND Attendance_Date BETWEEN  '" + Session("Start_date") + "' AND '" + Session("End_date") + "'"
        logincommand.Connection = con
        objreader = logincommand.ExecuteReader
        If objreader.Read Then
            btn_export_single_data.Visible = True
        Else
            btn_export_single_data.Visible = False
        End If
    End Sub
    Protected Sub btn_Export_Excel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Export_Excel.Click
        ExportGridView1()
    End Sub
    Protected Sub btn_export_single_data_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_export_single_data.Click
        ExportGridView2()
    End Sub
    Protected Sub ddl_month_report_category_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_month_report_category.SelectedIndexChanged
        If ddl_month_report_category.SelectedValue = "0" Then
            'Show all Employees data
            div_Month_Wise_All_Employess_Data.Visible = False
            month_year_div.Visible = False
            div_month_view_emp_name.Visible = False
        ElseIf ddl_month_report_category.SelectedValue = "1" Then
            month_year_div.Visible = True
            ddl_MonthName.SelectedIndex = "-1"
            ddl_Year.SelectedIndex = "-1"
            div_month_view_emp_name.Visible = False
            btn_submit_month_data.Visible = True
            btn_submit_month_data_all_emp.Visible = False
        ElseIf ddl_month_report_category.SelectedValue = "2" Then
            btn_submit_month_data.Visible = False
            month_year_div.Visible = True
            ddl_MonthName.SelectedIndex = "-1"
            ddl_Year.SelectedIndex = "-1"
            div_month_view_emp_name.Visible = True
            btn_submit_month_data_all_emp.Visible = True
        End If
    End Sub
    Protected Sub btn_submit_month_data_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_submit_month_data.Click
        div_Month_Wise_All_Employess_Data.Visible = True
        lbl_month_wise_month_name.Text = ddl_MonthName.SelectedItem.Text
        lbl_month_wise_year_name.Text = ddl_Year.SelectedItem.Text
        Dim con As New Data.SqlClient.SqlConnection
        con.ConnectionString = ConfigurationManager.ConnectionStrings("ConnectionStringName").ConnectionString
        con.Open()
        Dim cmd As New SqlCommand
        Dim query As String = "SELECT * FROM attendance_records WHERE Attendance_Month = '" & ddl_MonthName.SelectedItem.Text & "' AND Academic_Year = '" & ddl_Year.SelectedItem.Text & "' AND Department_Name='" & Session("Assigned_Departement") & "'  ORDER BY Attendance_Date,PsrNo"
        Dim adap As New SqlDataAdapter(query, con)
        Dim dt As New DataTable()
        adap.Fill(dt)
        DG_Month_Wise_All_Employee.DataSource = dt
        DG_Month_Wise_All_Employee.DataBind()

        'Check record is available in database
        Dim objreader As SqlDataReader
        Dim logincommand As New SqlCommand
        logincommand.CommandText = "SELECT * FROM attendance_records WHERE Attendance_Month = '" & ddl_MonthName.SelectedItem.Text & "' AND Academic_Year = '" & ddl_Year.SelectedItem.Text & "' AND Department_Name='" & Session("Assigned_Departement") & "'"
        logincommand.Connection = con
        objreader = logincommand.ExecuteReader
        If objreader.Read Then
            btn_month_wise_all_emp_report.Visible = True
        Else
            btn_month_wise_all_emp_report.Visible = False
        End If
    End Sub
    Protected Sub btn_month_wise_all_emp_report_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_month_wise_all_emp_report.Click
        ExportGridView3()
    End Sub
    Protected Sub btn_submit_month_data_all_emp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_submit_month_data_all_emp.Click
        div_Month_Wise_All_Employess_Data.Visible = True
        lbl_month_wise_month_name.Text = ddl_MonthName.SelectedItem.Text
        lbl_month_wise_year_name.Text = ddl_Year.SelectedItem.Text
        Dim con As New Data.SqlClient.SqlConnection
        con.ConnectionString = ConfigurationManager.ConnectionStrings("ConnectionStringName").ConnectionString
        con.Open()
        Dim cmd As New SqlCommand
        Dim query As String = "SELECT * FROM attendance_records WHERE Psrno= '" & ddl_emp_name_month_view.SelectedItem.Value & "' AND Attendance_Month = '" & ddl_MonthName.SelectedItem.Text & "' AND Academic_Year = '" & ddl_Year.SelectedItem.Text & "' AND Department_Name='" & Session("Assigned_Departement") & "'  ORDER BY Attendance_Date,PsrNo"
        Dim adap As New SqlDataAdapter(query, con)
        Dim dt As New DataTable()
        adap.Fill(dt)
        DG_Month_Wise_All_Employee.DataSource = dt
        DG_Month_Wise_All_Employee.DataBind()

        'Check record is available in database
        Dim objreader As SqlDataReader
        Dim logincommand As New SqlCommand
        logincommand.CommandText = "SELECT * FROM attendance_records WHERE Psrno= '" & ddl_emp_name_month_view.SelectedItem.Value & "' AND Attendance_Month = '" & ddl_MonthName.SelectedItem.Text & "' AND Academic_Year = '" & ddl_Year.SelectedItem.Text & "' AND Department_Name='" & Session("Assigned_Departement") & "'"
        logincommand.Connection = con
        objreader = logincommand.ExecuteReader
        If objreader.Read Then
            btn_month_wise_all_emp_report.Visible = True
        Else
            btn_month_wise_all_emp_report.Visible = False
        End If
    End Sub
End Class
