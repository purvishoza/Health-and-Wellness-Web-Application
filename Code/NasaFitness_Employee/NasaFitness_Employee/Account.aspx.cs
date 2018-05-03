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

public partial class Account : System.Web.UI.Page
{
    //SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);
    //string constr = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //string lname = lastname.Text.ToString();
            //string fname = firstname.Text.ToString();
            //string mname = middlename.Text.ToString();
            //string dobmon = dobmonth.Text.ToString();
            //string dobda = dobdate.Text.ToString();
            //string dobye = dobyear.Text.ToString();
            //string dob = dobmon + "/" + dobda + "/" + dobye;
            //string add = address.Text.ToString();
            //string cit = city.Text.ToString();
            //string sta = state.Text.ToString();
            //string zi = zip.Text.ToString();
            //string emai = email.Text.ToString();
            //string wophn = workphone.Text.ToString();
            //string celphn = cellphone.Text.ToString();
            //string comp = company.Text.ToString();
            //string dept = department.Text.ToString();
            //string desig = designation.Text.ToString();
            //string gend = ddlGender.SelectedValue.ToString();
            //string martsstat = maritalstatus.SelectedValue.ToString();
            //string hiemon = hiredatemonth.Text.ToString();
            //string hiedat = hiredatedate.Text.ToString();
            //string hieyea = hiredateyear.Text.ToString();
            //string hiredate = hiemon + "/" + hiedat + "/" + hieyea;
            //string termmon = terminationmonth.Text.ToString();
            //string termdat = terminationdate.Text.ToString();
            //string termyea = terminationyear.Text.ToString();
            //string emergcontname = emergencyname.Text.ToString();
            //string emercontphn = emergencyphone.Text.ToString();
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT LName, FName, MInitial, dob, gender, marital_status, address, city, state, zipcode, home_email, cell_phone, emergency_contact, emergency_phone, hire_date, term_date, department, supportgroupcontact,doctorname,doctornumber FROM web_users where Pernr = @empid", con);
            cmd.Parameters.AddWithValue("@empid", Session["empid"].ToString());
            try
            {
                con.Open();

                SqlDataReader sqlReader = cmd.ExecuteReader();
                while (sqlReader.Read())
                {
                    lastname.Text = sqlReader["LName"].ToString();
                    firstname.Text = sqlReader["FName"].ToString();
                    middlename.Text = sqlReader["MInitial"].ToString();
                    dob.Text = sqlReader["dob"].ToString();
                    ddlGender.SelectedItem.Text = sqlReader["gender"].ToString();
                    maritalstatus.SelectedItem.Text = sqlReader["marital_status"].ToString();
                    address.Text = sqlReader["address"].ToString();
                    city.Text = sqlReader["city"].ToString();
                    state.Text = sqlReader["state"].ToString();
                    zip.Text = sqlReader["zipcode"].ToString();
                    email.Text = sqlReader["home_email"].ToString();
                    cellphone.Text = sqlReader["cell_phone"].ToString();
                    emergencycontactname.Text = sqlReader["emergency_contact"].ToString();
                    emergencyphone.Text = sqlReader["emergency_phone"].ToString();
                    hiredate.Text = sqlReader["hire_date"].ToString();
                    terminationdate.Text = sqlReader["term_date"].ToString();
                    department.Text = sqlReader["department"].ToString();
                    support_group_number.Text = sqlReader["supportgroupcontact"].ToString();
                    doctorname.Text = sqlReader["doctorname"].ToString();
                    doctorphone.Text = sqlReader["doctornumber"].ToString();


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

    protected void save_button_Click(object sender, EventArgs e)
    {
        SqlConnection constr = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand("UPDATE web_users SET LName = @lname, FName = @fnme, MInitial = @mname, dob = @dob, gender = @gend, marital_status = @marStat, address = @add, city = @city, state = @state, zipcode = @zip, home_email = @email, cell_phone = @cellphone, emergency_contact=@emergency_contact, emergency_phone = @emergphn, hire_date = @hirdat, term_date = @termdate, department = @deprt, supportgroupcontact = @supportgroupcontact,doctorname=@doctorname,doctornumber=@doctornumber where Pernr = @empid", constr);
        try
        {

            constr.Open();
            cmd.Parameters.AddWithValue("emergency_contact", emergencycontactname.Text.ToString());
            cmd.Parameters.AddWithValue("doctornumber", doctorphone.Text.ToString());
            cmd.Parameters.AddWithValue("doctorname", doctorname.Text.ToString());
            cmd.Parameters.AddWithValue("@lname", lastname.Text.Trim());
            cmd.Parameters.AddWithValue("@fnme", firstname.Text.Trim());
            cmd.Parameters.AddWithValue("@mname", middlename.Text.Trim());
            cmd.Parameters.AddWithValue("@dob", dob.Text.Trim());
            cmd.Parameters.AddWithValue("@gend", ddlGender.SelectedItem.Text.Trim());
            cmd.Parameters.AddWithValue("@marStat", maritalstatus.SelectedItem.Text.Trim());
            cmd.Parameters.AddWithValue("@add", address.Text.Trim());
            cmd.Parameters.AddWithValue("@city", city.Text.Trim());
            cmd.Parameters.AddWithValue("@state", state.Text.Trim());
            cmd.Parameters.AddWithValue("@zip", zip.Text.Trim());
            cmd.Parameters.AddWithValue("@email", email.Text.Trim());
            cmd.Parameters.AddWithValue("@cellphone", cellphone.Text.Trim());
          //  cmd.Parameters.AddWithValue("@emergname", emergencyname.Text.Trim());
            cmd.Parameters.AddWithValue("@emergphn", emergencyphone.Text.Trim());
            cmd.Parameters.AddWithValue("@hirdat", hiredate.Text.Trim());
            cmd.Parameters.AddWithValue("@termdate", terminationdate.Text.Trim());
            cmd.Parameters.AddWithValue("@deprt", department.Text.Trim());
            cmd.Parameters.AddWithValue("@supportgroupcontact", support_group_number.Text.Trim());
            cmd.Parameters.AddWithValue("@empid", Session["empid"]);
            //cmd.Connection = con;
          int a= cmd.ExecuteNonQuery();
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