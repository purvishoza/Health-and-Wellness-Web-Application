using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace NasaFitness_Admin
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["id_health"] = "";

            // Session["solved"] = 0;
            int solved = 0;
            string constr = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
            string constr1 = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
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
                        int newcount = 0;
                        int attendcount = 0;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {

                            if (dt.Rows[i]["P_Headache_DT"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Headache"]) == solved)
                            {
                                newcount++;
                            }
                            else
                            {
                                if (dt.Rows[i]["P_Headache_DT"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Headache"]) != solved)
                                {
                                    attendcount++;
                                }
                            }

                            if (dt.Rows[i]["P_Neck_Shoulder_DT"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["NeckPain"]) == solved)
                            {
                                newcount++;
                            }
                            else
                            {
                                if (dt.Rows[i]["P_Neck_Shoulder_DT"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["NeckPain"]) != solved)
                                {
                                    attendcount++;
                                }

                            }

                            if (dt.Rows[i]["P_Upp_EXT_DT"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Arms_Hands_Pain"]) == solved)
                            {
                                newcount++;
                            }
                            else
                            {
                                if (dt.Rows[i]["P_Upp_EXT_DT"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Arms_Hands_Pain"]) != solved)
                                {
                                    attendcount++;
                                }

                            }

                            if (dt.Rows[i]["P_BTW_Shoulder_DT"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["ShoulderBladePain"]) == solved)
                            {
                                newcount++;
                            }
                            else
                            {
                                if (dt.Rows[i]["P_BTW_Shoulder_DT"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["ShoulderBladePain"]) != solved)
                                {
                                    attendcount++;
                                }
                            }

                            if (dt.Rows[i]["P_LBack_DT"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["LowBackPain"]) == solved)
                            {
                                newcount++;
                            }

                            else
                            {
                                if (dt.Rows[i]["P_LBack_DT"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["LowBackPain"]) != solved)
                                {
                                    attendcount++;
                                }

                            }
                            if (dt.Rows[i]["P_L_EXT_DT"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Legs_Feet_Pain_Numbness"]) == solved)
                            {
                                newcount++;
                            }
                            else
                            {
                                if (dt.Rows[i]["P_L_EXT_DT"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Legs_Feet_Pain_Numbness"]) != solved)
                                {
                                    attendcount++;
                                }

                            }

                        }
                        Session["newhealth"] = newcount;
                        Session["attendhealth"] = attendcount;
                        con.Close();
                    }

                }
            }
            string constr2 = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
            using (SqlConnection con2 = new SqlConnection(constr2))
            {
                using (SqlCommand cmd2 = new SqlCommand())
                {
                    int fit_newcount = 0;
                    int fit_attendcount = 0;
                    cmd2.CommandText = "SELECT Questionnaire_Fitness.*, web_users.Pernr, web_users.FName, web_users.Lname, Questionnaire_Fitness.QuestionnaireDate_Fitness FROM Questionnaire_Fitness, web_users where (Questionnaire_Fitness.employee_id = web_users.Pernr and (Questionnaire_Fitness.Nutrition_Eating = @solved or Questionnaire_Fitness.Exercise_Fitness = @solved or Questionnaire_Fitness.WeightManagement = @solved or Questionnaire_Fitness.Muscle_Flexibility_Strength  = @solved or Questionnaire_Fitness.Stress_Management = @solved or Questionnaire_Fitness.Diabetes = @solved or Questionnaire_Fitness.Sleeping_Disturbance = @solved or Questionnaire_Fitness.Addictive_Behaviour = @solved or Questionnaire_Fitness.Cardiovascular_Heart = @solved or Questionnaire_Fitness.Cancer = @solved or Questionnaire_Fitness.Lab_Assessment_values_out_of_range = @solved))";
                    cmd2.Parameters.AddWithValue("@solved", solved);
                    cmd2.CommandType = CommandType.Text;
                    cmd2.Connection = con2;
                    con2.Open();

                    DataTable dt = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd2);
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {


                            if (dt.Rows[i]["I_Eating_DP"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Nutrition_Eating"]) == solved)
                            {
                                fit_newcount++;

                            }
                            else if (dt.Rows[i]["I_Eating_DP"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Nutrition_Eating"]) != solved)
                            {
                                fit_attendcount++;
                            }
                            if (dt.Rows[i]["I_Fitness_DP"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Exercise_Fitness"]) == solved)
                            {
                                fit_newcount++;

                            }
                            else if (dt.Rows[i]["I_Fitness_DP"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Exercise_Fitness"]) != solved)
                            {
                                fit_attendcount++;
                            }
                            if (dt.Rows[i]["I_WeightMgmt_DP"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["WeightManagement"]) == solved)
                            {
                                fit_newcount++;

                            }
                            else if (dt.Rows[i]["I_WeightMgmt_DP"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["WeightManagement"]) != solved)
                            {
                                fit_attendcount++;
                            }
                            if (dt.Rows[i]["I_Muscle_DP"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Muscle_Flexibility_Strength"]) == solved)
                            {
                                fit_newcount++;

                            }
                            else if (dt.Rows[i]["I_Muscle_DP"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Muscle_Flexibility_Strength"]) != solved)
                            {
                                fit_attendcount++;
                            }

                            if (dt.Rows[i]["I_StressMgmt_DP"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Stress_Management"]) == solved)
                            {
                                fit_newcount++;

                            }
                            else if (dt.Rows[i]["I_StressMgmt_DP"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Stress_Management"]) != solved)
                            {
                                fit_attendcount++;
                            }
                            if (dt.Rows[i]["I_Diabetes_DP"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Diabetes"]) == solved)
                            {
                                fit_newcount++;

                            }
                            else if (dt.Rows[i]["I_Diabetes_DP"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Diabetes"]) != solved)
                            {
                                fit_attendcount++;
                            }
                            if (dt.Rows[i]["I_SleepD_DP"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Sleeping_Disturbance"]) == solved)
                            {
                                fit_newcount++;

                            }
                            else if (dt.Rows[i]["I_SleepD_DP"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Sleeping_Disturbance"]) != solved)
                            {
                                fit_attendcount++;
                            }
                            if (dt.Rows[i]["I_ADDBeh_DP"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Addictive_Behaviour"]) == solved)
                            {
                                fit_newcount++;

                            }
                            else if (dt.Rows[i]["I_ADDBeh_DP"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Addictive_Behaviour"]) != solved)
                            {
                                fit_attendcount++;
                            }
                            if (dt.Rows[i]["I_HeartD_DP"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Cardiovascular_Heart"]) == solved)
                            {
                                fit_newcount++;

                            }
                            else if (dt.Rows[i]["I_HeartD_DP"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Cardiovascular_Heart"]) != solved)
                            {
                                fit_attendcount++;
                            }
                            if (dt.Rows[i]["I_CancerD_DP"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Cancer"]) == solved)
                            {
                                fit_newcount++;

                            }
                            else if (dt.Rows[i]["I_CancerD_DP"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Cancer"]) != solved)
                            {
                                fit_attendcount++;
                            }
                            if (dt.Rows[i]["I_LabsD_DP"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Lab_Assessment_values_out_of_range"]) == solved)
                            {
                                fit_newcount++;

                            }
                            else if (dt.Rows[i]["I_LabsD_DP"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Lab_Assessment_values_out_of_range"]) != solved)
                            {
                                fit_attendcount++;
                            }


                        }
                    }
                    Session["fit_newcount"] = fit_newcount;
                    Session["fit_attendcount"] = fit_attendcount;
                    con2.Close();

                }

                using (SqlConnection con1 = new SqlConnection(constr1))
                {
                    using (SqlCommand cmd1 = new SqlCommand())
                    {
                        cmd1.CommandText = "SELECT count(ID) from web_users";
                        cmd1.CommandType = CommandType.Text;
                        cmd1.Connection = con1;
                        con1.Open();
                        SqlDataReader sqlReader = cmd1.ExecuteReader();
                        if (sqlReader.Read())
                        {
                            Session["noofpatients"] = sqlReader[0].ToString();
                        }
                        con1.Close();
                    }
                }
            }
        }
        

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}