using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Configuration;

public partial class FitnessMealPlan : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
            string monday = "abc";
            string tuesday = "abc";
            string wednesday = "abc";
            string thursday = "abc";
            string friday = "avc";
            string saturday = "edf";
            string sunday = "abc";
            string[] mondays;
            string[] tuesdays;
            string[] wednesdays;
            string[] thursdays;
            string[] fridays;
            string[] saturdays;
            string[] sundays;
            if (!Page.IsPostBack)
            {
                //Response.Write(Session["re"].ToString());
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand("SELECT * FROM MealPlanactual where ID = @id", con);
                cmd.Parameters.AddWithValue("@id", "21");
                try
                {
                    con.Open();

                    SqlDataReader sqlReader = cmd.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        monday = sqlReader["monday"].ToString();
                        tuesday = sqlReader["tuesday"].ToString();
                        wednesday = sqlReader["wednesday"].ToString();
                        thursday = sqlReader["thursday"].ToString();
                        friday = sqlReader["friday"].ToString();
                        saturday = sqlReader["saturday"].ToString();
                        sunday = sqlReader["sunday"].ToString();
                        breakfasttime.Text = sqlReader["breakfasttime"].ToString();
                        breakfastsnacktime.Text = sqlReader["breakfastsnacktime"].ToString();
                        lunchtime.Text = sqlReader["lunchtime"].ToString();
                        lunchsnacktime.Text = sqlReader["lunchsnacktime"].ToString();
                        dinnertime.Text = sqlReader["dinner"].ToString();
                        dinnersnacktime.Text = sqlReader["dinnersnacktime"].ToString();
                        DateTime start = Convert.ToDateTime(sqlReader["startdate"]);
                        DateTime end = Convert.ToDateTime(sqlReader["enddate"]);
                        string format = "MM/dd/yyyy";
                        txtCashAmt.Text = start.ToString(format);
                        txtCashAmt2.Text = end.ToString(format);
                    }

                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                    Console.WriteLine("error is" + ex);
                }
                finally
                {
                    con.Close();
                }
                mondays = monday.Split(new string[] { "," }, StringSplitOptions.None);
                tuesdays = tuesday.Split(new string[] { "," }, StringSplitOptions.None);
                wednesdays = wednesday.Split(new string[] { "," }, StringSplitOptions.None);
                thursdays = thursday.Split(new string[] { "," }, StringSplitOptions.None);
                fridays = friday.Split(new string[] { "," }, StringSplitOptions.None);
                saturdays = saturday.Split(new string[] { "," }, StringSplitOptions.None);
                sundays = sunday.Split(new string[] { "," }, StringSplitOptions.None);
                Mondaybreakfast.Text = mondays[0];
                mondaybreakfastsnack.Text = mondays[1];
                mondaylunch.Text = mondays[2];
                mondaylunchsnack.Text = mondays[3];
                mondaydinner.Text = mondays[4];
                mondaydinnersnack.Text = mondays[5];
                tuesdaybreak.Text = tuesdays[0];
                tuesdaybreaksnack.Text = tuesdays[1];
                tuesdaylunch.Text = tuesdays[2];
                tuesdaylunchsnack.Text = tuesdays[3];
                tuesdaydinner.Text = tuesdays[4];
                tuesdaydinnersnack.Text = tuesdays[5];
                wednesdaybreak.Text = wednesdays[0];
                wednesdaybreaksnack.Text = wednesdays[1];
                wednesdaylunch.Text = wednesdays[2];
                wednesdaylunchsnack.Text = wednesdays[3];
                wednesdaydinner.Text = wednesdays[4];
                wednesdaydinnersnack.Text = wednesdays[5];
                thursdaybreak.Text = thursdays[0];
                thursdaybreaksnack.Text = thursdays[1];
                thursdaylunch.Text = thursdays[2];
                thursdaylunchsnack.Text = thursdays[3];
                thursdaydinner.Text = thursdays[4];
                thursdaydinnersnack.Text = thursdays[5];
                fridaybreak.Text = fridays[0];
                fridaybreaksnack.Text = fridays[1];
                fridaylunch.Text = fridays[2];
                fridaylunchsnack.Text = fridays[3];
                fridaydinner.Text = fridays[4];
                fridaydinnersnack.Text = fridays[5];
                satbreak.Text = saturdays[0];
                satbreaksnack.Text = saturdays[1];
                satlunch.Text = saturdays[2];
                satlunchsnack.Text = saturdays[3];
                satdinner.Text = saturdays[4];
                satdinnersnack.Text = saturdays[5];
                sundaybreak.Text = sundays[0];
                sundbreaksnack.Text = sundays[1];
                sundaylunch.Text = sundays[2];
                sundaylunchsnack.Text = sundays[3];
                sundaydinner.Text = sundays[4];
                sundaydinnersnack.Text = sundays[5];
            }
       
    }
    protected void save_button_Click(object sender, EventArgs e)
    {

        string empid = Session["id_fitness"].ToString();
        string empname = Session["EmployeeName"].ToString();
        string problem="";
        if (!string.IsNullOrEmpty(Session["SolvingProblem"] as string))
        {
            problem = Session["SolvingProblem"].ToString();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('no probelm selected for this plan. go and select problem first')", true);
            string jScript = "<script>window.close();</script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "keyClientBlock", jScript);
        }
        

        string monday = Mondaybreakfast.Text.Trim() + "," + mondaybreakfastsnack.Text.Trim() + "," + mondaylunch.Text.Trim() + "," + mondaylunchsnack.Text.Trim() + "," + mondaydinner.Text.Trim() + "," + mondaydinnersnack.Text.Trim();
        string tuesday = tuesdaybreak.Text.Trim() + "," + tuesdaybreaksnack.Text.Trim() + "," + tuesdaylunch.Text.Trim() + "," + tuesdaylunchsnack.Text.Trim() + "," + tuesdaydinner.Text.Trim() + "," + tuesdaydinnersnack.Text.Trim();
        string wednesday = wednesdaybreak.Text.Trim() + "," + wednesdaybreaksnack.Text.Trim() + "," + wednesdaylunch.Text.Trim() + "," + wednesdaylunchsnack.Text.Trim() + "," + wednesdaydinner.Text.Trim() + "," + wednesdaydinnersnack.Text.Trim();
        string thursday = thursdaybreak.Text.Trim() + "," + thursdaybreaksnack.Text.Trim() + "," + thursdaylunch.Text.Trim() + "," + thursdaylunchsnack.Text.Trim() + "," + thursdaydinner.Text.Trim() + "," + thursdaydinnersnack.Text.Trim();
        string friday = fridaybreak.Text.Trim() + "," + fridaybreaksnack.Text.Trim() + "," + fridaylunch.Text.Trim() + "," + fridaylunchsnack.Text.Trim() + "," + fridaydinner.Text.Trim() + "," + fridaydinnersnack.Text.Trim();
        string saturday = satbreak.Text.Trim() + "," + satbreaksnack.Text.Trim() + "," + satlunch.Text.Trim() + "," + satlunchsnack.Text.Trim() + "," + satdinner.Text.Trim() + "," + satdinnersnack.Text.Trim();
        string sunday = sundaybreak.Text.Trim() + "," + sundbreaksnack.Text.Trim() + "," + sundaylunch.Text.Trim() + "," + sundaylunchsnack.Text.Trim() + "," + sundaydinner.Text.Trim() + "," + sundaydinnersnack.Text.Trim();
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand("INSERT INTO MealPlanPrescribed(employee_id,employee_name,problem,problemstartdate,problemreviewdate,monday,tuesday,wednesday,thursday,friday,saturday,sunday,breakfasttime,breakfastsnacktime,lunchtime,lunchsnacktime,dinner,dinnersnacktime,startdate,enddate) VALUES(@employee_id,@employee_name,@problem,@problemstartdate,@problemreviewdate,@monday,@tuesday,@wednesday,@thursday,@friday,@saturday,@sunday,@breakfasttime,@breakfastsnacktime,@lunchtime,@lunchsnacktime,@dinner,@dinnersnacktime,@startdate,@enddate)", con);


        SqlCommand cmd1 = new SqlCommand("INSERT INTO MealPlanactual(employee_id,problem,problemstartdate,problemreviewdate,monday,tuesday,wednesday,thursday,friday,saturday,sunday,breakfasttime,breakfastsnacktime,lunchtime,lunchsnacktime,dinner,dinnersnacktime,startdate,enddate) VALUES(@employee_id,@problem,@problemstartdate,@problemreviewdate,@monday,@tuesday,@wednesday,@thursday,@friday,@saturday,@sunday,@breakfasttime,@breakfastsnacktime,@lunchtime,@lunchsnacktime,@dinner,@dinnersnacktime,@startdate,@enddate)", con);
        //SqlCommand cmd = new SqlCommand("UPDATE MealPlanactual SET monday=@monday,tuesday=@tuesday,wednesday=@wednesday,thursday=@thursday,friday=@friday,saturday=@saturday,sunday=@sunday,breakfasttime=@breakfasttime,breakfastsnacktime=@breakfastsnacktime,lunchtime=@lunchtime,lunchsnacktime=@lunchsnacktime,dinner=@dinner,dinnersnacktime=@dinnersnacktime,startdate=@startdate,enddate=@enddate WHERE ID=@ID", con);
        try
        {
            con.Open();
            cmd.Parameters.AddWithValue("@employee_id", empid);
            cmd.Parameters.AddWithValue("@employee_name", empname);
            cmd.Parameters.AddWithValue("@problem",problem);
            cmd.Parameters.AddWithValue("@problemstartdate", Convert.ToDateTime(Session["date_fitness"].ToString()));
            cmd.Parameters.AddWithValue("@problemreviewdate", Convert.ToDateTime(Session["re"].ToString()));
            cmd.Parameters.AddWithValue("@monday", monday);
            cmd.Parameters.AddWithValue("@tuesday", tuesday);
            cmd.Parameters.AddWithValue("@wednesday", wednesday);
            cmd.Parameters.AddWithValue("@thursday", thursday);
            cmd.Parameters.AddWithValue("@friday", friday);
            cmd.Parameters.AddWithValue("@saturday", saturday);
            cmd.Parameters.AddWithValue("@sunday", sunday);
            cmd.Parameters.AddWithValue("@breakfasttime", breakfasttime.Text.Trim());
            cmd.Parameters.AddWithValue("@breakfastsnacktime", breakfastsnacktime.Text.Trim());
            cmd.Parameters.AddWithValue("@lunchtime", lunchtime.Text.Trim());
            cmd.Parameters.AddWithValue("@lunchsnacktime", lunchsnacktime.Text.Trim());
            cmd.Parameters.AddWithValue("@dinner", dinnertime.Text.Trim());
            cmd.Parameters.AddWithValue("@dinnersnacktime", dinnersnacktime.Text.Trim());
            cmd.Parameters.AddWithValue("@startdate", Convert.ToDateTime(txtCashAmt.Text));
            cmd.Parameters.AddWithValue("@enddate", Convert.ToDateTime(txtCashAmt2.Text));





            cmd1.Parameters.AddWithValue("@employee_id", empid);
            //cmd1.Parameters.AddWithValue("@employee_name", empname);
            cmd1.Parameters.AddWithValue("@problem", problem);
            cmd1.Parameters.AddWithValue("@problemstartdate", Convert.ToDateTime(Session["date_fitness"].ToString()));
            cmd1.Parameters.AddWithValue("@problemreviewdate", Convert.ToDateTime(Session["re"].ToString()));
            cmd1.Parameters.AddWithValue("@monday", monday);
            cmd1.Parameters.AddWithValue("@tuesday", tuesday);
            cmd1.Parameters.AddWithValue("@wednesday", wednesday);
            cmd1.Parameters.AddWithValue("@thursday", thursday);
            cmd1.Parameters.AddWithValue("@friday", friday);
            cmd1.Parameters.AddWithValue("@saturday", saturday);
            cmd1.Parameters.AddWithValue("@sunday", sunday);
            cmd1.Parameters.AddWithValue("@breakfasttime", breakfasttime.Text.Trim());
            cmd1.Parameters.AddWithValue("@breakfastsnacktime", breakfastsnacktime.Text.Trim());
            cmd1.Parameters.AddWithValue("@lunchtime", lunchtime.Text.Trim());
            cmd1.Parameters.AddWithValue("@lunchsnacktime", lunchsnacktime.Text.Trim());
            cmd1.Parameters.AddWithValue("@dinner", dinnertime.Text.Trim());
            cmd1.Parameters.AddWithValue("@dinnersnacktime", dinnersnacktime.Text.Trim());
            cmd1.Parameters.AddWithValue("@startdate", Convert.ToDateTime(txtCashAmt.Text));
            cmd1.Parameters.AddWithValue("@enddate", Convert.ToDateTime(txtCashAmt2.Text));
            int a = cmd.ExecuteNonQuery();
            if (a == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('not Successfully')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Meal Plan Inserted Successfully')", true);
            }
           int a1 =  cmd1.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Response.Write(ex);
        }
        finally
        {
            con.Close();
        }
    }

   
    protected void Save1_Click(object sender, EventArgs e)
    {
        string jScript = "<script>window.close();</script>";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "keyClientBlock", jScript);
    }
}