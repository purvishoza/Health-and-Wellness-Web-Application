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

public partial class FitnessProblemList : System.Web.UI.Page
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
		string htmlStr = "";
		string dp_fit = "";
		string problem_fit = "";
		int solved = Convert.ToInt16(Session["solved"]);
		string constr = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
		using (SqlConnection con = new SqlConnection(constr))
		{
			using (SqlCommand cmd = new SqlCommand())
			{
				
				cmd.CommandText = "SELECT Questionnaire_Fitness.*, web_users.Pernr, web_users.FName, web_users.Lname, Questionnaire_Fitness.QuestionnaireDate_Fitness FROM Questionnaire_Fitness, web_users where (Questionnaire_Fitness.employee_id = web_users.Pernr and (Questionnaire_Fitness.Nutrition_Eating = @solved or Questionnaire_Fitness.Exercise_Fitness = @solved or Questionnaire_Fitness.WeightManagement = @solved or Questionnaire_Fitness.Muscle_Flexibility_Strength  = @solved or Questionnaire_Fitness.Stress_Management = @solved or Questionnaire_Fitness.Diabetes = @solved or Questionnaire_Fitness.Sleeping_Disturbance = @solved or Questionnaire_Fitness.Addictive_Behaviour = @solved or Questionnaire_Fitness.Cardiovascular_Heart = @solved or Questionnaire_Fitness.Cancer = @solved or Questionnaire_Fitness.Lab_Assessment_values_out_of_range = @solved))";
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
						dp_fit = "";
						problem_fit = "";
						if (dt.Rows[i]["I_Eating_DP"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Nutrition_Eating"]) == solved)
						{
							count++;
							dp_fit += "Nutrition/Eating";
						}
						if (dt.Rows[i]["I_Fitness_DP"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Exercise_Fitness"]) == solved)
						{
							count++;
							dp_fit += "&nbsp;;&nbsp;" + "Exercise/Fitness";
						}
						if (dt.Rows[i]["I_WeightMgmt_DP"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["WeightManagement"]) == solved)
						{
							count++;
							dp_fit += "&nbsp;;&nbsp;" + "Weight Management";
						}
						if (dt.Rows[i]["I_Muscle_DP"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Muscle_Flexibility_Strength"]) == solved)
						{
							count++;
							dp_fit += " &nbsp;;&nbsp;" + "Muscle Flexibility/Strength";
						}

						if (dt.Rows[i]["I_StressMgmt_DP"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Stress_Management"]) == solved)
						{
							count++;
							dp_fit += " &nbsp;;&nbsp;" + "Stress Management";
						}
						if (dt.Rows[i]["I_Diabetes_DP"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Diabetes"]) == solved)
						{
							count++;
							dp_fit += " &nbsp;;&nbsp;" + "Diabetes";
						}
						if (dt.Rows[i]["I_SleepD_DP"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Sleeping_Disturbance"]) == solved)
						{
							count++;
							dp_fit += " &nbsp;;&nbsp;" + "Sleeping Disturbance";
						}
						if (dt.Rows[i]["I_ADDBeh_DP"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Addictive_Behaviour"]) == solved)
						{
							count++;
							dp_fit += " &nbsp;;&nbsp;" + "Addictive Behaviour";
						}
						if (dt.Rows[i]["I_HeartD_DP"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Cardiovascular_Heart"]) == solved)
						{
							count++;
							dp_fit += " &nbsp;;&nbsp;" + "Cardiovascular(Heart)";
						}
						if (dt.Rows[i]["I_CancerD_DP"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Cancer"]) == solved)
						{
							count++;
							dp_fit += " &nbsp;;&nbsp;" + "Cancer";
						}
						if (dt.Rows[i]["I_LabsD_DP"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Lab_Assessment_values_out_of_range"]) == solved)
						{
							count++;
							dp_fit += " &nbsp;;&nbsp;" + "Lab Assessment values out of range";
						}

						if (dt.Rows[i]["I_Eating_Status"].ToString().Equals("Have Problem"))
						{
							problem_fit += "Nutrition/Eating";
						}
						if (dt.Rows[i]["I_Fitness_Status"].ToString().Equals("Have Problem"))
						{
							problem_fit += " &nbsp;;&nbsp;" + "Excercise/Fitness";
						}
						if (dt.Rows[i]["I_WeightMgmt_Status"].ToString().Equals("Have Problem"))
						{
							problem_fit += " &nbsp;;&nbsp;" + "Weight Management";
						}
						if (dt.Rows[i]["I_Muscle_Status"].ToString().Equals("Have Problem"))
						{
							problem_fit += " &nbsp;;&nbsp;" + "Muscle Flexibility/Strength";
						}
						if (dt.Rows[i]["I_StressMgmt_Status"].ToString().Equals("Have Problem"))
						{
							problem_fit += " &nbsp;;&nbsp;" + "Stress Management";
						}
						if (dt.Rows[i]["I_Diabetes_Status"].ToString().Equals("Have Problem"))
						{
							problem_fit += " &nbsp;;&nbsp;" + "Diabetes";
						}
						if (dt.Rows[i]["I_SleepD_Status"].ToString().Equals("Have Problem"))
						{
							problem_fit += " &nbsp;;&nbsp;" + "Sleeping Disturbance";
						}
						if (dt.Rows[i]["I_ADDBeh_Status"].ToString().Equals("Have Problem"))
						{
							problem_fit += " &nbsp;;&nbsp;" + "Addictive Behaviour";
						}
						if (dt.Rows[i]["I_Heart_Status"].ToString().Equals("Have Problem"))
						{
							problem_fit += " &nbsp;;&nbsp;" + "Cardiovascular(Heart)";
						}
						if (dt.Rows[i]["I_Cancer_Status"].ToString().Equals("Have Problem"))
						{
							problem_fit += " &nbsp;;&nbsp;" + "Cancer";
						}
						if (dt.Rows[i]["I_Labs_Status"].ToString().Equals("Have Problem"))
						{
							problem_fit += " &nbsp;;&nbsp;" + "Lab Assessment values out of range";
						}

						if (count > 0)
						{
							String name = dt.Rows[i]["FName"].ToString() + " " + dt.Rows[i]["LName"].ToString();
							DateTime QuestionnaireDate = Convert.ToDateTime(dt.Rows[i]["QuestionnaireDate_Fitness"]);
							Session["dp_fit"] = dp_fit;
							Session["problem_fit"] = problem_fit;

                            if (solved == 0)
                            {
                                htmlStr += "<tr><td>" + dt.Rows[i]["Pernr"] + "</td><td>" + QuestionnaireDate + "</td><td>" + name + "</td><td>" + count + "</td><td>New</td><td style='display: none;'>" + dp_fit + "</td><td style='display: none;'>" + problem_fit + "</td></tr>";
                            }
                            else if (solved == 1)
                            {
								htmlStr += "<tr><td>" + dt.Rows[i]["Pernr"] + "</td><td>" + QuestionnaireDate + "</td><td>" + name + "</td><td>" + count + "</td><td>Attended</td><td style='display: none;'>" + dp_fit + "</td><td style='display: none;'>" + problem_fit + "</td></tr>";
							}
                            else
                            {
								htmlStr += "<tr><td>" + dt.Rows[i]["Pernr"] + "</td><td>" + QuestionnaireDate + "</td><td>" + name + "</td><td>" + count + "</td><td>Solved</td><td style='display: none;'>" + dp_fit + "</td><td style='display: none;'>" + problem_fit + "</td></tr>";
							}
						}
						else
						{

						}
						dp_fit = "";
						problem_fit = "";
					}
				}

			}
		}
		return htmlStr;
	}

}

