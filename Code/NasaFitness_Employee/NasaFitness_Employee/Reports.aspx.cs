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

public partial class Reports : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        

    }

    public string BindData()
    {
        string htmlStr = "";
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                //Use value in Select statement
                cmd.CommandText = "SELECT *  FROM HealthQuestionnaire WHERE QuestionnaireDate=(SELECT MAX(QuestionnaireDate) FROM HealthQuestionnaire WHERE employee_id='"+Session["empid"].ToString()+"');";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    string headache_dt;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                       // htmlStr += "<tr><td>" + dt.Rows[i]["QuestionnaireDate"].ToString()+ "</td>";
                        if (dt.Rows[i]["P_Headache_DT"].ToString().Equals("True") || dt.Rows[i]["P_Headache_Past"].ToString().Equals("True") || dt.Rows[i]["P_Headache_Curr"].ToString().Equals("True"))
                        {
                            string headache_past = dt.Rows[i]["P_Headache_Past"].ToString();
                            string headache_curr = dt.Rows[i]["P_Headache_Curr"].ToString();
                            if (dt.Rows[i]["P_Headache_DT"].ToString().Equals("True"))
                            {
                                headache_dt = "Yes";
                            }
                            else
                            {
                                headache_dt = "No";
                            }

                            htmlStr += "<tr><td>Headache</td><td>" + headache_past + "</td><td>" + headache_curr + "</td><td>" + headache_dt + "</td></tr>";


                        }
                        if (dt.Rows[i]["P_Neck_Shoulder_DT"].ToString().Equals("True") || dt.Rows[i]["P_Neck_Shoulder_Past"].ToString().Equals("True") || dt.Rows[i]["P_Neck_Shoulder_Curr"].ToString().Equals("True"))
                        {
                            string neck_dt;
                            string neck_past = dt.Rows[i]["P_Neck_Shoulder_Past"].ToString();
                            string neck_curr = dt.Rows[i]["P_Neck_Shoulder_Curr"].ToString();
                            if (dt.Rows[i]["P_Neck_Shoulder_DT"].ToString().Equals("True"))
                            {
                                neck_dt = "Yes";
                            }
                            else
                            {
                                neck_dt = "No";
                            }
                            htmlStr += "<tr><td>Neck Pain</td><td>" + neck_past + "</td><td>" +neck_curr+ "</td><td>" + neck_dt +"</td></tr>";

                        }
                        if (dt.Rows[i]["P_Upp_EXT_DT"].ToString().Equals("True") || dt.Rows[i]["P_Upp_EXT_Past"].ToString().Equals("True") || dt.Rows[i]["P_Upp_EXT_Curr"].ToString().Equals("True"))
                        {
                            string upp_dt;
                            string upp_past = dt.Rows[i]["P_Upp_EXT_Past"].ToString();
                            string upp_curr = dt.Rows[i]["P_Upp_EXT_Curr"].ToString();
                            if (dt.Rows[i]["P_Upp_EXT_DT"].ToString().Equals("True"))
                            {
                                upp_dt = "Yes";
                            }
                            else
                            {
                                upp_dt = "No";
                            }
                            htmlStr += "<tr><td>Arms/Hand Pain/Numbness/Tingling</td><td>" + upp_past + "</td><td>" + upp_curr + "</td><td>" + upp_dt + "</td></tr>";

                        }
                        if (dt.Rows[i]["P_BTW_Shoulder_DT"].ToString().Equals("True") || dt.Rows[i]["P_BTW_Shoulder_Past"].ToString().Equals("True") || dt.Rows[i]["P_BTW_Shoulder_Curr"].ToString().Equals("True"))
                        {
                            string shoulder_dt;
                            string shoulder_past = dt.Rows[i]["P_BTW_Shoulder_Past"].ToString();
                            string shoulder_curr = dt.Rows[i]["P_BTW_Shoulder_Curr"].ToString();
                            if (dt.Rows[i]["P_BTW_Shoulder_DT"].ToString().Equals("True"))
                            {
                                shoulder_dt = "Yes";
                            }
                            else
                            {
                                shoulder_dt = "No";
                            }
                            htmlStr += "<tr><td>Shoulder Blade Pain</td><td>" + shoulder_past + "</td><td>" + shoulder_curr + "</td><td>" + shoulder_dt + "</td></tr>";

                        }

                        if (dt.Rows[i]["P_LBack_DT"].ToString().Equals("True") || dt.Rows[i]["P_LBack_Past"].ToString().Equals("True") || dt.Rows[i]["P_LBack_Curr"].ToString().Equals("True"))
                        {
                            string lback_dt;
                            string lback_past = dt.Rows[i]["P_LBack_Past"].ToString();
                            string lback_curr = dt.Rows[i]["P_LBack_Curr"].ToString();
                            if (dt.Rows[i]["P_LBack_DT"].ToString().Equals("True"))
                            {
                                lback_dt = "Yes";
                            }
                            else
                            {
                                lback_dt = "No";
                            }
                            htmlStr += "<tr><td>Low Back Pain</td><td>" + lback_past + "</td><td>" + lback_curr + "</td><td>" + lback_dt + "</td></tr>";

                        }
                        if (dt.Rows[i]["P_L_EXT_DT"].ToString().Equals("True") || dt.Rows[i]["P_L_EXT_Past"].ToString().Equals("True") || dt.Rows[i]["P_L_EXT_Curr"].ToString().Equals("True"))
                        {
                            string lext_dt;
                            string lext_past = dt.Rows[i]["P_L_EXT_Past"].ToString();
                            string lext_curr = dt.Rows[i]["P_L_EXT_Curr"].ToString();
                            if (dt.Rows[i]["P_L_EXT_DT"].ToString().Equals("True"))
                            {
                                lext_dt = "Yes";
                            }
                            else
                            {
                                lext_dt = "No";
                            }
                          
                            htmlStr += "<tr><td>Legs/Feet Pain, Numbness or Tingling</td><td>" + lext_past + "</td><td>" + lext_curr + "</td><td>" + lext_dt + "</td></tr>";
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
            "window.alert('" + Message + "')</script>";
        Page.Controls.Add(lblMessageBox);
    }

   
 }