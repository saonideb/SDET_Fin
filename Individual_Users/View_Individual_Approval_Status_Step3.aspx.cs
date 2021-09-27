using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class Individual_Users_View_Individual_Approval_Status_Step3 : System.Web.UI.Page
{
    Common_Class Gd = new Common_Class();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Email"] == null)
            Response.Redirect("login.aspx");

        if (!Page.IsPostBack)
        {
            string department_division_email_id = Session["Email"].ToString();
            string department_division_id = Session["Department_Divison_Id"].ToString();
            string financial_year = Session["View_Individual_Approval_Status_Finacial_Year"].ToString();
            lbl_current_financial_year.Text = "Financial Year" + " " + financial_year.ToString();
            if (Page.IsPostBack == false)
            {
                // Get Department Budget Record from the database
                DataSet ds = new DataSet();
                ds = Gd.Getdata("SELECT COUNT(*) FROM tbl_Individual_Consumables_form WHERE Financial_Year = '" + financial_year.ToString() + "' AND Department_Id = '" + department_division_id.ToString() + "' and Approval_Status='Not Approved'");
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                { BindGrid(); }
                else
                {
                    Response.Redirect("No_Budget_Records_Found_Individual.aspx");
                }

            }
        }
    }

    private void BindGrid()
    {
        string current_financial_year = Session["Current_Financial_Year"].ToString();
        string department_division_id = Session["Department_Divison_Id"].ToString();

        DataSet ds = new DataSet();
        ds = Gd.Getdata("SELECT * FROM tbl_Individual_Consumables_form WHERE Financial_Year = '" + current_financial_year.ToString() + "' "
                      + " AND Department_Id = '" + department_division_id.ToString() + "' and Approval_Status='Not Approved' order by Consumable_ID desc");

        DG1.DataSource = ds;
        DG1.DataBind();
    }
    protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        var con = new System.Data.SqlClient.SqlConnection();

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[9].Text == "Pending")
            {
                e.Row.Cells[9].Font.Bold = true;
                e.Row.Cells[9].ForeColor = System.Drawing.Color.DarkRed;
            }
            else if (e.Row.Cells[9].Text == "Approved")
            {
                e.Row.Cells[9].Font.Bold = true;
                e.Row.Cells[9].ForeColor = System.Drawing.Color.Green;
            }
            else if (e.Row.Cells[9].Text == "Not Approved")
            {
                e.Row.Cells[9].Font.Bold = true;
                e.Row.Cells[9].ForeColor = System.Drawing.Color.Red;
            }

            if (e.Row.Cells[10].Text == "Pending" || e.Row.Cells[10].Text == "")
            {
                e.Row.Cells[10].Text = "Under Process";
                e.Row.Cells[10].Font.Bold = true;
                e.Row.Cells[10].ForeColor = System.Drawing.Color.Blue;
            }
            else if (e.Row.Cells[10].Text == "Approved")
            {
                e.Row.Cells[10].Font.Bold = true;
                e.Row.Cells[10].ForeColor = System.Drawing.Color.Green;
            }
            else if (e.Row.Cells[10].Text == "Not Approved")
            {
                e.Row.Cells[10].Font.Bold = true;
                e.Row.Cells[10].ForeColor = System.Drawing.Color.Red;
            }
            else if (e.Row.Cells[10].Text == "Approval Not Approved")
            {
                e.Row.Cells[10].Font.Bold = true;
                e.Row.Cells[10].ForeColor = System.Drawing.Color.Red;
            }

            if (e.Row.Cells[13].Text == "Pending" || e.Row.Cells[13].Text == "")
            {
                e.Row.Cells[13].Text = "Under Process";
                e.Row.Cells[13].Font.Bold = true;
                e.Row.Cells[13].ForeColor = System.Drawing.Color.Blue;
            }
            else if (e.Row.Cells[13].Text == "Approved")
            {
                e.Row.Cells[13].Font.Bold = true;
                e.Row.Cells[13].ForeColor = System.Drawing.Color.Green;
            }
            else if (e.Row.Cells[13].Text == "Not Approved")
            {
                e.Row.Cells[13].Font.Bold = true;
                e.Row.Cells[13].ForeColor = System.Drawing.Color.Red;
            }
            else if (e.Row.Cells[13].Text == "Approval Not Approved")
            {
                e.Row.Cells[13].Font.Bold = true;
                e.Row.Cells[13].ForeColor = System.Drawing.Color.Red;
            }


            if (e.Row.Cells[16].Text == "Pending" || e.Row.Cells[16].Text == "")
            {
                e.Row.Cells[16].Text = "Under Process";
                e.Row.Cells[16].Font.Bold = true;
                e.Row.Cells[16].ForeColor = System.Drawing.Color.Blue;
            }
            else if (e.Row.Cells[16].Text == "Approved")
            {
                e.Row.Cells[16].Font.Bold = true;
                e.Row.Cells[16].ForeColor = System.Drawing.Color.Green;
            }
            else if (e.Row.Cells[16].Text == "Not Approved")
            {
                e.Row.Cells[16].Font.Bold = true;
                e.Row.Cells[16].ForeColor = System.Drawing.Color.Red;
            }
            else if (e.Row.Cells[16].Text == "Approval Not Approved")
            {
                e.Row.Cells[16].Font.Bold = true;
                e.Row.Cells[16].ForeColor = System.Drawing.Color.Red;
            }


            if (e.Row.Cells[19].Text == "N/A")
            {
                e.Row.Cells[19].Font.Bold = true;
                e.Row.Cells[19].ForeColor = System.Drawing.Color.Green;
            }
            else if (e.Row.Cells[19].Text == "Pending")
            {
                e.Row.Cells[19].Text = "Under Process";
                e.Row.Cells[19].Font.Bold = true;
                e.Row.Cells[19].ForeColor = System.Drawing.Color.Blue;
            }
            else if (e.Row.Cells[19].Text == "Approved")
            {
                e.Row.Cells[19].Font.Bold = true;
                e.Row.Cells[19].ForeColor = System.Drawing.Color.Green;
            }
            else if (e.Row.Cells[19].Text == "Not Approved")
            {
                e.Row.Cells[19].Font.Bold = true;
                e.Row.Cells[19].ForeColor = System.Drawing.Color.Red;
            }
            else if (e.Row.Cells[19].Text == "Approval Not Required")
            {
                e.Row.Cells[19].Font.Bold = true;
                e.Row.Cells[19].ForeColor = System.Drawing.Color.DarkRed;
                e.Row.Cells[19].Text = "N/A";
                //e.Row.Cells[20].Text = "--";
            }


            if (e.Row.Cells[10].Text == "Not Approved")
            {
                e.Row.Cells[13].Text = "--";
                e.Row.Cells[16].Text = "--";
                if (e.Row.Cells[19].Text == "N/A" || e.Row.Cells[19].Text == "Approval Not Required")
                { }
                else
                    e.Row.Cells[19].Text = "--";

            }
            else if (e.Row.Cells[13].Text == "Not Approved")
            {
                e.Row.Cells[16].Text = "--";
                if (e.Row.Cells[19].Text == "N/A" || e.Row.Cells[19].Text == "Approval Not Required")
                { }
                else
                    e.Row.Cells[19].Text = "--";
            }
            else if (e.Row.Cells[16].Text == "Not Approved")
            {
                if (e.Row.Cells[19].Text == "N/A" || e.Row.Cells[19].Text == "Approval Not Required")
                { }
                else
                    e.Row.Cells[19].Text = "--";
            }

            for (int i = 0, loopTo = e.Row.Cells.Count - 1; i <= loopTo; i++)
            {
                TableCell rowcell = e.Row.Cells[i];
                rowcell.BorderColor = System.Drawing.Color.Black;
            }
        }
    }

}