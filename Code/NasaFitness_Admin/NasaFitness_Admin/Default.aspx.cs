using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;



public partial class _Default : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        

    }
    protected void signUP(object sender, EventArgs e)
    {
        if (user1.Text == "" || empid.Text == "" || fname.Text == "" || lname.Text == "" || pass1.Text == "" || pass2.Text == "")
        {
            MessageBox("Please Enter All the Fields");
        }
        else
        {
            if (pass1.Text.Equals(pass2.Text))
            {
                string cs = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from web_users where Pernr='" + empid.Text + "' or uname='" + user1.Text + "'", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    DataTable dt = new DataTable();

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    if (dt.Rows.Count <= 0)
                    {
                        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
                        using (SqlConnection con1 = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd1 = new SqlCommand())
                            {
                                //Use value in Select statement
                                cmd1.CommandText = "insert into web_users(Pernr, LName, Fname, uname, upass)" +
                           " values (@id,@lname,@fname,@uname,@upass)";

                                cmd1.Parameters.Add("@id", SqlDbType.VarChar).Value = empid.Text;
                                cmd1.Parameters.Add("@lname", SqlDbType.VarChar).Value = lname.Text;
                                cmd1.Parameters.Add("@fname", SqlDbType.VarChar).Value = fname.Text;
                                cmd1.Parameters.Add("@uname", SqlDbType.VarChar).Value = user1.Text;
                                cmd1.Parameters.Add("@upass", SqlDbType.VarChar).Value = pass1.Text;
                                cmd1.CommandType = CommandType.Text;
                                cmd1.Connection = con;
                                con1.Open();
                                int a = cmd1.ExecuteNonQuery();
                                con1.Close();
                                if (a == 0)
                                {

                                }
                                else
                                {
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully Registered. Please Login into your Account'); window.location='Default.aspx';", true);

                                }
                                con.Close();
                            }

                        }
                    }
                    else
                    {
                        MessageBox("User already exists with this account. Please go and login");
                    }

                }
            }
            else
            {
                MessageBox("Password and Repeat Password Should be same");
            }

        }



    }

    protected void logIn(object sender, EventArgs e)
    {
        if (user.Text == "" || pass.Text == "")
        {
            MessageBox("Please Enter all Fields");

        }
        /* if (user.Text == "admin" || pass.Text == "admin")
         {
             Response.Redirect("Problem_list.aspx");
         }*/
        else

        {
            string cs = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                if (user.Text == "admin")
                {
                    Session["admin"] = "admin";
                } else
                {
                    Session["admin"] = "other";
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from admin where uname = '" + user.Text + "' and upass = '" + pass.Text + "'", con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    MessageBox("It appears this user is not in our database. Please click Register Now Link");
                }
                else
                {

                    Dashboard();
                }
                con.Close();
            }

        }
    }

    public void Dashboard()
    {
        DateTime current = DateTime.Now;
        string current1 = current.ToString("yyyy-MM-dd HH:mm:ss.fffffff");
        

        DateTime current_time = Convert.ToDateTime(current1);
        SqlConnection con1 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);
        SqlCommand cmd3 = new SqlCommand("select * from Dashboard where LastLogin = (select max(LastLogin) from Dashboard)", con1);

        try
        {
            con1.Open();
            SqlDataReader sqlReader = cmd3.ExecuteReader();
            if (sqlReader.Read())
            {
                string tempdate = sqlReader["LastLogin"].ToString();
                string tempncases = sqlReader["NewCases"].ToString();
                string tempnusers = sqlReader["NoofPatients"].ToString();
                DateTime lastlogin = Convert.ToDateTime(tempdate);
                TimeSpan span = current_time.Subtract(lastlogin);
                string sessionLastLogin = lastlogin.ToString("yyyy-MM-dd HH:mm:ss");
                
                Session["lastlogin"] = sessionLastLogin;


                if (lastlogin < current_time)
                {
                    int recentCasesCount = Convert.ToInt32(Session["newhealth"]) - Convert.ToInt32(tempncases);
                    int recentUsersCount = Convert.ToInt32(Session["noofpatients"]) - Convert.ToInt32(tempnusers);
                    Session["recentCasesCount"] = recentCasesCount;
                    Session["recentUsersCount"] = recentUsersCount;
                }


            }
        }
        catch (Exception ex)
        {
            Response.Write(ex);
        }
        finally
        {
            con1.Close();
        }

        SqlConnection con2 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);
        SqlCommand cmd4 = new SqlCommand("select max(QuestionnaireDate) from HealthQuestionnaire", con2);
        try
        {
            con2.Open();
            SqlDataReader sqlReader = cmd4.ExecuteReader();
            if (sqlReader.Read())
            {
                string temphealth = sqlReader[0].ToString();
                DateTime lastentry = Convert.ToDateTime(temphealth);
                //TimeSpan span1 = current_time.Subtract(lastentry);
                //int days1 = span1.Days;
                //int hours1 = span1.Hours;
                //int minutes1 = span1.Minutes;
                //Session["days1"] = days1;
                //Session["hours1"] = hours1;
                //Session["minutes1"] = minutes1;
                Session["lastentry"] = lastentry;

            }
        }
        catch (Exception ex)
        {
            Response.Write(ex);
        }
        finally
        {
            con2.Close();
        }

        SqlConnection con3 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);
        SqlCommand cmd5 = new SqlCommand();
        cmd5.CommandText = "select * from HealthQuestionnaire where QuestionnaireDate > '" + Session["lastlogin"].ToString() + "'";
        //cmd5.Parameters.AddWithValue("@lastentry", lastlogin);
        cmd5.CommandType = CommandType.Text;
        cmd5.Connection = con3;
        con3.Open();
        DataTable dt = new DataTable();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd5);
        adapter.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            int newhealthpatients = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["P_Headache_DT"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Headache"]) == 0)
                {
                    newhealthpatients++;
                }

                if (dt.Rows[i]["P_Neck_Shoulder_DT"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["NeckPain"]) == 0)
                {
                    newhealthpatients++;
                }

                if (dt.Rows[i]["P_Upp_EXT_DT"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Arms_Hands_Pain"]) == 0)
                {
                    newhealthpatients++;
                }

                if (dt.Rows[i]["P_BTW_Shoulder_DT"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["ShoulderBladePain"]) == 0)
                {
                    newhealthpatients++;
                }

                if (dt.Rows[i]["P_LBack_DT"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["LowBackPain"]) == 0)
                {
                    newhealthpatients++;
                }
                if (dt.Rows[i]["P_L_EXT_DT"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[i]["Legs_Feet_Pain_Numbness"]) == 0)
                {
                    newhealthpatients++;
                }
            }
            Session["newhealthpatients"] = newhealthpatients;
            con3.Close();
        }
        else
        {
            Session["newhealthpatients"] = 0;
            con3.Close();
        }


        SqlConnection con4 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);
        SqlCommand cmd6 = new SqlCommand();
        cmd6.CommandText = "select * from Questionnaire_Fitness where QuestionnaireDate_Fitness > '" + Session["lastlogin"].ToString() + "'";
        cmd6.Connection = con4;
        con4.Open();
        DataTable dt1 = new DataTable();
        SqlDataAdapter adapter2 = new SqlDataAdapter(cmd6);
        adapter2.Fill(dt1);
        int newfitnesspatients = 0;
        if (dt1.Rows.Count > 0)
        {
            for (int j = 0; j < dt1.Rows.Count; j++)
            {
                if (dt1.Rows[j]["I_Eating_DP"].ToString().Equals("True") && Convert.ToInt16(dt1.Rows[j]["Nutrition_Eating"]) == 0)
                {
                    newfitnesspatients++;

                }

                if (dt1.Rows[j]["I_Fitness_DP"].ToString().Equals("True") && Convert.ToInt16(dt1.Rows[j]["Exercise_Fitness"]) == 0)
                {
                    newfitnesspatients++;

                }

                if (dt1.Rows[j]["I_WeightMgmt_DP"].ToString().Equals("True") && Convert.ToInt16(dt1.Rows[j]["WeightManagement"]) == 0)
                {
                    newfitnesspatients++;

                }

                if (dt1.Rows[j]["I_Muscle_DP"].ToString().Equals("True") && Convert.ToInt16(dt1.Rows[j]["Muscle_Flexibility_Strength"]) == 0)
                {
                    newfitnesspatients++;

                }


                if (dt1.Rows[j]["I_StressMgmt_DP"].ToString().Equals("True") && Convert.ToInt16(dt1.Rows[j]["Stress_Management"]) == 0)
                {
                    newfitnesspatients++;

                }

                if (dt1.Rows[j]["I_Diabetes_DP"].ToString().Equals("True") && Convert.ToInt16(dt1.Rows[j]["Diabetes"]) == 0)
                {
                    newfitnesspatients++;

                }

                if (dt1.Rows[j]["I_SleepD_DP"].ToString().Equals("True") && Convert.ToInt16(dt.Rows[j]["Sleeping_Disturbance"]) == 0)
                {
                    newfitnesspatients++;

                }

                if (dt1.Rows[j]["I_ADDBeh_DP"].ToString().Equals("True") && Convert.ToInt16(dt1.Rows[j]["Addictive_Behaviour"]) == 0)
                {
                    newfitnesspatients++;

                }

                if (dt1.Rows[j]["I_HeartD_DP"].ToString().Equals("True") && Convert.ToInt16(dt1.Rows[j]["Cardiovascular_Heart"]) == 0)
                {
                    newfitnesspatients++;

                }

                if (dt1.Rows[j]["I_CancerD_DP"].ToString().Equals("True") && Convert.ToInt16(dt1.Rows[j]["Cancer"]) == 0)
                {
                    newfitnesspatients++;

                }

                if (dt1.Rows[j]["I_LabsD_DP"].ToString().Equals("True") && Convert.ToInt16(dt1.Rows[j]["Lab_Assessment_values_out_of_range"]) == 0)
                {
                    newfitnesspatients++;

                }


            }
            Session["newfitnesspatients"] = newfitnesspatients;
            con4.Close();
        }
        else
        {
            Session["newfitnesspatients"] = 0;
            con4.Close();
        }



        /*string cs = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd2 = new SqlCommand("insert into Dashboard(LastLogin, NewCases, NoofPatients)" + "values(@LastLogin, @NewCases, @NoofPatients)");
            cmd2.Parameters.AddWithValue("@LastLogin", SqlDbType.DateTime2).Value = current_time;
            cmd2.Parameters.AddWithValue("@NewCases", SqlDbType.Int).Value = Session["newhealth"];
            cmd2.Parameters.AddWithValue("@NoofPatients", SqlDbType.Int).Value = Session["noofpatients"];

            cmd2.CommandType = CommandType.Text;
            cmd2.Connection = con;
            con.Open();
            /cmd2.ExecuteNonQuery();
            con.Close();

        } */
        Response.Redirect("Dashboard.aspx");
    }

    protected void Recovery_Click(object sender, EventArgs e)
    {
        if (recovery.Text == "")
        {
            MessageBox("Please Enter the Field");
        }
        else
        {

            try
            {
                DataSet ds = new DataSet();
                string cs = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT uname, upass FROM admin Where email= '" + recovery.Text.Trim() + "'", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    SqlDataReader sr = cmd.ExecuteReader();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    if (sr.Read())
                    {

                        String msgTo = recovery.Text;
                        string name = sr["uname"].ToString();
                        string pwd = sr["upass"].ToString();

                        String msgSubject = "We have recovered your password!";

                        String msgBody = "Hi, <br/>Please check your Login Detailss<br/><br/>Your Username: " + name + "<br/><br/>Your Password: " + pwd + "<br/><br/>";

                        MailMessage mailObj = new MailMessage();

                        mailObj.Body = msgBody;

                        mailObj.From = new MailAddress("wadsp17@gmail.com", "NASA Fitness LLC");

                        mailObj.To.Add(new MailAddress(msgTo));

                        mailObj.Subject = msgSubject;

                        mailObj.IsBodyHtml = true;

                        SmtpClient SMTPClient = new SmtpClient();

                        SMTPClient.Host = "smtp.gmail.com";

                        SMTPClient.Port = 587;

                        SMTPClient.Credentials = new NetworkCredential("wadsp17@gmail.com", "wad@2017");

                        SMTPClient.EnableSsl = true;

                        try

                        {

                            SMTPClient.Send(mailObj);

                            ClientScript.RegisterStartupScript(this.GetType(), "callfunction", "alert('We have sent a mail to your registered mail id. Thank You')", true);



                        }

                        catch (Exception)

                        {

                            MessageBox("Error");

                        }
                    }
                    else
                    {
                        MessageBox("This is not in our database.");
                    }

                    con.Close();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
        }
    }
    private void MessageBox(string Message)
    {
        recovery.Text = " ";
        Label lblMessageBox = new Label();
        lblMessageBox.Text =
            "<script language='javascript'>" + Environment.NewLine +
            "window.alert('" + Message + "')</script>";
        Page.Controls.Add(lblMessageBox);
    }
}











