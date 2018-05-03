using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Empname"] != null) { 
        empName.Text = "Welcome&nbsp;" + Session["Empname"].ToString();
        } else
        {
            Label lblMessageBox = new Label();
            lblMessageBox.Text =
                "<script language='javascript'>" + Environment.NewLine +
                             "window.alert('Sorry, Your session has timeout. Please login again'); window.location.replace('/Default.aspx');</script>";
            Page.Controls.Add(lblMessageBox);
        }
    }

    public void logoutButton_Click(Object sender, EventArgs e)
    {
        // your code here
        Session.Abandon();
    }
}
