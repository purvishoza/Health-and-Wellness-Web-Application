
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Text;
using System.Web.Script.Serialization;

public partial class FitnessLogging : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["EmployeeName"] = "JSCEmp001 JSCEmp001";
        empnamehealthPage.Text = Session["EmployeeName"].ToString();

    }

    [System.Web.Services.WebMethod]
    public static string ViewMealPlan_Click(string date_curr, string prob, string rdate)
    {
        string htmlStr = "";
        string emp = HttpContext.Current.Session["EmployeeName"].ToString();
        string emp_id = HttpContext.Current.Session["id_health"].ToString();
        String[] mondays, tuesdays, wednesdays, thursdays, fridays, saturdays, sundays;
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        DataTable dt = new DataTable();
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select * from MealPlanPrescribed where problemstartdate = '" + date_curr + "' AND problemreviewdate = '" + rdate + "' AND problem = '" + prob + "' AND employee_id = '" + emp_id + "'";
                //cmd.Parameters.AddWithValue("@employee_id", HttpContext.Current.Session["id_health"].ToString());
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row1 in dt.Rows)
                    {
                        List<string> time = new List<string> { };
                        DateTime start = Convert.ToDateTime(row1["startdate"]).Date;
                        DateTime end = Convert.ToDateTime(row1["enddate"]).Date;
                        time.Add(start.ToShortDateString());
                        time.Add(end.ToShortDateString());
                        mondays = row1["monday"].ToString().Split(new string[] { "," }, StringSplitOptions.None);
                        tuesdays = row1["tuesday"].ToString().Split(new string[] { "," }, StringSplitOptions.None);
                        wednesdays = row1["wednesday"].ToString().Split(new string[] { "," }, StringSplitOptions.None);
                        thursdays = row1["thursday"].ToString().Split(new string[] { "," }, StringSplitOptions.None);
                        fridays = row1["friday"].ToString().Split(new string[] { "," }, StringSplitOptions.None);
                        saturdays = row1["saturday"].ToString().Split(new string[] { "," }, StringSplitOptions.None);
                        sundays = row1["sunday"].ToString().Split(new string[] { "," }, StringSplitOptions.None);
                        time.Add(row1["breakfasttime"].ToString());
                        time.Add(row1["breakfastsnacktime"].ToString());
                        time.Add(row1["lunchtime"].ToString());
                        time.Add(row1["lunchsnacktime"].ToString());
                        time.Add(row1["dinner"].ToString());
                        time.Add(row1["dinnersnacktime"].ToString());
                        var times = new JavaScriptSerializer().Serialize(time);
                        var mon = new JavaScriptSerializer().Serialize(mondays);
                        var tue = new JavaScriptSerializer().Serialize(tuesdays);
                        var wed = new JavaScriptSerializer().Serialize(wednesdays);
                        var thu = new JavaScriptSerializer().Serialize(thursdays);
                        var fri = new JavaScriptSerializer().Serialize(fridays);
                        var sat = new JavaScriptSerializer().Serialize(saturdays);
                        var sun = new JavaScriptSerializer().Serialize(sundays);
                        htmlStr += emp + "^" + times + "^" + mon + "^" + tue + "^" + wed + "^" + thu + "^" + fri + "^" + sat + "^" + sun;
                    }
                }

            }
        }
        return htmlStr;
    }

    public string BindData()
    {
        string htmlStr = "";
        string emp_id = HttpContext.Current.Session["id_health"].ToString();
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        DataTable dt = new DataTable();
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM [FitnessLogging] WHERE ([Employee_Id] = '" + emp_id + "') ORDER BY [Date] DESC";
                //cmd.Parameters.AddWithValue("@employee_id", HttpContext.Current.Session["id_health"].ToString());
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DateTime Var = Convert.ToDateTime(dt.Rows[i]["ReviewDate"]).Date; //only date part
                        string date = Var.ToShortDateString();
                        htmlStr += "<tr><td>"
                           + dt.Rows[i]["Date"].ToString() + "</td><td>"
                           + dt.Rows[i]["ProblemName"].ToString() + "</td><td>"
                               + dt.Rows[i]["HistoryOfProblem"].ToString() + "</td><td>"
                               + date + "</td><td class='text-center'><button type='button' data-toggle='modal' class='summary btn btn-primary'><i class='fa fa-file-text-o' aria-hidden='true'></i></button></td><td class='text-center'><button type='button' data-toggle='modal' class='meal btn btn-primary'><i class='fa fa-cutlery' aria-hidden='true'></i></button></td></tr>";

                    }
                }
            }
        }
        return htmlStr;
    }


    [System.Web.Services.WebMethod]
    public static string GetSummary(string date_curr, string prob)
    {
        string emp = HttpContext.Current.Session["EmployeeName"].ToString(); ;
        string emp_id = HttpContext.Current.Session["id_health"].ToString();
        string data1 = "";
        DataTable dt = new DataTable();
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM [FitnessLogging] WHERE Employee_Id='" + emp_id + "' AND ProblemName='" + prob + "' AND Date='" + date_curr + "'";
                // cmd.Parameters.AddWithValue("@employee_id", emp_id);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data1 += emp + "^" + dt.Rows[i]["Date"].ToString() + "^" + dt.Rows[i]["ProblemName"].ToString() + "^"
                                               + dt.Rows[i]["HistoryOfProblem"].ToString() + "^" + dt.Rows[i]["ProblemCodeGroup"].ToString()
                                               + "^" + dt.Rows[i]["ProblemDxCodeDescription"].ToString() + "^" + dt.Rows[i]["MonthlyPlanStartDate"].ToString() + "^"
                                               + dt.Rows[i]["MonthlyPlanEndDate"].ToString() + "^" + dt.Rows[i]["Goal1"].ToString() + "^" + dt.Rows[i]["Payoffs1"].ToString()
                                               + "^" + dt.Rows[i]["SuggestedVideos"].ToString() + "^" + dt.Rows[i]["SuggestedClasses"].ToString() + "^"
                                               + dt.Rows[i]["MiniGoalDate"].ToString() + "^" + dt.Rows[i]["MiniGoal"].ToString() + "^" + dt.Rows[i]["Miscellaneous"].ToString()
                                               + "^" + dt.Rows[i]["FitnessBuddies"].ToString() + "^" + dt.Rows[i]["ReviewDate"].ToString();
                    }
                }
            }
        }
        return data1;
    }

}