using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Individual_Users_Institue_Approval_All : System.Web.UI.Page
{
    int budget_record_count;
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

        string department_division_email_id = Session["Email"].ToString();
        string department_division_id = Session["Department_Divison_Id"].ToString();
        string current_financial_year = "";

        // Get Current Financial Year from the database
        SqlDataReader objreader1;
        SqlCommand logincommand1 = new SqlCommand();
        logincommand1.CommandText = "SELECT Current_Financial_Year FROM Current_Financial_Year";
        logincommand1.Connection = con;
        con.Open();
        objreader1 = logincommand1.ExecuteReader();
        if (objreader1.Read())
        {
            Session["Current_Financial_Year"] = objreader1["Current_Financial_Year"].ToString();
            current_financial_year = objreader1["Current_Financial_Year"].ToString();
        }
        con.Close();


        lbl_current_financial_year.Text = "Financial Year" + " " + Session["Current_Financial_Year"];

        // Get Department Budget Record from the database
        SqlDataReader objreader31;
        //SqlCommand command2;

        //// Dim str2 As String = "SELECT COUNT(*) FROM Budget_Master_Individual WHERE Financial_Year = '" & current_financial_year.ToString() & "' AND Department_Id = '" & department_division_id.ToString() & "'"
        ////string str2 = "SELECT COUNT(*) FROM Budget_Master_Individual WHERE Financial_Year = '" + current_financial_year.ToString() + "' AND Email = '" + Session["Email"].ToString() + "'";
        //command2 = new SqlCommand(str2, con);
        //con.Open();
        //budget_record_count = command2.;
        ////con.Close();


        SqlCommand command2 = new SqlCommand();
        command2.CommandText = "SELECT Distinct COUNT(*) as y1 FROM Budget_Master_Individual WHERE Financial_Year = '" + current_financial_year.ToString() + "' AND Email = '" + Session["Email"].ToString() + "'";
        command2.Connection = con;
        con.Open();
        objreader31 = command2.ExecuteReader();
        if (objreader31.Read())
            budget_record_count = int.Parse(objreader31["y1"].ToString());

        if (budget_record_count == 0)
            //Response.Redirect("No_Budget_Records_Found.aspx");
            Response.Redirect("No_Budget_Records_Found_Individual.aspx");
        else
            BindGrid();
        con.Close();

        // Get Department Name from the database
        SqlDataReader objreader3;
        SqlCommand logincommand3 = new SqlCommand();
        logincommand3.CommandText = "SELECT Department_Name FROM Department_Division_Master  WHERE Department_Id = '" + department_division_id.ToString() + "'";
        logincommand3.Connection = con;
        con.Open();
        objreader3 = logincommand3.ExecuteReader();
        if (objreader3.Read())
            lbl_department_name.Text = objreader3["Department_Name"].ToString();

        // Get Faculty Name from the database
        SqlDataReader objreader4;
        SqlCommand logincommand4 = new SqlCommand();
        logincommand4.CommandText = "SELECT FullName FROM Login_Details_Individual WHERE  username = '" + Session["Email"].ToString() + "'";
        logincommand4.Connection = con;

        objreader4 = logincommand4.ExecuteReader();
        if (objreader4.Read())
            lbl_faculty_name.Text = objreader4["FullName"].ToString();
        con.Close();
    }

    private void BindGrid()
    {
        string current_financial_year = Session["Current_Financial_Year"].ToString();
        string department_division_id = Session["Department_Divison_Id"].ToString();


        string constr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            // Dim str1 As String = "SELECT * FROM Budget_Master WHERE  Financial_Year = '" & current_financial_year.ToString() & "' AND Department_Id = '" & department_division_id.ToString() & "'"
            string str1 = "SELECT Distinct Financial_Year, Head,Project_Title,Department_Id FROM Budget_Master_Individual WHERE  Financial_Year = '" + current_financial_year.ToString() + "' AND Email = '" + Session["Email"].ToString() + "'";
            using (SqlCommand cmd = new SqlCommand(str1))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        DG1.DataSource = dt;
                        DG1.DataBind();
                    }
                }
            }
        }
    }


    protected void DG1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
}