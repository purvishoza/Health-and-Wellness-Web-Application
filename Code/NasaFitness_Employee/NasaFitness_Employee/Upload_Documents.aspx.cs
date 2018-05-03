using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using iTextSharp.text;

using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Data.SqlTypes;

public partial class Upload_Documents : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            display_forms();

        }



    }
    protected void UploadButton_Click(object sender, EventArgs e)
    {
        
        string filePath = FileUpload1.PostedFile.FileName;
        string filename = Path.GetFileName(filePath);
        string ext = Path.GetExtension(filename);
        //string cmd = "select * from Documents_employee where employee_id = '" + Session["empid"].ToString() + "' and Name ='" + filename+ "'";
        //SqlCommand sql = new SqlCommand(cmd);
        //DataTable dt = GetData(sql);
        //if(dt.Rows.Count>0)
        //{
        //    MessageBox("File already exists.");
        //}
        //else
        //{
            string contenttype = String.Empty;

            //Set the contenttype based on File Extension
            switch (ext)
            {
                case ".doc":
                    contenttype = "application/vnd.ms-word";
                    break;
                case ".docx":
                    contenttype = "application/vnd.ms-word";
                    break;
                case ".xls":
                    contenttype = "application/vnd.ms-excel";
                    break;
                case ".xlsx":
                    contenttype = "application/vnd.ms-excel";
                    break;
                case ".jpg":
                    contenttype = "image/jpg";
                    break;
                case ".png":
                    contenttype = "image/png";
                    break;
                case ".gif":
                    contenttype = "image/gif";
                    break;
                case ".pdf":
                    contenttype = "application/pdf";
                    break;
                case ".txt":
                    contenttype = "text/plain";
                    break;
               case ".rtf":
                contenttype = "application/rtf";
                break;
              default:
                MessageBox("Cannot accept this file format");
                break;

        }
            if (contenttype != String.Empty)
            {

                Stream fs = FileUpload1.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(fs);
                Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                //insert the file into database
                string strQuery = "insert into Documents_employee(employee_id, Name, ContentType, Data, Date)" +
                   " values (@employee_id, @Name, @ContentType, @Data, @Date)";
                SqlCommand cmd2= new SqlCommand(strQuery);
                cmd2.Parameters.Add("@employee_id", SqlDbType.NVarChar).Value = Session["empid"].ToString();
                cmd2.Parameters.Add("@Name", SqlDbType.NVarChar).Value = filename;
                cmd2.Parameters.Add("@ContentType", SqlDbType.NVarChar).Value = contenttype;
                cmd2.Parameters.Add("@Data", SqlDbType.Binary).Value = bytes;
                cmd2.Parameters.Add("@Date", SqlDbType.NVarChar).Value = DateTime.Now.ToString();
                InsertUpdateData(cmd2);
                display_forms();

            }
            else
            {

            }
            Response.Redirect(Request.Url.AbsoluteUri);


        //}

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
            int a = cmd.ExecuteNonQuery();
            if (a<0)
            {
                MessageBox("Fail");
            }
            else
            {
                MessageBox("true");
            }
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
    protected void remove_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridView1.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = (row.Cells[1].FindControl("chkRow") as CheckBox);

                if (chkRow.Checked)
                {

                    string da = row.Cells[1].Text;
                    string name = row.Cells[0].Text;
                  
                    string constr = System.Configuration.ConfigurationManager
       .ConnectionStrings["SqlConnectionString"].ConnectionString;
                    try
                    {
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            con.Open();
                            using (SqlCommand command = new SqlCommand("DELETE FROM Documents_employee WHERE Name = '" + name + "' AND Date = '"+ da +"'", con))
                            {
                               
                                int a = command.ExecuteNonQuery();
                                //if(a > 0)
                                //{

                                //}
                                //else
                                //{
                                //    MessageBox("Error");
                                //}
                                display_forms();
                            }
                            con.Close();
                        }
                    }
                    catch (SystemException ex)
                    {

                    }
                }
            }
        }

    }
    public void display_forms()
    {
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataSet ds = new DataSet();
        string sql = null;
       
        string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        sql = "select Id, Name, Date from Documents_employee where employee_id='" + Session["empid"].ToString() + "' ORDER BY Date DESC";
        SqlConnection connection = new SqlConnection(connetionString);
        connection.Open();
        SqlCommand command = new SqlCommand(sql, connection);
        adapter.SelectCommand = command;
        adapter.Fill(ds);
        adapter.Dispose();
        command.Dispose();
        connection.Close();
        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();
       
       
    }
   
   
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        display_forms();
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
    private void download(DataTable dt)
    {
       
        int i = 0;
        while (i < dt.Rows.Count)
        {
            Byte[] bytes = (Byte[])dt.Rows[i]["Data"];
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = dt.Rows[i]["ContentType"].ToString();
            Response.AddHeader("content-disposition", "attachment;filename="
            + dt.Rows[i]["Name"].ToString());
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
            i++;
        }

    }
    protected void Unnamed_Click(object sender, EventArgs e)
    {
        GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
        int index = gvRow.RowIndex;
        string Name = gvRow.Cells[0].Text;
        string da = gvRow.Cells[1].Text;
       // MessageBox(Name);
        string strQuery = "select Id, Name, ContentType, Data from Documents_employee where Name = @Name AND Date = '"+ da +"'";
        SqlCommand cmd = new SqlCommand(strQuery);
        cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = Name;
        DataTable dt = GetData(cmd);
        string temp = dt.Rows[0]["ContentType"].ToString();


        if (temp.Equals("application/pdf"))
        {
            int id = int.Parse((sender as LinkButton).CommandArgument);
            string embed = "<object data=\"{0}{1}\"  type=\"application/pdf\" width=\"500px\" height=\"600px\">";
            embed += "If you are unable to view file, you can download from <a href = \"{0}{1}&download=1\">here</a>";
            embed += " or download <a target = \"_blank\" href = \"http://get.adobe.com/reader/\">Adobe PDF Reader</a> to view the file.";
            embed += "</object>";
            displayfile.Text = Name;
            displayfile.Visible = true;
            ltEmbed.Text = string.Format(embed, ResolveUrl("Documents.ashx?Id="), id);

        }

        else
        {
            download(dt);
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