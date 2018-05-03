using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

    public partial class FitnessCoaching : System.Web.UI.Page
    {
		protected void Page_Load(object sender, EventArgs e)
		{
			
		}


    public void Fitnessinventory_save_Click(object sender, EventArgs e)
	{
        
	   string cs = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;

	    using (SqlConnection con1 = new SqlConnection(cs))
	    {
	        using (SqlCommand cmd2 = new SqlCommand())
	        {
	            cmd2.CommandText = "Insert into Questionnaire_Fitness(employee_id, QuestionnaireDate_Fitness, I_Eating_Status, I_Eating_DP, I_Fitness_Status, I_Fitness_DP, I_WeightMgmt_Status, I_WeightMgmt_DP, I_Muscle_Status, I_Muscle_DP, I_StressMgmt_Status, I_StressMgmt_DP, I_Diabetes_Status, I_Diabetes_DP, I_SleepD_Status, I_SleepD_DP, I_ADDBeh_Status, I_ADDBeh_DP, Addiction, I_Heart_Status, I_HeartD_DP, I_Cancer_Status, I_CancerD_DP, I_Labs_Status, I_LabsD_DP, notes, solved ,Nutrition_Eating,Exercise_Fitness,WeightManagement,Muscle_Flexibility_Strength,Stress_Management,Diabetes,Sleeping_Disturbance,Addictive_Behaviour,Cardiovascular_Heart,Cancer,Lab_Assessment_values_out_of_range) Values(@employee_id, @QuestionnaireDate_Fitness, @I_Eating_Status, @I_Eating_DP, @I_Fitness_Status, @I_Fitness_DP, @I_WeightMgmt_Status, @I_WeightMgmt_DP, @I_Muscle_Status, @I_Muscle_DP, @I_StressMgmt_Status, @I_StressMgmt_DP, @I_Diabetes_Status, @I_Diabetes_DP, @I_SleepD_Status, @I_SleepD_DP, @I_ADDBeh_Status, @I_ADDBeh_DP, @Addiction, @I_Heart_Status, @I_HeartD_DP, @I_Cancer_Status, @I_CancerD_DP, @I_Labs_Status, @I_LabsD_DP, @notes, @solved,@Nutrition_Eating,@Exercise_Fitness,@WeightManagement,@Muscle_Flexibility_Strength,@Stress_Management,@Diabetes,@Sleeping_Disturbance,@Addictive_Behaviour,@Cardiovascular_Heart,@Cancer,@Lab_Assessment_values_out_of_range)";
               
	            cmd2.Parameters.AddWithValue("@Lab_Assessment_values_out_of_range", 0);
	            cmd2.Parameters.AddWithValue("@Cancer",0);
	            cmd2.Parameters.AddWithValue("@Cardiovascular_Heart", 0);
	            cmd2.Parameters.AddWithValue("@Addictive_Behaviour", 0);
	            cmd2.Parameters.AddWithValue("@Sleeping_Disturbance", 0);
	            cmd2.Parameters.AddWithValue("@Diabetes", 0);
	            cmd2.Parameters.AddWithValue("@Stress_Management",0);
	            cmd2.Parameters.AddWithValue("@Muscle_Flexibility_Strength", 0);
	            cmd2.Parameters.AddWithValue("@WeightManagement", 0);
	            cmd2.Parameters.AddWithValue("@Exercise_Fitness",0);
	            cmd2.Parameters.AddWithValue("@Nutrition_Eating",0);
                cmd2.Parameters.AddWithValue("@employee_id", Convert.ToString(HttpContext.Current.Session["empid"]));
	            cmd2.Parameters.AddWithValue("@I_Eating_Status", nutrition_status.SelectedValue);
	            cmd2.Parameters.AddWithValue("@I_Eating_DP", nutrition_dp.Checked);
	            cmd2.Parameters.AddWithValue("@I_Fitness_Status", fitness_status.SelectedValue);
	            cmd2.Parameters.AddWithValue("@I_Fitness_DP", fitness_dp.Checked);
	            cmd2.Parameters.AddWithValue("@I_WeightMgmt_Status", weight_status.SelectedValue);
	            cmd2.Parameters.AddWithValue("@I_WeightMgmt_DP", weight_dp.Checked);
	            cmd2.Parameters.AddWithValue("@I_Muscle_Status", muscle_status.SelectedValue);
	            cmd2.Parameters.AddWithValue("@I_Muscle_DP", muscle_dp.Checked);
	            cmd2.Parameters.AddWithValue("@I_StressMgmt_Status", stress_status.SelectedValue);
	            cmd2.Parameters.AddWithValue("@I_StressMgmt_DP", stress_dp.Checked);
	            cmd2.Parameters.AddWithValue("@I_Diabetes_Status", diabetes_status.SelectedValue);
	            cmd2.Parameters.AddWithValue("@I_Diabetes_DP", diabetes_dp.Checked);
	            cmd2.Parameters.AddWithValue("@I_SleepD_Status", sleeping_status.SelectedValue);
	            cmd2.Parameters.AddWithValue("@I_SleepD_DP", sleeping_dp.Checked);
	            cmd2.Parameters.AddWithValue("@I_ADDBeh_Status", addictive_status.SelectedValue);
	            cmd2.Parameters.AddWithValue("@I_ADDBeh_DP", Addictive_dp.Checked);
	            cmd2.Parameters.AddWithValue("@I_Heart_Status", cardio_status.SelectedValue);
	            cmd2.Parameters.AddWithValue("@I_HeartD_DP", Cardiovascular_dp.Checked);
	            cmd2.Parameters.AddWithValue("@I_Cancer_Status", cancer_status.SelectedValue);
	            cmd2.Parameters.AddWithValue("@I_CancerD_DP", Cancer_dp.Checked);
	            cmd2.Parameters.AddWithValue("@I_Labs_Status", lab_status.SelectedValue);
	            cmd2.Parameters.AddWithValue("@I_LabsD_DP", Labassessment_dp.Checked);
	            cmd2.Parameters.AddWithValue("@Addiction", addictive_text.Text);
	            cmd2.Parameters.AddWithValue("@notes", notes.Text);
	            cmd2.Parameters.AddWithValue("@QuestionnaireDate_Fitness", DateTime.Now);
	            cmd2.Parameters.Add("@solved", SqlDbType.Int).Value = 0;
	            // cmd2.CommandType = CommandType.Text;
	            cmd2.Connection = con1;
	            con1.Open();
	            int a = cmd2.ExecuteNonQuery();

	            if (a == 0)
	            {
                    MessageBox("OOPS! There is a problem with the database. Please try again after some time",1);
	            }
	            else
	            {
                    MessageBox("Your information will be sent to a Health Coach who will contact you to schedule an appointment to discuss your desired behavior changes. Thank You! ☺" ,0);
	                
	            }

	            con1.Close();

	        }
	    }
	    }

	private void MessageBox(string Message, int op)
	{
		if (op == 1)
		{
			Label lblMessageBox = new Label();
			lblMessageBox.Text =
				"<script language='javascript'>" + Environment.NewLine +
							 "window.alert('" + Message + "');</script>";
			Page.Controls.Add(lblMessageBox);
		}
		else
		{
			Label lblMessageBox = new Label();
			lblMessageBox.Text =
				"<script language='javascript'>" + Environment.NewLine +
							 "window.alert('" + Message + "');" + Environment.NewLine + "window.location = 'PARQ.aspx';</script>";
			Page.Controls.Add(lblMessageBox);
		}

	}
}

