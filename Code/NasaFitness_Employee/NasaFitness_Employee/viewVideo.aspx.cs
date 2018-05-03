using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;

    public partial class viewVideo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)

            //BindGrid();
            {
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
        private static TaskEventHandler GetStream(TaskEventHandler stream)
        {
            return stream;
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
