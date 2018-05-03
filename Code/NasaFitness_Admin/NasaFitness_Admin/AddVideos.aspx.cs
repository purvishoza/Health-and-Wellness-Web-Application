using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using System.Threading;


public partial class AddVideos : System.Web.UI.Page
{
    string file;
    string selectedtype;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        //ha.Text = "Click here To Add Files";
        if (!IsPostBack)

        //BindGrid();
        {
            
            viewcategory.Items.Clear();
            viewcategory.Items.Add("select category");
            viewcategory.Items.Add("All Videos");
            databasecategories.Items.Clear();
            databasecategories.Items.Add("select category");

            DataTable dt = new DataTable();

            DataTable dt1 = this.GetData("select DISTINCT ExcerciseType from ExerciseVideos WHERE ExcerciseType IS NOT NULL");
            foreach (DataRow row in dt1.Rows)
            {
                if (row["ExcerciseType"] != null)
                {
                    viewcategory.Items.Add(row["ExcerciseType"].ToString());
                    databasecategories.Items.Add(row["ExcerciseType"].ToString());
                }
                else
                {

                }
            }
        }

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

    [System.Web.Services.WebMethod]
    protected void UploadButton_Click(object sender, EventArgs e)
    {
        string fileName = "";

        if (f1.FileName=="")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please upload the file');", true);
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
           // HttpContext.Current.Server.MapPath("~/pdffiles/" + Session["fil"].ToString());
            string filename2 = HttpContext.Current.Server.MapPath("~/FileVideos/" + Session["fil"].ToString());
            //Server.MapPath("~//FileVideos//" + Session["fil"].ToString());

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
                string valQuery = "select max(id) from ExerciseVideos";  //pradeep
                SqlConnection con = new SqlConnection(strConnString);  //pradeep
                SqlCommand ncmd = new SqlCommand(valQuery, con); //pradeep
                con.Open(); //pradeep
                SqlDataReader dr = ncmd.ExecuteReader(); //pradeep
                dr.Read(); //pradeep
                int max = dr.GetInt32(0) + 1; //pradeep

                //insert the file into database
                string strQuery = "insert into ExerciseVideos(Id,Name, ContentType, Data,ExcerciseType)" +
                       " values (@Id,@Name, @ContentType, @Data,@ExcerciseType)"; //pradeep
                SqlCommand cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = max; //pradeep
                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = filename1;
                cmd.Parameters.Add("@ContentType", SqlDbType.VarChar).Value = contenttype;
                cmd.Parameters.Add("@Data", SqlDbType.VarBinary).Value = bytes;
                string exerciseType = databasecategories.SelectedItem.Text.ToString();
                if (exerciseType == "Select Video Category")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select or create a category to add the new video');", true);
                }
                else
                {
                    cmd.Parameters.Add("@ExcerciseType", SqlDbType.VarChar).Value = exerciseType;
                    InsertUpdateData(cmd);
                    con.Close(); //pradeep
                }

            }
            else
            {

            }
            viewcategory.Items.Clear();
            viewcategory.Items.Add("select category");
            viewcategory.Items.Add("All Videos");

            DataTable dt = new DataTable();

            DataTable dt1 = this.GetData("select DISTINCT ExcerciseType from ExerciseVideos WHERE ExcerciseType IS NOT NULL");
            foreach (DataRow row in dt1.Rows)
            {
                if (row["ExcerciseType"] != null)
                {
                    viewcategory.Items.Add(row["ExcerciseType"].ToString());
                }
                else
                {

                }
            }
        }
    }

    private static TaskEventHandler GetStream(TaskEventHandler stream)
    {
        return stream;
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
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error uploading the video. Please try again');", true);
            }
            else
            {
                
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Video has been uploaded successfully.');", true);
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

    private void BindGrid1()
    {

        string strConnString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(strConnString))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select Id, Name from ExerciseVideos";
                cmd.Connection = con;
                con.Open();
                DataList1.DataSource = cmd.ExecuteReader();
                DataList1.DataBind();
                con.Close();
            }
        }
    }


    protected void addCat_Click(object sender, EventArgs e)
    {
        if(addCategory.Text =="")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter the category');", true);
        }
        else
        {
            databasecategories.Items.Insert(databasecategories.Items.Count, new ListItem(addCategory.Text.ToString()));
            addCategory.Text = "";
        }
        
    }

    protected void viewcategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectedtype1 = viewcategory.SelectedItem.Text.ToString();
        if (selectedtype1 == "All Videos")
        {
            BindGrid1();
        }
        else
        {
            string strConnString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select Id, Name from ExerciseVideos where ExcerciseType = '" + selectedtype1 + "' ";
                    cmd.Connection = con;
                    con.Open();
                    DataList1.DataSource = cmd.ExecuteReader();
                    DataList1.DataBind();
                    con.Close();
                }
            }
        }
    }

 
}