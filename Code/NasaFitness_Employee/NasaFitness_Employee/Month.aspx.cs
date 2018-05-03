using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
//using Spire.Presentation;
using System.Data;


public partial class Month : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string month = (string)Session["month"];
        string week1 = month + "1";
        string week2 = month + "2";
        string week3 = month + "3";
        string week4 = month + "4";
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        string query = "SELECT * from Presentation_QuestionsAnswers where Id='" + week1 + "'";
        query += "SELECT * from Presentation_QuestionsAnswers where Id='" + week2 + "'";
        query += "SELECT * from Presentation_QuestionsAnswers where Id='" + week3 + "'";
        query += "SELECT * from Presentation_QuestionsAnswers where Id='" + week4 + "'";
        using (SqlConnection con = new SqlConnection(cs))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataSet ds = new DataSet())
                    {
                        sda.Fill(ds);
                        if (ds.Tables[0].Rows.Count != 0)
                        {
                            DataRow dr1 = ds.Tables[0].Rows[0];
                            string que = dr1["Questions"].ToString();
                            string[] qs = que.Split('#');
                            for(int i=0;i<qs.Length;i++)
                            {
                                Session["week1-question"+(i+1)] = qs[i];
                            }
                            //Session["week1-question1"] = dr1["Questions"];
                            //Session["week1-question2"] = dr1["Questions"];
                            //Session["week1-question3"] = dr1["Questions"];
                            //Session["week1-question4"] = dr1["Questions"];
                            //Session["week1-question5"] = dr1["Questions"];
                            Session["week1-Presentation"] = dr1["Presentation"];
                            Session["week1-Topic"] = dr1["Topic"];
                            Session["week1-Answers"] = dr1["Answers"];

                            if (dr1["Topic"].ToString().Equals(""))
                            {
                                topic_1.InnerHtml = "";
                                week_1.Enabled = false;
                                topic_sub1.InnerHtml = "";
                            }
                            else
                            {
                                topic_1.InnerHtml = (string)Session["week1-Topic"];
                            }
                        }
                        else
                        {

                            topic_1.InnerHtml = "";
                            week_1.Enabled = false;
                            topic_sub1.InnerHtml = "";

                        }

                        if (ds.Tables[1].Rows.Count != 0)
                        {
                            DataRow dr2 = ds.Tables[1].Rows[0];
                            string que = dr2["Questions"].ToString();
                            string[] qs = que.Split('#');
                            for (int i = 0; i < qs.Length; i++)
                            {
                                Session["week2-question" + (i + 1)] = qs[i];
                            }
                            //Session["week1-question1"] = dr1["Questions"];
                            //Session["week1-question2"] = dr1["Questions"];
                            //Session["week1-question3"] = dr1["Questions"];
                            //Session["week1-question4"] = dr1["Questions"];
                            //Session["week1-question5"] = dr1["Questions"];
                            Session["week2-Presentation"] = dr2["Presentation"];
                            Session["week2-Topic"] = dr2["Topic"];
                            Session["week2-Answers"] = dr2["Answers"];

                            if (dr2["Topic"].ToString().Equals(""))
                            {
                                topic_2.InnerHtml = "";
                                week_2.Enabled = false;
                                topic_sub2.InnerHtml = "";
                            }
                            else
                            {
                                topic_2.InnerHtml = (string)Session["week2-Topic"];
                            }
                        }
                        else
                        {
                            topic_2.InnerHtml = "";
                            topic_sub2.InnerHtml = "";
                            week_2.Enabled = false;

                        }

                        if (ds.Tables[2].Rows.Count != 0)
                        {
                            DataRow dr3 = ds.Tables[2].Rows[0];

                            string que = dr3["Questions"].ToString();
                            string[] qs = que.Split('#');
                            for (int i = 0; i < qs.Length; i++)
                            {
                                Session["week3-question" + (i + 1)] = qs[i];
                            }
                            //Session["week3-question1"] = dr3["Questions"];
                            //Session["week3-question2"] = dr3["Questions"];
                            //Session["week3-question3"] = dr3["Questions"];
                            //Session["week3-question4"] = dr3["Questions"];
                            //Session["week3-question5"] = dr3["Questions"];
                            Session["week3-Presentation"] = dr3["Presentation"];
                            Session["week3-Topic"] = dr3["Topic"];
                            Session["week3-Answers"] = dr3["Answers"];


                            if (dr3["Topic"].ToString().Equals(""))
                            {
                                topic_3.InnerHtml = "";
                                topic_sub3.InnerHtml = "";
                                week_3.Enabled = false;
                            }
                            else
                            {
                                topic_3.InnerHtml = (string)Session["week3-Topic"];

                            }
                        }
                        else
                        {
                            topic_3.InnerHtml = "";
                            topic_sub3.InnerHtml = "";
                            week_3.Enabled = false;

                        }

                        if (ds.Tables[3].Rows.Count != 0)
                        {
                            DataRow dr4 = ds.Tables[3].Rows[0];
                            string que = dr4["Questions"].ToString();
                            string[] qs = que.Split('#');
                            for (int i = 0; i < qs.Length; i++)
                            {
                                Session["week3-question" + (i + 1)] = qs[i];
                            }
                            //Session["week4-question1"] = dr4["Questions"];
                            //Session["week4-question2"] = dr4["Questions"];
                            //Session["week4-question3"] = dr4["Questions"];
                            //Session["week4-question4"] = dr4["Questions"];
                            //Session["week4-question5"] = dr4["Questions"];
                            Session["week4-Presentation"] = dr4["Presentation"];
                            Session["week4-Topic"] = dr4["Topic"];
                            Session["week4-Answers"] = dr4["Answers"];


                            if (dr4["Topic"].ToString().Equals(""))
                            {
                                topic_4.InnerHtml = "";
                                topic_sub4.InnerHtml = "";
                                week_4.Enabled = false;
                            }
                            else
                            {
                                topic_4.InnerHtml = (string)Session["week4-Topic"];
                            }
                        }
                        else
                        {
                            topic_4.InnerHtml = "";
                            topic_sub4.InnerHtml = "";
                            week_4.Enabled = false;


                        }

                    }



                }




            }
        }
        string name = "";
        switch (month)
        {
            case "1":
                name = "January";
                break;
            case "2":
                name = "Feburay";
                break;
            case "3":
                name = "March";
                break;
            case "4":
                name = "April";
                break;
            case "5":
                name = "May";
                break;
            case "6":
                name = "June";
                break;
            case "7":
                name = "July";
                break;
            case "8":
                name = "August";
                break;
            case "9":
                name = "September";
                break;
            case "10":
                name = "October";
                break;
            case "11":
                name = "November";
                break;
            case "12":
                name = "December";
                break;

        }

        heading.InnerHtml = "Lectures:" + " " + name;

    }

    protected void questions_navigate(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)sender;
        string id = lbtn.ID;
        string[] week = id.Split('_');
        Session["week"] = week[1];
        Response.Redirect("Questionnaire.aspx");

    }

}