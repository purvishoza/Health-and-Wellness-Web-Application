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



public partial class Questionnaire : System.Web.UI.Page
{
    ArrayList al = new ArrayList();
    ArrayList anslist = new ArrayList();
    DataSet ds = new DataSet();
    string week1 = "";
    DataTable dtab = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            bindData();
        }
    }

    protected void save_Click(object sender, EventArgs e)
    {

        Response.Redirect("View_Presentation.aspx");

    }
    protected void Store_Modal_data(object sender, EventArgs e)
    {
        string month = (string)Session["month"];
        string week = month + (string)Session["week"];
        string finalname = month + week;
        string ques = modalQuestion.Text;
        string ans = ModalRadioButtons.Text;
        modalQuestion.Text = "";
        ModalRadioButtons.SelectedValue = null;
        if (ques == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please add question');", true);

        }
        else if (ans == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter your answer');", true);
        }
        else
        {

            string q = "";
            string a = "";
            string cs = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {

                string quer = "select Questions, Answers from Presentation_QuestionsAnswers where id =" + week;
                SqlCommand cmd1 = new SqlCommand(quer, con);
                con.Open();
                SqlDataReader reader = cmd1.ExecuteReader();

                while (reader.Read())
                {
                    q = reader["Questions"].ToString();
                    a = reader["Answers"].ToString();
                }
                con.Close();
                q = q + "#" + ques;
                a = a + "," + ans;
                string qur2 = "UPDATE Presentation_QuestionsAnswers SET Answers='" + a + "', Questions ='" + q + "'Where id =" + week;
                SqlCommand cmd2 = new SqlCommand(qur2, con);
                con.Open();
                int r = cmd2.ExecuteNonQuery();
                con.Close();
                if (r < 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Not able to make changes. Please Verify');", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Updated Successfully');", true);
                }


            }
            bindData();
        }
    }

    protected void dgrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        dgrid.EditIndex = e.NewEditIndex;
        bindData();
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
            if(quesArray[i] != "")
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
        if(dtab.Columns.Count >0)
        {
            for(int i= dtab.Columns.Count-1; i>=0;i--)
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

    protected void dgrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
      
        DataTable dt = dtab;

        GridViewRow row = dgrid.Rows[e.RowIndex];
        TextBox tb = (TextBox)row.FindControl("quesid");
        RadioButtonList rb = (RadioButtonList)row.FindControl("ansid");
        string tbtn = tb.Text;
        string rbtn = rb.Text;
        
        if (tbtn == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter the Question');", true);
            if(rbtn == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select either True or False');", true);
            }
        }
        else if(rbtn == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select either True or False');", true);
        }
        else
        {
            bindData();
            dt.Rows[row.DataItemIndex]["Questions"] = tbtn;
            dt.Rows[row.DataItemIndex]["Answers"] = rbtn;
            updateData(dt);
        }
       
        }



    protected void dgrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        dgrid.EditIndex = -1;
        bindData();
    }

    protected void dgrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dt = dtab;
        bindData();
        DataRow r = dt.Rows[e.RowIndex];
        r.Delete();
        updateData(dt);
       
    }
    private void updateData(DataTable dt)
    {
        DataTable dumm = dt;
        string updateQues = "";
        string updateAns = "";

        

        for (int i = 0; i < dumm.Rows.Count; i++)
        {

            if (i == 0)
            {
                updateQues = dumm.Rows[i]["Questions"].ToString() + "#";
                if (dumm.Rows[i]["Answers"].ToString() == "True" || dumm.Rows[i]["Answers"].ToString() == "T")
                {
                    updateAns = "T,";
                }
                else
                {
                    updateAns = "F,";
                }
            }
            else if (i == dumm.Rows.Count - 1)
            {
                updateQues += dumm.Rows[i]["Questions"].ToString();
                if (dumm.Rows[i]["Answers"].ToString() == "True" || dumm.Rows[i]["Answers"].ToString() == "T")
                {
                    updateAns += "T";
                }
                else
                {
                    updateAns += "F";
                }
            }
            else
            {
                updateQues += dumm.Rows[i]["Questions"].ToString() + "#";
                if (dumm.Rows[i]["Answers"].ToString() == "True" || dumm.Rows[i]["Answers"].ToString() == "T")
                {
                    updateAns += "T,";
                }
                else
                {
                    updateAns += "F,";
                }
            }
        }
        string qva = updateQues;
        string aval = updateAns;
        string query = "UPDATE Presentation_QuestionsAnswers set Questions='" + updateQues + "', Answers='" + updateAns + "' where Id=" + week1;
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd1 = new SqlCommand(query, con);
            con.Open();
            int sdr = cmd1.ExecuteNonQuery();
            if (sdr > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Updated Successfully');", true);
            }
            con.Close();
            dgrid.EditIndex = -1;
            bindData();
            this.Page_Load(null, null);
            Response.Redirect("Questionnaire.aspx");
        }
    }

}