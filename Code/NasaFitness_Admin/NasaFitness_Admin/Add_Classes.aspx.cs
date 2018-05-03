using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Spire.Presentation;
using System.Configuration;

public partial class Add_Classes : System.Web.UI.Page
{
    string finalname = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        string mon = (string)Session["month"];
        monthly.SelectedValue = mon;

        Label1.Visible = false;
      

    }

    protected void Upload_data(object sender, EventArgs e)
    {
        string month = monthly.SelectedValue;
        if (uploadppt.FileName == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please upload a PPT file');", true);
        }
        else
        {
            string week = weekly.SelectedValue;
            finalname = month + week;
            if (uploadppt.HasFile)
            {
                if (Path.GetExtension(uploadppt.FileName) == ".pptx" || Path.GetExtension(uploadppt.FileName) == ".ppt")
                {
                    uploadppt.SaveAs(HttpContext.Current.Server.MapPath("~/files/" + finalname + ".ppt"));
                    Label1.Text = "File Uploaded";
                    Label1.ForeColor = System.Drawing.Color.ForestGreen;

                    if (File.Exists(HttpContext.Current.Server.MapPath("~/files/" + finalname + ".ppt")))
                    {
                        Label1.Text = "File in server";
                        Label1.ForeColor = System.Drawing.Color.DarkOrange;
                        Presentation presentation = new Presentation();
                        presentation.LoadFromFile(HttpContext.Current.Server.MapPath("~/files/" + finalname + ".ppt"));
                        presentation.SaveToFile(HttpContext.Current.Server.MapPath("~/pdffiles/" + finalname + ".pdf"), FileFormat.PDF);
                        embedpdf.Attributes["src"] = "~/pdffiles/" + finalname + ".pdf";

                    }
                    else
                    {
                        Label1.Text = "File not in server";
                        Label1.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    Label1.Text = "Please Select your file";
                    Label1.ForeColor = System.Drawing.Color.Red;
                }



            }
        }
    }
    protected void UploadButton_Click(object sender, EventArgs e)
    {
        string fileName = "";
        string month = monthly.SelectedValue;
        string week = weekly.SelectedValue;
        finalname = month + week;
        if (f1.FileName == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please upload the video file');", true);
        }
      
        else
        {
            string strConnString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
            if (f1.PostedFile != null && f1.PostedFile.ContentLength > 0)
            {

                fileName = Path.GetFileName(f1.PostedFile.FileName);
                Session["fil"] = fileName;
                string folder = HttpContext.Current.Server.MapPath("~/FileVideos/");
                Directory.CreateDirectory(folder);
                f1.PostedFile.SaveAs(Path.Combine(folder, fileName));
                try
                {

                    // Response.Write("Uploaded: " + fileName);
                }
                catch
                {

                }
            }
            //Session["filx"] = Server.MapPath("~/Videos/" + fileName);


            string filename1;
            string filename2 = HttpContext.Current.Server.MapPath("~/FileVideos/" + Session["fil"].ToString());

            var ffMpeg = new NReco.VideoConverter.FFMpegConverter();

            string filename = Path.GetFileName(filename2);
            // string file = Path.GetFileName(file2);

            string[] str = filename.Split('.');
            //string temp = ofd.FileName;

            string oo = "Videos/" + str[0] + ".mp4";
            filename1 = Path.GetFileName(oo);
            ffMpeg.ConvertMedia(filename2, oo, NReco.VideoConverter.Format.mp4);



            string ext = Path.GetExtension(filename1);
            // Response.Write();
            string contenttype = String.Empty;





            //Set the contenttype based on File Extension
            switch (ext)
            {
                case ".mp4":
                    contenttype = "video/mp4";
                    break;
                case ".mp3":
                    contenttype = "video/mp3";
                    break;
                case ".wmv":
                    contenttype = "video/wmv";
                    break;
            }
            if (contenttype != String.Empty)
            {

                byte[] bytes = System.IO.File.ReadAllBytes(HttpContext.Current.Server.MapPath("~/Videos/" + filename1));

                //pradeep
                string valQuery = "select max(id) from PresentationVideos";  //pradeep
                SqlConnection con = new SqlConnection(strConnString);  //pradeep
                SqlCommand ncmd = new SqlCommand(valQuery, con); //pradeep
                con.Open(); //pradeep
                SqlDataReader dr = ncmd.ExecuteReader(); //pradeep
                dr.Read(); //pradeep
                int max = dr.GetInt32(0) + 1; //pradeep

                //insert the file into database
                string strQuery = "insert into PresentationVideos(Id,Name, ContentType, Data,MonthAndWeek)" +
                       " values (@Id,@Name, @ContentType, @Data,@MonthAndWeek)"; //pradeep
                SqlCommand cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = max; //pradeep
                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = filename1;
                cmd.Parameters.Add("@ContentType", SqlDbType.VarChar).Value = contenttype;
                cmd.Parameters.Add("@Data", SqlDbType.VarBinary).Value = bytes;
                cmd.Parameters.Add("@MonthAndWeek", SqlDbType.VarChar).Value = finalname;
                //string exerciseType = databasecategories.SelectedItem.Text.ToString();
                //if (exerciseType == "Select Video Category")
                //{
                //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select or create a category to add the new video');", true);
                //}
                //else
                //{
                //    cmd.Parameters.Add("@ExcerciseType", SqlDbType.VarChar).Value = exerciseType;
                InsertUpdateData(cmd);
                //    con.Close(); //pradeep
                //}

            }

        }
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
            if (a == 0)
            {
                 ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Fail');", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Success');", true);

            }
            //BindGrid();
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
    protected void Store_Modal_data(object sender, EventArgs e)
    {

        string month = monthly.SelectedValue;
        string week = weekly.SelectedValue;
        finalname = month + week;
        string ques = modalQuestion.Text;
        string ans = ModalRadioButtons.Text;
        modalQuestion.Text = "";
        ModalRadioButtons.SelectedValue = null;
        if (ques == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter the Question');", true);
            if (ans == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select either True or False');", true);
            }
        }
        else if (ans == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select either True or False');", true);
        }
        else
        {
            string q = "";
            string a = "";
            string cs = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {

                string quer = "select Questions, Answers from Presentation_QuestionsAnswers where id =" + finalname;
                SqlCommand cmd1 = new SqlCommand(quer, con);
                con.Open();
                SqlDataReader reader = cmd1.ExecuteReader();

                while (reader.Read())
                {
                    q = reader["Questions"].ToString();
                    a = reader["Answers"].ToString();
                }
                con.Close();
                q = q + "#" + ques;
                a = a + "," + ans;
                string qur2 = "UPDATE Presentation_QuestionsAnswers SET Answers='" + a + "', Questions ='" + q + "'Where id =" + finalname;
                SqlCommand cmd2 = new SqlCommand(qur2, con);
                con.Open();
                int r = cmd2.ExecuteNonQuery();
                con.Close();
                if (r < 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Not able to make changes. Please Verify');", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Updated Successfully');", true);
                }


            }
        }
    }
        protected void Store_data(object sender, EventArgs e)
    {
        string month = monthly.SelectedValue;
        string week = weekly.SelectedValue;
        finalname = month + week;
        string q1 = Question1.Text;
        string q2 = Question2.Text;
        string q3 = Question3.Text;
        string q4 = Question4.Text;
        string q5 = Question5.Text;
        string question = Question1.Text + "#" + Question2.Text + "#" + Question3.Text + "#" + Question4.Text + "#" + Question5.Text;
        string answer = Answer1.Text + "," + Answer2.Text + "," + Answer3.Text + "," + Answer4.Text + "," + Answer5.Text;

        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cs))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string qr = "select * from Presentation_QuestionsAnswers where Id=" + finalname;
               SqlCommand cmd2 = new SqlCommand(qr, con);
                //cmd.CommandText = "select * from Presentation_QuestionsAnswers where Id=@id";
                //cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = finalname;
                //cmd.CommandType = CommandType.Text;
                //cmd.Connection = con;
                con.Open();
                SqlDataReader reader = cmd2.ExecuteReader();

             
                
                if (reader.Read())
                {
                    con.Close();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('There is data already Existing for this particular week. Do you really need to insert new data??');", true);
                    if (Topic.Text == "")
                    {
                        con.Close();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter the topic details');", true);
                    }
                }
                else if(Topic.Text =="")
                {
                    con.Close();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter the topic details');", true);
                }
                else
                {
                    con.Close();
                    cmd.CommandText = "insert into Presentation_QuestionsAnswers(Id,Topic,Presentation, Questions, Answers) values (@id,@Topic,@Presentation,@Questions,@Answers)";
                    //cmd.CommandText = "UPDATE Weekly_Users SET Presentation = @Presentation, Answers= @Answer, Question1 = @Question1, Question2 = @Question2, Question3 = @Question3, Question4 = @Question4, Question5 = @Question5, Topic = @topic Where id = @id";
                    cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = finalname;
                    cmd.Parameters.Add("@Topic", SqlDbType.NVarChar).Value = Topic.Text;
                    cmd.Parameters.Add("@Presentation", SqlDbType.NVarChar).Value = finalname + ".pdf";
                    cmd.Parameters.Add("@Questions", SqlDbType.NVarChar).Value = question;
                    cmd.Parameters.Add("@Answers", SqlDbType.NVarChar).Value = answer;

                    //cmd.Parameters.Add("@Question2", SqlDbType.NVarChar).Value = q2;
                    //cmd.Parameters.Add("@Question3", SqlDbType.NVarChar).Value = q3;
                    //cmd.Parameters.Add("@Question4", SqlDbType.NVarChar).Value = q4;
                    //cmd.Parameters.Add("@Question5", SqlDbType.NVarChar).Value = q5;

                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    con.Close();
                    if (a > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successful Updated');", true);
                    }
                }
            }
        }


    }

    protected void back_nav(object sender, EventArgs e)
    {
        Response.Redirect("Presentations.aspx");
    }

    protected void Topic_TextChanged(object sender, EventArgs e)
    {
        if(Topic.Text == "")
        {
            addBtn.Disabled = true;
        }
        else
        {
            addBtn.Disabled = false;
            this.Page_Load(null, null);
        }
    }
}