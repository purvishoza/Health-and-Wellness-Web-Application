using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using System.Web.Script.Serialization;

namespace NasaFitness_Admin
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            SqlConnection con1 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);
            SqlConnection con2 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);
            SqlConnection con3 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);
            SqlConnection con4 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);
            SqlCommand cmd1 = new SqlCommand("SELECT count(ID) from web_users", con1);
            SqlCommand cmd2 = new SqlCommand("SELECT count(ID) from ExerciseVideos", con2);
            SqlCommand cmd3 = new SqlCommand("SELECT count(ID) from Presentation_QuestionsAnswers", con3);
            SqlCommand cmd4 = new SqlCommand("SELECT count(ID) from Medicalrecords", con4);
            try
            {
                con1.Open();
                SqlDataReader sqlReader = cmd1.ExecuteReader();
                if (sqlReader.Read())
                {
                    nofpatients.Text = sqlReader[0].ToString();
                }


            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
            finally
            {
                con1.Close();
            }
            try
            {
                con2.Open();
                SqlDataReader sqlReader1 = cmd2.ExecuteReader();
                if (sqlReader1.Read())
                {
                    nofvideos.Text = sqlReader1[0].ToString();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
            finally
            {
                con2.Close();
            }
            try
            {
                con3.Open();
                SqlDataReader sqlReader2 = cmd3.ExecuteReader();
                if (sqlReader2.Read())
                {
                    nooflectures.Text = sqlReader2[0].ToString();
                }


            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
            finally
            {
                con3.Close();
            }
            try
            {
                con4.Open();
                SqlDataReader sqlReader3 = cmd4.ExecuteReader();
                if (sqlReader3.Read())
                {
                    mrecords.Text = sqlReader3[0].ToString();
                }


            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
            finally
            {
                con1.Close();
            }

            int totalnewcount = Convert.ToInt32(Session["newhealth"]) + Convert.ToInt32(Session["fit_newcount"]);
            int totalattendcount = Convert.ToInt32(Session["attendhealth"]) + Convert.ToInt32(Session["fit_attendcount"]);

            newPatientsLbl.Text = totalnewcount.ToString();
            attendpatientlbl.Text = totalattendcount.ToString();


        }

        public string GetValue()
        {

            string countjsc = "";
            SqlConnection constr = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);

            SqlCommand cmd4 = new SqlCommand("SELECT count(organization) from web_users where organization = 'JSC'", constr);

            try
            {
                constr.Open();
                SqlDataReader sqlReader4 = cmd4.ExecuteReader();
                if (sqlReader4.Read())
                {
                    countjsc = sqlReader4[0].ToString();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
            finally
            {
                constr.Close();
            }
            return countjsc;

        }
        public string GetValue2()
        {
            string countjsc1 = "";
            SqlConnection constr1 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);

            SqlCommand cmd5 = new SqlCommand("SELECT count(organization) from web_users where organization = 'SAFB'", constr1);

            try
            {
                constr1.Open();
                SqlDataReader sqlReader4 = cmd5.ExecuteReader();
                if (sqlReader4.Read())
                {
                    countjsc1 = sqlReader4[0].ToString();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
            finally
            {
                constr1.Close();
            }
            return countjsc1;
        }

        public string PopulateValue()
        {

            string htmlstr = "";

            
                htmlstr += "<li class='list-group-item'>" + Session["recentCasesCount"] +" New cases are added recently</li>";
            
            return htmlstr;
        }

        public string PopulateValue1()
        {


            string htmlstr = "";
            
                htmlstr += "<li class='list-group-item'>" + Session["recentUsersCount"]+ " New users have been added from last login </li>";
            
            return htmlstr;


        }

        public string PopulateValue2()
        {
            string htmlstr = "";
            int temp = Convert.ToInt32(Session["newhealthpatients"]);
            if (temp == 1)
            {
                htmlstr += "<li class='list-group-item'>" + Session["newhealthpatients"] + " User had updated their Health Related Problems </li>";
            }
            else
            {
                htmlstr += "<li class='list-group-item'>" + Session["newhealthpatients"] + " Users have updated their Health Related Problems </li>";
            }
            return htmlstr;

        }
        public string PopulateValue3()
        {
            string htmlstr = "";
            int temp = Convert.ToInt32(Session["newfitnesspatients"]);
            if (temp == 1)
            {
                htmlstr += "<li class='list-group-item'>" + Session["newfitnesspatients"] + " User had updated their Fitness Related Problems </li>";
            }
            else
            {
                htmlstr += "<li class='list-group-item'>" + Session["newfitnesspatients"] + " Users have updated their Fitness Related Problems </li>";
            }
            return htmlstr;
        }

        public string GetLastLogin()
        {
            string llgn = "";
            llgn = Session["lastlogin"].ToString();
            return llgn;
        }



    }

}