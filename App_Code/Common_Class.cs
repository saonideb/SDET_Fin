using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Common_Class
/// </summary>
public class Common_Class : DBConnection
{
    //SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ToString());
    //SqlCommand logincommand1;
    //SqlDataReader objreader1;

    public Common_Class()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public DataSet Getdata(string query)
    {
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand(query, OpenConnection());
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        da.Fill(ds);
        CloseConnection();
        return ds;
    }
}