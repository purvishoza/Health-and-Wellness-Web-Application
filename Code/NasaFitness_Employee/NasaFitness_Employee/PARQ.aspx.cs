using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Net;
using System.Net.Mail;
using System.Configuration;


public partial class PARQ : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["dis"] != null)
        {
            if (Session["dis"].ToString() == "none")
            {
                Button3.Visible = true;
                Session["dis"] = "other";
            }
            else
            {
                Button3.Visible = false;
            }
        }
       
    }

    protected void Mail_Click(object sender, EventArgs e)
    {
        Response.Redirect("Reports_P.aspx");
    }
   
    public void PARQ_save_Click(object sender, EventArgs e)
    {
        
        string answers = "";
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;

       answers = RadioButtonList1.Text + "," + RadioButtonList2.Text + "," + RadioButtonList3.Text + "," + RadioButtonList4.Text + "," + RadioButtonList5.Text + "," + RadioButtonList6.Text + "," + RadioButtonList7.Text + "," + RadioButtonList8.Text + "," + RadioButtonList9.Text + "," + RadioButtonList10.Text + "," + RadioButtonList11.Text;
        using (SqlConnection con = new SqlConnection(cs))
        {

            SqlCommand cmd = new SqlCommand("insert into PARQ_Answers(employee_id, Date, answer)" +
          " values (@employee_id, @Date, @answer)");


            cmd.Parameters.Add("@employee_id", SqlDbType.NVarChar).Value = Convert.ToString(HttpContext.Current.Session["empid"]);
            cmd.Parameters.Add("@Date", SqlDbType.DateTime2).Value = DateTime.Now;
            cmd.Parameters.Add("@answer", SqlDbType.NVarChar).Value = answers;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            int a = cmd.ExecuteNonQuery();

            if (a == 0)
            {
                MessageBox("OOPS! There is a problem with the database. Please try again after some time", 1);
            }
            else
            {
                if(answers.Contains("Yes")) {
					MessageBox("Your information will be sent to a Health Coach who will contact you to schedule an appointment to discuss your desired behavior changes. Thank You! ☺", 2);
                } else {
					MessageBox("Your information will be sent to a Health Coach who will contact you to schedule an appointment to discuss your desired behavior changes. Thank You! ☺", 0);

				}

            }
            con.Close();

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
        else if(op == 0)
        {
            Label lblMessageBox = new Label();
            lblMessageBox.Text =
                "<script language='javascript'>" + Environment.NewLine +
                             "window.alert('" + Message + "');" + Environment.NewLine + "window.location = 'PARQ.aspx';</script>";
            Page.Controls.Add(lblMessageBox);
        } else {
			Label lblMessageBox = new Label();
			lblMessageBox.Text =
				"<script language='javascript'>" + Environment.NewLine +
                             "window.alert('" + Message + "');" + Environment.NewLine + "window.location = 'PARQ.aspx';</script>";
            Session["dis"] = "none";
			Page.Controls.Add(lblMessageBox);
        }
    }

   
}
