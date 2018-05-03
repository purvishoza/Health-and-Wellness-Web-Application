using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentations : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void page_navigate(object sender, EventArgs e)
    {
        Response.Redirect("Add_Classes.aspx");
    }

    protected void month_click(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)sender;
        string id = lbtn.ID;
        string[] month = id.Split('_');
        Session["month"] = month[1];
        Response.Redirect("Month.aspx");



    }
}