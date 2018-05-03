using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Security.Cryptography;
using System.Xml;
using System.Web.Services;
using System.IO;
public partial class Problem_list : System.Web.UI.Page
{
    SqlDataAdapter da;
    DataSet ds = new DataSet();
    StringBuilder htmlTable = new StringBuilder();
    //protected override void OnInit(EventArgs e)
    //{
    //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //    Response.Cache.SetNoStore();
    //    Response.Cache.SetExpires(DateTime.MinValue);

    //    base.OnInit(e);
    //}
    protected void Page_Load(object sender, EventArgs e)
    {

        // Response.Write("hello");
        //panel1.Visible = true;
        //panel2.Visible = false;

        //Session.Clear();
        if (!IsPostBack)
        {
            Session["flag"] = "true";
            Session["solved"] = 0;
            Session["cate"] = "health";
        }

    }

    public string GetTable()
    {
        string htmlStr = "";
        for (int i = 0; i < 3; i++)
        {
            Session["solved"] = i;
            htmlStr += BindData();
        }
        return htmlStr;
    }

    public string BindData()
    {
        //Session.Clear();
        string htmlStr = "";
        string dp = "";
        string problem = "";
        int solved = Convert.ToInt16(Session["solved"]);

        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                //Response.Write(solved.ToString());
                //Use value in Select statement
                cmd.CommandText = "SELECT HealthQuestionnaire.*, web_users.Pernr, web_users.FName, web_users.Lname, HealthQuestionnaire.QuestionnaireDate FROM HealthQuestionnaire, web_users where (HealthQuestionnaire.employee_id = web_users.Pernr and (HealthQuestionnaire.Headache = @solved or HealthQuestionnaire.NeckPain = @solved or HealthQuestionnaire.Arms_Hands_Pain = @solved or HealthQuestionnaire.ShoulderBladePain = @solved or HealthQuestionnaire.LowBackPain = @solved or HealthQuestionnaire.Legs_Feet_Pain_Numbness = @solved))";
                cmd.Parameters.AddWithValue("@solved", solved);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int count = 0;
                        dp = "";
                        problem = "";

                        if (dt.Rows[i]["P_Headache_DT"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Headache"]) == solved)
                        {
                            count++;
                            dp += "Headache;";
                        }
                        if (dt.Rows[i]["P_Neck_Shoulder_DT"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["NeckPain"]) == solved)
                        {
                            count++;
                            dp += "Neck Pain;";
                        }
                        if (dt.Rows[i]["P_Upp_EXT_DT"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Arms_Hands_Pain"]) == solved)
                        {
                            count++;
                            dp += "Arms/Hands Pain/Numbness/Tingling;";
                        }
                        if (dt.Rows[i]["P_BTW_Shoulder_DT"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["ShoulderBladePain"]) == solved)
                        {
                            count++;
                            dp += "Shoulder blade pain;";
                        }

                        if (dt.Rows[i]["P_LBack_DT"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["LowBackPain"]) == solved)
                        {
                            count++;
                            dp += "&nbsp;;&nbsp;" + "Low Back Pain";
                        }
                        else
                        {
                            //  Response.Write(dt.Rows[i]["LowBackPain"].ToString());
                        }
                        if (dt.Rows[i]["P_L_EXT_DT"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Legs_Feet_Pain_Numbness"]) == solved)
                        {
                            count++;
                            dp += "&nbsp;;&nbsp;" + "Legs/Feet Pain, Numbness, or Tingling";
                        }
                        if (dt.Rows[i]["P_Headache_Curr"].ToString().Equals("True"))
                        {

                            problem += "Headache";
                        }
                        if (dt.Rows[i]["P_Neck_Shoulder_Curr"].ToString().Equals("True"))
                        {

                            problem += "&nbsp;;&nbsp;" + "Neck Pain";
                        }
                        if (dt.Rows[i]["P_Upp_EXT_Curr"].ToString().Equals("True"))
                        {

                            problem += "&nbsp;;&nbsp;" + "Arms/Hands Pain/Numbness/Tingling";
                        }
                        if (dt.Rows[i]["P_BTW_Shoulder_Curr"].ToString().Equals("True"))
                        {

                            problem += "&nbsp;;&nbsp;" + "Shoulder blade pain";
                        }

                        if (dt.Rows[i]["P_LBack_Curr"].ToString().Equals("True"))
                        {

                            problem += "&nbsp;;&nbsp;" + "Low Back Pain";
                        }
                        if (dt.Rows[i]["P_L_EXT_Curr"].ToString().Equals("True"))
                        {

                            problem += "&nbsp;;&nbsp;" + "Legs/Feet Pain, Numbness, or Tingling";
                        }

                        if (count > 0)
                        {
                            String name = dt.Rows[i]["FName"].ToString() + " " + dt.Rows[i]["LName"].ToString();
                            DateTime QuestionnaireDate = Convert.ToDateTime(dt.Rows[i]["QuestionnaireDate"]);

                            if (solved == 0)
                            {
                                htmlStr += "<tr><td>" + dt.Rows[i]["Pernr"] + "</td><td>" + QuestionnaireDate + "</td><td>" + name + "</td><td>" + count + "</td><td>New</td><td style='display: none;'>" + dp + "</td><td style='display: none;'>" + problem + "</td></tr>";
                            }
                            else if (solved == 1)
                            {
                                htmlStr += "<tr><td>" + dt.Rows[i]["Pernr"] + "</td><td>" + QuestionnaireDate + "</td><td>" + name + "</td><td>" + count + "</td><td>Attended</td><td style='display: none;'>" + dp + "</td><td style='display: none;'>" + problem + "</td></tr>";

                            }
                            else
                            {
                                htmlStr += "<tr><td>" + dt.Rows[i]["Pernr"] + "</td><td>" + QuestionnaireDate + "</td><td>" + name + "</td><td>" + count + "</td><td>Solved</td><td style='display: none;'>" + dp + "</td><td style='display: none;'>" + problem + "</td></tr>";

                            }
                        }
                        else
                        {

                        }
                        dp = "";
                        problem = "";
                    }
                }

            }
        }
        return htmlStr;
    }
}