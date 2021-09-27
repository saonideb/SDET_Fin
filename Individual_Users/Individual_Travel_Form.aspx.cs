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
using System;
using System.Configuration;

public partial class Individual_Users_Individual_Travel_Form : System.Web.UI.Page
{
    Common_Class CC = new Common_Class();
    protected decimal available_balance_amount = 0;
    public string Email_User_ID = System.Configuration.ConfigurationManager.AppSettings["EmailID"];
    public string Email_Password = System.Configuration.ConfigurationManager.AppSettings["EmailPassword"];
    public string rail_fare;
    public string Air_fare;
    public string Local_Journey;
    public string Accommodation_Rate;
    public string Accommodation_Day;
    public string Accommodation_Total_Amount;
    public string Food_Rate;
    public string Food_Day;
    public string Food_Expenses_total_Amount;
    public string Registration_fee;
    public string total_Amount;
    string current_financial_year;
    string department_division_id;
    // Dim con As New Data.SqlClient.SqlConnection
    string NameDesignation = "";

    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ToString());
    SqlCommand logincommand1;
    SqlDataReader objreader1;

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.MaintainScrollPositionOnPostBack = true;
        if (Session["Email"] == null)
        {
            Response.Redirect("../SessionExpire.aspx");
        }
        if (!Page.IsPostBack)
        {
            //Panel1.Visible = false;
            //Panel2.Visible = true;
            //Bind_data_Preview();

            string financial_year = Session["Form_A_Entry_Financial_Year"].ToString();
            string department_division_id = Session["Department_Divison_Id"].ToString();
            //' Dim budget_main_head  = Session["Form_A_Entry_Main_Head"];
            string budget_head = Session["Form_A_Entry_Head"].ToString();
            string budget_sub_head = Session["Form_A_Entry_Sub_Head"].ToString();

            string budget_main_head_for_balance = Session["Form_A_Entry_Main_Head"].ToString();
            string budget_head_for_balance = Session["Form_A_Entry_Head"].ToString();
            string budget_sub_head_for_balance = Session["Form_A_Entry_Sub_Head"].ToString();

            current_financial_year = Session["Current_Financial_Year"].ToString();
            department_division_id = Session["Department_Divison_Id"].ToString();

            SetInitialRow();
            lbl_current_date.Text = Convert.ToDateTime(System.DateTime.Now.ToShortDateString()).ToString("dd/MM/yyyy");

            txt_Accommodation_Day.Text = txt_Accommodation_Rate.Text = txt_Accommodation_Total_Amount.Text =
                txt_Air_fare.Text = txt_Food_Day.Text = txt_Food_Expenses_total_Amount.Text = txt_Food_Rate.Text = "0";

            txt_Local_Journey.Text = txt_rail_fare.Text = txt_Registration_fee.Text = txt_total_Amount.Text = "0";


            SqlCommand logincommand1 = new SqlCommand();

            logincommand1 = new SqlCommand();
            logincommand1.CommandText = "SELECT Department_Name FROM Department_Division_Master  WHERE Department_Id = '" + Session["Department_Divison_Id"].ToString() + "'";
            logincommand1.Connection = con;
            con.Open();
            objreader1 = logincommand1.ExecuteReader();
            if (objreader1.Read())
                Lbl_Name_Department_PI.Text = objreader1["Department_Name"].ToString();
            con.Close();


            //SqlDataReader objreader2;
            logincommand1 = new SqlCommand();
            logincommand1.CommandText = "SELECT FullName FROM Login_Details_Individual  WHERE Username = '" + Session["Email"].ToString() + "'";
            logincommand1.Connection = con;
            con.Open();
            objreader1 = logincommand1.ExecuteReader();
            if (objreader1.Read())
                lbl_user_name.Text = objreader1["FullName"].ToString();
            con.Close();


            logincommand1 = new SqlCommand();
            //logincommand1.CommandText = "SELECT * FROM Budget_Master_Individual WHERE Department_Id='" + department_division_id + "' and Sub_Head='Travel' and Financial_Year = '" + current_financial_year.ToString() + "' AND Email = '" + Session["Email"].ToString() + "'";
			  logincommand1.CommandText = "SELECT * FROM Budget_Master_Individual WHERE Department_Id='" + department_division_id + "' and Head = '" + budget_head_for_balance.ToString() + "'  and Sub_Head='Travel' and Financial_Year = '" + current_financial_year.ToString() + "' AND Email = '" + Session["Email"].ToString() + "' ";
            logincommand1.Connection = con;
            con.Open();
            objreader1 = logincommand1.ExecuteReader();
            if (objreader1.Read())
            {
                Lbl_Project_No.Text = objreader1["Project_Title"].ToString();
                txt_Project_Title.Text = objreader1["Head"].ToString() + "/" + objreader1["Sub_Head"].ToString();
            }
            con.Close();


            // '----------------Get Avalaible Balance-----
            SqlCommand command8;
            int institute_approval_record_count;
            // 'Dim str8 As String = "SELECT COUNT(*) FROM Institute_Approval_Master WHERE Financial_Year = '" + financial_year.ToString() + "' AND Department_Id = '" + department_division_id.ToString() + "' AND Main_Head = '" + budget_main_head_for_balance.ToString() + "' AND Head = '" + budget_head_for_balance.ToString() + "' AND Sub_Head = '" + budget_sub_head_for_balance.ToString() + "' AND Approval_Status IN ('Approved') "
            string str8 = "SELECT COUNT(*) FROM tbl_Individual_Consumables_form WHERE Financial_Year = '" + financial_year.ToString() + "' AND Department_Id = '" + department_division_id.ToString() + "' AND   Head = '" + budget_head_for_balance.ToString() + "' AND Sub_Head = '" + budget_sub_head_for_balance.ToString() + "' AND Approval_Status IN ('Approved') ";
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
                    balance_amount = Convert.ToInt32(objreader9["Approved_Amount"]);
                    available_balance_amount = balance_amount;


                    //    'lbl_budget_head_balance_amount.Text = String.Format("{0:C}", balance_amount)
                    lbl_budget_head_balance_amount.Text = "Rs." + " " + balance_amount + ".00" + "";
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
                    approved_amount = Convert.ToDecimal(objreader9["Approved_Amount"].ToString());

                con.Close();


                // 'Estimated Amount
                SqlDataReader objreader10;
                SqlCommand logincommand10 = new SqlCommand();
                // ' logincommand10.CommandText = "SELECT SUM(Estimated_Amount) as Estimated_Amount FROM Institute_Approval_Master WHERE Financial_Year = '" + financial_year.ToString() + "' AND Department_Id = '" + department_division_id.ToString() + "' AND Main_Head = '" + budget_main_head_for_balance.ToString() + "' AND Head = '" + budget_head_for_balance.ToString() + "' AND Sub_Head = '" + budget_sub_head_for_balance.ToString() + "' AND Dean_Approval_Status IN ('Approved') AND Bill_Amount_Submit_Status = 'Pending'"
                logincommand10.CommandText = "SELECT CASE WHEN SUM(cast(Estimated_Amount as decimal(10,2))) is null then '0' ELSE SUM(cast(Estimated_Amount as decimal(10,2))) END as Estimated_Amount FROM tbl_Individual_Consumables_form WHERE Financial_Year = '" + financial_year.ToString() + "' AND Department_Id = '" + department_division_id.ToString() + "' AND  Head = '" + budget_head_for_balance.ToString() + "' AND Sub_Head = '" + budget_sub_head_for_balance.ToString() + "' AND Dean_Approval_Status IN ('Approved') AND Bill_Amount_Submit_Status = 'Pending'";
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
                logincommand11.CommandText = "SELECT  CASE WHEN SUM(cast(Bill_Amount as decimal(10,2))) is null then '0' ELSE SUM(cast(Bill_Amount as decimal(10,2))) END as Billed_Amount FROM tbl_Individual_Consumables_form WHERE Financial_Year = '" + financial_year.ToString() + "' AND Department_Id = '" + department_division_id.ToString() + "' AND   Head = '" + budget_head_for_balance.ToString() + "' AND Sub_Head = '" + budget_sub_head_for_balance.ToString() + "' AND Approval_Status IN ('Approved') AND Bill_Amount_Submit_Status = 'Processed' ";
                logincommand11.Connection = con;
                con.Open();
                objreader11 = logincommand11.ExecuteReader();
                if (objreader11.Read())
                    bill_amount = Convert.ToDecimal(objreader11["Billed_Amount"].ToString());

                con.Close();

                balance_amount = approved_amount - (estimated_amount + bill_amount);
                available_balance_amount = balance_amount;
                lbl_budget_head_balance_amount.Text = "Rs." + " " + balance_amount + "";//+ ".00"

            }

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

    protected void btn_preview_Click(object sender, EventArgs e)
    {

        Panel2.Visible = true;
        Bind_data_Preview();
        Panel1.Visible = false;

    }

    private void Bind_data_Preview()
    {


        lbl_current_date_p.Text = lbl_current_date.Text;
        Lbl_Name_Department_PI_p.Text = Lbl_Name_Department_PI.Text;
        lbl_user_name_P.Text = lbl_user_name.Text;

        Lbl_Project_No_P.Text = Lbl_Project_No.Text;
        Lbl_Funding_Agency_P.Text = Lbl_Funding_Agency.Text;
        txt_Project_Title_P.Text = txt_Project_Title.Text;
        lbl_budget_head_balance_amount_P.Text = lbl_budget_head_balance_amount.Text;

        txt_StartDate_P.Text = txt_StartDate.Text;
        txt_End_Date_P.Text = txt_End_Date.Text;

        txt_Place_Visited_P.Text = txt_Place_Visited.Text;

        txt_Purpose_visit_P.Text = txt_Purpose_visit.Text;
        txt_Type_of_Leave_P.Text = txt_Type_of_Leave.Text;
        txt_Mode_Of_Travel_P.Text = txt_Mode_Of_Travel.Text;
        txt_rail_fare_P.Text = (txt_rail_fare.Text == "" ? "0" : txt_rail_fare.Text);
        txt_Air_fare_P.Text = (txt_Air_fare.Text == "" ? "0" : txt_Air_fare.Text);
        txt_Local_Journey_P.Text = (txt_Local_Journey.Text == "" ? "0" : txt_Local_Journey.Text);

        txt_Accommodation_Rate_P.Text = (txt_Accommodation_Rate.Text == "" ? "0" : txt_Accommodation_Rate.Text);
        txt_Accommodation_Day_P.Text = (txt_Accommodation_Day.Text == "" ? "0" : txt_Accommodation_Day.Text);
        txt_Accommodation_Total_Amount_P.Text = (txt_Accommodation_Total_Amount.Text == "" ? "0" : txt_Accommodation_Total_Amount.Text);
        txt_Food_Day_P.Text = (txt_Food_Day.Text == "" ? "0" : txt_Food_Day.Text);
        txt_Food_Rate_P.Text = (txt_Food_Rate.Text == "" ? "0" : txt_Food_Rate.Text);
        txt_Food_Expenses_total_Amount_P.Text = (txt_Food_Expenses_total_Amount.Text == "" ? "0" : txt_Food_Expenses_total_Amount.Text);

        txt_Registration_fee_P.Text = (txt_Registration_fee.Text == "" ? "0" : txt_Registration_fee.Text);


        int rail_fare = Convert.ToInt32(txt_rail_fare.Text == "" ? "0" : txt_rail_fare.Text);
        int Air_fare = Convert.ToInt32(txt_Air_fare.Text == "" ? "0" : txt_Air_fare.Text);
        int Local_fare = Convert.ToInt32(txt_Local_Journey.Text == "" ? "0" : txt_Local_Journey.Text);
        int Registration_fee = Convert.ToInt32(txt_Registration_fee.Text == "" ? "0" : txt_Registration_fee.Text);

        int Accommodation_Rate = Convert.ToInt32(txt_Accommodation_Rate.Text == "" ? "0" : txt_Accommodation_Rate.Text);
        int Accommodation_Day = Convert.ToInt32(txt_Accommodation_Day.Text == "" ? "0" : txt_Accommodation_Day.Text);
        int Accommodation_Total_Amount = Convert.ToInt32(txt_Accommodation_Rate.Text == "" ? "0" : txt_Accommodation_Rate.Text) * Convert.ToInt32(txt_Accommodation_Day.Text == "" ? "0" : txt_Accommodation_Day.Text);
        txt_Accommodation_Total_Amount_P.Text = txt_Accommodation_Total_Amount.Text = Accommodation_Total_Amount.ToString();

        int Food_Day = Convert.ToInt32(txt_Food_Day.Text == "" ? "0" : txt_Food_Day.Text);
        int Food_Rate = Convert.ToInt32(txt_Food_Rate.Text == "" ? "0" : txt_Food_Rate.Text);
        int Food_Expenses_total_Amount = Convert.ToInt32(txt_Food_Day.Text == "" ? "0" : txt_Food_Day.Text) * Convert.ToInt32(txt_Food_Rate.Text == "" ? "0" : txt_Food_Rate.Text);

        txt_Food_Expenses_total_Amount_P.Text = txt_Food_Expenses_total_Amount.Text = Food_Expenses_total_Amount.ToString();

        int Tot_Amount = rail_fare + Air_fare + Local_fare + Registration_fee + Accommodation_Total_Amount + Food_Expenses_total_Amount;

        txt_total_Amount_P.Text = txt_total_Amount.Text = Tot_Amount.ToString();

        justification.InnerHtml = txt_justification.Text;




        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        dt.Columns.Add(new DataColumn("Name", typeof(string)));


        for (int i = 0; i < grd_Travel_details.Rows.Count; i++)
        {
            TextBox txt_item_description = (TextBox)grd_Travel_details.Rows[i].FindControl("txt_Name_and_Designation");


            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["Name"] = txt_item_description.Text;
            dt.Rows.Add(dr);

        }

        dt.AcceptChanges();

        grd_Travel_details.Style.Add("display", "none");
        grd_Travel_details_P.Style.Add("display", "");
        ViewState["CurrentTable"] = dt;
        grd_Travel_details_P.DataSource = dt;
        grd_Travel_details_P.DataBind();
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
        dt.Columns.Add(new DataColumn("txt_Name_and_Designation", typeof(string)));

        dr = dt.NewRow();
        dr["RowNumber"] = 1;
        dr["txt_Name_and_Designation"] = string.Empty;

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
                TextBox txt_Name_and_Designation = (TextBox)grd_Travel_details.Rows[rowIndex].Cells[1].FindControl("txt_Name_and_Designation");


                drCurrentRow = dtCurrentTable.NewRow();
                drCurrentRow["RowNumber"] = i + 1;

                dtCurrentTable.Rows[i - 1]["txt_Name_and_Designation"] = txt_Name_and_Designation.Text;

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
                TextBox txt_Name_and_Designation = (TextBox)grd_Travel_details.Rows[rowIndex].Cells[1].FindControl("txt_Name_and_Designation");


                txt_Name_and_Designation.Text = dt.Rows[i]["txt_Name_and_Designation"].ToString();


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
                    TextBox txt_Name_and_Designation = (TextBox)grd_Travel_details.Rows[rowIndex].Cells[1].FindControl("txt_Name_and_Designation");


                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] = i + 1;

                    dtCurrentTable.Rows[i - 1]["txt_Name_and_Designation"] = txt_Name_and_Designation.Text;

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

    protected void btn_edit_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        dt.Columns.Add(new DataColumn("txt_Name_and_Designation", typeof(string)));

        for (int i = 0; i < grd_Travel_details_P.Rows.Count; i++)
        {
            Label txt_item_description = (Label)grd_Travel_details_P.Rows[i].FindControl("txt_item_description");


            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["txt_Name_and_Designation"] = txt_item_description.Text;



            dt.Rows.Add(dr);

            //rowIndex++;
        }

        dt.AcceptChanges();
        ViewState["CurrentTable"] = dt;

        grd_Travel_details.Style.Add("display", "");
        DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
        grd_Travel_details.DataSource = dtCurrentTable;
        grd_Travel_details.DataBind();
        // GridView1.Style.Add("display", "none");

        justification.InnerHtml = "";
        txt_justification.Style.Add("display", ""); ;

        btn_preview.Style.Add("display", "");

        Panel1.Visible = true;
        Panel2.Visible = false;
    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        if (Session["captcha"].ToString() == txt_captcha_code.Text)
        {
            decimal TotalCost = 0;
            string ApprvalNo = "";
            string Last_Sequence_No = "";
            string Director_Approval_Status = "Pending";

            if (txt_rail_fare.Text == "")
                rail_fare = "0";
            else
                rail_fare = txt_rail_fare.Text;

            if (txt_Air_fare.Text == "")
                Air_fare = "0";
            else
                Air_fare = txt_Air_fare.Text;

            if (txt_Local_Journey.Text == "")
                Local_Journey = "0";
            else
                Local_Journey = txt_Local_Journey.Text;

            if (txt_Accommodation_Rate.Text == "")
                Accommodation_Rate = "0";
            else
                Accommodation_Rate = txt_Accommodation_Rate.Text;


            if (txt_Accommodation_Day.Text == "")
                Accommodation_Day = "0";
            else
                Accommodation_Day = txt_Accommodation_Day.Text;


            if (txt_Accommodation_Total_Amount.Text == "")
                Accommodation_Total_Amount = "0";
            else
                Accommodation_Total_Amount = txt_Accommodation_Total_Amount.Text;


            if (txt_Food_Rate.Text == "")
                Food_Rate = "0";
            else
                Food_Rate = txt_Food_Rate.Text;


            if (txt_Food_Day.Text == "")
                Food_Day = "0";
            else
                Food_Day = txt_Food_Day.Text;


            if (txt_Food_Expenses_total_Amount.Text == "")
                Food_Expenses_total_Amount = "0";
            else
                Food_Expenses_total_Amount = txt_Food_Expenses_total_Amount.Text;


            if (txt_Registration_fee.Text == "")
                Registration_fee = "0";
            else
                Registration_fee = txt_Registration_fee.Text;


            if (txt_total_Amount.Text == "")
                total_Amount = "0";
            else
                total_Amount = txt_total_Amount.Text;

            string commandstr3;
            SqlCommand logincommand3 = new SqlCommand();
            //'commandstr3 = "INSERT INTO Form_A_Item_Details_Draft(Department_Id,Reference_No,Item_Description,Item_Quantity,Item_Cost,Submitted_On) values ( '" & department_division_id.ToString() & "','" & reference_no.ToString() & "','" & txt_item_description.Text.ToString() & "','" & txt_item_quantity.Text.ToString() & "','" & txt_item_cost.Text.ToString() & "','" & submitted_on.ToString() & "')"
            //commandstr3 = "INSERT INTO Individual_Travel_Form(Project_No,Name_Department_PI,Funding_Agency,Project_Title,StatrtDate,End_Date,Name_Deg_1,Name_Deg_2,Name_Deg_3,Name_Deg_4,Place_Visited,Purpose_visit,Type_of_Leave,Mode_Of_Travel,rail_fare,Air_fare,Local_Journey,Accommodation_Rate,Accommodation_Day,Accommodation_Total_Amount,Food_Rate,Food_Day,Food_Expenses_total_Amount,Registration_fee,total_Amount,Created_On,Created_By) values ( '" + Lbl_Project_No.Text + "','" + Lbl_Name_Department_PI.Text + "','" + Lbl_Funding_Agency.Text.ToString() + "','" + txt_Project_Title.Text.ToString() + "','" + txt_StartDate.Text.ToString() + "','" + txt_End_Date.Text.ToString() + "','" + txt_Name_Deg_1.Text.ToString() + "','" + txt_Name_Deg_2.Text.ToString() + "','" + txt_Name_Deg_3.Text.ToString() + "','" + txt_Name_Deg_4.Text.ToString() + "','" + txt_Place_Visited.Text.ToString() + "','" + txt_Purpose_visit.Text.ToString() + "','" + txt_Type_of_Leave.Text.ToString() + "','" + txt_Mode_Of_Travel.Text.ToString() + "','" + rail_fare.ToString() + "','" + Air_fare.ToString() + "','" + Local_Journey.ToString() + "','" + Accommodation_Rate.ToString() + "','" + Accommodation_Day.ToString() + "','" + Accommodation_Total_Amount.ToString() + "','" + Food_Rate.ToString() + "','" + Food_Day.ToString() + "','" + Food_Expenses_total_Amount.ToString() + "','" + Registration_fee.ToString() + "','" + total_Amount.ToString() + "',getdate(),'" + Session["Email"].ToString() + "')";

            decimal Balance11 = Convert.ToDecimal(lbl_budget_head_balance_amount.Text.Replace("Rs.", "").Trim() == "" ? "0" : lbl_budget_head_balance_amount.Text.Replace("Rs.", "").Trim());

            // if (TotalCost < )
            if (Convert.ToDecimal(total_Amount) <= Balance11)
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

                //if (TotalCost < 100000)
                //{
                //    Director_Approval_Status = "Approval Not Required";
                //}
                //else if (TotalCost < 100000)
                //    Director_Approval_Status = "Pending";

                if (Convert.ToDecimal(total_Amount) > 100000)
                {
                    Director_Approval_Status = "Pending";
                }
                else if (Convert.ToDecimal(total_Amount) <= 100000)
                    Director_Approval_Status = "Approval Not Required";


                //CC.Getdata("insert into tbl_Individual_Consumables_form(UserName,BudgetHead,ProjectTitle,BudgetHead_BalanceAmount,Justification,Added_By,AddedByName,Added_On,IndividualIP_Address,All_Total_Cost,Estimated_Amount, Department,Approval_No,Financial_Year,SubHead,Sequence_no,Approval_Status,Department_ID,HOD_Approval_Status,SRCD_Dean_Approval_Status,Dean_Approval_Status,Director_Approval_Status)"
                //    + " values ('" + lbl_user_name.Text.Replace("'", "''") + "','" + lbl_budget_head_details.Text.Replace("'", "''") + "','" + lbl_Project_head_Title.Text.Replace("'", "''") + "',"
                //    + " '" + lbl_budget_head_balance_amount.Text.Replace("'", "''") + "','" + txt_justification.Text.Replace("'", "''") + "','" + Request.QueryString["Session_Id"].ToString() + "',"
                //    + "'" + Session["Email"].ToString() + "',getdate(),'" + Session["User_IP_Address"].ToString() + "','" + TotalCost + "','" + TotalCost + "','" + lbl_department_name.Text + "','" + ApprvalNo + "','" + Session["Form_A_Entry_Financial_Year"].ToString() + "','" + Session["Form_A_Entry_Sub_Head"].ToString() + "','" + Last_Sequence_No + "','Pending','" + Session["Department_Divison_Id"].ToString() + "','Pending','Pending','Pending','" + Director_Approval_Status + "')");

                CC.Getdata("insert into tbl_Individual_Consumables_form(UserName,Head,ProjectTitle,BudgetHead_BalanceAmount,Justification,Added_By,AddedByName,Added_On,IndividualIP_Address,All_Total_Cost,Estimated_Amount, Department,Approval_No,Financial_Year,Sub_Head,Sequence_no,Approval_Status,Department_ID,HOD_Approval_Status,SRCD_Dean_Approval_Status,Dean_Approval_Status,Director_Approval_Status,Bill_Amount_Submit_Status,Bill_Amount)"
                 + " values ('" + lbl_user_name.Text.Replace("'", "''") + "','" + Session["Form_A_Entry_Head"].ToString().Replace("'", "''") + "','" + Lbl_Project_No_P.Text + "',"
                 + " '" + lbl_budget_head_balance_amount.Text.Replace("'", "''") + "','" + txt_justification.Text.Replace("'", "''") + "','" + Request.QueryString["Session_Id"].ToString() + "',"
                 + "'" + Session["Email"].ToString() + "',getdate(),'" + Session["User_IP_Address"].ToString() + "','" + total_Amount + "','" + total_Amount + "','" + Lbl_Name_Department_PI_p.Text + "','" + ApprvalNo + "','" + Session["Form_A_Entry_Financial_Year"].ToString() + "','" + Session["Form_A_Entry_Sub_Head"].ToString() + "','" + Last_Sequence_No + "','Pending','" + Session["Department_Divison_Id"].ToString() + "','Pending','Pending','Pending','" + Director_Approval_Status + "','Pending','0')");


                for (int x = 0; x < grd_Travel_details.Rows.Count; x++)
                {
                    TextBox txt_Name_and_Designation = (TextBox)grd_Travel_details.Rows[x].FindControl("txt_Name_and_Designation");
                    NameDesignation += txt_Name_and_Designation.Text + "~";
                }

                commandstr3 = "INSERT INTO Individual_Travel_Form(Project_No,Name_Department_PI,Funding_Agency,Project_Title,StatrtDate,End_Date,Place_Visited,"
                    + "Purpose_visit,Type_of_Leave,Mode_Of_Travel,rail_fare,Air_fare,Local_Journey,Accommodation_Rate,Accommodation_Day,Accommodation_Total_Amount,"
                    + "Food_Rate,Food_Day,Food_Expenses_total_Amount,Registration_fee,total_Amount,Created_On,Created_By,Name_Deg_1,Justification,Added_By,ApprvalNo)"
                    + " values ( '" + Lbl_Project_No.Text + "','" + Lbl_Name_Department_PI.Text + "','" + Lbl_Funding_Agency.Text.ToString() + "',"
                    + "'" + txt_Project_Title.Text.ToString() + "','" + txt_StartDate.Text.ToString() + "','" + txt_End_Date.Text.ToString() + "',"
                    + "'" + txt_Place_Visited.Text.ToString() + "','" + txt_Purpose_visit.Text.ToString() + "','" + txt_Type_of_Leave.Text.ToString() + "',"
                    + "'" + txt_Mode_Of_Travel.Text.ToString() + "','" + rail_fare.ToString() + "','" + Air_fare.ToString() + "','" + Local_Journey.ToString() + "',"
                    + "'" + Accommodation_Rate.ToString() + "','" + Accommodation_Day.ToString() + "','" + Accommodation_Total_Amount.ToString() + "',"
                    + "'" + Food_Rate.ToString() + "','" + Food_Day.ToString() + "','" + Food_Expenses_total_Amount.ToString() + "','" + Registration_fee.ToString() + "',"
                    + "'" + total_Amount.ToString() + "',getdate(),'" + Session["Email"].ToString() + "','" + NameDesignation.TrimEnd('~') + "',"
                    + "'" + txt_justification.Text.Replace("'", "''") + "','" + Request.QueryString["Session_Id"].ToString() + "','" + ApprvalNo + "')";

                logincommand3.CommandText = commandstr3;
                logincommand3.Connection = con;
                con.Open();
                logincommand3.ExecuteNonQuery();
                con.Close();


                //string message = "Data Save Successfully.";
                //string url = "Approved_Budget_Individual.aspx";
                //string script = "window.onload = function(){ alert('";
                //script += message;
                //script += "');";
                //script += "window.location = '";
                //script += url;
                //script += "'; }";
                //this.ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);

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