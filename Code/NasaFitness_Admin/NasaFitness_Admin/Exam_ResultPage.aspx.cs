using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Exam_ResultPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string[] answers = new string[] { " ", " ", " ", " ", " " };
        string db_answers = (string)Session["week-Answers"];
        string[] db_Ans = db_answers.Split(',');
        for (int i = 0; i < 5; i++)
        {
            if (db_Ans[i].Equals("T"))
            {
                answers[i] = "True";
            }
            else
            {
                answers[i] = "False";
            }
        }

        int q1 = 0;
        int q2 = 0;


        string[] arr1 = new string[] { };
        string[] arr2 = new string[] { };

        arr1 = (string[])Session["ansArray1"];
        arr2 = (string[])Session["ansArray2"];

        for (int i = 0; i < 5; i++)
        {
            if (answers[i].Equals(arr1[i]))
            {
                q1 = q1 + 1;
            }
            if (answers[i].Equals(arr2[i]))
            {
                q2 = q2 + 1;
            }
        }
        time.InnerHtml = Session["diff2"].ToString();
        before.InnerHtml = q1.ToString();
        after.InnerHtml = q2.ToString();
        ans1.InnerHtml = answers[0];
        ans2.InnerHtml = answers[1];
        ans3.InnerHtml = answers[2];
        ans4.InnerHtml = answers[3];
        ans5.InnerHtml = answers[4];

        before1.InnerHtml = arr1[0];
        before2.InnerHtml = arr1[1];
        before3.InnerHtml = arr1[2];
        before4.InnerHtml = arr1[3];
        before5.InnerHtml = arr1[4];

        after1.InnerHtml = arr2[0];
        after2.InnerHtml = arr2[1];
        after3.InnerHtml = arr2[2];
        after4.InnerHtml = arr2[3];
        after5.InnerHtml = arr2[4];
        after1.InnerHtml = arr2[0];
        after1.InnerHtml = arr2[0];



        question1.InnerText = "1." + " " + (string)Session["week-question1"];


        question2.InnerText = "2." + " " + (string)Session["week-question2"];

        question3.InnerText = "3." + " " + (string)Session["week-question3"];

        question4.InnerText = "4." + " " + (string)Session["week-question4"];

        question5.InnerText = "5." + " " + (string)Session["week-question5"];


    }
}