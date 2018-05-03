using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Configuration;

public partial class Loggings : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }


    protected void Fitnesstesting_save_Click(object sender, EventArgs e)
    {
       // Int16 fitnessId=0;
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);

        string bmi = BMI_Text.Text;
        try
        {
            SqlCommand cmd1 = new SqlCommand("INSERT INTO FitnessTesting(date,notes,height,weight,bmi,blood_pressure,blood_pressure2,heart_rate,blood_oxygen,skin_fold1,skin_fold2,skin_fold3,hip_flexion,hip_extension,l_side_bridge,r_side_bridge,curl_ups,push_up,grip_left,grip_right,arm_raise,knee_bend,sit_reach1,sit_reach2,sit_reach3,employee_id) VALUES(@date,@notes,@height,@weight,@bmi,@blood_pressure,@blood_pressure2,@heart_rate,@blood_oxygen,@skin_fold1,@skin_fold2,@skin_fold3,@hip_flexion,@hip_extension,@l_side_bridge,@r_side_bridge,@curl_ups,@push_up,@grip_left,@grip_right,@arm_raise,@knee_bend,@sit_reach1,@sit_reach2,@sit_reach3,@employee_id) ", con);
            con.Open();
            cmd1.Parameters.AddWithValue("@height", Height_text.Text.Trim());
            cmd1.Parameters.AddWithValue("@notes", note_text.Text.Trim());
            cmd1.Parameters.AddWithValue("@date", DateTimeOffset.Now);
            cmd1.Parameters.AddWithValue("@weight", Weight_text.Text.Trim());
            cmd1.Parameters.AddWithValue("@bmi", BMI_Text.Text.Trim());
            cmd1.Parameters.AddWithValue("@blood_pressure", BP_1.Text.Trim());
            cmd1.Parameters.AddWithValue("@blood_pressure2", BP_2.Text.Trim());
            cmd1.Parameters.AddWithValue("@heart_rate", Heartrate_text.Text.Trim());
            cmd1.Parameters.AddWithValue("@blood_oxygen", oxygen_text.Text.Trim());
            cmd1.Parameters.AddWithValue("@skin_fold1", skin1_text.Text.Trim());
            cmd1.Parameters.AddWithValue("@skin_fold2", skin2_text.Text.Trim());
            cmd1.Parameters.AddWithValue("@skin_fold3", skin3_text.Text.Trim());
            cmd1.Parameters.AddWithValue("@hip_flexion", Hipflex_text.Text.Trim());
            cmd1.Parameters.AddWithValue("@hip_extension", Hipext_text.Text.Trim());
            cmd1.Parameters.AddWithValue("@l_side_bridge", Lside_text.Text.Trim());
            cmd1.Parameters.AddWithValue("@r_side_bridge", Rside_text.Text.Trim());
            cmd1.Parameters.AddWithValue("@curl_ups", curlup_text.Text.Trim());
            cmd1.Parameters.AddWithValue("@push_up", Pushup_text.Text.Trim());
            cmd1.Parameters.AddWithValue("@grip_left", Gripleft_text.Text.Trim());
            cmd1.Parameters.AddWithValue("@grip_right", Gripright_text.Text.Trim());
            cmd1.Parameters.AddWithValue("@arm_raise", armraise.SelectedItem.Text.Trim());
            cmd1.Parameters.AddWithValue("@knee_bend", KneeBend.SelectedItem.Text.Trim());
            cmd1.Parameters.AddWithValue("@sit_reach1", sit1_text.Text.Trim());
            cmd1.Parameters.AddWithValue("@sit_reach2", sit2_text.Text.Trim());
            cmd1.Parameters.AddWithValue("@sit_reach3", sit3_text.Text.Trim());
            cmd1.Parameters.AddWithValue("@employee_id", Session["empid"].ToString());
           // cmd1.Parameters.AddWithValue("@ID", 1);
          int a=  cmd1.ExecuteNonQuery();
        if(a>0)
            {
                MessageBox("Fitness logging successfully saved");
            }
        }
        catch(Exception ex)
        {
            Response.Write(ex);
        }
        finally
        {
            con.Close();
        }
    }
    private void MessageBox(string Message)
    {
        Label lblMessageBox = new Label();
        lblMessageBox.Text =
            "<script language='javascript'>" + Environment.NewLine +
                         "window.alert('" + Message + "');window.location = 'Loggings.aspx';</script>";
        Page.Controls.Add(lblMessageBox);
    }

}