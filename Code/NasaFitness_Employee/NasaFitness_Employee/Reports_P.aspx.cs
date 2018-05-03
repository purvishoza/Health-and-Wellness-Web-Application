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

public partial class Reports_P : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        empName.Text = "Employee Name:&nbsp;" + Session["Empname"].ToString();
    }

    public string BindData3()
    {

        string htmlStr = "", answers = "";
        DataTable dt3 = this.GetData("SELECT *  FROM PARQ_Answers WHERE Date = (SELECT MAX(Date) FROM PARQ_Answers WHERE employee_id='" + Session["empid"].ToString() + "');");
        DataTable veena = this.GetData("select Questions from PARQ_Questions");
        foreach (DataRow row in dt3.Rows)
        {
            if (row["answer"] != null)
            {
                answers = row["answer"].ToString();
            }
            else
            {

            }
        }

        var arr = answers.Split(',');
        for (int i = 0; i < arr.Length; i++)
        {
            htmlStr += "<tr><td>" + veena.Rows[i]["Questions"] + "</td><td>" + arr[i] + "</td></tr>";
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
        }
        return dt1;
    }


    private void MessageBox(string Message)
    {
        Label lblMessageBox = new Label();
        lblMessageBox.Text =
            "<script language='javascript'>" + Environment.NewLine +
                         "window.alert('" + Message + "');</script>";
        Page.Controls.Add(lblMessageBox);
    }

    protected void hello_Click(object sender, EventArgs e)
    {
        if (doctor.Text == "")
        {
            MessageBox("Enter E-mail Address");
        }
        else
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {

                    ppp.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(new Rectangle(288f, 144f), 10, 10, 10, 10);
                    pdfDoc.SetPageSize(iTextSharp.text.PageSize.A4);
                  //  pdfDoc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                        pdfDoc.Open();
                        htmlparser.Parse(sr);
                        pdfDoc.Close();
                        byte[] bytes = memoryStream.ToArray();
                        memoryStream.Close();
                        MailMessage mm = new MailMessage();

                        mm.To.Add(doctor.Text);
                        mm.From = new MailAddress("fitnessnasa@gmail.com");
                        mm.Subject = "Please review " + Session["Empname"].ToString() + "'s" + " Physical Readiness Fitness Questionnaire";

                        mm.Body = comments.Text;

                        mm.Attachments.Add(new Attachment(new MemoryStream(bytes), "PARQ.pdf"));
                        mm.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        //System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                        //NetworkCred.UserName = mm.From.Address;
                        //NetworkCred.Password = "nasafitnessadmin";
                        //smtp.UseDefaultCredentials = true;
                        //smtp.Credentials = NetworkCred;
						smtp.Credentials = new System.Net.NetworkCredential("fitnessnasa@gmail.com", "nasafitnessadmin");
						smtp.Port = 587;
                        smtp.Send(mm);
                    }
                }
            }

            MessageBox("Mail sent to your Doctor");

        }
    }
}

