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
    public partial class PersonalInfo1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand("SELECT * FROM web_users where Pernr = @empid", con);
                cmd.Parameters.AddWithValue("@empid", Session["empid"].ToString());
                try
                {
                    con.Open();

                    SqlDataReader sqlReader = cmd.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        
                        fname.Text = sqlReader["FName"].ToString();
                        lname.Text = sqlReader["LName"].ToString();
                        address.Text = sqlReader["address"].ToString();
                        city.Text = sqlReader["city"].ToString();
                        state.Text = sqlReader["state"].ToString();
                        zip.Text = sqlReader["zipcode"].ToString();
                        dob.Text = sqlReader["dob"].ToString();
                        marital.Text = sqlReader["marital_status"].ToString();
                        DropDownList1.Text = sqlReader["race"].ToString();
                        gender.Text = sqlReader["gender"].ToString();



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
       protected void save_personal_info(object sender, EventArgs e)
        {
            SqlConnection constr = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Update web_users set LName=  @lname, FName = @fname, address= @address, city=@city, state=@state, zipcode= @zip, dob=@dob, gender=@gender, marital_status=@maritalstatus,race=@race  where Pernr = @empid", constr);
            try
            {
                constr.Open();
                

                cmd.Parameters.AddWithValue("@lname", lname.Text.Trim());
                cmd.Parameters.AddWithValue("@fname", fname.Text.Trim());
                cmd.Parameters.AddWithValue("@address", address.Text.Trim());
                cmd.Parameters.AddWithValue("@city", city.Text.Trim());
                cmd.Parameters.AddWithValue("@state", state.Text.Trim());
                cmd.Parameters.AddWithValue("@zip", zip.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", dob.Text.Trim());
                cmd.Parameters.AddWithValue("@gender", gender.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@maritalstatus", marital.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@race", DropDownList1.SelectedItem.Value);



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
            Response.Redirect("PersonalInformation2.aspx");
            
        }
      
    }
}