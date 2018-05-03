using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Exam_Presentation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string presentation = (string)Session["week-Presentation"];
        ppt1.Attributes["src"] = "~/pdffiles/" + presentation;
        heading.InnerHtml = (string)Session["week-Topic"];
    }
    protected void done_Click(object sender, EventArgs e)
    {
        Response.Redirect("Exam_End.aspx");
    }
}