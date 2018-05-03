using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace NasaFitness_Admin
{
    public partial class AddCompany : System.Web.UI.Page
    {

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public string GetTable()
        {
            string htmlStr = "";
            htmlStr += BindData();
            
            return htmlStr;
        }

        public string BindData()
        {
            //Session.Clear();
            string htmlStr = "";

            string constr = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    //Response.Write(solved.ToString());
                    //Use value in Select statement
                    cmd.CommandText = "SELECT Company_Name, Company_Location from CompanyInfo";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            htmlStr += "<tr><td>" + dt.Rows[i]["Company_Name"] + "</td><td>" + dt.Rows[i]["Company_Location"] + "</td>";
                        }
                    }
                }
            }

            return htmlStr;
        }



    protected void add_company(object sender, EventArgs e)
        {
            SqlConnection constr = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into CompanyInfo(Company_Name, Company_Location)" +
                           " values (@Company_Name,@Company_Location)";
            try
            {
                constr.Open();

                cmd.Parameters.Add("@Company_Name", SqlDbType.VarChar).Value = cname.Text;
                cmd.Parameters.Add("@Company_Location", SqlDbType.VarChar).Value = clocation.Text;
                
                cmd.CommandType = CommandType.Text;
                cmd.Connection = constr;
  
                int a = cmd.ExecuteNonQuery();
                if (a == 0)
                {

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully Added'); window.location='AddCompany.aspx';", true);

                }
            }

            catch (Exception ex)
            {
                Response.Write(ex);
                Console.WriteLine(ex);
            }
            finally
            {
                constr.Close();
            }
        }
    }
}