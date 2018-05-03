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


public partial class viewResults : System.Web.UI.Page
{
    ArrayList al = new ArrayList();
    ArrayList anslist = new ArrayList();
    ArrayList bread = new ArrayList();
    ArrayList aread = new ArrayList();
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
    private void bindData()
    {
        string month = (string)Session["month"];
        string weekly = (string)Session["week"];
        week1 = month + weekly;
        string q = "";
        string a = "";
        string br = "";
        string ar = "";
        string query = "select pq.Questions as Questions,pq.Answers as Answers,er.BeforeReading as BeforeReading,er.AfterReading as AfterReading from Presentation_QuestionsAnswers pq, ExamResults er where pq.Id=" + week1 + " and er.Employee_id='" + empid + "'";
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
                br = reader["BeforeReading"].ToString();
                ar = reader["AfterReading"].ToString();

            }
            con.Close();
        }
        string[] quesArray = q.Split('#');
        string[] ansArray = a.Split(',');
        string[] brArray = br.Split('#');
        string[] arArray = ar.Split('#');
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
        for (int i = 0; i < brArray.Length - 1; i++)
        {
            if (brArray[i] != "")
            {
                bread.Add(brArray[i]);
                //al.Add(quesArray[i]);
            }
            else
            {
                bread.Add("-");
            }

        }
        for (int i = 0; i < arArray.Length - 1; i++)
        {
            if (arArray[i] != "")
            {
                aread.Add(arArray[i]);
            }
            else
            {
                aread.Add("-");
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
            dtab.Columns.Add("BeforeReading");
            dtab.Columns.Add("AfterReading");
        }
        else
        {
            dtab.Columns.Add("Questions");
            dtab.Columns.Add("Answers");
            dtab.Columns.Add("BeforeReading");
            dtab.Columns.Add("AfterReading");
        }
        for (int i = 0; i < quesArray.Length && i < ansArray.Length; i++)
        {
            DataRow drow = dtab.NewRow();
            drow["Questions"] = quesArray[i];
            drow["Answers"] = anslist[i];
            drow["BeforeReading"] = bread[i];
            drow["AfterReading"] = aread[i];
            dtab.Rows.Add(drow);

        }

        dgrid.DataSource = dtab;
        dgrid.DataBind();

    }
    protected void save_Click(object sender, EventArgs e)
    {
        Response.Redirect("Presentations.aspx");
    }
}
