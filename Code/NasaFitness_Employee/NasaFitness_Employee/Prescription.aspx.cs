using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Configuration;
using System.Text;
using System.Security.Cryptography;
using System.Xml;
using System.IO;
public partial class Prescription : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
       

        if (!IsPostBack)
        {
           
           if (Request.QueryString["type"] != null) {
                Session["prblmsstring"] = Request.QueryString["dp"];
                Session["type_issue"] = Request.QueryString["type"];
                if (Session["type_issue"].ToString() == "Health") {
                    Session["date_health"] = Request.QueryString["date"];  
                } else {
					Session["date_fitness"] = Request.QueryString["date"]; 
                }
            }
           
            string prblmsstring = Session["prblmsstring"].ToString();
            Session["problmsarray"] = prblmsstring.Trim(';');

            probName.Text = "<h3>Prescription for Problem : " + Session["problmsarray"].ToString() + "</h3>";
           showmealplan();
        }

        if (Session["type_issue"].ToString() == "Fitness")
        {
          bindGrid1();
        } else if (Session["type_issue"].ToString() == "Health")
        {
          bindGrid();
        }


    }

	private void showmealplan()
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
		//if (!Page.IsPostBack)
		//{
		SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);
		SqlCommand cmd = new SqlCommand("SELECT * FROM MealPlanactual where (employee_id = @employee_id and Problem=@problem and problemStartDate=@problemstartdate)", con);




		cmd.Parameters.AddWithValue("@employee_id", Session["empid"].ToString());
		cmd.Parameters.AddWithValue("@problem", Session["problmsarray"].ToString());
        if (Session["type_issue"].ToString() == "Health")
		{
			cmd.Parameters.AddWithValue("@problemstartdate", Convert.ToDateTime(Session["date_health"].ToString()));
		}
		else
		{
			cmd.Parameters.AddWithValue("@problemstartdate", Convert.ToDateTime(Session["date_fitness"].ToString()));
		}

		try
		{
			con.Open();

			SqlDataReader sqlReader = cmd.ExecuteReader();
			if (sqlReader.HasRows)
			{

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
			else
			{
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
	}

	protected void goback_Click(object sender, EventArgs e)
	{
		Response.Redirect("FollowUp.aspx");
        probName.Text = "";
	}

	private void MessageBox(string Message)
	{
		Label lblMessageBox = new Label();
		lblMessageBox.Text =
			"<script language='javascript'>" + Environment.NewLine +
                         "window.alert('" + Message + "');</script>";
		Page.Controls.Add(lblMessageBox);
	}

	protected void save_button_Click(object sender, EventArgs e)
	{
		string monday = Mondaybreakfast.Text.Trim() + "," + mondaybreakfastsnack.Text.Trim() + "," + mondaylunch.Text.Trim() + "," + mondaylunchsnack.Text.Trim() + "," + mondaydinner.Text.Trim() + "," + mondaydinnersnack.Text.Trim();
		string tuesday = tuesdaybreak.Text.Trim() + "," + tuesdaybreaksnack.Text.Trim() + "," + tuesdaylunch.Text.Trim() + "," + tuesdaylunchsnack.Text.Trim() + "," + tuesdaydinner.Text.Trim() + "," + tuesdaydinnersnack.Text.Trim();
		string wednesday = wednesdaybreak.Text.Trim() + "," + wednesdaybreaksnack.Text.Trim() + "," + wednesdaylunch.Text.Trim() + "," + wednesdaylunchsnack.Text.Trim() + "," + wednesdaydinner.Text.Trim() + "," + wednesdaydinnersnack.Text.Trim();
		string thursday = thursdaybreak.Text.Trim() + "," + thursdaybreaksnack.Text.Trim() + "," + thursdaylunch.Text.Trim() + "," + thursdaylunchsnack.Text.Trim() + "," + thursdaydinner.Text.Trim() + "," + thursdaydinnersnack.Text.Trim();
		string friday = fridaybreak.Text.Trim() + "," + fridaybreaksnack.Text.Trim() + "," + fridaylunch.Text.Trim() + "," + fridaylunchsnack.Text.Trim() + "," + fridaydinner.Text.Trim() + "," + fridaydinnersnack.Text.Trim();
		string saturday = satbreak.Text.Trim() + "," + satbreaksnack.Text.Trim() + "," + satlunch.Text.Trim() + "," + satlunchsnack.Text.Trim() + "," + satdinner.Text.Trim() + "," + satdinnersnack.Text.Trim();
		string sunday = sundaybreak.Text.Trim() + "," + sundbreaksnack.Text.Trim() + "," + sundaylunch.Text.Trim() + "," + sundaylunchsnack.Text.Trim() + "," + sundaydinner.Text.Trim() + "," + sundaydinnersnack.Text.Trim();

		SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);
		// SqlCommand cmd = new SqlCommand("INSERT INTO MealPlanactual(ID,monday,tuesday,wednesday,thursday,friday,saturday,sunday,breakfasttime,breakfastsnacktime,lunchtime,lunchsnacktime,dinner,dinnersnacktime) VALUES(@ID,@monday,@tuesday,@wednesday,@thursday,@friday,@saturday,@sunday,@breakfasttime,@breakfastsnacktime,@lunchtime,@lunchsnacktime,@dinner,@dinnersnacktime)", con);
		SqlCommand cmd = new SqlCommand("UPDATE MealPlanactual SET monday=@monday,tuesday=@tuesday,wednesday=@wednesday,thursday=@thursday,friday=@friday,saturday=@saturday,sunday=@sunday,breakfasttime=@breakfasttime,breakfastsnacktime=@breakfastsnacktime,lunchtime=@lunchtime,lunchsnacktime=@lunchsnacktime,dinner=@dinner,dinnersnacktime=@dinnersnacktime,startdate=@startdate,enddate=@enddate  where (employee_id = @employee_id and problem=@problem and problemstartdate=@problemstartdate)", con);
		try
		{
			con.Open();
			// cmd.Parameters.AddWithValue("@ID",21);
			cmd.Parameters.AddWithValue("@employee_id", Session["empid"].ToString());
			cmd.Parameters.AddWithValue("@problem", Session["problmsarray"].ToString());

            if (Session["type_issue"].ToString() == "Health")
			{
				cmd.Parameters.AddWithValue("@problemstartdate", Convert.ToDateTime(Session["date_health"].ToString()));

			}
			else
			{
				cmd.Parameters.AddWithValue("@problemstartdate", Convert.ToDateTime(Session["date_fitness"].ToString()));
				// Response.Write(Convert.ToDateTime(Session["date_fitness"].ToString()));
			}
			//cmd.Parameters.AddWithValue("@problemstartdate", Convert.ToDateTime(Session["date_health"].ToString()));
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
			int a = cmd.ExecuteNonQuery();
			if (a > 0)
			{
				MessageBox("Meal plan successfully updated");

			}
		}
		catch (Exception ex)
		{
			Response.Write(ex);
		}
		finally
		{
			con.Close();
		}
		showmealplan();
	}

	private void bindGrid()
	{
		string minigoals = "";
		string minigoaldates = "";
		string goals = "";
		string goalsatrtdates = "";
		string goalenddates = "";

		string strConnString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
		using (SqlConnection con = new SqlConnection(strConnString))
		{
			using (SqlCommand cmd = new SqlCommand())
			{

				cmd.CommandText = "select * from HealthLogging where Employee_Id = @Employee_Id and ProblemName = @ProblemName and Date = @Date";
				//cmd.CommandText = "select Id, Name from ExerciseVideos";
				cmd.Connection = con;
				cmd.Parameters.AddWithValue("@Employee_Id", Session["empid"].ToString());
                cmd.Parameters.AddWithValue("@ProblemName", Session["problmsarray"].ToString());
				cmd.Parameters.AddWithValue("@Date", Convert.ToDateTime(Session["date_health"].ToString()));
				try
				{
					con.Open();
					SqlDataReader sqlReader = cmd.ExecuteReader();
					if (sqlReader.HasRows)
					{
						while (sqlReader.Read())
						{
							
							minigoals = sqlReader["MiniGoal"].ToString();
							minigoaldates = sqlReader["MiniGoalDate"].ToString();
							goals = sqlReader["Goal1"].ToString();
							goalsatrtdates = sqlReader["MonthlyPlanStartDate"].ToString();
							goalenddates = sqlReader["MonthlyPlanEndDate"].ToString();
							//Response.Write(videos);
						}
						if (!string.IsNullOrEmpty(minigoals) || !string.IsNullOrEmpty(minigoaldates) || !string.IsNullOrEmpty(goals) || !string.IsNullOrEmpty(goalsatrtdates) || !string.IsNullOrEmpty(goalenddates))
						{
							
							minigoal.Text = "Mini goal : " + minigoals;
							minigoaldate.Text = "Mini goal Date : "+ minigoaldates;
							goal.Text = "Goal : " + goals;
							goalsatrtdate.Text = "Goal Start Date : " + goalsatrtdates;
							goalenddate.Text = "Goal End Date : " + goalenddates;
						}
						else
						{
							minigoal.Text = "No data found";
							minigoaldate.Text = "No data found";
							goal.Text = "No data found";
							goalsatrtdate.Text = "No data found";
							goalenddate.Text = "No data found";
						}


					}


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
		}
	}

	private void bindGrid1()
	{
		string minigoals = "";
		string minigoaldates = "";
		string goals = "";
		string goalsatrtdates = "";
		string goalenddates = "";
		string strConnString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
		using (SqlConnection con = new SqlConnection(strConnString))
		{
			using (SqlCommand cmd = new SqlCommand())
			{

				cmd.CommandText = "select * from FitnessLogging where Employee_Id = @Employee_Id and ProblemName = @ProblemName and Date = @Date";
				//cmd.CommandText = "select Id, Name from ExerciseVideos";
				cmd.Connection = con;
				cmd.Parameters.AddWithValue("@Employee_Id", Session["empid"].ToString());
                cmd.Parameters.AddWithValue("@ProblemName", Session["problmsarray"].ToString());
				cmd.Parameters.AddWithValue("@Date", Convert.ToDateTime(Session["date_fitness"].ToString()));
				try
				{
					con.Open();
					SqlDataReader sqlReader = cmd.ExecuteReader();
					if (sqlReader.HasRows)
					{
						while (sqlReader.Read())
						{
							minigoals = sqlReader["MiniGoal"].ToString();
							minigoaldates = sqlReader["MiniGoalDate"].ToString();
							goals = sqlReader["Goal1"].ToString();
							goalsatrtdates = sqlReader["MonthlyPlanStartDate"].ToString();
							goalenddates = sqlReader["MonthlyPlanEndDate"].ToString();
							//Response.Write(videos);
						}
						if (!string.IsNullOrEmpty(minigoals) || !string.IsNullOrEmpty(minigoaldates) || !string.IsNullOrEmpty(goals) || !string.IsNullOrEmpty(goalsatrtdates) || !string.IsNullOrEmpty(goalenddates))
						{
							minigoal.Text = "Mini goal : " + minigoals;
							minigoaldate.Text = "Mini goal Date : " + minigoaldates;
							goal.Text = "Goal : " + goals;
							goalsatrtdate.Text = "Goal Start Date : " + goalsatrtdates;
							goalenddate.Text = "Goal End Date : " + goalenddates;
						}
						else
						{
							minigoal.Text = "No data found";
							minigoaldate.Text = "No data found";
							goal.Text = "No data found";
							goalsatrtdate.Text = "No data found";
							goalenddate.Text = "No data found";
						}
					}

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
		}
	}

}