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
        if (Session["admin"] != null)
        {

            string admin_user = Session["admin"].ToString();

            if (admin_user.Equals("admin"))
            {
                signup_a.Visible = true;
            }
            else
            {
                signup_a.Visible = false;
            }
        }
        else
        {
            
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sorry,Your Session Has Timed Out!! Please Login Again..'); window.location.replace('/Default.aspx');", true);
            
        }
        
    }
    void logoutButton_Click(Object sender, EventArgs e)
    {
        // your code here
        Session.Abandon();
    }
}
