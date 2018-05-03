 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class HealthCoaching : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       

    }


    public void health_save_Click(object sender, EventArgs e)
    {
       
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cs))
        {

            SqlCommand cmd = new SqlCommand("insert into HealthQuestionnaire(employee_id, QuestionnaireDate, P_Headache_Past, P_Headache_Curr, P_Headache_DT, P_Neck_Shoulder_Past, P_Neck_Shoulder_Curr, P_Neck_Shoulder_DT, P_Upp_EXT_Past, P_Upp_EXT_Curr, P_Upp_EXT_DT, P_BTW_Shoulder_Past, P_BTW_Shoulder_Curr, P_BTW_Shoulder_DT, P_LBack_Past, P_LBack_Curr, P_LBack_DT, P_L_EXT_Past, P_L_EXT_Curr, P_L_EXT_DT, P_Other, solved ,Headache,NeckPain,Arms_Hands_Pain,ShoulderBladePain,LowBackPain,Legs_Feet_Pain_Numbness )" +
           " values (@employee_id, @QuestionnaireDate, @P_Headache_Past, @P_Headache_Curr, @P_Headache_DT, @P_Neck_Shoulder_Past, @P_Neck_Shoulder_Curr, @P_Neck_Shoulder_DT, @P_Upp_EXT_Past, @P_Upp_EXT_Curr, @P_Upp_EXT_DT, @P_BTW_Shoulder_Past, @P_BTW_Shoulder_Curr, @P_BTW_Shoulder_DT, @P_LBack_Past, @P_LBack_Curr, @P_LBack_DT, @P_L_EXT_Past, @P_L_EXT_Curr, @P_L_EXT_DT, @P_Other, @solved,@Headache,@NeckPain,@Arms_Hands_Pain,@ShoulderBladePain,@LowBackPain,@Legs_Feet_Pain_Numbness)");

            //cmd.Parameters.AddWithValue("@employee_id",Session["empid"].ToString());
            cmd.Parameters.AddWithValue("@Headache", 0);
            cmd.Parameters.AddWithValue("@NeckPain", 0);
            cmd.Parameters.AddWithValue("@Arms_Hands_Pain", 0);
            cmd.Parameters.AddWithValue("@ShoulderBladePain", 0);
            cmd.Parameters.AddWithValue("@LowBackPain",0);
            cmd.Parameters.AddWithValue("@Legs_Feet_Pain_Numbness",0);
            cmd.Parameters.Add("@employee_id", SqlDbType.NVarChar).Value = Convert.ToString(HttpContext.Current.Session["empid"]);
            cmd.Parameters.Add("@QuestionnaireDate", SqlDbType.DateTime2).Value = DateTime.Now;
            cmd.Parameters.Add("@P_Headache_Past", SqlDbType.Bit).Value = Convert.ToInt32(headache_past.Checked);
            cmd.Parameters.Add("@P_Headache_Curr", SqlDbType.Bit).Value = Convert.ToInt32(headache_current.Checked);
            cmd.Parameters.Add("@P_Headache_DT", SqlDbType.Bit).Value = Convert.ToInt32(headache_treatment.Checked);
                cmd.Parameters.Add("@P_Neck_Shoulder_Past", SqlDbType.Bit).Value = Convert.ToInt32(Neckpain_past.Checked);
            cmd.Parameters.Add("@P_Neck_Shoulder_Curr", SqlDbType.Bit).Value = Convert.ToInt32(Neckpain_current.Checked);
            cmd.Parameters.Add("@P_Neck_Shoulder_DT", SqlDbType.Bit).Value = Convert.ToInt32(Neckpain_treatment.Checked);
            cmd.Parameters.Add("@P_Upp_EXT_Past", SqlDbType.Bit).Value = Convert.ToInt32(arms_past.Checked);
            cmd.Parameters.Add("@P_Upp_EXT_Curr", SqlDbType.Bit).Value = Convert.ToInt32(arms_current.Checked);
            cmd.Parameters.Add("@P_Upp_EXT_DT", SqlDbType.Bit).Value = Convert.ToInt32(arms_treatment.Checked);
            cmd.Parameters.Add("@P_BTW_Shoulder_Past", SqlDbType.Bit).Value = Convert.ToInt32(shoulder_past.Checked);
            cmd.Parameters.Add("@P_BTW_Shoulder_Curr", SqlDbType.Bit).Value = Convert.ToInt32(shoulder_current.Checked);
            cmd.Parameters.Add("@P_BTW_Shoulder_DT", SqlDbType.Bit).Value = Convert.ToInt32(shoulder_treatment.Checked);
            cmd.Parameters.Add("@P_LBack_Past", SqlDbType.Bit).Value = Convert.ToInt32(lowback_past.Checked);
            cmd.Parameters.Add("@P_LBack_Curr", SqlDbType.Bit).Value = Convert.ToInt32(lowback_current.Checked);
            cmd.Parameters.Add("@P_LBack_DT", SqlDbType.Bit).Value = Convert.ToInt32(lowback_treatment.Checked);
            cmd.Parameters.Add("@P_L_EXT_Past", SqlDbType.Bit).Value = Convert.ToInt32(leg_past.Checked);
            cmd.Parameters.Add("@P_L_EXT_Curr", SqlDbType.Bit).Value = Convert.ToInt32(leg_current.Checked);
            cmd.Parameters.Add("@P_L_EXT_DT", SqlDbType.Bit).Value = Convert.ToInt32(leg_treatment.Checked);
            cmd.Parameters.Add("@P_Other", SqlDbType.NVarChar).Value = health_comments.Text;
            cmd.Parameters.Add("@solved", SqlDbType.Int).Value=0;

            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            int a = 0;
            a = cmd.ExecuteNonQuery();
            if (a < 0)
            {
               MessageBox("OOPS! There is a problem with the database. Please try again after some time",1);
            }
            else
            {
				MessageBox("Your information will be sent to a Health Coach who will contact you to schedule an appointment to discuss your desired behavior changes. Thank You! ☺", 0);

			}
            con.Close();
            // Panel3.Visible = false;

        }


    }









    private void MessageBox(string Message, int op)
    {
        if (op == 1) {
			Label lblMessageBox = new Label();
			lblMessageBox.Text =
				"<script language='javascript'>" + Environment.NewLine +
							 "window.alert('" + Message + "');</script>";
			Page.Controls.Add(lblMessageBox);
        } else {
			Label lblMessageBox = new Label();
			lblMessageBox.Text =
				"<script language='javascript'>" + Environment.NewLine +
                             "window.alert('" + Message + "');"+ Environment.NewLine +"window.location = 'FitnessCoaching.aspx';</script>";
			Page.Controls.Add(lblMessageBox);
        }

    }

    //protected void Parq_Click(object sender, EventArgs e)
    //{

    //    Panel3.Visible = true;
    //    Panel2.Visible = false;
    //    Panel1.Visible = false;



    //}


}