using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace NasaFitness_Employee
{
    public partial class DashboardEmp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /* rhr.InnerText = Session["hrate"].ToString();
             bp1.InnerText = Session["blood_pressure1"].ToString();
             bp2.InnerText = Session["blood_pressure2"].ToString();
             bmi.InnerText = Session["bmi"].ToString(); */


            rhr.InnerText = "12";
            bp1.InnerText = "123";
            bp2.InnerText = "899";
            bmi.InnerText = "78";
        }

        public string PopulateValue()
        {
            string htmlstr = " ";

            if (Session["probname"] != null)
            {
                string prbname = Session["probname"].ToString();
                var arr = prbname.Split(',');
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    htmlstr += "<li class='list-group-item'> Your Problem  " + arr[i] + " was attended </li>";
                }
            }
            else
            {
                htmlstr += "<li class='list-group-item'> Your Problem need to be attended </li>";
            }
            return htmlstr;
        }

        public string PopulateValue1()
        {
            string htmlstr = " ";
            if (Session["probname"] != null)
            {
                string mpstartdate = Session["monthplanstartdate"].ToString();
                string prbname = Session["probname"].ToString();
                var arr = prbname.Split(',');
                var arr1 = mpstartdate.Split(',');
                for (int i = 0; i < arr1.Length - 1; i++)
                {
                    htmlstr += "<li class='list-group-item'> Your Monthly Plan start date for problem " + arr[i] + "is " + arr1[i] + " </li>";
                }
            }
            else
            {
                htmlstr += "<li class='list-group-item'> Your Monthly Plan was not set  </li>";
            }
            return htmlstr;
        }
        public string PopulateValue2()
        {
            string htmlstr = " ";
            if (Session["probname"] != null)
            {
                string minigoaldate = Session["MiniGoalDate"].ToString();
                string prbname = Session["probname"].ToString();
                var arr = prbname.Split(',');
                var arr1 = minigoaldate.Split(',');
                for (int i = 0; i < arr1.Length - 1; i++)
                {
                    htmlstr += "<li class='list-group-item'> Your Mini Goal start date for problem " + arr[i] + "is " + arr1[i] + " </li>";
                }
            }
            else
            {
                htmlstr += "<li class='list-group-item'> Your Mini Goal was not set  </li>";
            }
            return htmlstr;

        }

        public string PopulateValue3()
        {
            string htmlstr = " ";
            if (Session["mealprobname"] != null)
            {
                string mealprobname = Session["mealprobname"].ToString();
                var arr2 = mealprobname.Split(',');
                for (int i = 0; i < arr2.Length - 1; i++)
                {
                    htmlstr += "<li class='list-group-item'> Your Meal Plan for Problem " + arr2[i] + " is updated </li>";
                }
            }
            else
            {
                htmlstr += "<li class='list-group-item'> Your Meal Plan was not updated </li>";
            }
            return htmlstr;
        }

    }


    
}