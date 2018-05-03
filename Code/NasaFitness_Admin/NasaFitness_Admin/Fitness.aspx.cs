using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Security.Cryptography;
using System.Xml;
using System.IO;

public partial class Fitness : System.Web.UI.Page
{
    string empid;
    DateTime date1; string answers; string CurrentProblems, DesiredTreatment;
    string[] ids;
    string[] pres;
    public string state = "collapse";
    public string state1 = "collapse";
    public string state2 = "collapse";
    public string state3 = "collapse";
    //string[] problemList = new string[] { "Head Ache", "Neck Pain", "Knee Pain", "Palm Pain" };

    protected void Page_Load(object sender, EventArgs e)
    {
        //A1.ServerClick += new EventHandler(A1_Click);
        objExam.ServerClick += new EventHandler(objExam_Click);

        if (Request.QueryString["date"] != null)
        {
            Session["date_fitness"] = Request.QueryString["date"];
            Session["dp_fit"] = Request.QueryString["dp"].Trim(';');
            Session["problem_fitness"] = Request.QueryString["prob"].Trim(';');
            Session["id_fitness"] = Request.QueryString["id"];
        }

        if (Request.QueryString["Employeeid"] != null)
        {
            Session["id_fitness"] = Decrypt(HttpUtility.UrlDecode(Request.QueryString["Employeeid"]));


        }
        if (Request.QueryString["QuestionnaireDate"] != null)
        {
            Session["date_fitness"] = Decrypt(HttpUtility.UrlDecode(Request.QueryString["QuestionnaireDate"]));
        }
        if (Request.QueryString["dp_fit"] != null)
        {
            Session["dp_fit"] = Decrypt(HttpUtility.UrlDecode(Request.QueryString["dp_fit"]));
        }
        if (Request.QueryString["problem_fit"] != null)
        {
            Session["problem_fitness"] = Decrypt(HttpUtility.UrlDecode(Request.QueryString["problem_fit"]));
        }


        if (!Page.IsPostBack)
        {
            string classids = "";
            string presentations = "";
            SqlConnection con1 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);
            SqlCommand cmd1 = new SqlCommand("SELECT Id,Topic,Presentation FROM Weekly_Users where Topic is not null", con1);
            classesddl.Items.Add("Classes");
            try
            {

                con1.Open();
                SqlDataReader sqlReader = cmd1.ExecuteReader();
                while (sqlReader.Read())
                {
                    classesddl.Items.Add(sqlReader["Topic"].ToString());
                    presentations += sqlReader["Presentation"].ToString() + ",";
                    classids += "," + sqlReader["ID"].ToString() + ",";
                    Session["presentations"] = presentations;
                    Session["classids"] = classids;
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
            healthnames.Items.Clear();
            healthnames.Items.Add("CodeGroups");
            DataTable t = new DataTable();
            string query1 = "select DISTINCT CodeGroup from codes WHERE CodeGroup IS NOT NULL";
            string strConnString1 = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strConnString1))
            {
                using (SqlCommand cmd = new SqlCommand(query1))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        sda.Fill(t);
                        foreach (DataRow row in t.Rows)
                        {
                            if (row["CodeGroup"] != null)
                            {
                                healthnames.Items.Add(row["CodeGroup"].ToString());
                            }
                            else
                            {

                            }
                        }
                    }


                }
            }

            excercisesTypes.Items.Clear();
            excercisesTypes.Items.Add("ExcerciseTypes");
            DataTable t1 = this.GetData("select DISTINCT ExcerciseType from ExerciseVideos WHERE ExcerciseType IS NOT NULL");
            //excercisesTypes.Items.Add("Select Excercise Video Type");

            foreach (DataRow row in t1.Rows)
            {
                if (row["ExcerciseType"] != null )
                {
                    excercisesTypes.Items.Add(row["ExcerciseType"].ToString());
                }
                else
                {

                }
            }




            desiredTreatmentsList.Items.Clear();
            empid = Session["id_fitness"].ToString();

            date1 = Convert.ToDateTime(Session["date_fitness"]);
            //Response.Write(date1);
            CurrentProblems = "";
            CurrentProblems = Session["problem_fitness"].ToString();
            current.InnerText = CurrentProblems;
            DesiredTreatment = "";
            DesiredTreatment = Session["dp_fit"].ToString();
            desired.InnerText = DesiredTreatment;
            var DesiredTreatmentArray = DesiredTreatment.Split(';');



            Session["DesiredArray"] = DesiredTreatmentArray;
            desiredTreatmentsList.Items.Add("Select");
            for (int i = 0; i < DesiredTreatmentArray.Length; i++)
            {
                if (DesiredTreatmentArray[i].Equals(" ") || DesiredTreatmentArray[i].Equals(""))
                {

                }
                else
                {
                    desiredTreatmentsList.Items.Add(DesiredTreatmentArray[i].ToString());
                }

            }

            DataTable dt2 = this.GetData("select FName,LName from web_users WHERE Pernr='" + empid + "'");
            //excercisesTypes.Items.Add("Select Excercise Video Type");
            foreach (DataRow row in dt2.Rows)
            {

                empnameFitnessPage.Text = row["FName"].ToString() + "," + row["LName"].ToString();
                Session["EmployeeName"] = row["FName"].ToString() + "," + row["LName"].ToString();
            }


            healthnames.Items.Clear();
            healthnames.Items.Add("select DXCode");
            DataTable dt = new DataTable();
            string query = "select DISTINCT CodeGroup from codes WHERE CodeGroup IS NOT NULL";
            string strConnString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);
                        foreach (DataRow row in dt.Rows)
                        {
                            if (row["CodeGroup"] != null && row["CodeGroup"].ToString() != " ")
                            {
                                healthnames.Items.Add(row["CodeGroup"].ToString());
                            }
                            else
                            {

                            }
                        }
                    }


                }
            }
            excercisesTypes.Items.Clear();
            excercisesTypes.Items.Add("Select Ex Type");
            DataTable dt1 = this.GetData("select DISTINCT ExcerciseType from ExerciseVideos WHERE ExcerciseType IS NOT NULL");
            //excercisesTypes.Items.Add("Select Excercise Video Type");
            //excercisesTypes.Items.Add("Select");
            foreach (DataRow row in dt1.Rows)
            {
                if (row["ExcerciseType"] != null)
                {
                    excercisesTypes.Items.Add(row["ExcerciseType"].ToString());
                }
                else
                {

                }
            }

            //for gridview column answers



            DataTable dt3 = this.GetData("select answer from PARQ_Answers where employee_id='" + empid + "'");
            DataTable veena = this.GetData("select Questions from PARQ_Questions");
            foreach (DataRow row in dt3.Rows)
            {
                if (row["answer"] != null)
                {
                    answers = row["answer"].ToString();
                }
                else
                {

                }
            }

            DataTable dt4 = new DataTable();
            dt4.Columns.Add("UserId");

            for (int i = 0; i < answers.Length; i++)
            {
                dt4.Rows.Add(answers[i]);
            }
            var arr = answers.Split(',');
        }
    }
    protected void Save_Click(object sender, EventArgs e)
    {

    }

    protected void send_Click(object sender, EventArgs e)
    {

    }


    protected void healthnames_SelectedIndexChanged(object sender, EventArgs e)
    {
        healthcodes.Items.Clear();
        state = "expand";
        DataTable dt1 = new DataTable();
        DropDownList ddl = (DropDownList)sender;
        string ID = ddl.Text.ToString();
        string strConnString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(strConnString);
        conn.Open();
        SqlCommand command = new SqlCommand("select DxCode,Description from codes WHERE CodeGroup =@id", conn);
        //
        // Add new SqlParameter to the command.
        //
        command.Parameters.AddWithValue("@id", ID);
        using (SqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                healthcodes.Items.Add(reader["DxCode"].ToString() + "," + "-------------" + reader["Description"].ToString());


            }


        }

        conn.Close();
        healthcodes.Visible = true;

    }
    private DataTable GetData(string query)
    {
        DataTable dt1 = new DataTable();
        string strConnString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(strConnString))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    sda.Fill(dt1);
                }
            }
            return dt1;
        }
    }



    protected void excercisesTypes_SelectedIndexChanged(object sender, EventArgs e)
    {
        excercisenames.Items.Clear();
        state2 = "expand";
        DataTable dt1 = new DataTable();
        DropDownList ddl = (DropDownList)sender;
        string ID = ddl.Text.ToString();
       // Response.Write(ID);
        string strConnString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(strConnString);
        conn.Open();
        SqlCommand command = new SqlCommand("select Name from ExerciseVideos WHERE ExcerciseType =@id", conn);
        //
        // Add new SqlParameter to the command.
        //
        command.Parameters.AddWithValue("@id", ID);
        //  excercisenames.Items.Add("--Select Video--");

        using (SqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                excercisenames.Items.Add(reader["Name"].ToString());
            }

        }
        conn.Close();
        excercisenames.Visible = true;
        AddMoreVideos.Visible = true;


    }

    protected void PARQ_Click(object sender, EventArgs e)
    {

    }
    public string BindData1()
    {
        string htmlStr = "";
        DataTable dt3 = this.GetData("select answer from PARQ_Answers where employee_id=1234 AND id=1");
        DataTable veena = this.GetData("select Questions from PARQ_Questions");
        foreach (DataRow row in dt3.Rows)
        {
            if (row["answer"] != null)
            {
                answers = row["answer"].ToString();
            }
            else
            {

            }
        }

        var arr = answers.Split(',');
        for (int i = 0; i < arr.Length; i++)
        {
            htmlStr += "<tr><td>" + veena.Rows[i]["Questions"] + "</td><td>" + arr[i] + "</td></tr>";
        }
        return htmlStr;
    }


    protected void SaveFormIntoDatabase_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(reviewdate1.Text) || string.IsNullOrEmpty(monthlystartdate.Text) || string.IsNullOrEmpty(monthlyenddate.Text) || string.IsNullOrEmpty(minigoaldate.Text) || Session["SolvingProblem"] == null)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('need to fill all dates')", true);
        }
        else
        {
            string id = Session["id_fitness"].ToString();
            DateTime problemStartDate = Convert.ToDateTime(Session["date_fitness"]);

            DateTime reviewdate = Convert.ToDateTime(reviewdate1.Text);
            Session["reviewdate"] = reviewdate.ToString();

            string history1 = historytext1.Text.ToString();
            string problem = "";
            string exam = "exam";
            //string exam = paneldropdown.SelectedItem.Text.ToString();
            string code = "";
            string dxcode = "";
            DateTime startdate = Convert.ToDateTime(monthlystartdate.Text);
            DateTime enddate = Convert.ToDateTime(monthlyenddate.Text);
            string goal1 = "";
            string payoffs = "";
            string suggestedvideos = "";
            string classes = "";
            DateTime goaldate11 = Convert.ToDateTime(minigoaldate.Text);

            string goal = "";
            string mis = "";
            string buddies = "";


            if (!string.IsNullOrEmpty(goal12.Text))
            {
                goal1 = goal12.Text.ToString();
            }
            if (!string.IsNullOrEmpty(pay.Text))
            {
                payoffs = pay.Text.ToString();
            }
            if (!string.IsNullOrEmpty(selectedVideos.Text))
            {
                suggestedvideos = selectedVideos.Text.ToString();
            }


            if (!string.IsNullOrEmpty(minigoals.Text))
            {
                goal = minigoals.Text.ToString();
            }
            if (!string.IsNullOrEmpty(miscellaneous.Text))
            {
                mis = miscellaneous.Text.ToString();

            }
            if (!string.IsNullOrEmpty(supportgroup.Text))
            {
                buddies = supportgroup.Text.ToString();
            }

            if (desiredTreatmentsList.SelectedIndex > -1)
            {
                problem = desiredTreatmentsList.SelectedItem.Text.ToString();
            }
            if (healthnames.SelectedIndex > -1)
            {
                code = healthnames.SelectedItem.Text.ToString();
            }
            if (healthcodes.SelectedIndex > -1)
            {
                dxcode = healthcodes.SelectedItem.Text.ToString();
            }

            classes = classesddl.SelectedItem.Text.ToString();

            int Nutrition_Eating;
            int Exercise_Fitness;
            int WeightManagement;
            int Muscle_Flexibility_Strength;
            int Stress_Management;

            int Diabetes;
            int Sleeping_Disturbance;
            int Addictive_Behaviour;
            int Cardiovascular_Heart;
            int Cancer;
            int Lab_Assessment_values_out_of_range;
            string query = "";
            if (desiredTreatmentsList.SelectedItem.Text.Trim().Equals("Nutrition/Eating"))
            {
                Nutrition_Eating = 1;
                query = "UPDATE Questionnaire_Fitness SET Nutrition_Eating = '" + Nutrition_Eating + "' WHERE employee_id='" + id + "' AND QuestionnaireDate_Fitness= '" + problemStartDate + "'";
            }
            else if (desiredTreatmentsList.SelectedItem.Text.Trim().Equals("Exercise/Fitness"))
            {
                Exercise_Fitness = 1;
                query = "UPDATE Questionnaire_Fitness SET Exercise_Fitness = '" + Exercise_Fitness + "' WHERE employee_id='" + id + "' AND QuestionnaireDate_Fitness= '" + problemStartDate + "'";
            }
            else if (desiredTreatmentsList.SelectedItem.Text.Trim().Equals("Weight Management"))
            {
                WeightManagement = 1;
                query = "UPDATE Questionnaire_Fitness SET WeightManagement = '" + WeightManagement + "' WHERE employee_id='" + id + "' AND QuestionnaireDate_Fitness= '" + problemStartDate + "'";
            }
            else if (desiredTreatmentsList.SelectedItem.Text.Trim().Equals("Muscle Flexibility/Strength"))
            {
                Muscle_Flexibility_Strength = 1;
                query = "UPDATE Questionnaire_Fitness SET Muscle_Flexibility_Strength = '" + Muscle_Flexibility_Strength + "' WHERE employee_id='" + id + "' AND QuestionnaireDate_Fitness= '" + problemStartDate + "'";
            }
            else if (desiredTreatmentsList.SelectedItem.Text.Trim().Equals("Stress Management"))
            {
                Stress_Management = 1;
                query = "UPDATE Questionnaire_Fitness SET Stress_Management = '" + Stress_Management + "' WHERE employee_id='" + id + "' AND QuestionnaireDate_Fitness= '" + problemStartDate + "'";
            }
            else if (desiredTreatmentsList.SelectedItem.Text.Trim().Equals("Sleeping Disturbance"))
            {
                Sleeping_Disturbance = 1;
                query = "UPDATE Questionnaire_Fitness SET Sleeping_Disturbance = '" + Sleeping_Disturbance + "' WHERE employee_id='" + id + "' AND QuestionnaireDate_Fitness= '" + problemStartDate + "'";
            }
            else if (desiredTreatmentsList.SelectedItem.Text.Trim().Equals("Addictive Behaviour"))
            {
                Addictive_Behaviour = 1;
                query = "UPDATE Questionnaire_Fitness SET Addictive_Behaviour = '" + Addictive_Behaviour + "' WHERE employee_id='" + id + "' AND QuestionnaireDate_Fitness= '" + problemStartDate + "'";
            }
            else if (desiredTreatmentsList.SelectedItem.Text.Trim().Equals("Diabetes"))
            {
                Diabetes = 1;
                query = "UPDATE Questionnaire_Fitness SET Diabetes = '" + Diabetes + "' WHERE employee_id='" + id + "' AND QuestionnaireDate_Fitness= '" + problemStartDate + "'";
            }
            else if (desiredTreatmentsList.SelectedItem.Text.Trim().Equals("Cardiovascular(Heart)"))
            {
                Cardiovascular_Heart = 1;
                query = "UPDATE Questionnaire_Fitness SET Cardiovascular_Heart = '" + Cardiovascular_Heart + "' WHERE employee_id='" + id + "' AND QuestionnaireDate_Fitness= '" + problemStartDate + "'";
            }
            else if (desiredTreatmentsList.SelectedItem.Text.Trim().Equals("Cancer"))
            {
                Cancer = 1;
                query = "UPDATE Questionnaire_Fitness SET Cancer = '" + Cancer + "' WHERE employee_id='" + id + "' AND QuestionnaireDate_Fitness= '" + problemStartDate + "'";
            }
            else
            {
                Lab_Assessment_values_out_of_range = 1;
                query = "UPDATE Questionnaire_Fitness SET Lab_Assessment_values_out_of_range = '" + Lab_Assessment_values_out_of_range + "' WHERE employee_id='" + id + "' AND QuestionnaireDate_Fitness= '" + problemStartDate + "'";
            }


            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("INSERT INTO FitnessLogging(Employee_Id,Date,ReviewDate,ProblemName,HistoryOfProblem,ObjectiveFindingExamName,ProblemCodeGroup,ProblemDxCodeDescription,MonthlyPlanStartDate,MonthlyPlanEndDate,Goal1,Payoffs1,SuggestedVideos,SuggestedClasses,MiniGoalDate,MiniGoal,Miscellaneous,FitnessBuddies) VALUES(@empid,@date,@reviewdate,@problemname,@history,@objectiveexam,@problemcode,@problemdxcode,@monthlystartdate,@monthlyenddate,@goal1,@payoffs1,@suggestedvideos,@suggestedclasses,@minigoaldate11,@minigoal,@miscellaneous,@fitnessbuddies)", con);
            //SqlCommand cmd = new SqlCommand("UPDATE MealPlanactual SET monday=@monday,tuesday=@tuesday,wednesday=@wednesday,thursday=@thursday,friday=@friday,saturday=@saturday,sunday=@sunday,breakfasttime=@breakfasttime,breakfastsnacktime=@breakfastsnacktime,lunchtime=@lunchtime,lunchsnacktime=@lunchsnacktime,dinner=@dinner,dinnersnacktime=@dinnersnacktime,startdate=@startdate,enddate=@enddate WHERE ID=@ID", con);
            SqlCommand cmd2 = new SqlCommand(query, con);

            try
            {
                con.Open();


                cmd2.ExecuteNonQuery();


                cmd.Parameters.AddWithValue("@empid", SqlDbType.NVarChar).Value = id;

                //cmd.Parameters.AddWithValue("@date", date1);
                cmd.Parameters.AddWithValue("@date", SqlDbType.DateTime2).Value = problemStartDate;

                cmd.Parameters.AddWithValue("@reviewdate", SqlDbType.DateTime2).Value = reviewdate;
                //cmd.Parameters.AddWithValue("@date", SqlDbType.DateTime).Value = DateTime.Now;
                //cmd.Parameters.AddWithValue("@reviewdate", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.AddWithValue("@problemname", SqlDbType.NVarChar).Value = problem;
                cmd.Parameters.AddWithValue("@history", SqlDbType.NVarChar).Value = history1;
                cmd.Parameters.AddWithValue("@objectiveexam", SqlDbType.NVarChar).Value = exam;
                cmd.Parameters.AddWithValue("@problemcode", SqlDbType.NVarChar).Value = code;
                cmd.Parameters.AddWithValue("@problemdxcode", SqlDbType.NVarChar).Value = dxcode;
                cmd.Parameters.AddWithValue("@monthlystartdate", SqlDbType.DateTime2).Value = startdate;
                cmd.Parameters.AddWithValue("@monthlyenddate", SqlDbType.NVarChar).Value = enddate;

                //cmd.Parameters.AddWithValue("@monthlystartdate", SqlDbType.DateTime).Value = DateTime.Now;
                //cmd.Parameters.AddWithValue("@monthlyenddate", SqlDbType.DateTime).Value = DateTime.Now;

                cmd.Parameters.AddWithValue("@goal1", SqlDbType.NVarChar).Value = goal1;
                cmd.Parameters.AddWithValue("@payoffs1", SqlDbType.NVarChar).Value = payoffs;
                cmd.Parameters.AddWithValue("@suggestedvideos", SqlDbType.NVarChar).Value = suggestedvideos;
                cmd.Parameters.AddWithValue("@suggestedclasses", SqlDbType.NVarChar).Value = classeslisttextbox.Text.ToString();
                cmd.Parameters.AddWithValue("@minigoaldate11", SqlDbType.DateTime2).Value = goaldate11;

                //cmd.Parameters.AddWithValue("@minigoaldate11", SqlDbType.DateTime).Value = DateTime.Now;

                cmd.Parameters.AddWithValue("@minigoal", SqlDbType.NVarChar).Value = goal;
                cmd.Parameters.AddWithValue("@miscellaneous", SqlDbType.NVarChar).Value = mis;
                cmd.Parameters.AddWithValue("@fitnessbuddies", SqlDbType.NVarChar).Value = buddies;

                //cmd1.Parameters.AddWithValue("@solvedProblem", SqlDbType.Int).Value = no;
                //cmd1.Parameters.AddWithValue("@ID", SqlDbType.NVarChar).Value = empid;

                //cmd1.Parameters.AddWithValue("@date1", SqlDbType.NVarChar).Value = date1;

                int a = cmd.ExecuteNonQuery();
                //int a1 = cmd1.ExecuteNonQuery();
                if (a == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something Went Wrong.Can you Insert It Again')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('SOAP Inserted Successfully')", true);
                }

                cmd2.ExecuteNonQuery();
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
    private string Decrypt(string cipherText)
    {
        string EncryptionKey = "MAKV2SPBNI99212";
        cipherText = cipherText.Replace(" ", "+");
        byte[] cipherBytes = Convert.FromBase64String(cipherText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.Close();
                }
                cipherText = Encoding.Unicode.GetString(ms.ToArray());
            }
        }
        return cipherText;
    }


    protected void solved_Click(object sender, EventArgs e)
    {
        string id = Session["id_fitness"].ToString();

        DateTime problemStartDate = Convert.ToDateTime(Session["date_fitness"]);
        int Nutrition_Eating;
        int Exercise_Fitness;
        int WeightManagement;
        int Muscle_Flexibility_Strength;
        int Stress_Management;

        int Diabetes;
        int Sleeping_Disturbance;
        int Addictive_Behaviour;
        int Cardiovascular_Heart;
        int Cancer;
        int Lab_Assessment_values_out_of_range;
        string query = "";
        if (desiredTreatmentsList.SelectedItem.Text.Trim().Equals("Nutrition/Eating"))
        {
            Nutrition_Eating = 2;
            query = "UPDATE Questionnaire_Fitness SET Nutrition_Eating = '" + Nutrition_Eating + "' WHERE employee_id=@empid AND QuestionnaireDate_Fitness=@date";
        }
        else if (desiredTreatmentsList.SelectedItem.Text.Trim().Equals("Exercise/Fitness"))
        {
            Exercise_Fitness = 2;
            query = "UPDATE Questionnaire_Fitness SET Exercise_Fitness = '" + Exercise_Fitness + "' WHERE employee_id=@empid AND QuestionnaireDate_Fitness=@date";
        }
        else if (desiredTreatmentsList.SelectedItem.Text.Trim().Equals("Weight Management"))
        {
            WeightManagement = 2;
            query = "UPDATE Questionnaire_Fitness SET WeightManagement = '" + WeightManagement + "' WHERE employee_id=@empid AND QuestionnaireDate_Fitness=@date";
        }
        else if (desiredTreatmentsList.SelectedItem.Text.Trim().Equals("Muscle Flexibility/Strength"))
        {
            Muscle_Flexibility_Strength = 2;
            query = "UPDATE Questionnaire_Fitness SET Muscle_Flexibility_Strength = '" + Muscle_Flexibility_Strength + "' WHERE employee_id=@empid AND QuestionnaireDate_Fitness=@date";
        }
        else if (desiredTreatmentsList.SelectedItem.Text.Trim().Equals("Stress Management"))
        {
            Stress_Management = 2;
            query = "UPDATE Questionnaire_Fitness SET Stress_Management = '" + Stress_Management + "' WHERE employee_id=@empid AND QuestionnaireDate_Fitness=@date";
        }
        else if (desiredTreatmentsList.SelectedItem.Text.Trim().Equals("Sleeping Disturbance"))
        {
            Sleeping_Disturbance = 2;
            query = "UPDATE Questionnaire_Fitness SET Sleeping_Disturbance = '" + Sleeping_Disturbance + "' WHERE employee_id=@empid AND QuestionnaireDate_Fitness=@date";
        }
        else if (desiredTreatmentsList.SelectedItem.Text.Trim().Equals("Addictive Behaviour"))
        {
            Addictive_Behaviour = 2;
            query = "UPDATE Questionnaire_Fitness SET Addictive_Behaviour = '" + Addictive_Behaviour + "' WHERE employee_id=@empid AND QuestionnaireDate_Fitness=@date";
        }
        else if (desiredTreatmentsList.SelectedItem.Text.Trim().Equals("Diabetes"))
        {
            Diabetes = 2;
            query = "UPDATE Questionnaire_Fitness SET Diabetes = '" + Diabetes + "' WHERE employee_id=@empid AND QuestionnaireDate_Fitness=@date";
        }
        else if (desiredTreatmentsList.SelectedItem.Text.Trim().Equals("Cardiovascular(Heart)"))
        {
            Cardiovascular_Heart = 2;
            query = "UPDATE Questionnaire_Fitness SET Cardiovascular_Heart = '" + Cardiovascular_Heart + "' WHERE employee_id=@empid AND QuestionnaireDate_Fitness=@date";
        }
        else if (desiredTreatmentsList.SelectedItem.Text.Trim().Equals("Cancer"))
        {
            Cancer = 2;
            query = "UPDATE Questionnaire_Fitness SET Cancer = '" + Cancer + "' WHERE employee_id=@empid AND QuestionnaireDate_Fitness=@date";
        }
        else
        {
            Lab_Assessment_values_out_of_range = 2;
            query = "UPDATE Questionnaire_Fitness SET Lab_Assessment_values_out_of_range = '" + Lab_Assessment_values_out_of_range + "' WHERE employee_id=@empid AND QuestionnaireDate_Fitness=@date";
        }

        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);
        SqlCommand cmd2 = new SqlCommand(query, con);
        try
        {
            con.Open();
            

            cmd2.Parameters.AddWithValue("@empid", SqlDbType.NVarChar).Value = id;


            cmd2.Parameters.AddWithValue("@date", SqlDbType.DateTime2).Value = problemStartDate;

            
            int c = cmd2.ExecuteNonQuery();
            if (c == 0)
            {

            }
            else
            {

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
        Session["actualseletpres"] = "";
        Session["SolvingProblem"] = "";
    }

    protected void desiredTreatmentsList_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["SolvingProblem"] = desiredTreatmentsList.SelectedItem.Text.ToString();
        //desiredTreatmentsList.SelectedItem.Text = Session["SolvingProblem"].ToString();
        state1 = "exapnd";
    }

    protected void AddMoreVideos_Click1(object sender, EventArgs e)
    {
        selectedVideos.Visible = true;

        selectedVideos.Text += ";" + excercisenames.SelectedItem.Text.ToString();
    }

