using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Net;
using System.Net.Mail;

  public partial class Reports_Fitness : System.Web.UI.Page
    {
	protected void Page_Load(object sender, EventArgs e)
	{


	}
	public string BindData2()
	{
		string htmlStr = "";
		string constr = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
		using (SqlConnection con = new SqlConnection(constr))
		{
			using (SqlCommand cmd = new SqlCommand())
			{
				
				cmd.CommandText = "SELECT *  FROM Questionnaire_Fitness WHERE QuestionnaireDate_Fitness =(SELECT MAX(QuestionnaireDate_Fitness) FROM Questionnaire_Fitness WHERE employee_id='" + Session["empid"].ToString() + "');";
				cmd.CommandType = CommandType.Text;
				cmd.Connection = con;
				con.Open();
				DataTable dt = new DataTable();
				SqlDataAdapter adapter = new SqlDataAdapter(cmd);
				adapter.Fill(dt);
				con.Close();
				if (dt.Rows.Count > 0)
				{

					for (int i = 0; i < dt.Rows.Count; i++)
					{
						
						if (dt.Rows[i]["I_Eating_DP"].ToString().Equals("True") || dt.Rows[i]["I_Eating_Status"].ToString().Equals("Have Problem"))
						{

							string eating_stat = dt.Rows[i]["I_Eating_Status"].ToString();
							string eating_dp;
							if (dt.Rows[i]["I_Eating_DP"].ToString().Equals("True"))
							{
								eating_dp = "Yes";
							}
							else
							{
								eating_dp = "No";
							}

							htmlStr += "<tr><td>Nutrition/Eating</td><td>" + eating_stat + "</td><td>" + eating_dp + "</td></tr>";


						}
						if (dt.Rows[i]["I_Fitness_DP"].ToString().Equals("True") || dt.Rows[i]["I_Fitness_Status"].ToString().Equals("Have Problem"))
						{

							string fitness_stat = dt.Rows[i]["I_Eating_Status"].ToString();
							string fitness_dp;
							if (dt.Rows[i]["I_Fitness_Status"].ToString().Equals("True"))
							{
								fitness_dp = "Yes";
							}
							else
							{
								fitness_dp = "No";
							}

							htmlStr += "<tr><td>Excercise/Fitness</td><td>" + fitness_stat + "</td><td>" + fitness_dp + "</td></tr>";


						}
						if (dt.Rows[i]["I_WeightMgmt_DP"].ToString().Equals("True") || dt.Rows[i]["I_WeightMgmt_Status"].ToString().Equals("Have Problem"))
						{

							string fitness_stat = dt.Rows[i]["I_WeightMgmt_Status"].ToString();
							string fitness_dp;
							if (dt.Rows[i]["I_WeightMgmt_DP"].ToString().Equals("True"))
							{
								fitness_dp = "Yes";
							}
							else
							{
								fitness_dp = "No";
							}

							htmlStr += "<tr><td>Weight Management</td><td>" + fitness_stat + "</td><td>" + fitness_dp + "</td></tr>";


						}
						if (dt.Rows[i]["I_Muscle_DP"].ToString().Equals("True") || dt.Rows[i]["I_Muscle_Status"].ToString().Equals("Have Problem"))
						{

							string fitness_stat = dt.Rows[i]["I_Muscle_Status"].ToString();
							string fitness_dp;
							if (dt.Rows[i]["I_Muscle_DP"].ToString().Equals("True"))
							{
								fitness_dp = "Yes";
							}
							else
							{
								fitness_dp = "No";
							}

							htmlStr += "<tr><td>Muscle Flexibility/Strength</td><td>" + fitness_stat + "</td><td>" + fitness_dp + "</td></tr>";


						}
						if (dt.Rows[i]["I_StressMgmt_DP"].ToString().Equals("True") || dt.Rows[i]["I_StressMgmt_Status"].ToString().Equals("Have Problem"))
						{

							string fitness_stat = dt.Rows[i]["I_StressMgmt_Status"].ToString();
							string fitness_dp;
							if (dt.Rows[i]["I_StressMgmt_DP"].ToString().Equals("True"))
							{
								fitness_dp = "Yes";
							}
							else
							{
								fitness_dp = "No";
							}

							htmlStr += "<tr><td>Stress Management</td><td>" + fitness_stat + "</td><td>" + fitness_dp + "</td></tr>";


						}

						if (dt.Rows[i]["I_Diabetes_DP"].ToString().Equals("True") || dt.Rows[i]["I_Diabetes_Status"].ToString().Equals("Have Problem"))
						{

							string fitness_stat = dt.Rows[i]["I_Diabetes_Status"].ToString();
							string fitness_dp;
							if (dt.Rows[i]["I_Diabetes_DP"].ToString().Equals("True"))
							{
								fitness_dp = "Yes";
							}
							else
							{
								fitness_dp = "No";
							}

							htmlStr += "<tr><td>Diabetes</td><td>" + fitness_stat + "</td><td>" + fitness_dp + "</td></tr>";


						}
						if (dt.Rows[i]["I_SleepD_DP"].ToString().Equals("True") || dt.Rows[i]["I_SleepD_Status"].ToString().Equals("Have Problem"))
						{

							string fitness_stat = dt.Rows[i]["I_SleepD_Status"].ToString();
							string fitness_dp;
							if (dt.Rows[i]["I_SleepD_DP"].ToString().Equals("True"))
							{
								fitness_dp = "Yes";
							}
							else
							{
								fitness_dp = "No";
							}

							htmlStr += "<tr><td>Sleeping Disturbance</td><td>" + fitness_stat + "</td><td>" + fitness_dp + "</td></tr>";


						}
						if (dt.Rows[i]["I_ADDBeh_DP"].ToString().Equals("True") || dt.Rows[i]["I_ADDBeh_Status"].ToString().Equals("Have Problem"))
						{

							string fitness_stat = dt.Rows[i]["I_ADDBeh_Status"].ToString();
							string fitness_dp;
							if (dt.Rows[i]["I_ADDBeh_DP"].ToString().Equals("True"))
							{
								fitness_dp = "Yes";
							}
							else
							{
								fitness_dp = "No";
							}

							htmlStr += "<tr><td>Addictive Behaviour</td><td>" + fitness_stat + "</td><td>" + fitness_dp + "</td></tr>";


						}
						if (dt.Rows[i]["I_HeartD_DP"].ToString().Equals("True") || dt.Rows[i]["I_Heart_Status"].ToString().Equals("Have Problem"))
						{

							string fitness_stat = dt.Rows[i]["I_Heart_Status"].ToString();
							string fitness_dp;
							if (dt.Rows[i]["I_HeartD_DP"].ToString().Equals("True"))
							{
								fitness_dp = "Yes";
							}
							else
							{
								fitness_dp = "No";
							}

							htmlStr += "<tr><td>Cardiovascular(heart)</td><td>" + fitness_stat + "</td><td>" + fitness_dp + "</td></tr>";


						}
						if (dt.Rows[i]["I_CancerD_DP"].ToString().Equals("True") || dt.Rows[i]["I_Cancer_Status"].ToString().Equals("Have Problem"))
						{

							string fitness_stat = dt.Rows[i]["I_Cancer_Status"].ToString();
							string fitness_dp;
							if (dt.Rows[i]["I_CancerD_DP"].ToString().Equals("True"))
							{
								fitness_dp = "Yes";
							}
							else
							{
								fitness_dp = "No";
							}

							htmlStr += "<tr><td>Cancer</td><td>" + fitness_stat + "</td><td>" + fitness_dp + "</td></tr>";


						}
						if (dt.Rows[i]["I_LabsD_DP"].ToString().Equals("True") || dt.Rows[i]["I_Labs_Status"].ToString().Equals("Have Problem"))
						{

							string fitness_stat = dt.Rows[i]["I_Labs_Status"].ToString();
							string fitness_dp;
							if (dt.Rows[i]["I_LabsD_DP"].ToString().Equals("True"))
							{
								fitness_dp = "Yes";
							}
							else
							{
								fitness_dp = "No";
							}

							htmlStr += "<tr><td>Lab Assessment Values</td><td>" + fitness_stat + "</td><td>" + fitness_dp + "</td></tr>";


						}

					}
                } else {
                    htmlStr = "No records found.";
                }
			}
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


		private void MessageBox(string Message)
		{
			Label lblMessageBox = new Label();
			lblMessageBox.Text =
				"<script language='javascript'>" + Environment.NewLine +
                             "window.alert('" + Message + "');</script>";
			Page.Controls.Add(lblMessageBox);
		}


	}

