using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Configuration;

public partial class classes : System.Web.UI.Page
{
    //string[] ids;
    //string[] pres;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        
    //    bindData();
    //    if (!IsPostBack)
    //    {
    //        string classids = "";
    //        string presentations = "";
    //        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);
    //        SqlCommand cmd = new SqlCommand("SELECT Id,Topic,Presentation FROM Weekly_Users where Topic is not null", con);
    //        //cmd.Parameters.AddWithValue("@empid", "1527");
    //        //cmd.Parameters.AddWithValue("@prese",DBNull.Value);
    //        try
    //        {

    //            con.Open();
    //            SqlDataReader sqlReader = cmd.ExecuteReader();
    //            while (sqlReader.Read())
    //            {
    //                classesddl.Items.Add(sqlReader["Topic"].ToString());
    //                presentations += sqlReader["Presentation"].ToString() + ","  ;
    //                classids += "," + sqlReader["ID"].ToString() + ",";
    //                Session["presentations"] = presentations;
    //                Session["classids"] = classids;
    //            }
    //            //Response.Write(presentations);
    //            //Response.Write(classids);
               
    //            // string test = ids[5];
    //            // Response.Write(test);
    //             //Response.Write(ids[2]);
    //             //Response.Write(pres[4]);
    //        }
    //        catch (Exception ex)
    //        {
    //            Response.Write(ex);
    //        }
    //        finally
    //        {
    //            con.Close();
    //        }
    //    }
    //    }

    //protected void classesddl_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    ids = Session["classids"].ToString().Split(new string[] { "," }, StringSplitOptions.None);
    //    pres = Session["presentations"].ToString().Split(new string[] { "," }, StringSplitOptions.None);
    //   // Response.Write(classesddl.SelectedIndex);
    //    int selectedvalue = classesddl.SelectedIndex;
    //    int desiredvalueindex = selectedvalue + 1;
    //    string selctedid = ids[desiredvalueindex];
    //    string selectedpresentation = pres[selectedvalue];
    //    Response.Write(selctedid);
    //    Response.Write(selectedpresentation);


    //    // Response.Write(selectedvalue);

    //}
    //protected void addclasses_Click(object sender, EventArgs e)
    //{
    //    ids = Session["classids"].ToString().Split(new string[] { "," }, StringSplitOptions.None);
    //    pres = Session["presentations"].ToString().Split(new string[] { "," }, StringSplitOptions.None);
    //    // Response.Write(classesddl.SelectedIndex);
    //    int selectedvalue = classesddl.SelectedIndex;
    //    int desiredvalueindex = selectedvalue + 1;
    //    string selctedid = ids[desiredvalueindex];
    //    string selectedpresentation = pres[selectedvalue-1];
    //    if (Session["actualseletpres"] == null)
    //    {
    //        Session["actualseletpres"] = selectedpresentation + ",";
    //    }
    //    else
    //    {
    //        Session["actualseletpres"] = Session["actualseletpres"].ToString() + selectedpresentation + ",";
    //    }
    //    Response.Write(selctedid);
    //    Response.Write(selectedpresentation);
    //    classeslisttextbox.Text = Session["actualseletpres"].ToString();
    //}
    //public void bindData()
    //{
    //    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);
    //    SqlCommand cmd = new SqlCommand("SELECT * FROM HealthQuestionnaire where employee_id=@employee_id and solved=@solved", con);
    //    cmd.Parameters.AddWithValue("@employee_id", "1527");
    //    cmd.Parameters.AddWithValue("@solved", "2");
    //    try
    //    {
    //        con.Open();
    //        SqlDataReader sqlReader = cmd.ExecuteReader();
    //        GridView1.DataSource = sqlReader;
    //        GridView1.DataBind();
    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Write(ex);
    //    }
    //    finally
    //    {
    //        con.Close();
    //    }
    }
}