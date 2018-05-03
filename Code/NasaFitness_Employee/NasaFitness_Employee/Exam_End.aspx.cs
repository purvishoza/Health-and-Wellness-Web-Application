using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Exam_End : System.Web.UI.Page
{
    String[] myArray = new String[] { "True", "False", "True", "False", "False" };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            Session["ansArray2"] = null;

        }

        table2.Rows[0].Cells[0].InnerText = "1." + " " + (string)Session["week-question1"];

        table2.Rows[1].Cells[0].InnerText = "2." + " " + (string)Session["week-question2"];

        table2.Rows[2].Cells[0].InnerText = "3." + " " + (string)Session["week-question3"];

        table2.Rows[3].Cells[0].InnerText = "4." + " " + (string)Session["week-question4"];

        table2.Rows[4].Cells[0].InnerText = "5." + " " + (string)Session["week-question5"];

    }
    protected void save_Click(object sender, EventArgs e)
    {
        string answer1 = RadioButtonList.SelectedValue;
        string answer2 = RadioButtonList1.SelectedValue;
        string answer3 = RadioButtonList2.SelectedValue;
        string answer4 = RadioButtonList3.SelectedValue;
        string answer5 = RadioButtonList4.SelectedValue;
        if (answer1 == "" || answer2 == "" || answer3 == "" || answer4 == "" || answer5 == "")
        {
            MessageBox("Please Fill all the answers");
        }
        else
        {
            String[] ansArray2 = new String[] { answer1, answer2, answer3, answer4, answer5 };
            Session["ansArray2"] = ansArray2;
            //MessageBox("Thank You");
            DateTime dt2 = DateTime.Now;
            DateTime dt1 = Convert.ToDateTime(Session["dt1"]);
            TimeSpan t = dt2 - dt1;
            Session["diff2"] = t.ToString(@"mm\:ss\.ff");
            Response.Redirect("Exam_ResultPage.aspx");
        }



    }
    private void MessageBox(string Message)
    {
        Label lblMessageBox = new Label();
        lblMessageBox.Text =
            "<script language='javascript'>" + Environment.NewLine +
            "window.alert('" + Message + "')</script>";
        Page.Controls.Add(lblMessageBox);
    }
}