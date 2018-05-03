using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;
using System.Collections;

public partial class FollowUpLectures : System.Web.UI.Page
{
    string empid = "";
    DataTable dtab = new DataTable();
    DataTable dtab1 = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
       empid = Session["empid"].ToString();
        if (!IsPostBack)
        {
            viewcategory.Items.Clear();
            viewcategory.Items.Add("select category");
            DataTable dt1 = this.GetData("select DISTINCT ProblemName from HealthLogging WHERE Employee_Id='"+empid+"'");
            foreach (DataRow row in dt1.Rows)
            {
                if (row["ProblemName"] != null)
                {
                    viewcategory.Items.Add(row["ProblemName"].ToString());
                }
               
            }

        }
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
    protected void viewcategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        ArrayList al = new ArrayList();
        ArrayList arrfil = new ArrayList();
        string val = "";
        string fi = "";
        string selectedtype1 = viewcategory.SelectedItem.Text.ToString();
        string strConnString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(strConnString))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select SuggestedVideos,SuggestedClasses from HealthLogging where ProblemName = '" + selectedtype1 + "' and Employee_Id='" + empid + "'";
                cmd.Connection = con;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                        val += reader["SuggestedVideos"].ToString();
                    fi += reader["SuggestedClasses"].ToString();
                    
                }
                con.Close();
            }
        }
        string[] arr = val.Split(';');
        string[] arv = fi.Split(',');
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != "")
            {
                al.Add(arr[i]);
            }

        }
        for (int i = 0; i < arv.Length-1; i++)
        {
            if (arv[i] != "")
            {
                arrfil.Add(arv[i]);
            }

        }
        dtab.Clear();
        dtab1.Clear();
        if (dtab.Columns.Count > 0)
        {
            for (int i = dtab.Columns.Count - 1; i >= 0; i--)
            {
                dtab.Columns.RemoveAt(i);
            }
            dtab.Columns.Add("Id");
            dtab.Columns.Add("Presentation");

        }
        else
        {
            dtab.Columns.Add("Id");
            dtab.Columns.Add("Presentation");
        }

        if (dtab1.Columns.Count > 0)
        {
            for (int i = dtab1.Columns.Count - 1; i >= 0; i--)
            {
                dtab1.Columns.RemoveAt(i);
            }
            dtab1.Columns.Add("Presentation");

        }
        else
        {
            dtab1.Columns.Add("Presentation");
        }
        for (int i = 0; i < al.Count; i++)
        {
            DataRow drow = dtab.NewRow();
            drow["Id"] = al[i];
            
            dtab.Rows.Add(drow);

        }
        for(int i=0;i<arrfil.Count;i++)
        {
            DataRow r = dtab1.NewRow();
            r["Presentation"] = "~/pdffiles/" + arrfil[i];
            dtab1.Rows.Add(r);
        }
        DataList2.DataSource = dtab1;
        DataList2.DataBind();
        DataList1.DataSource = dtab;
        DataList1.DataBind();

    }
}
