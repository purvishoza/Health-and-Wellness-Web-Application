using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Text;
using System.Security.Cryptography;
using System.Xml;
using System.IO;
using System.Web.Script.Serialization;
using Ionic.Zip;

    public partial class Fitness_Records : System.Web.UI.Page
    {

    protected void Page_Load(object sender, EventArgs e)
    {
        empnamehealthPage.Text = Session["EmployeeName"].ToString();

        string inputData = Request.QueryString["name"];
        if (inputData != null)
        {
            ViewRecord(inputData);
        }
    }

    public string BindData()
    {
        string htmlstr = "";
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        DataTable dt = new DataTable();
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select Name, Id, Date from Documents_employee where employee_id = '"+Session["id_health"].ToString()+"'";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row1 in dt.Rows)
                    {
                        htmlstr += "<tr><td class='sel'>" + row1["Name"] + "</td><td>"+row1["Date"]+"</td><td class='text-center'><input type = 'checkbox' class='remove' value = '" + row1["Id"] + "' runat='server' /></td></tr>";
                    }
                }
            }
        }
        return htmlstr;
    }

    [System.Web.Services.WebMethod]
    public static void SendMail(string data, string to, string msg) {
        
        byte[] bytes;
        string[] checkedVal = data.Split(',');
        string fileName;
        string att = "";
        MailMessage email = new MailMessage();
        Fitness_Records emp = new Fitness_Records();

            email.To.Add(to);
            email.From = new MailAddress("fitnessnasa@gmail.com");

        email.Subject = "Medical Records of "+HttpContext.Current.Session["EmployeeName"].ToString()+"for review.";
            email.Body = msg;

            foreach (string id in checkedVal)
            {
                        string constr = System.Configuration.ConfigurationManager
            .ConnectionStrings["SqlConnectionString"].ConnectionString;
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                //Use value in Select statement
                                cmd.CommandText = "SELECT Name, ContentType, Data from Medicalrecords where Id = '" + id + "'";
                                cmd.Connection = con;
                                con.Open();
                                using (SqlDataReader sdr = cmd.ExecuteReader())
                                {
                                    //Get CV Data
                                    sdr.Read();
                                    bytes = (byte[])sdr["Data"];
                                    fileName = sdr["Name"].ToString();

                                    //This works if files are stored in folder instead of the below code
                                    //Attachment resume = new Attachment(Server.MapPath(VirtualPathUtility.ToAbsolute("~/images/cv/" + fileName)));

                                    //Attach Data as Email Attachment
                                    MemoryStream pdf = new MemoryStream(bytes);
                                    Attachment data1 = new Attachment(pdf, fileName);
                                    email.Attachments.Add(data1);
                                    att += fileName + " ; ";
                                }
                                con.Close();
                            }
                        }

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("fitnessnasa@gmail.com", "nasafitnessadmin");
            smtp.Port = 587;
            smtp.Send(email);


            //-------------------Employee Mail-----------------//
            string sql = "select * from web_users where Pernr='" + HttpContext.Current.Session["id_health"].ToString() + "'";
            SqlCommand cmd1 = new SqlCommand(sql);
            DataTable dt = emp.GetData(cmd1);

            string strQuery = "insert into Email_loggings(Name, Date, Time, Subject, Body, Attachment, employee_id, To_mail)" +
                  " values (@Name, @Date, @Time, @Subject, @Body, @Attachment, @employee_id, @To_mail)";
            SqlCommand cmd3 = new SqlCommand(strQuery);
            cmd3.Parameters.Add("@Name", SqlDbType.NVarChar).Value = dt.Rows[0]["FName"].ToString() + " " + dt.Rows[0]["LName"].ToString();
            cmd3.Parameters.Add("@Date", SqlDbType.NVarChar).Value = DateTime.Now.ToString("MM-dd-yyyy");
            cmd3.Parameters.Add("@Time", SqlDbType.NVarChar).Value = DateTime.Now.ToString("HH:mm");
            cmd3.Parameters.Add("@Subject", SqlDbType.NVarChar).Value = "Medical Records of " + HttpContext.Current.Session["EmployeeName"].ToString() + "for review.";
            cmd3.Parameters.Add("@Body", SqlDbType.NVarChar).Value = msg;
            cmd3.Parameters.Add("@Attachment", SqlDbType.NVarChar).Value = att;
            cmd3.Parameters.Add("@employee_id", SqlDbType.NVarChar).Value = HttpContext.Current.Session["id_health"].ToString();
            cmd3.Parameters.Add("@To_mail", SqlDbType.NVarChar).Value = to;
            emp.InsertUpdateData(cmd3);

        }
    }

    public string BindData1()
    {
        string htmlstr = "";
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        DataTable dt = new DataTable();
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select Name, Id from Medicalrecords";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row1 in dt.Rows)
                    {
                        htmlstr += "<tr><td class='sel1'>" + row1["Name"] + "</td><td class='text-center'><input type = 'checkbox' class='sel-att' value = '" + row1["Id"] + "' /></td></tr>";
                    }
                }
            }
        }
        return htmlstr;
    }

    private DataTable GetData(SqlCommand cmd)
    {
        DataTable dt = new DataTable();
        String strConnString = System.Configuration.ConfigurationManager
        .ConnectionStrings["SqlConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        SqlDataAdapter sda = new SqlDataAdapter();
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        try
        {
            con.Open();
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            return dt;
        }
        catch
        {
            return null;
        }
        finally
        {
            con.Close();
            sda.Dispose();
            con.Dispose();
        }
    }

    //protected void UploadButton_Click(object sender, EventArgs e)
    //{
    //  string filePath = FileUpload1.PostedFile.FileName;
    //  string filename = Path.GetFileName(filePath);
    //  string ext = Path.GetExtension(filename);


    //  string cmd = "select * from Documents_employee where Name ='" + filename + "'";
    //  SqlCommand sql = new SqlCommand(cmd);
    //  DataTable dt = GetData(sql);
    //  if (dt.Rows.Count > 0)
    //  {
    //      MessageBox("File already exists.");
    //  }
    //  else
    //  {
    //      string contenttype = String.Empty;

    //      //Set the contenttype based on File Extension
    //      switch (ext)
    //      {
    //          case ".doc":
    //              contenttype = "application/vnd.ms-word";
    //              break;
    //          case ".docx":
    //              contenttype = "application/vnd.ms-word";
    //              break;
    //          case ".xls":
    //              contenttype = "application/vnd.ms-excel";
    //              break;
    //          case ".xlsx":
    //              contenttype = "application/vnd.ms-excel";
    //              break;
    //          case ".jpg":
    //              contenttype = "image/jpg";
    //              break;
    //          case ".png":
    //              contenttype = "image/png";
    //              break;
    //          case ".gif":
    //              contenttype = "image/gif";
    //              break;
    //          case ".pdf":
    //              contenttype = "application/pdf";
    //              break;
    //          case ".pptx":
    //              contenttype = "application/x-mspowerpoint";
    //              break;
    //          case ".txt":
    //              contenttype = "text/plain";
    //              break;
    //          case ".rtf":
    //              contenttype = "application/rtf";
    //              break;
    //          default:
    //              MessageBox("Cannot accept this file format");
    //              break;


    //      }
    //      if (contenttype != String.Empty)
    //      {

    //          Stream fs = FileUpload1.PostedFile.InputStream;
    //          BinaryReader br = new BinaryReader(fs);
    //          Byte[] bytes = br.ReadBytes((Int32)fs.Length);

    //          //insert the file into database
    //          string strQuery = "insert into Documents_employee(employee_id, Name, ContentType, Data, Date)" +
    //             " values (@employee_id, @Name, @ContentType, @Data, @Date)";
    //          SqlCommand cmd2 = new SqlCommand(strQuery);
 //               cmd2.Parameters.Add("@employee_id", SqlDbType.VarChar).Value = Session["id_health"].ToString();
    //          cmd2.Parameters.Add("@Name", SqlDbType.VarChar).Value = filename;
    //          cmd2.Parameters.Add("@ContentType", SqlDbType.VarChar).Value
    //            = contenttype;
    //          cmd2.Parameters.Add("@Data", SqlDbType.VarBinary).Value = bytes;
 //               cmd2.Parameters.Add("@Date", SqlDbType.DateTime2).Value = filename;
    //          InsertUpdateData(cmd2);
    //          Response.Redirect("medical_menu.aspx");

    //      }
    //      else
    //      {

    //      }
    //  }

    //}

    private void MessageBox(string Message)
    {
        Label lblMessageBox = new Label();
        lblMessageBox.Text =
            "<script language='javascript'>" + Environment.NewLine +
            "window.alert('" + Message + "')</script>";
        Page.Controls.Add(lblMessageBox);
    }

    private Boolean InsertUpdateData(SqlCommand cmd)
    {
        String strConnString = System.Configuration.ConfigurationManager
        .ConnectionStrings["SqlConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
            return false;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }

    [System.Web.Services.WebMethod]
    public static string Delete(string ids)
    {
        if (ids.Equals("None"))
        {
            string constr = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand("DELETE FROM Documents_employee", con))
                    {
                        command.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
            catch (SystemException ex)
            {

            }
        }
        else
        {

            string constr = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand("DELETE FROM Documents_employee WHERE Id in (" + ids + ")", con))
                    {
                        command.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
            catch (SystemException ex)
            {

            }
        }
        return "true";
    }


    public void ViewRecord(string inputData)
    {

        string strQuery = "select Name, ContentType, Data from Documents_employee where Name = '" + inputData + "'";
        SqlCommand cmd = new SqlCommand(strQuery);
        DataTable dt = GetData(cmd);
        if (dt != null)
        {
            download(dt);
        }

    }

    private void download(DataTable dt)
    {

        // MessageBox(dt.Rows.Count.ToString());
        int i = 0;
        while (i < dt.Rows.Count)
        {
            Byte[] bytes = (Byte[])dt.Rows[i]["Data"];
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();
            File.WriteAllBytes(HttpContext.Current.Server.MapPath("~/pdffiles/" + dt.Rows[0]["Name"].ToString()), bytes);
            HttpContext.Current.Response.Charset = "";
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.ContentType = dt.Rows[i]["ContentType"].ToString();
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + dt.Rows[i]["Name"].ToString());
            HttpContext.Current.Response.BinaryWrite(bytes);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
            i++;
        }
    }
    }

