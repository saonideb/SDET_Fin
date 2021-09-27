using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

public partial class Individual_Users_View_Individual_Approval_Status_Step4 : System.Web.UI.Page
{
    Common_Class Gd = new Common_Class();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DataSet ds = new DataSet();
            //ds = Gd.Getdata("SELECT DISTINCT Financial_Year FROM tbl_Individual_Consumables_form ORDER BY Financial_Year DESC");
            ds = Gd.Getdata("SELECT DISTINCT Financial_Year,Financial_Year_Id FROM Financial_Year_For_Approval_Options ORDER BY Financial_Year_Id DESC");
            ddl_financial_year.DataSource = ds;
            ddl_financial_year.DataTextField = "Financial_Year";
            ddl_financial_year.DataValueField = "Financial_Year";
            ddl_financial_year.DataBind();
        }
    }

    protected void btn_sbumit_Click(object sender, EventArgs e)
    {
        var con = new System.Data.SqlClient.SqlConnection();
        //con.ConnectionString = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString;
        string department_division_email_id = Session["Email"].ToString();
        string department_division_id = Session["Department_Divison_Id"].ToString();
        string financial_year = ddl_financial_year.SelectedValue.ToString();
        Session["View_Individual_Approval_Status_Finacial_Year"] = ddl_financial_year.SelectedValue.ToString();
        Response.Redirect("View_Individual_Approval_Status_Step3.aspx");
    }
}