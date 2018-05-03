using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections;
using System.Data;



public partial class AfterQuestionnaire : System.Web.UI.Page
    {
    ArrayList al = new ArrayList();
    ArrayList anslist = new ArrayList();
    DataSet ds = new DataSet();
    string week1 = "";
    DataTable dtab = new DataTable();
    string empid = "";
    protected void Page_Load(object sender, EventArgs e)
        {
        empid = Session["empid"].ToString();
        if (!Page.IsPostBack)
        {
            bindData();
        }
    }
    protected void save_Click(object sender, EventArgs e)
    {
        string ans = "";
        string month = (string)Session["month"];
        string weekly = (string)Session["week"];
        week1 = month + weekly;
        foreach (GridViewRow row in dgrid.Rows)
        {
            RadioButtonList rb = (RadioButtonList)row.FindControl("ansid");
            if (rb.SelectedItem != null)
            {
                ans += rb.SelectedValue;
                ans += "#";
            }
            else
            {
                ans += "-";
                ans += "#";
            }
        }
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cs))
        {
            string query = "SELECT * from ExamResults where Employee_id='" + empid + "' and Week_id='"+ week1+"'";
            SqlCommand cmd1 = new SqlCommand(query, con);
            DateTime dt = new DateTime();
            con.Open();
            int a = cmd1.ExecuteNonQuery();
            if (a<0)
            {
                con.Close();
                dt = DateTime.Now;
                //string query1 = "UPDATE Presentation_QuestionsAnswers set BeforeReading='" + ans + "', BeforeTimeStamp=" + dt + " where Week_id='" + week1 + "', Employee_id='"+empid+"'";
                SqlCommand cmd2 = new SqlCommand();
                cmd2.CommandText = "UPDATE ExamResults set AfterReading= @breading, AfterTimeStamp= @btime where Week_id=@wid and Employee_id=@empid";
                cmd2.Parameters.Add("@breading", SqlDbType.NVarChar).Value = ans;
                cmd2.Parameters.Add("@btime", SqlDbType.DateTime).Value = dt;
                cmd2.Parameters.Add("@wid", SqlDbType.NVarChar).Value = week1;
                cmd2.Parameters.Add("@empid", SqlDbType.NVarChar).Value = empid;
                cmd2.CommandType = CommandType.Text;
                cmd2.Connection = con;
                con.Open();
               int k = cmd2.ExecuteNonQuery();
                
                con.Close();
                if (k>0)
                {
                    Response.Redirect("viewResults.aspx");
                }
            }
            //SqlCommand cm = new SqlCommand();
            //cm.CommandText = "insert into ExamResults(Employee_id, Week_id,BeforeReading,BeforeTimeStamp) values (@empid,@weekid,@before,@beforeTs)";
            //cm.Parameters.Add("@empid", SqlDbType.NVarChar).Value = empid;
            //cm.Parameters.Add("@weekid", SqlDbType.NVarChar).Value = week1;
            //cm.Parameters.Add("@before", SqlDbType.NVarChar).Value = ans;
           
            //dt = DateTime.Now;
            //cm.Parameters.Add("@beforeTs", SqlDbType.DateTime).Value = dt;
            //cm.CommandType = CommandType.Text;
            //cm.Connection = con;
            //con.Open();
            //int a1 = cm.ExecuteNonQuery();
            //con.Close();
            //if (a1 > 0)
            //{
            //    Response.Redirect("View_Presentation.aspx");
            //}
        }



    }
    private void bindData()
    {
        string month = (string)Session["month"];
        string weekly = (string)Session["week"];
        week1 = month + weekly;
        string q = "";
        string a = "";
        string query = "SELECT Questions,Answers from Presentation_QuestionsAnswers where Id=" + week1;
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd1 = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = cmd1.ExecuteReader();

            while (reader.Read())
            {
                q = reader["Questions"].ToString();
                a = reader["Answers"].ToString();

            }
            con.Close();
        }
        string[] quesArray = q.Split('#');
        string[] ansArray = a.Split(',');
        for (int i = 0; i < quesArray.Length; i++)
        {
            if (quesArray[i] != "")
            {
                al.Add(quesArray[i]);
            }

        }
        for (int i = 0; i < ansArray.Length; i++)
        {
            if (ansArray[i] == "T" || ansArray[i] == "True")
            {
                anslist.Add("True");
            }
            else if (ansArray[i] == "F" || ansArray[i] == "False")
            {
                anslist.Add("False");

            }

        }

        dtab.Clear();
        if (dtab.Columns.Count > 0)
        {
            for (int i = dtab.Columns.Count - 1; i >= 0; i--)
            {
                dtab.Columns.RemoveAt(i);
            }
            dtab.Columns.Add("Questions");
            dtab.Columns.Add("Answers");
        }
        else
        {
            dtab.Columns.Add("Questions");
            dtab.Columns.Add("Answers");
        }
        for (int i = 0; i < quesArray.Length && i < ansArray.Length; i++)
        {
            DataRow drow = dtab.NewRow();
            drow["Questions"] = quesArray[i];
            drow["Answers"] = anslist[i];
            dtab.Rows.Add(drow);

        }

        dgrid.DataSource = dtab;
        dgrid.DataBind();

    }
}
