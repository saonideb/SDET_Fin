using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Net.Mail;
using System.IO;
using System.Web.Configuration;
using System.Collections.Specialized;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Globalization;

public partial class Individual_Users_Individual_Approval_Overhead : System.Web.UI.Page
{
    Common_Class CC = new Common_Class();
    public string Email_User_ID = System.Configuration.ConfigurationManager.AppSettings["EmailID"];
    public string Email_Password = System.Configuration.ConfigurationManager.AppSettings["EmailPassword"];
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ToString());
    SqlCommand logincommand1;
    SqlDataReader objreader1;
    protected decimal available_balance_amount = 0;
    protected decimal items_total_amount;
    protected decimal items_total_amount_p;
    private Random random = new Random();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //'Disable Submit Button
            //Me.btn_submit.Attributes.Add("onclick", DisableTheButton(Me.Page, Me.btn_submit))

            GridView1.Style.Add("display", "none");
            SetInitialRow();
            string reference_no = "";

            try
            {
                reference_no = Request.QueryString["Session_Id"].ToString();
            }
            catch (Exception ex)
            {
                Response.Redirect("Invalid_Request.aspx");
            }

            if (Session["Form_A_Reference_No"] == reference_no)
                Response.Redirect("Invalid_Request.aspx");


            string financial_year = Session["Form_A_Entry_Financial_Year"].ToString();
            string department_division_id = Session["Department_Divison_Id"].ToString();
            //' Dim budget_main_head  = Session["Form_A_Entry_Main_Head"];
            string budget_head = Session["Form_A_Entry_Head"].ToString();
            string budget_sub_head = Session["Form_A_Entry_Sub_Head"].ToString();

            string budget_main_head_for_balance = Session["Form_A_Entry_Main_Head"].ToString();
            string budget_head_for_balance = Session["Form_A_Entry_Head"].ToString();
            string budget_sub_head_for_balance = Session["Form_A_Entry_Sub_Head"].ToString();


            lbl_current_date.Text = DateTime.Now.ToString("dd/MMM/yyyy");


            // 'Get Department Name from the database
            SqlDataReader objreader1;
            logincommand1 = new SqlCommand();
            logincommand1.CommandText = "SELECT Department_Name FROM Department_Division_Master  WHERE Department_Id = '" + department_division_id.ToString() + "'";
            logincommand1.Connection = con; ;
            con.Open(); ;
            objreader1 = logincommand1.ExecuteReader();
            if (objreader1.Read())
                lbl_department_name.Text = objreader1["Department_Name"].ToString();

            con.Close(); ;

            // 'Get Budget Head Description
            string budget_head_description = "";
            SqlDataReader objreader2;
            SqlCommand logincommand2 = new SqlCommand();
            logincommand2.CommandText = "SELECT Project_Title FROM Budget_Master_Individual WHERE Financial_Year = '" + financial_year.ToString() + "' AND Email = '" + Session["Email"].ToString() + "' AND  Head = '" + budget_head.ToString() + "' AND Sub_Head = '" + budget_sub_head.ToString() + "'";
            logincommand2.Connection = con; ;
            con.Open(); ;
            objreader2 = logincommand2.ExecuteReader();
            if (objreader2.Read())
                budget_head_description = objreader2["Project_Title"].ToString();

            con.Close(); ;

            lbl_budget_head_details.Text = budget_head.ToString() + "/" + budget_sub_head.ToString();
            lbl_Project_head_Title.Text = budget_head_description.ToString();

            if (!Page.IsPostBack)
            {

                // 'Get Justification Record Count
                SqlCommand command5;
                int approval_justification_record_count;
                //' Dim str5 As String = "SELECT COUNT(*) FROM Form_A_Justification_Details_Draft WHERE Reference_No = '" + reference_no.ToString() + "' "
                string str5 = "SELECT COUNT(*) FROM Form_A_Equipment_Justification_Details_Draft WHERE Reference_No = '" + reference_no.ToString() + "' ";
                command5 = new SqlCommand(str5, con);
                con.Open(); ;
                approval_justification_record_count = Convert.ToInt32(command5.ExecuteScalar());
                con.Close(); ;

                // 'Get Justification details from the database
                if (approval_justification_record_count > 0)
                {

                    SqlDataReader objreader6;
                    SqlCommand logincommand6 = new SqlCommand();
                    // 'logincommand6.CommandText = "SELECT Justification_Details FROM Form_A_Justification_Details_Draft WHERE Reference_No = '" + reference_no.ToString() + "' "
                    logincommand6.CommandText = "SELECT Justification_Details FROM Form_A_Equipment_Justification_Details_Draft WHERE Reference_No = '" + reference_no.ToString() + "' ";
                    logincommand6.Connection = con; ;
                    con.Open(); ;
                    objreader6 = logincommand6.ExecuteReader();
                    if (objreader6.Read())
                        txt_justification.Text = objreader6["Justification_Details"].ToString();

                    con.Close(); ;
                }


                // 'Get Items Record Count
                SqlCommand command7;
                int approval_items_record_count;
                // ' Dim str7 As String = "SELECT COUNT(*) FROM Form_A_Item_Details_Draft WHERE Reference_No = '" + reference_no.ToString() + "' "
                string str7 = "SELECT COUNT(*) FROM Form_A_Equipment_Item_Details_Draft WHERE Reference_No = '" + reference_no.ToString() + "' ";
                command7 = new SqlCommand(str7, con);
                con.Open(); ;
                approval_items_record_count = Convert.ToInt32(command7.ExecuteScalar());
                con.Close(); ;

                if (approval_items_record_count > 0)
                {
                    //'Bind Data to Gridview
                    Bind_Item_Details();
                    div_item_details.Visible = true;
                }
            }


            // '----------------Get Avalaible Balance-----
            SqlCommand command8;
            int institute_approval_record_count;
            // 'Dim str8 As String = "SELECT COUNT(*) FROM Institute_Approval_Master WHERE Financial_Year = '" + financial_year.ToString() + "' AND Department_Id = '" + department_division_id.ToString() + "' AND Main_Head = '" + budget_main_head_for_balance.ToString() + "' AND Head = '" + budget_head_for_balance.ToString() + "' AND Sub_Head = '" + budget_sub_head_for_balance.ToString() + "' AND Approval_Status IN ('Approved') "
            string str8 = "SELECT COUNT(*) FROM Institute_Approval_Master_Individual WHERE Financial_Year = '" + financial_year.ToString() + "' AND Department_Id = '" + department_division_id.ToString() + "' AND   Head = '" + budget_head_for_balance.ToString() + "' AND Sub_Head = '" + budget_sub_head_for_balance.ToString() + "' AND Approval_Status IN ('Approved') ";
            command8 = new SqlCommand(str8, con);
            con.Open();
            institute_approval_record_count = Convert.ToInt32(command8.ExecuteScalar());
            con.Close();



            decimal approved_amount = 0;
            decimal spent_amount = 0;
            decimal balance_amount = 0;

            if (institute_approval_record_count == 0)
            {

                //  'If No Approval is Submitted then Get the Approved Budget Head Amount from the database
                SqlDataReader objreader9;
                SqlCommand logincommand9 = new SqlCommand();
                //'logincommand9.CommandText = "SELECT Approved_Amount FROM Budget_Master WHERE Financial_Year = '" + financial_year.ToString() + "' AND Department_Id = '" + department_division_id.ToString() + "' AND Main_Head = '" + budget_main_head_for_balance.ToString() + "' AND Head = '" + budget_head_for_balance.ToString() + "' AND Sub_Head = '" + budget_sub_head_for_balance.ToString() + "' "
                logincommand9.CommandText = "SELECT Approved_Amount FROM Budget_Master_Individual WHERE Financial_Year = '" + financial_year.ToString() + "' AND Department_Id = '" + department_division_id.ToString() + "' AND   Head = '" + budget_head_for_balance.ToString() + "' AND Sub_Head = '" + budget_sub_head_for_balance.ToString() + "' ";
                logincommand9.Connection = con;
                con.Open();
                objreader9 = logincommand9.ExecuteReader();
                if (objreader9.Read())
                {
                    balance_amount = Convert.ToDecimal(objreader9["Approved_Amount"]);
                    available_balance_amount = balance_amount;


                    //    'lbl_budget_head_balance_amount.Text = String.Format("{0:C}", balance_amount)
                    lbl_budget_head_balance_amount.Text = "Rs." + " " + balance_amount.ToString().Replace(".00", "") + ".00" + "";
                }
                con.Close();
            }
            else if (institute_approval_record_count > 0)
            {
                decimal estimated_amount = 0;
                decimal bill_amount = 0;

                SqlDataReader objreader9;
                SqlCommand logincommand9 = new SqlCommand();
                //'logincommand9.CommandText = "SELECT Approved_Amount FROM Budget_Master WHERE Financial_Year = '" + financial_year.ToString() + "' AND Department_Id = '" + department_division_id.ToString() + "' AND Main_Head = '" + budget_main_head_for_balance.ToString() + "' AND Head = '" + budget_head_for_balance.ToString() + "' AND Sub_Head = '" + budget_sub_head_for_balance.ToString() + "' "
                logincommand9.CommandText = "SELECT Approved_Amount FROM Budget_Master_Individual WHERE Financial_Year = '" + financial_year.ToString() + "' AND Department_Id = '" + department_division_id.ToString() + "' AND Head = '" + budget_head_for_balance.ToString() + "' AND Sub_Head = '" + budget_sub_head_for_balance.ToString() + "' ";
                logincommand9.Connection = con;
                con.Open();
                objreader9 = logincommand9.ExecuteReader();
                if (objreader9.Read())
                    approved_amount = Convert.ToDecimal(objreader9["Approved_Amount"]);

                con.Close();


                // 'Estimated Amount
                SqlDataReader objreader10;
                SqlCommand logincommand10 = new SqlCommand();
                // ' logincommand10.CommandText = "SELECT SUM(Estimated_Amount) as Estimated_Amount FROM Institute_Approval_Master WHERE Financial_Year = '" + financial_year.ToString() + "' AND Department_Id = '" + department_division_id.ToString() + "' AND Main_Head = '" + budget_main_head_for_balance.ToString() + "' AND Head = '" + budget_head_for_balance.ToString() + "' AND Sub_Head = '" + budget_sub_head_for_balance.ToString() + "' AND Dean_Approval_Status IN ('Approved') AND Bill_Amount_Submit_Status = 'Pending'"
                logincommand10.CommandText = "SELECT SUM(Estimated_Amount) as Estimated_Amount FROM Institute_Approval_Master_Individual WHERE Financial_Year = '" + financial_year.ToString() + "' AND Department_Id = '" + department_division_id.ToString() + "' AND  Head = '" + budget_head_for_balance.ToString() + "' AND Sub_Head = '" + budget_sub_head_for_balance.ToString() + "' AND Dean_Approval_Status IN ('Approved') AND Bill_Amount_Submit_Status = 'Pending'";
                logincommand10.Connection = con;
                con.Open();
                objreader10 = logincommand10.ExecuteReader();
                if (objreader10.Read())
                    estimated_amount = Convert.ToDecimal(objreader10["Estimated_Amount"].ToString());

                con.Close();


                //'Get Bill Amount/Actual Amount
                SqlDataReader objreader11;
                SqlCommand logincommand11 = new SqlCommand();
                //' logincommand11.CommandText = "SELECT SUM(Bill_Amount) as Billed_Amount FROM Institute_Approval_Master WHERE Financial_Year = '" + financial_year.ToString() + "' AND Department_Id = '" + department_division_id.ToString() + "' AND Main_Head = '" + budget_main_head_for_balance.ToString() + "' AND Head = '" + budget_head_for_balance.ToString() + "' AND Sub_Head = '" + budget_sub_head_for_balance.ToString() + "' AND Approval_Status IN ('Approved') AND Bill_Amount_Submit_Status = 'Processed' "
                logincommand11.CommandText = "SELECT SUM(Bill_Amount) as Billed_Amount FROM Institute_Approval_Master_Individual WHERE Financial_Year = '" + financial_year.ToString() + "' AND Department_Id = '" + department_division_id.ToString() + "' AND   Head = '" + budget_head_for_balance.ToString() + "' AND Sub_Head = '" + budget_sub_head_for_balance.ToString() + "' AND Approval_Status IN ('Approved') AND Bill_Amount_Submit_Status = 'Processed' ";
                logincommand11.Connection = con;
                con.Open();
                objreader11 = logincommand11.ExecuteReader();
                if (objreader11.Read())
                    bill_amount = Convert.ToDecimal(objreader11["Billed_Amount"].ToString());

                con.Close();

                balance_amount = approved_amount - (estimated_amount + bill_amount);
                available_balance_amount = balance_amount;
                lbl_budget_head_balance_amount.Text = "Rs." + " " + balance_amount.ToString().Replace(".00", "") + ".00" + "";

            }


            //'Get Head Name from the database
            string faculty_name = "";
            string Faculty_Salutation = "";

            SqlDataReader objreader12;
            SqlCommand logincommand12 = new SqlCommand();
            // 'logincommand12.CommandText = "SELECT Department_Head_Incharge_Name,Department_Head_Incharge_Salutation FROM Department_Division_Master WHERE Department_Id = '" + department_division_id.ToString() + "'"

            logincommand12.CommandText = "SELECT  Faculty_Salutation, Faculty_Name FROM Faculty_Master WHERE Department_Id = '" + department_division_id.ToString() + "'";
            logincommand12.Connection = con;
            con.Open();
            objreader12 = logincommand12.ExecuteReader();
            if (objreader12.Read())
            {
                Faculty_Salutation = objreader12["Faculty_Salutation"].ToString();
                faculty_name = objreader12["Faculty_Name"].ToString();

                Session["Head_FullName"] = faculty_name.ToString();

                lbl_user_name.Text = faculty_name.ToString() + ", " + Faculty_Salutation.ToString();
            }
            con.Close();


            // 'Get Intitute Approval Creation Permission Details from the database

            string institute_approval_creation_permission_status = "";
            SqlDataReader objreader13;
            SqlCommand logincommand13 = new SqlCommand();
            logincommand13.CommandText = "SELECT Institute_Approval_Permission_Status FROM Institute_Approval_Permission_Details";
            logincommand13.Connection = con;
            con.Open();
            objreader13 = logincommand13.ExecuteReader();
            if (objreader13.Read())
            {
                institute_approval_creation_permission_status = objreader13["Institute_Approval_Permission_Status"].ToString();

                if (institute_approval_creation_permission_status == "No")
                    Response.Redirect("Institute_Approval_Creation_Permission_Denied.aspx");

            }
            con.Close();


            if (Page.IsPostBack == false)
                FillCapctha();/* TODO ERROR: Skipped SkippedTokensTrivia */
        }
    }

    private void FillCapctha()
    {
        try
        {
            Random random = new Random();
            // Dim combination As String = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
            string combination = "123456789";
            StringBuilder captcha = new StringBuilder();
            for (int i = 0; i <= 3; i++)
                captcha.Append(combination[random.Next(combination.Length)]);
            Session["captcha"] = captcha.ToString();
            imgCaptcha.ImageUrl = "Captcha/Captcha.aspx?" + DateTime.Now.Ticks.ToString();
        }
        catch
        {
            throw;
        }
    }


    private void Bind_Item_Details()
    {
        string reference_no;
        reference_no = Request.QueryString["Session_Id"].ToString();

        // SqlConnection constr = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ToString()))
        {
            // Dim str1 As String = "SELECT * FROM Form_A_Item_Details_Draft WHERE Reference_No = '" + reference_no.ToString() + "' "
            string str1 = "SELECT * FROM Form_A_Equipment_Item_Details_Draft WHERE Reference_No = '" + reference_no.ToString() + "' ";
            using (SqlCommand cmd = new SqlCommand(str1))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con; ;
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


    #region Add New ROW
    protected void grd_Travel_details_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SetRowData();
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;
            int rowIndex = Convert.ToInt32(e.RowIndex);
            if (dt.Rows.Count > 1)
            {
                dt.Rows.Remove(dt.Rows[rowIndex]);
                drCurrentRow = dt.NewRow();
                ViewState["CurrentTable"] = dt;
                grd_Travel_details.DataSource = dt;
                grd_Travel_details.DataBind();

                for (int i = 0; i < grd_Travel_details.Rows.Count - 1; i++)
                {
                    grd_Travel_details.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                }
                SetPreviousData();

            }
            else
            {
                SetInitialRow();
            }
        }
    }
    protected void grd_Travel_details_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }



    protected void ButtonAdd_Click(object sender, EventArgs e)
    {
        AddNewRowToGrid();
    }

    private void SetInitialRow()
    {

        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        dt.Columns.Add(new DataColumn("txt_item_description", typeof(string)));
        dt.Columns.Add(new DataColumn("txt_item_quantity", typeof(string)));
        dt.Columns.Add(new DataColumn("txt_item_cost", typeof(string)));

        dr = dt.NewRow();
        dr["RowNumber"] = 1;
        dr["txt_item_description"] = string.Empty;
        dr["txt_item_quantity"] = string.Empty;
        dr["txt_item_cost"] = string.Empty;


        dt.Rows.Add(dr);

        //Store the DataTable in ViewState
        ViewState["CurrentTable"] = dt;

        grd_Travel_details.DataSource = dt;
        grd_Travel_details.DataBind();
    }

    private void AddNewRowToGrid()
    {
        int rowIndex = 0;

        DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
        DataRow drCurrentRow = null;
        if (dtCurrentTable.Rows.Count > 0)
        {
            for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
            {
                TextBox txt_item_description = (TextBox)grd_Travel_details.Rows[rowIndex].FindControl("txt_item_description");
                TextBox txt_item_quantity = (TextBox)grd_Travel_details.Rows[rowIndex].FindControl("txt_item_quantity");
                TextBox txt_item_cost = (TextBox)grd_Travel_details.Rows[rowIndex].FindControl("txt_item_cost");


                drCurrentRow = dtCurrentTable.NewRow();
                drCurrentRow["RowNumber"] = i + 1;

                dtCurrentTable.Rows[i - 1]["txt_item_description"] = txt_item_description.Text;
                dtCurrentTable.Rows[i - 1]["txt_item_quantity"] = txt_item_quantity.Text;
                dtCurrentTable.Rows[i - 1]["txt_item_cost"] = txt_item_cost.Text;

                rowIndex++;
            }
            dtCurrentTable.Rows.Add(drCurrentRow);
            ViewState["CurrentTable"] = dtCurrentTable;

            grd_Travel_details.DataSource = dtCurrentTable;
            grd_Travel_details.DataBind();
        }

        SetPreviousData();
    }

    private void SetPreviousData()
    {
        int rowIndex = 0;


        DataTable dt = (DataTable)ViewState["CurrentTable"];
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TextBox txt_item_description = (TextBox)grd_Travel_details.Rows[rowIndex].FindControl("txt_item_description");
                TextBox txt_item_quantity = (TextBox)grd_Travel_details.Rows[rowIndex].FindControl("txt_item_quantity");
                TextBox txt_item_cost = (TextBox)grd_Travel_details.Rows[rowIndex].FindControl("txt_item_cost");


                txt_item_description.Text = dt.Rows[i]["txt_item_description"].ToString();
                txt_item_quantity.Text = dt.Rows[i]["txt_item_quantity"].ToString();
                txt_item_cost.Text = dt.Rows[i]["txt_item_cost"].ToString();


                rowIndex++;
            }
        }
    }

    private void SetRowData()
    {
        int rowIndex = 0;

        if (ViewState["CurrentTable"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    TextBox txt_item_description = (TextBox)grd_Travel_details.Rows[rowIndex].FindControl("txt_item_description");
                    TextBox txt_item_quantity = (TextBox)grd_Travel_details.Rows[rowIndex].FindControl("txt_item_quantity");
                    TextBox txt_item_cost = (TextBox)grd_Travel_details.Rows[rowIndex].FindControl("txt_item_cost");


                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] = i + 1;

                    dtCurrentTable.Rows[i - 1]["txt_item_description"] = txt_item_description.Text;
                    dtCurrentTable.Rows[i - 1]["txt_item_quantity"] = txt_item_quantity.Text;
                    dtCurrentTable.Rows[i - 1]["txt_item_cost"] = txt_item_cost.Text;

                    rowIndex++;
                }
                //dtCurrentTable.Rows.Add(drCurrentRow);
                //ViewState["CurrentTable"] = dtCurrentTable;

                //grd_Travel_details.DataSource = dtCurrentTable;
                //grd_Travel_details.DataBind();
                ViewState["CurrentTable"] = dtCurrentTable;
            }
        }
        else
        {
            Response.Write("ViewState is null");
        }
        //SetPreviousData();
    }
    #endregion

    protected void DG1_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }
    protected void DG1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void DG2_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }
    protected void DG2_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    #region MyRegion
    //protected void btn_preview_Click(object sender, EventArgs e)
    //{
    //    Panel1.Enabled = false;
    //    Panel2.Visible = true;
    //}

    //protected void btn_edit_Click(object sender, EventArgs e)
    //{

    //    Panel1.Enabled = true;
    //    Panel2.Visible = false;
    //}


    //protected void btn_submit_Click(object sender, EventArgs e)
    //{
    //    if (Session["captcha"].ToString() == txt_captcha_code.Text)
    //    {
    //        decimal TotalCost = 0;

    //        for (int x = 0; x < grd_Travel_details.Rows.Count; x++)
    //        {
    //            TextBox txt_item_description = (TextBox)grd_Travel_details.Rows[x].FindControl("txt_item_description");
    //            TextBox txt_item_quantity = (TextBox)grd_Travel_details.Rows[x].FindControl("txt_item_quantity");
    //            TextBox txt_item_cost = (TextBox)grd_Travel_details.Rows[x].FindControl("txt_item_cost");
    //            TotalCost += Convert.ToDecimal(txt_item_cost.Text == "" ? "0" : txt_item_cost.Text);
    //        }

    //        CC.Getdata("insert into tbl_Individual_OverHead_form(UserName,BudgetHead,ProjectTitle,BudgetHead_BalanceAmount,Justification,Added_By,AddedByName,Added_On,IndividualIP_Address,All_Total_Cost,Department)"
    //            + " values ('" + lbl_user_name.Text.Replace("'", "''") + "','" + lbl_budget_head_details.Text.Replace("'", "''") + "','" + lbl_Project_head_Title.Text.Replace("'", "''") + "',"
    //            + " '" + lbl_budget_head_balance_amount.Text.Replace("'", "''") + "','" + txt_justification.Text.Replace("'", "''") + "','" + Request.QueryString["Session_Id"].ToString() + "','" + Session["Email"].ToString() + "',getdate(),'" + Session["User_IP_Address"].ToString() + "','" + TotalCost + "','" + lbl_department_name.Text + "')");

    //        for (int x = 0; x < grd_Travel_details.Rows.Count; x++)
    //        {
    //            TextBox txt_item_description = (TextBox)grd_Travel_details.Rows[x].FindControl("txt_item_description");
    //            TextBox txt_item_quantity = (TextBox)grd_Travel_details.Rows[x].FindControl("txt_item_quantity");
    //            TextBox txt_item_cost = (TextBox)grd_Travel_details.Rows[x].FindControl("txt_item_cost");


    //            // TotalCost = Convert.ToDecimal(txt_item_cost.Text == "" ? "0" : txt_item_cost.Text);

    //            CC.Getdata("insert into tbl_Individual_OverHead_form_Details(Added_By,ItemDescription,Quantity,ApproxTotalCost,All_Total_Cost)"
    //            + " values ('" + Request.QueryString["Session_Id"].ToString() + "','" + txt_item_description.Text.Replace("'", "''") + "','" + txt_item_quantity.Text.Replace("'", "''") + "','" + txt_item_cost.Text.Replace("'", "''") + "','" + TotalCost + "')");

    //        }

    //        // CC.Getdata("update tbl_Individual_Consumables_form set All_Total_Cost");


    //        string message = "Data Save Successfully.";
    //        string url = "Approved_Budget_Individual.aspx";
    //        string script = "window.onload = function(){ alert('";
    //        script += message;
    //        script += "');";
    //        script += "window.location = '";
    //        script += url;
    //        script += "'; }";
    //        this.ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
    //    }
    //    else
    //    {
    //        lbl_error_message.Text = "Wrong Captcha Code";
    //    }
    //} 
    #endregion

    protected void btn_preview_Click(object sender, EventArgs e)
    {
        int Cost = 0;
        int rowIndex = 0;
        Panel1.Enabled = false;
        Panel2.Visible = true;

        justification.InnerHtml = txt_justification.Text;
        txt_justification.Style.Add("display", "none"); ;



        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        dt.Columns.Add(new DataColumn("txt_item_description", typeof(string)));
        dt.Columns.Add(new DataColumn("txt_item_quantity", typeof(string)));
        dt.Columns.Add(new DataColumn("txt_item_cost", typeof(string)));



        //DataTable dtCurrentTable = new DataTable();
        //DataRow drCurrentRow = null;
        //if (dtCurrentTable.Rows.Count > 0)
        //{
        for (int i = 0; i < grd_Travel_details.Rows.Count; i++)
        {
            TextBox txt_item_description = (TextBox)grd_Travel_details.Rows[i].FindControl("txt_item_description");
            TextBox txt_item_quantity = (TextBox)grd_Travel_details.Rows[i].FindControl("txt_item_quantity");
            TextBox txt_item_cost = (TextBox)grd_Travel_details.Rows[i].FindControl("txt_item_cost");


            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["txt_item_description"] = txt_item_description.Text;
            dr["txt_item_quantity"] = txt_item_quantity.Text;
            dr["txt_item_cost"] = txt_item_cost.Text;


            dt.Rows.Add(dr);

            //rowIndex++;
        }

        dt.AcceptChanges();
        //ViewState["CurrentTable"] = dtCurrentTable;

        //grd_Travel_details.DataSource = dtCurrentTable;
        //grd_Travel_details.DataBind();
        // }
        //DataTable dt = (DataTable)ViewState["CurrentTable"];
        //SetPreviousData();
        grd_Travel_details.Style.Add("display", "none");
        GridView1.Style.Add("display", "");
        ViewState["CurrentTable"] = dt;
        GridView1.DataSource = dt;
        GridView1.DataBind();

        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            Label txt_item_description = (Label)GridView1.Rows[i].FindControl("txt_item_description");
            Label txt_item_quantity = (Label)GridView1.Rows[i].FindControl("txt_item_quantity");
            Label txt_item_cost = (Label)GridView1.Rows[i].FindControl("txt_item_cost");




            Cost += int.Parse(txt_item_cost.Text == "" ? "0" : txt_item_cost.Text);


            //rowIndex++;
        }

        Label lbl_footer = (Label)GridView1.FooterRow.FindControl("lbl_footer");
        lbl_footer.Text = Cost.ToString();

        btn_preview.Style.Add("display", "none");
    }

    protected void btn_edit_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        dt.Columns.Add(new DataColumn("txt_item_description", typeof(string)));
        dt.Columns.Add(new DataColumn("txt_item_quantity", typeof(string)));
        dt.Columns.Add(new DataColumn("txt_item_cost", typeof(string)));

        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            Label txt_item_description = (Label)GridView1.Rows[i].FindControl("txt_item_description");
            Label txt_item_quantity = (Label)GridView1.Rows[i].FindControl("txt_item_quantity");
            Label txt_item_cost = (Label)GridView1.Rows[i].FindControl("txt_item_cost");


            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["txt_item_description"] = txt_item_description.Text;
            dr["txt_item_quantity"] = txt_item_quantity.Text;
            dr["txt_item_cost"] = txt_item_cost.Text;


            dt.Rows.Add(dr);

            //rowIndex++;
        }

        dt.AcceptChanges();
        ViewState["CurrentTable"] = dt;

        grd_Travel_details.Style.Add("display", "");
        DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
        grd_Travel_details.DataSource = dtCurrentTable;
        grd_Travel_details.DataBind();
        GridView1.Style.Add("display", "none");

        justification.InnerHtml = "";
        txt_justification.Style.Add("display", ""); ;

        btn_preview.Style.Add("display", "");

        Panel1.Enabled = true;
        Panel2.Visible = false;
    }


    //protected void btn_submit_Click(object sender, EventArgs e)
    //{
    //    if (Session["captcha"].ToString() == txt_captcha_code.Text)
    //    {
    //        decimal TotalCost = 0;

    //        for (int x = 0; x < grd_Travel_details.Rows.Count; x++)
    //        {
    //            TextBox txt_item_description = (TextBox)grd_Travel_details.Rows[x].FindControl("txt_item_description");
    //            TextBox txt_item_quantity = (TextBox)grd_Travel_details.Rows[x].FindControl("txt_item_quantity");
    //            TextBox txt_item_cost = (TextBox)grd_Travel_details.Rows[x].FindControl("txt_item_cost");
    //            TotalCost += Convert.ToDecimal(txt_item_cost.Text == "" ? "0" : txt_item_cost.Text);
    //        }

    //        CC.Getdata("insert into tbl_Individual_Equipment_form(UserName,BudgetHead,ProjectTitle,BudgetHead_BalanceAmount,Justification,Added_By,AddedByName,Added_On,IndividualIP_Address,All_Total_Cost,Department)"
    //            + " values ('" + lbl_user_name.Text.Replace("'", "''") + "','" + lbl_budget_head_details.Text.Replace("'", "''") + "','" + lbl_Project_head_Title.Text.Replace("'", "''") + "',"
    //            + " '" + lbl_budget_head_balance_amount.Text.Replace("'", "''") + "','" + txt_justification.Text.Replace("'", "''") + "','" + Request.QueryString["Session_Id"].ToString() + "','" + Session["Email"].ToString() + "',getdate(),'" + Session["User_IP_Address"].ToString() + "','" + TotalCost + "','" + lbl_department_name.Text + "')");

    //        for (int x = 0; x < grd_Travel_details.Rows.Count; x++)
    //        {
    //            TextBox txt_item_description = (TextBox)grd_Travel_details.Rows[x].FindControl("txt_item_description");
    //            TextBox txt_item_quantity = (TextBox)grd_Travel_details.Rows[x].FindControl("txt_item_quantity");
    //            TextBox txt_item_cost = (TextBox)grd_Travel_details.Rows[x].FindControl("txt_item_cost");


    //            // TotalCost = Convert.ToDecimal(txt_item_cost.Text == "" ? "0" : txt_item_cost.Text);

    //            CC.Getdata("insert into tbl_Individual_Equipment_form_Details(Added_By,ItemDescription,Quantity,ApproxTotalCost,All_Total_Cost)"
    //            + " values ('" + Request.QueryString["Session_Id"].ToString() + "','" + txt_item_description.Text.Replace("'", "''") + "','" + txt_item_quantity.Text.Replace("'", "''") + "','" + txt_item_cost.Text.Replace("'", "''") + "','" + TotalCost + "')");

    //        }

    //        // CC.Getdata("update tbl_Individual_Consumables_form set All_Total_Cost");


    //        string message = "Data Save Successfully.";
    //        string url = "Approved_Budget_Individual.aspx";
    //        string script = "window.onload = function(){ alert('";
    //        script += message;
    //        script += "');";
    //        script += "window.location = '";
    //        script += url;
    //        script += "'; }";
    //        this.ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
    //    }
    //    else
    //    {
    //        lbl_error_message.Text = "Wrong Captcha Code";
    //    }
    //}


    protected void btn_submit_Click(object sender, EventArgs e)
    {
        if (Session["captcha"].ToString() == txt_captcha_code.Text)
        {
            decimal TotalCost = 0;
            string ApprvalNo = "";
            string Last_Sequence_No = "";
            string Director_Approval_Status = "Pending";

            for (int x = 0; x < grd_Travel_details.Rows.Count; x++)
            {
                TextBox txt_item_description = (TextBox)grd_Travel_details.Rows[x].FindControl("txt_item_description");
                TextBox txt_item_quantity = (TextBox)grd_Travel_details.Rows[x].FindControl("txt_item_quantity");
                TextBox txt_item_cost = (TextBox)grd_Travel_details.Rows[x].FindControl("txt_item_cost");
                TotalCost += Convert.ToDecimal(txt_item_cost.Text == "" ? "0" : txt_item_cost.Text);

            }

            decimal Balance11 = Convert.ToDecimal(lbl_budget_head_balance_amount.Text.Replace("Rs.", "").Trim() == "" ? "0" : lbl_budget_head_balance_amount.Text.Replace("Rs.", "").Trim());
            if (TotalCost <= Balance11)
            {
                DataSet ds21 = new DataSet();
                ds21 = CC.Getdata("select max(Sequence_no) as Last_Sequence_No from tbl_Individual_Consumables_form where Financial_Year='" + Session["Form_A_Entry_Financial_Year"].ToString() + "'");
                if (ds21 != null && ds21.Tables[0].Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(ds21.Tables[0].Rows[0]["Last_Sequence_No"].ToString()))
                    {
                        Last_Sequence_No = (int.Parse(ds21.Tables[0].Rows[0]["Last_Sequence_No"].ToString()) + 1).ToString();
                        ApprvalNo = "BITS/PRJ-IND/" + Last_Sequence_No;// (int.Parse(ds21.Tables[0].Rows[0]["Last_Sequence_No"].ToString()) + 1);
                    }
                    else
                    {
                        Last_Sequence_No = "1";
                        ApprvalNo = "BITS/PRJ-IND/" + Last_Sequence_No;// (int.Parse(ds21.Tables[0].Rows[0]["Last_Sequence_No"].ToString()) + 1);
                    }
                }

                if (TotalCost < 100000)
                {
                    Director_Approval_Status = "Approval Not Required";
                }
                else
                    Director_Approval_Status = "Pending";


                //CC.Getdata("insert into tbl_Individual_Consumables_form(UserName,BudgetHead,ProjectTitle,BudgetHead_BalanceAmount,Justification,Added_By,AddedByName,Added_On,IndividualIP_Address,All_Total_Cost,Estimated_Amount, Department,Approval_No,Financial_Year,SubHead,Sequence_no,Approval_Status,Department_ID,HOD_Approval_Status,SRCD_Dean_Approval_Status,Dean_Approval_Status,Director_Approval_Status)"
                //    + " values ('" + lbl_user_name.Text.Replace("'", "''") + "','" + lbl_budget_head_details.Text.Replace("'", "''") + "','" + lbl_Project_head_Title.Text.Replace("'", "''") + "',"
                //    + " '" + lbl_budget_head_balance_amount.Text.Replace("'", "''") + "','" + txt_justification.Text.Replace("'", "''") + "','" + Request.QueryString["Session_Id"].ToString() + "',"
                //    + "'" + Session["Email"].ToString() + "',getdate(),'" + Session["User_IP_Address"].ToString() + "','" + TotalCost + "','" + TotalCost + "','" + lbl_department_name.Text + "','" + ApprvalNo + "','" + Session["Form_A_Entry_Financial_Year"].ToString() + "','" + Session["Form_A_Entry_Sub_Head"].ToString() + "','" + Last_Sequence_No + "','Pending','" + Session["Department_Divison_Id"].ToString() + "','Pending','Pending','Pending','" + Director_Approval_Status + "')");

                CC.Getdata("insert into tbl_Individual_Consumables_form(UserName,Head,ProjectTitle,BudgetHead_BalanceAmount,Justification,Added_By,AddedByName,Added_On,IndividualIP_Address,All_Total_Cost,Estimated_Amount, Department,Approval_No,Financial_Year,Sub_Head,Sequence_no,Approval_Status,Department_ID,HOD_Approval_Status,SRCD_Dean_Approval_Status,Dean_Approval_Status,Director_Approval_Status,Bill_Amount_Submit_Status,Bill_Amount)"
                 + " values ('" + lbl_user_name.Text.Replace("'", "''") + "','" + Session["Form_A_Entry_Head"].ToString().Replace("'", "''") + "','" + lbl_Project_head_Title.Text.Replace("'", "''") + "',"
                 + " '" + lbl_budget_head_balance_amount.Text.Replace("'", "''") + "','" + txt_justification.Text.Replace("'", "''") + "','" + Request.QueryString["Session_Id"].ToString() + "',"
                 + "'" + Session["Email"].ToString() + "',getdate(),'" + Session["User_IP_Address"].ToString() + "','" + TotalCost + "','" + TotalCost + "','" + lbl_department_name.Text + "','" + ApprvalNo + "','" + Session["Form_A_Entry_Financial_Year"].ToString() + "','" + Session["Form_A_Entry_Sub_Head"].ToString() + "','" + Last_Sequence_No + "','Pending','" + Session["Department_Divison_Id"].ToString() + "','Pending','Pending','Pending','" + Director_Approval_Status + "','Pending','0')");


                for (int x = 0; x < grd_Travel_details.Rows.Count; x++)
                {
                    TextBox txt_item_description = (TextBox)grd_Travel_details.Rows[x].FindControl("txt_item_description");
                    TextBox txt_item_quantity = (TextBox)grd_Travel_details.Rows[x].FindControl("txt_item_quantity");
                    TextBox txt_item_cost = (TextBox)grd_Travel_details.Rows[x].FindControl("txt_item_cost");


                    // TotalCost = Convert.ToDecimal(txt_item_cost.Text == "" ? "0" : txt_item_cost.Text);

                    CC.Getdata("insert into tbl_Individual_Consumables_form_Details(Added_By,ItemDescription,Quantity,ApproxTotalCost,All_Total_Cost,Approval_No,Department_Id,FinancialYear)"
                    + " values ('" + Request.QueryString["Session_Id"].ToString() + "','" + txt_item_description.Text.Replace("'", "''") + "','" + txt_item_quantity.Text.Replace("'", "''") + "','" + txt_item_cost.Text.Replace("'", "''") + "','" + TotalCost + "','" + ApprvalNo + "','" + Session["Department_Divison_Id"].ToString() + "','" + Session["Form_A_Entry_Financial_Year"].ToString() + "')");

                }

                Response.Redirect("Individual_Approval_Confirmation.aspx");
            }
            else
            {
                Page.RegisterStartupScript("as", "<script>alert('Please check your balance amount');</script>");
            }
        }
        else
        {
            lbl_error_message.Visible = true;
            lbl_error_message.Text = "Wrong Captcha Code";
            //lbl_error_message.Text = "Budgeting Cost should be less thne Budget Head Balance Amount";

        }
    }
}