using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class View_Presentation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //ppt.InnerHtml= "<iframe id='frame1' src='https://onedrive.live.com/embed?cid=6DECB2DEC50A81A9&resid=6DECB2DEC50A81A9%212004&authkey=ANgVJPeHWDcPMVU&em=2&wdAr=1.7777777777777777' width='610px' height='367px' frameborder='1'>This is an embedded <a target='_blank' href='https://office.com'>Microsoft Office</a> presentation, powered by <a target='_blank' href='https://office.com/webapps'>Office Online</a>.</iframe>";

        string week = (string)Session["week"];
        string presentation_name = "week" + week + "-Presentation";
        string presentation = (string)Session[presentation_name];
        ppt1.Attributes["src"] = "~/pdffiles/" + presentation;
        string week_topic = "week" + week + "-Topic";
        heading.InnerHtml = (string)Session[week_topic];

    }


    protected void done_Click(object sender, EventArgs e)
    {
        Response.Redirect("Presentations.aspx");
    }

    protected void DataList1_Load(object sender, EventArgs e)
    {
        string month = (string)Session["month"];
        string week = (string)Session["week"];
        string fin = month + week;
        string strConnString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(strConnString))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select MonthAndWeek, Name from PresentationVideos where MonthAndWeek=" + fin;
                cmd.Connection = con;
                con.Open();
                DataList1.DataSource = cmd.ExecuteReader();
                DataList1.DataBind();
                con.Close();
            }
        }
    }
}