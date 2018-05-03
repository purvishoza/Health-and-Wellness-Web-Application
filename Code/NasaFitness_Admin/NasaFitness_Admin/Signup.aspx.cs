using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NasaFitness_Admin
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Signup_Click(object sender, EventArgs e)
        {
            if (user1.Text == "" || email.Text == "" || fname.Text == "" || lname.Text == "" || pass1.Text == "" || pass2.Text == "")
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
                        SqlCommand cmd = new SqlCommand("select * from admin where email='" + email.Text + "' or uname='" + user1.Text + "'", con);
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
                                    cmd1.CommandText = "insert into admin(uname, lname, fname, email, upass)" +
                               " values (@uname,@lname,@fname,@email,@upass)";

                                    cmd1.Parameters.Add("@uname", SqlDbType.VarChar).Value = user1.Text;
                                    cmd1.Parameters.Add("@lname", SqlDbType.VarChar).Value = lname.Text;
                                    cmd1.Parameters.Add("@fname", SqlDbType.VarChar).Value = fname.Text;
                                    cmd1.Parameters.Add("@email", SqlDbType.VarChar).Value = email.Text;
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
                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully Registered. Please Login into your Account'); window.location='Dashboard.aspx';", true);

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

        private void MessageBox(string Message)
        {
            Label lblMessageBox = new Label();
            lblMessageBox.Text =
                "<script language='javascript'>" + Environment.NewLine +
                "window.alert('" + Message + "')</script>";
            Page.Controls.Add(lblMessageBox);
        }
    }

}
