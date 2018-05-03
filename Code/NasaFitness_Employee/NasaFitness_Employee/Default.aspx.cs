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
        if (user1.Text == "" || email.Text == "" || fname.Text == "" || lname.Text == "" || pass1.Text == "" || pass2.Text == "" || phn.Text == "")
        {
            MessageBox("Please Enter All the Fields", 2);

        }
        else
        {
            if (pass1.Text.Equals(pass2.Text))
            {
                string cs = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from web_users where Pernr='" + email.Text + "' or uname='" + user1.Text + "'", con);
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
                           " values (@home_email,@lname,@fname,@uname,@upass)";

                                cmd1.Parameters.Add("@home_email", SqlDbType.VarChar).Value = email.Text;
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
                        MessageBox("User already exists with this account. Please go and login", 1);
                    }

                }
            }
            else
            {
                MessageBox("Password and Repeat Password Should be same", 2);
            }

        }

        Server.Transfer("PersonalInfo1.aspx");

    }

    protected void logIn(object sender, EventArgs e)
    {
        string probname = " ";
        string monthplanstartdate = " ";
        string minigoaldate = " ";
        string mealprobname = " ";
        if (user.Text == "" || pass.Text == "")
        {
            MessageBox("Please Enter all Fields", 1);

        }
        else
        {
            string cs = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from web_users where uname='" + user.Text + "' and upass='" + pass.Text + "'", con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                if (dt.Rows.Count <= 0)
                {
                    MessageBox("It appears this user is not in our database. Please Sign Up", 1);
                }
                else
                {
                    Session["empid"] = dt.Rows[0]["Pernr"];
                    Session["Empname"] = dt.Rows[0]["FName"] + " " + dt.Rows[0]["LName"];
                    // MessageBox(Session["empid"].ToString() + " " + Session["Empname"].ToString());


                    //Vihitha --- start

                    DateTime current = DateTime.Now;
                    string current1 = current.ToString("yyyy-MM-dd HH:mm:ss.fffffff");
                    DateTime current_time = Convert.ToDateTime(current1);

                    SqlConnection con3 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);
                    SqlCommand cmd3 = new SqlCommand("select max(EmpLastLogin) from Dashboard_Emp  where  EmpId = '" + Session["empid"].ToString() + "'", con3);

                    try
                    {
                        con3.Open();
                        SqlDataReader sqlReader1 = cmd3.ExecuteReader();
                        if (sqlReader1.Read())
                        {
                            string tempdate = sqlReader1[0].ToString();
                            DateTime lastlogin = Convert.ToDateTime(tempdate);
                            string sessionLastLogin = lastlogin.ToString("yyyy-MM-dd HH:mm:ss");

                            Session["emplastlogin"] = sessionLastLogin;
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex);
                    }
                    finally
                    {
                        con3.Close();
                    }

                    SqlConnection con4 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);
                    SqlCommand cmd4 = new SqlCommand();

                    cmd4.CommandText = "select * from HealthLogging where Employee_Id ='" + Session["empid"].ToString() + "'";
                    cmd4.CommandType = CommandType.Text;
                    cmd4.Connection = con4;
                    con4.Open();

                    DataTable dt1 = new DataTable();
                    SqlDataAdapter adapter1 = new SqlDataAdapter(cmd4);
                    adapter1.Fill(dt1);

                    if (dt1.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt1.Rows)
                        {

                            string tempdate1 = row["ReviewDate"].ToString();
                            DateTime reviewdate = Convert.ToDateTime(tempdate1);
                            DateTime temp1 = Convert.ToDateTime(Session["emplastlogin"]);

                            if (reviewdate > temp1)
                            {
                                probname = row["ProblemName"].ToString();
                                monthplanstartdate = row["MonthlyPlanStartDate"].ToString();
                                minigoaldate = row["MiniGoalDate"].ToString();

                                Session["probname"] += probname + ",";
                                Session["monthplanstartdate"] += monthplanstartdate + ",";
                                Session["minigoaldate"] += minigoaldate + ",";
                            }


                        }
                    }


                    SqlConnection con5 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);
                    SqlCommand cmd5 = new SqlCommand();
                    cmd5.CommandText = "select * from MealPlanPrescribed where employee_id = '" + Session["empid"].ToString() + "' ";
                    cmd5.CommandType = CommandType.Text;
                    cmd5.Connection = con5;
                    try
                    {
                        con5.Open();
                        DataTable dt2 = new DataTable();
                        SqlDataAdapter adapter2 = new SqlDataAdapter(cmd5);
                        adapter2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {
                            foreach (DataRow row1 in dt2.Rows)
                            {
                                string tempdate2 = row1["problemreviewdate"].ToString();
                                DateTime problemreviewdate = Convert.ToDateTime(tempdate2);
                                DateTime temp2 = Convert.ToDateTime(Session["emplastlogin"]);

                                if (problemreviewdate > temp2)
                                {
                                    mealprobname = row1["MealProblemName"].ToString();
                                    Session["mealprobname"] += mealprobname + ",";
                                }

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex);
                    }
                    finally
                    {
                        con5.Close();
                    }



                    SqlConnection con6 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);
                    SqlCommand cmd6 = new SqlCommand();
                    cmd6.CommandText = "SELECT * FROM FitnessTesting WHERE employee_id = '" + Session["empid"].ToString() + "' and date = (SELECT MAX(date) FROM FitnessTesting WHERE employee_id = '" + Session["empid"].ToString() + "')";
                    cmd6.CommandType = CommandType.Text;
                    cmd6.Connection = con6;
                    try
                    {

                        con6.Open();

                        DataTable dt3 = new DataTable();
                        SqlDataAdapter adapter3 = new SqlDataAdapter(cmd6);
                        adapter3.Fill(dt3);
                        if (dt3.Rows.Count > 0)
                        {
                            foreach (DataRow row2 in dt3.Rows)
                            {
                                string hrate = row2["heart_rate"].ToString();
                                Session["hrate"] = row2["heart_rate"].ToString();
                                Session["blood_pressure1"] = row2["blood_pressure"].ToString();
                                Session["blood_pressure2"] = row2["blood_pressure2"].ToString();
                                Session["bmi"] = row2["bmi"].ToString();

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex);
                    }
                    finally
                    {
                        con6.Close();
                    }


                    //string cs1 = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
                    //using (SqlConnection con2 = new SqlConnection(cs1))
                    //{
                    //    SqlCommand cmd2 = new SqlCommand("insert into Dashboard_Emp(EmpId, EmpLastLogin )" + "values(@EmpId, @EmpLastLogin)");

                    //    cmd2.Parameters.AddWithValue("@EmpId", SqlDbType.NVarChar).Value = Session["empid"];
                    //    cmd2.Parameters.AddWithValue("@EmpLastLogin", SqlDbType.DateTime2).Value = current_time;

                    //    cmd2.CommandType = CommandType.Text;
                    //    cmd2.Connection = con2;
                    //    con2.Open();
                    //    cmd2.ExecuteNonQuery();
                    //    con2.Close();

                    //}



                    Response.Redirect("PersonalInfo1.aspx");
                }
                con.Close();
            }
        }
       
    }

    protected void Recovery_Click(object sender, EventArgs e)
    {
        if (recovery.Text == "")
        {
            MessageBox("Please Enter  the Field", 1);

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
                    SqlCommand cmd = new SqlCommand("SELECT uname, upass FROM web_users Where Pernr= '" + recovery.Text.Trim() + "'", con);
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

                            MessageBox("Error", 2);

                        }
                    }
                    else
                    {
                        MessageBox("This email address is not in our database", 3);
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
    private void MessageBox(string Message, int op)
    {
        if (op == 1)
        {
            Label lblMessageBox = new Label();
            lblMessageBox.Text =
                "<script language='javascript'>" + Environment.NewLine +
                             "alert('" + Message + "');" + Environment.NewLine + "$('#tab-1').attr('checked', true);</script>";
            Page.Controls.Add(lblMessageBox);
        }
        else if(op == 2)
        {
            Label lblMessageBox = new Label();
            lblMessageBox.Text =
                "<script language='javascript'>" + Environment.NewLine +
                             "alert('" + Message + "');" + Environment.NewLine + "$('#tab-2').attr('checked', true);</script>";
            Page.Controls.Add(lblMessageBox);
        } else
        {
            recovery.Text = "";
            Label lblMessageBox = new Label();
            lblMessageBox.Text =
                "<script language='javascript'>" + Environment.NewLine +
                             "alert('" + Message + "');</script>";
            Page.Controls.Add(lblMessageBox);
        }


    }
}