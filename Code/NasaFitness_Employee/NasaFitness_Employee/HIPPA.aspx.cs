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

namespace NasaFitness_Employee
{
    public partial class HIPPA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand("SELECT * FROM web_patients where web_users_id = @empid", con);
                cmd.Parameters.AddWithValue("@empid", Session["empid"].ToString());
                try
                {
                    con.Open();

                    SqlDataReader sqlReader = cmd.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        WorkEmailOK.Checked = (bool)sqlReader["WorkEmailOK"];
                        HomeEmailOK.Checked = (bool)sqlReader["HomeEmailOK"];
                        WorkTeleOK.Checked = (bool)sqlReader["WorkTeleOK"] == true ? true : false;
                        WorkAnsOK.Checked = (bool)sqlReader["WorkAnsOK"] == true ? true : false;
                        HomeTeleOK.Checked = (bool)sqlReader["HomeTeleOK"] == true ? true : false;
                        HomeAnsOK.Checked = (bool)sqlReader["HomeAnsOK"] == true ? true : false;
                        CellTeleOK.Checked = (bool)sqlReader["CellTeleOK"] == true ? true : false;
                        CellAnsOK.Checked = (bool)sqlReader["CellAnsOK"] == true ? true : false;
                        CellSMSOK.Checked = (bool)sqlReader["CellSMSOK"] == true ? true : false;
                        //OhterFamily.Text = sqlReader["OhterFamily"].ToString();
                        ExamResultsOK.Checked = (bool)sqlReader["ExamResultsOK"] == true ? true : false;
                        HealthFitnessOK.Checked = (bool)sqlReader["HealthFitnessOK"] == true ? true : false;
                        WhatOtherReports.Text = sqlReader["WhatOtherReports"].ToString();
                        IndivRequestsOK.Checked = (bool)sqlReader["IndivRequestsOK"] == true ? true : false;
                        MedicalCareOK.Checked = (bool)sqlReader["MedicalCareOK"] == true ? true : false;
                        OtherInfo.Text = sqlReader["OtherInfo"].ToString();
                        NoEndDate.Text = sqlReader["NoEndDate"].ToString();
                        EndDateForOKs.Text = sqlReader["EndDateForOKs"].ToString();
                        //name.Text = ManipulateLabel();
                        //name.Text = "Patient's Name";
                        
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                    Console.WriteLine("error is" + ex);
                }
                finally
                {
                    con.Close();
                }
            }
        }
        protected void save_hippa_info(object sender, EventArgs e)
        {
            SqlConnection constr = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Update web_patients set WorkEmailOK=  @WorkEmailOK,HomeEmailOK = @HomeEmailOK,WorkTeleOK= @WorkTeleOK,WorkAnsOK=@WorkAnsOK,HomeTeleOK=@HomeTeleOK,HomeAnsOK= @HomeAnsOK,CellTeleOK=@CellTeleOK,CellAnsOK=@CellAnsOK,CellSMSOK=@CellSMSOK,ExamResultsOK=@ExamResultsOK,HealthFitnessOK=@HealthFitnessOK,WhatOtherReports=@WhatOtherReports,IndivRequestsOK=@IndivRequestsOK,MedicalCareOK=@MedicalCareOK,OtherInfo=@OtherInfo, NoEndDate=@NoEndDate, EndDateForOKs=@EndDateForOKs, OtherReportsOK=@OtherReportsOK where web_users_id = @empid", constr);
            try
            {
                constr.Open();
                cmd.Parameters.AddWithValue("@WorkEmailOK", WorkEmailOK.Checked);
                cmd.Parameters.AddWithValue("@HomeEmailOK", HomeEmailOK.Checked);
                cmd.Parameters.AddWithValue("@WorkTeleOK", WorkTeleOK.Checked);
                cmd.Parameters.AddWithValue("@WorkAnsOK", WorkAnsOK.Checked);
                cmd.Parameters.AddWithValue("@HomeTeleOK", HomeTeleOK.Checked);
                cmd.Parameters.AddWithValue("@HomeAnsOK", HomeAnsOK.Checked);
                cmd.Parameters.AddWithValue("@CellTeleOK", CellTeleOK.Checked);
                cmd.Parameters.AddWithValue("@CellAnsOK", CellAnsOK.Checked);
                cmd.Parameters.AddWithValue("@CellSMSOK", CellSMSOK.Checked);
                cmd.Parameters.AddWithValue("@OhterFamily", OhterFamily.Text.Trim());
                cmd.Parameters.AddWithValue("@ExamResultsOK", ExamResultsOK.Checked);
                cmd.Parameters.AddWithValue("@HealthFitnessOK", HealthFitnessOK.Checked);
                cmd.Parameters.AddWithValue("@OtherReportsOK", 0);
                cmd.Parameters.AddWithValue("@WhatOtherReports", WhatOtherReports.Text.Trim());
                cmd.Parameters.AddWithValue("@IndivRequestsOK", IndivRequestsOK.Checked);
                cmd.Parameters.AddWithValue("@MedicalCareOK", MedicalCareOK.Checked);

                cmd.Parameters.AddWithValue("@OtherInfo", OtherInfo.Text.Trim());
                cmd.Parameters.AddWithValue("@NoEndDate", NoEndDate.Text.Trim());
                cmd.Parameters.AddWithValue("@EndDateForOKs", DateTime.Now);

                cmd.Parameters.AddWithValue("@empid", Session["empid"]);
                int a = cmd.ExecuteNonQuery();
                if (a <= 0)
                {

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully Updated.'); ", true);
                }
            }

            catch (Exception ex)
            {
                Response.Write(ex);
                Console.WriteLine(ex);
            }
            finally
            {
                constr.Close();
            }
            Response.Redirect("HIPPA2.aspx");
            //Server.Transfer("HIPPA2.aspx");
        }

        

        protected string ManipulateLabel()
        {

            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM web_users where Pernr = @empid", con);
            cmd.Parameters.AddWithValue("@empid", Session["empid"].ToString());
            string namePatient = "";
            try
            {
                con.Open();

                SqlDataReader sqlReader = cmd.ExecuteReader();
                while (sqlReader.Read())
                {
                    if (name.Text == null)
                        name.Text = sqlReader["FName"].ToString();
                        namePatient = name.Text;
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
                Console.WriteLine("error is" + ex);
            }
            finally
            {
                con.Close();
            }
            return namePatient;
        }
    }
}