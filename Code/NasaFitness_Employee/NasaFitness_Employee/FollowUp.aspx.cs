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
using System.IO;

public partial class FollowUp : System.Web.UI.Page
{
    SqlDataAdapter da;
    DataSet ds = new DataSet();
    StringBuilder htmlTable = new StringBuilder();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string GetTable()
    {
        string htmlStr = "";

            htmlStr += BindData();
            htmlStr += BindData1();
        return htmlStr;
    }

    public string BindData()
    {
        //Session.Clear();
        string htmlStr = "";
        string dp = "";
        string problem = "";

        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                //Use value in Select statement
                cmd.CommandText = "SELECT HealthQuestionnaire.*, web_users.FName, web_users.Lname, HealthQuestionnaire.QuestionnaireDate FROM HealthQuestionnaire, web_users where (HealthQuestionnaire.employee_id = '" + Session["empid"].ToString() + "' and web_users.Pernr = '" + Session["empid"].ToString() + "')";

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

                        if (dt.Rows[i]["P_Headache_DT"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Headache"]) == 1)
                        {
                            count++;
                            dp += "Headache";
                        }
                        if (dt.Rows[i]["P_Neck_Shoulder_DT"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["NeckPain"]) == 1)
                        {
                            count++;
                            dp += " ;" + "Neck Pain";
                        }
                        if (dt.Rows[i]["P_Upp_EXT_DT"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Arms_Hands_Pain"]) == 1)
                        {
                            count++;
                            dp += " ;" + "Arms/Hands Pain/Numbness/Tingling";
                        }
                        if (dt.Rows[i]["P_BTW_Shoulder_DT"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["ShoulderBladePain"]) == 1)
                        {
                            count++;
                            dp += " ;" + "Shoulder blade pain";
                        }

                        if (dt.Rows[i]["P_LBack_DT"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["LowBackPain"]) == 1)
                        {
                            count++;
                            dp += " ;" + "Low Back Pain";
                        }
                        if (dt.Rows[i]["P_L_EXT_DT"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Legs_Feet_Pain_Numbness"]) == 1)
                        {
                            count++;
                            dp += " ;" + "Legs/Feet Pain, Numbness, or Tingling";
                        }
                        if (dt.Rows[i]["P_Headache_Curr"].ToString().Equals("True"))
                        {

                            problem += "Headache";
                        }
                        if (dt.Rows[i]["P_Neck_Shoulder_Curr"].ToString().Equals("True"))
                        {

                            problem += " ;" + "Neck Pain";
                        }
                        if (dt.Rows[i]["P_Upp_EXT_Curr"].ToString().Equals("True"))
                        {

                            problem += " ;" + "Arms/Hands Pain/Numbness/Tingling";
                        }
                        if (dt.Rows[i]["P_BTW_Shoulder_Curr"].ToString().Equals("True"))
                        {

                            problem += " ;" + "Shoulder blade pain";
                        }

                        if (dt.Rows[i]["P_LBack_Curr"].ToString().Equals("True"))
                        {

                            problem += " ;" + "Low Back Pain";
                        }
                        if (dt.Rows[i]["P_L_EXT_Curr"].ToString().Equals("True"))
                        {

                            problem += " ;" + "Legs/Feet Pain, Numbness, or Tingling";
                        }



                        if (count > 0)
                        {
                            String name = dt.Rows[i]["FName"].ToString() + " " + dt.Rows[i]["LName"].ToString();
                            DateTime QuestionnaireDate = Convert.ToDateTime(dt.Rows[i]["QuestionnaireDate"]);

							htmlStr += "<tr><td>" + QuestionnaireDate + "</td><td>" + name + "</td><td>" + count + "</td><td>Health</td><td>" + dp + "</td></tr>";


						}
                        else
                        {

                        }



                    }
                }

            }
        }

        return htmlStr;
    }

    public string BindData1()
    {
        string htmlStr = "";
        string dp_fit = "";
        string problem_fit = "";
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                //Use value in Select statement

                cmd.CommandText = "SELECT Questionnaire_Fitness.*, web_users.FName, web_users.Lname, Questionnaire_Fitness.QuestionnaireDate_Fitness FROM Questionnaire_Fitness, web_users where (Questionnaire_Fitness.employee_id = '" + Session["empid"] + "' and web_users.Pernr = '" + Session["empid"].ToString() + "')";
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
                        if (dt.Rows[i]["I_Eating_DP"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Nutrition_Eating"]) == 1)
                        {
                            count++;
                            dp_fit += "Nutrition/Eating";
                        }
                        if (dt.Rows[i]["I_Fitness_DP"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Exercise_Fitness"]) == 1)
                        {
                            count++;
                            dp_fit += " ;" + "Exercise/Fitness";
                        }
                        if (dt.Rows[i]["I_WeightMgmt_DP"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["WeightManagement"]) == 1)
                        {
                            count++;
                            dp_fit += " ;" + "Weight Management";
                        }
                        if (dt.Rows[i]["I_Muscle_DP"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Muscle_Flexibility_Strength"]) == 1)
                        {
                            count++;
                            dp_fit += " ;" + "Muscle Flexibility/Strength";
                        }

                        if (dt.Rows[i]["I_StressMgmt_DP"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Stress_Management"]) == 1)
                        {
                            count++;
                            dp_fit += " ;" + "Stress Management";
                        }
                        if (dt.Rows[i]["I_Diabetes_DP"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Diabetes"]) == 1)
                        {
                            count++;
                            dp_fit += " ;" + "Diabetes";
                        }
                        if (dt.Rows[i]["I_SleepD_DP"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Sleeping_Disturbance"]) == 1)
                        {
                            count++;
                            dp_fit += " ;" + "Sleeping Disturbance";
                        }
                        if (dt.Rows[i]["I_ADDBeh_DP"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Addictive_Behaviour"]) == 1)
                        {
                            count++;
                            dp_fit += " ;" + "Addictive Behaviour";
                        }
                        if (dt.Rows[i]["I_HeartD_DP"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Cardiovascular_Heart"]) == 1)
                        {
                            count++;
                            dp_fit += " ;" + "Cardiovascular(Heart)";
                        }
                        if (dt.Rows[i]["I_CancerD_DP"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Cancer"]) == 1)
                        {
                            count++;
                            dp_fit += " ;" + "Cancer";
                        }
                        if (dt.Rows[i]["I_LabsD_DP"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Lab_Assessment_values_out_of_range"]) == 1)
                        {
                            count++;
                            dp_fit += " ;" + "Lab Assessment values out of range";
                        }

                        if (dt.Rows[i]["I_Eating_Status"].ToString().Equals("Have Problem"))
                        {
                            problem_fit += "Nutrition/Eating";
                        }
                        if (dt.Rows[i]["I_Fitness_Status"].ToString().Equals("Have Problem"))
                        {
                            problem_fit += " ;" + "Excercise/Fitness";
                        }
                        if (dt.Rows[i]["I_WeightMgmt_Status"].ToString().Equals("Have Problem"))
                        {
                            problem_fit += " ;" + "Weight Management";
                        }
                        if (dt.Rows[i]["I_Muscle_Status"].ToString().Equals("Have Problem"))
                        {
                            problem_fit += " ;" + "Muscle Flexibility/Strength";
                        }
                        if (dt.Rows[i]["I_StressMgmt_Status"].ToString().Equals("Have Problem"))
                        {
                            problem_fit += " ;" + "Stress Management";
                        }
                        if (dt.Rows[i]["I_Diabetes_Status"].ToString().Equals("Have Problem"))
                        {
                            problem_fit += " ;" + "Diabetes";
                        }
                        if (dt.Rows[i]["I_SleepD_Status"].ToString().Equals("Have Problem"))
                        {
                            problem_fit += " ;" + "Sleeping Disturbance";
                        }
                        if (dt.Rows[i]["I_ADDBeh_Status"].ToString().Equals("Have Problem"))
                        {
                            problem_fit += " ;" + "Addictive Behaviour";
                        }
                        if (dt.Rows[i]["I_Heart_Status"].ToString().Equals("Have Problem"))
                        {
                            problem_fit += " ;" + "Cardiovascular(Heart)";
                        }
                        if (dt.Rows[i]["I_Cancer_Status"].ToString().Equals("Have Problem"))
                        {
                            problem_fit += " ;" + "Cancer";
                        }
                        if (dt.Rows[i]["I_Labs_Status"].ToString().Equals("Have Problem"))
                        {
                            problem_fit += " ;" + "Lab Assessment values out of range";
                        }

                        if (count > 0)
                        {

                            String name = dt.Rows[i]["FName"].ToString() + " " + dt.Rows[i]["LName"].ToString();
                            DateTime QuestionnaireDate = Convert.ToDateTime(dt.Rows[i]["QuestionnaireDate_Fitness"]);
							htmlStr += "<tr><td>" + QuestionnaireDate + "</td><td>" + name + "</td><td>" + count + "</td><td>Fitness</td><td>" + dp_fit + "</td></tr>";


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

    private void MessageBox(string Message)
    {
        Label lblMessageBox = new Label();
        lblMessageBox.Text =
            "<script language='javascript'>" + Environment.NewLine +
            "window.alert('" + Message + "')</script>";
        Page.Controls.Add(lblMessageBox);
    }
}