protected void reviewdate1_TextChanged(object sender, EventArgs e)
    {
        Session["re"] = Convert.ToDateTime(reviewdate1.Text.ToString());
        state1 = "expand";
    }
    protected void addclasses_Click(object sender, EventArgs e)
    {
        ids = Session["classids"].ToString().Split(new string[] { "," }, StringSplitOptions.None);
        pres = Session["presentations"].ToString().Split(new string[] { "," }, StringSplitOptions.None);
        // Response.Write(classesddl.SelectedIndex);
        int selectedvalue = classesddl.SelectedIndex;
        int desiredvalueindex = selectedvalue + 1;
        string selctedid = ids[desiredvalueindex];
        string selectedpresentation = pres[selectedvalue - 1];
        if (Session["actualseletpres"] == null)
        {
            Session["actualseletpres"] = selectedpresentation + ",";
        }
        else
        {
            Session["actualseletpres"] = Session["actualseletpres"].ToString() + selectedpresentation + ",";
        }
       // Response.Write(selctedid);
       // Response.Write(selectedpresentation);
        classeslisttextbox.Text = Session["actualseletpres"].ToString();

    }

    

    protected void A1_Click(object sender, EventArgs e)
    {

        if(string.IsNullOrEmpty(reviewdate1.Text) || Session["SolvingProblem"] == null)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('need to select problem and review date')", true);
            //Response.Write("<script>window.open('FitnessMealPlan.aspx','_blank'); return false; </script>");
        }
        else
        {
            string redirect = "<script>window.open('FitnessMealPlan.aspx','_blank');</script>";
            Response.Write(redirect);
            
            
        }
       // Response.Write("<script>alert('hello')</script>");
    }

    protected void expandallfitbtn_Click(object sender, EventArgs e)
    {
        state = "expand";
        state1 = "expand";
        state2 = "expand";
        state3 = "expand";
        expandoutfitbtn.Visible = true;
        expandallfitbtn.Visible = false;
       

    }

    protected void expandoutfitbtn_Click(object sender, EventArgs e)
    {
        state = "collapse";
        state1 = "collapse";
        state2 = "collapse";
        state3 = "collapse";
        expandallfitbtn.Visible = true;
        expandoutfitbtn.Visible = false;

    }

    protected void objectivenxtfitbtn_Click(object sender, EventArgs e)
    {
        state = "expand";
        state3 = "collapse";

    }

    protected void nxtbtn_Click(object sender, EventArgs e)
    {
        state3 = "expand";
    }

    protected void assmntnxtbtn_Click(object sender, EventArgs e)
    {
        state2 = "expand";
        state = "collapse";
    }

    protected void objExam_Click(object sender, EventArgs e)
    {

        if (string.IsNullOrEmpty(reviewdate1.Text) || Session["SolvingProblem"] == null)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('need to select problem and review date')", true);
            //Response.Write("<script>window.open('FitnessMealPlan.aspx','_blank'); return false; </script>");
        }
        else
        {
            string redirect = "<script>window.open('FitnessObjectiveFindingsExam.aspx','_blank');</script>";
            Response.Write(redirect);
            state3 = "expand";

        }
        // Response.Write("<script>alert('hello')</script>");
    }
}