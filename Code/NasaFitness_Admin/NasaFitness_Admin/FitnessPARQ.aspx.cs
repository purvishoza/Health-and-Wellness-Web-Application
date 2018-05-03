using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FitnessPARQ : System.Web.UI.Page
{
    string answers;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public string BindData1()
    {
        string htmlStr = "";
        DataTable dt3 = this.GetData("SELECT answer FROM PARQ_Answers WHERE Date = (SELECT MAX(Date) FROM PARQ_Answers WHERE employee_id = '" + Session["id_fitness"].ToString() + "')");
        

                DataTable veena = this.GetData("select Questions from PARQ_Questions");
        foreach (DataRow row in dt3.Rows)
        {
            if (row["answer"] != null)
            {
                answers = row["answer"].ToString();
            }
            else
            {

            }
        }

        var arr = answers.Split(',');
        for (int i = 0; i < arr.Length; i++)
        {
            htmlStr += "<tr><td>" + veena.Rows[i]["Questions"] + "</td><td>" + arr[i] + "</td></tr>";
        }
        return htmlStr;
    }
    private DataTable GetData(string query)
    {
        DataTable dt1 = new DataTable();
        string strConnString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(strConnString))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    sda.Fill(dt1);
                }
            }
            return dt1;
        }
    }
}