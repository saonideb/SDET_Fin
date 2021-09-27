using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for DBConnection
/// </summary>

public class DBConnection
{

    SqlConnection sqlConn;

    public DBConnection()
    {
        //
        // TODO: Add constructor logic here
        // 
    }
    public SqlConnection OpenConnection()
    {
        sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);

        if (sqlConn.State != ConnectionState.Open)
        {
            sqlConn.Open();
        }
        return sqlConn;
    }
    public SqlConnection CloseConnection()
    {
        if (sqlConn.State != ConnectionState.Closed)
        {
            sqlConn.Close();
        }
        return sqlConn;
    }
}

