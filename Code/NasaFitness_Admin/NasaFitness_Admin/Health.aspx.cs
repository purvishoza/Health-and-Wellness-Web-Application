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

public partial class Health : System.Web.UI.Page
{
    string empid;
    DateTime date; string answers; string CurrentProblems, DesiredTreatment;
    string[] ids;
    string[] pres;
    public string state = "collapse";
    public string state1 = "collapse";
    public string state2 = "collapse";
    public string state3 = "collapse";
    //protected void page_init

    //string[] problemList = new string[] { "Head Ache", "Neck Pain", "Knee Pain", "Palm Pain" };
    public void Page_Load(object sender, EventArgs e)
    {
        //A1.ServerClick += new EventHandler(A1_Click);
        //A2.ServerClick +=new EventHandler(A2_Click);
       if(Request.QueryString["id"] != null) {
            Session["id_health"] = Request.QueryString["id"];
            objExam1.ServerClick += new EventHandler(objExam1_Click);
            Session["date_health"] = Request.QueryString["date"];
            Session["dp_health"] = Request.QueryString["dp"];
            Session["problem_health"] = Request.QueryString["prob"];
        }
        
            if (!Page.IsPostBack)
            {
                //if (Session["flag"].ToString().Equals("true"))
                //{
                string classids = "";
                string presentations = "";
                SqlConnection con1 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);
                SqlCommand cmd1 = new SqlCommand("SELECT Id,Topic,Presentation FROM Presentation_QuestionsAnswers where Topic is not null", con1);
                classesddl.Items.Add("Classes");
                //cmd.Parameters.AddWithValue("@empid", "1527");
                //cmd.Parameters.AddWithValue("@prese",DBNull.Value);
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
                if (Session["selectedProblem"] != null)
                {
                    desiredTreatmentsList.SelectedValue = Session["selectedProblem"].ToString();

                }


                if (ViewState["history"] != null)
                {
                    historytext1.Text = ViewState["history"].ToString();

                }
                else
                {

                }
                // Response.Write(ViewState["history"].ToString());
                healthnames.Items.Clear();
                healthnames.Items.Add("select code");
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
                excercisesTypes.Items.Add("ExcerciseTypes");
                DataTable dt1 = this.GetData("select DISTINCT ExcerciseType from ExerciseVideos WHERE ExcerciseType IS NOT NULL");
                //excercisesTypes.Items.Add("Select Excercise Video Type");

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




                desiredTreatmentsList.Items.Clear();
                empid = Session["id_health"].ToString();
                //Session["EmployeeId"] = empid;
                // date = null;
                date = Convert.ToDateTime(Session["date_health"]);
                CurrentProblems = "";
                CurrentProblems = Session["problem_health"].ToString();
                current.InnerText = " " + CurrentProblems;
                DesiredTreatment = "";
                DesiredTreatment = Session["dp_health"].ToString();
               // desired.InnerText = " " + DesiredTreatment;
                string[] DesiredTreatmentArray = DesiredTreatment.Split(';');
            foreach(string temp in DesiredTreatmentArray)
            {   if(temp != "") { 
                desired.InnerText += temp + ";" ;
                }
            }
                desiredTreatmentsList.Items.Add("select");
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

                    empnamehealthPage.Text = row["FName"].ToString() + "," + row["LName"].ToString();
                    Session["EmployeeName"] = row["FName"].ToString() + "," + row["LName"].ToString();
                }




                //for gridview column answers



                DataTable dt3 = this.GetData("select answer from PARQ_Answers where employee_id='" +empid + "'");
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
                //    dt4.Columns.AddRange(new DataColumn[2] { new DataColumn("Name",
                //typeof(string)),
                //new DataColumn("Age", typeof(string)) });
                for (int i = 0; i < answers.Length; i++)
                {
                    dt4.Rows.Add(answers[i]);
                }
                var arr = answers.Split(',');
            }
     //   Response.Redirect("~/Health.aspx");
    }


    protected void Save_Click(object sender, EventArgs e)
    {

    }

    protected void send_Click(object sender, EventArgs e)
    {

    }

    public void healthnames_SelectedIndexChanged(object sender, EventArgs e)
    {
        healthcodes.Items.Clear();
        state = "expand";
        DataTable dt1 = new DataTable();
        DropDownList ddl = (DropDownList)sender;
        string ID = ddl.Text.ToString();
        //Response.Write(ID);
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
                healthcodes.Items.Add(reader["DxCode"].ToString() + "," + "----" + reader["Description"].ToString());

                // result.Add(reader["DxCode"].ToString());
            }

            // iterate your results here
            //Console.WriteLine(String.Format("{0}", reader["id"]));

        }
        // Session["c"] = result;
        conn.Close();
        healthcodes.Visible = true;
        assmntnxtbtn.Visible = true;

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



    protected void AddMoreVideos_Click(object sender, EventArgs e)
    {
        selectedVideos.Visible = true;

        selectedVideos.Text += ";" + excercisenames.SelectedItem.Text.ToString();
        state2 = "expand";
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
        SqlCommand command = new SqlCommand("select * from ExerciseVideos ", conn);
        //
        // Add new SqlParameter to the command.
        //
       // command.Parameters.AddWithValue("@id", ID);
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



    protected void paneldropdown_SelectedIndexChanged(object sender, EventArgs e)
    {


    }
    protected void addclasses_Click(object sender, EventArgs e)
    {
        ids = Session["classids"].ToString().Split(new string[] { "," }, StringSplitOptions.None);
        pres = Session["presentations"].ToString().Split(new string[] { "," }, StringSplitOptions.None);
        // Response.Write(classesddl.SelectedIndex);
        int selectedvalue = classesddl.SelectedIndex;
        int desiredvalueindex = selectedvalue + 1;
        string selctedid = ids[desiredvalueindex];
        state2 = "expand";
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
    protected void SaveFormIntoDatabase_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(reviewdate1.Text) || string.IsNullOrEmpty(monthlystartdate.Text) || string.IsNullOrEmpty(monthlyenddate.Text) || string.IsNullOrEmpty(minigoaldate.Text) || Session["SolvingProblem"] == null)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('need to fill all dates')", true);
        }
        else
        {
            string id = Session["id_health"].ToString();
            DateTime problemStartDate = Convert.ToDateTime(Session["date_health"]);
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

            int Headache;
            int NeckPain;
            int Arms_Hands_Pain;
            int ShoulderBladePain;
            int LowBackPain;
            int Legs_Feet_Pain_Numbness;
            string query = "";

            if (desiredTreatmentsList.SelectedItem.Text.Trim().Equals("Headache"))
            {
                Headache = 1;
                query = "UPDATE HealthQuestionnaire SET Headache= '" + Headache + "'WHERE employee_id=@ID AND QuestionnaireDate=@date1";
            }
            else if (desiredTreatmentsList.SelectedItem.Text.Trim().Equals("Neck Pain"))
            {
                NeckPain = 1;
                query = "UPDATE HealthQuestionnaire SET Headache= '" + NeckPain + "'WHERE employee_id=@ID AND QuestionnaireDate=@date1";
            }
            else if (desiredTreatmentsList.SelectedItem.Text.Trim().Equals("Arms/Hands Pain/Numbness/Tingling"))
            {
                Arms_Hands_Pain = 1;
                query = "UPDATE HealthQuestionnaire SET Arms_Hands_Pain= '" + Arms_Hands_Pain + "'WHERE employee_id=@ID AND QuestionnaireDate=@date1";
            }
            else if (desiredTreatmentsList.SelectedItem.Text.Trim().Equals("Shoulder blade pain"))
            {
                ShoulderBladePain = 1;
                query = "UPDATE HealthQuestionnaire SET ShoulderBladePain= '" + ShoulderBladePain + "'WHERE employee_id=@ID AND QuestionnaireDate=@date1";
            }
            else if (desiredTreatmentsList.SelectedItem.Text.Trim().Equals("Low Back Pain"))
            {
                LowBackPain = 1;
                query = "UPDATE HealthQuestionnaire SET LowBackPain= '" + LowBackPain + "'WHERE employee_id=@ID AND QuestionnaireDate=@date1";
            }
            else if (desiredTreatmentsList.SelectedItem.Text.Trim().Equals("Legs/Feet Pain, Numbness, or Tingling"))
            {
                Legs_Feet_Pain_Numbness = 1;
                query = "UPDATE HealthQuestionnaire SET Legs_Feet_Pain_Numbness= '" + Legs_Feet_Pain_Numbness + "'WHERE employee_id=@ID AND QuestionnaireDate=@date1";
            }
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("INSERT INTO HealthLogging(Employee_Id,Date,ReviewDate,ProblemName,HistoryOfProblem,ObjectiveFindingExamName,ProblemCodeGroup,ProblemDxCodeDescription,MonthlyPlanStartDate,MonthlyPlanEndDate,Goal1,Payoffs1,SuggestedVideos,SuggestedClasses,MiniGoalDate,MiniGoal,Miscellaneous,FitnessBuddies) VALUES(@empid,@date,@reviewdate,@problemname,@history,@objectiveexam,@problemcode,@problemdxcode,@monthlystartdate,@monthlyenddate,@goal1,@payoffs1,@suggestedvideos,@suggestedclasses,@minigoaldate11,@minigoal,@miscellaneous,@fitnessbuddies)", con);
            //SqlCommand cmd = new SqlCommand("UPDATE MealPlanactual SET monday=@monday,tuesday=@tuesday,wednesday=@wednesday,thursday=@thursday,friday=@friday,saturday=@saturday,sunday=@sunday,breakfasttime=@breakfasttime,breakfastsnacktime=@breakfastsnacktime,lunchtime=@lunchtime,lunchsnacktime=@lunchsnacktime,dinner=@dinner,dinnersnacktime=@dinnersnacktime,startdate=@startdate,enddate=@enddate WHERE ID=@ID", con);
            SqlCommand cmd1 = new SqlCommand(query, con);

            try
            {
                con.Open();


                cmd.Parameters.AddWithValue("@empid", SqlDbType.NVarChar).Value = id;
                cmd1.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = id;
                //cmd.Parameters.AddWithValue("@date", date1);
                cmd.Parameters.AddWithValue("@date", SqlDbType.DateTime2).Value = problemStartDate;
                cmd1.Parameters.AddWithValue("@date1", SqlDbType.DateTime2).Value = problemStartDate;
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



                cmd.Parameters.AddWithValue("@goal1", SqlDbType.NVarChar).Value = goal1;
                cmd.Parameters.AddWithValue("@payoffs1", SqlDbType.NVarChar).Value = payoffs;
                cmd.Parameters.AddWithValue("@suggestedvideos", SqlDbType.NVarChar).Value = suggestedvideos;
                cmd.Parameters.AddWithValue("@suggestedclasses", SqlDbType.NVarChar).Value = classeslisttextbox.Text.ToString();
                cmd.Parameters.AddWithValue("@minigoaldate11", SqlDbType.DateTime2).Value = goaldate11;



                cmd.Parameters.AddWithValue("@minigoal", SqlDbType.NVarChar).Value = goal;
                cmd.Parameters.AddWithValue("@miscellaneous", SqlDbType.NVarChar).Value = mis;
                cmd.Parameters.AddWithValue("@fitnessbuddies", SqlDbType.NVarChar).Value = buddies;


                int a = cmd.ExecuteNonQuery();
                int a1 = cmd1.ExecuteNonQuery();
                if (a1 == 0)
                {

                }
                else
                {

                }
                if (a == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something Went Wrong.Can you Insert It Again')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Health Inventory of the Patient is Updated Successfully')", true);
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
        string id = Session["id_health"].ToString();

        DateTime problemStartDate = Convert.ToDateTime(Session["date_health"]);
        int Headache;
        int NeckPain;
        int Arms_Hands_Pain;
        int ShoulderBladePain;
        int LowBackPain;
        int Legs_Feet_Pain_Numbness;
        string query = "";

        if (desiredTreatmentsList.SelectedItem.Text.Trim().Equals("Headache"))
        {
            Headache = 2;
            query = "UPDATE HealthQuestionnaire SET Headache= '" + Headache + "'WHERE employee_id=@ID AND QuestionnaireDate=@date1";
        }
        else if (desiredTreatmentsList.SelectedItem.Text.Trim().Equals("Neck Pain"))
        {
            NeckPain = 2;
            query = "UPDATE HealthQuestionnaire SET Headache= '" + NeckPain + "'WHERE employee_id=@ID AND QuestionnaireDate=@date1";
        }
        else if (desiredTreatmentsList.SelectedItem.Text.Trim().Equals("Arms/Hands Pain/Numbness/Tingling"))
        {
            Arms_Hands_Pain = 2;
            query = "UPDATE HealthQuestionnaire SET Arms_Hands_Pain= '" + Arms_Hands_Pain + "'WHERE employee_id=@ID AND QuestionnaireDate=@date1";
        }
        else if (desiredTreatmentsList.SelectedItem.Text.Trim().Equals("Shoulder blade pain"))
        {
            ShoulderBladePain = 2;
            query = "UPDATE HealthQuestionnaire SET ShoulderBladePain= '" + ShoulderBladePain + "'WHERE employee_id=@ID AND QuestionnaireDate=@date1";
        }
        else if (desiredTreatmentsList.SelectedItem.Text.Trim().Equals("Low Back Pain"))
        {
            LowBackPain = 2;
            query = "UPDATE HealthQuestionnaire SET LowBackPain= '" + LowBackPain + "'WHERE employee_id=@ID AND QuestionnaireDate=@date1";
        }
        else if (desiredTreatmentsList.SelectedItem.Text.Trim().Equals("Legs/Feet Pain, Numbness, or Tingling"))
        {
            Legs_Feet_Pain_Numbness = 2;
            query = "UPDATE HealthQuestionnaire SET Legs_Feet_Pain_Numbness= '" + Legs_Feet_Pain_Numbness + "'WHERE employee_id=@ID AND QuestionnaireDate=@date1";
        }
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);
        //SqlCommand cmd = new SqlCommand("INSERT INTO HealthLogging(Employee_Id,Date,ReviewDate,ProblemName,HistoryOfProblem,ObjectiveFindingExamName,ProblemCodeGroup,ProblemDxCodeDescription,MonthlyPlanStartDate,MonthlyPlanEndDate,Goal1,Payoffs1,SuggestedVideos,SuggestedClasses,MiniGoalDate,MiniGoal,Miscellaneous,FitnessBuddies) VALUES(@empid,@date,@reviewdate,@problemname,@history,@objectiveexam,@problemcode,@problemdxcode,@monthlystartdate,@monthlyenddate,@goal1,@payoffs1,@suggestedvideos,@suggestedclasses,@minigoaldate11,@minigoal,@miscellaneous,@fitnessbuddies)", con);
        //SqlCommand cmd = new SqlCommand("UPDATE MealPlanactual SET monday=@monday,tuesday=@tuesday,wednesday=@wednesday,thursday=@thursday,friday=@friday,saturday=@saturday,sunday=@sunday,breakfasttime=@breakfasttime,breakfastsnacktime=@breakfastsnacktime,lunchtime=@lunchtime,lunchsnacktime=@lunchsnacktime,dinner=@dinner,dinnersnacktime=@dinnersnacktime,startdate=@startdate,enddate=@enddate WHERE ID=@ID", con);
        SqlCommand cmd1 = new SqlCommand(query, con);
        try
        {
            con.Open();


            cmd1.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = id;


            cmd1.Parameters.AddWithValue("@date1", SqlDbType.DateTime2).Value = problemStartDate;
            int c = cmd1.ExecuteNonQuery();
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


    }
    protected void desiredTreatmentsList_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["SolvingProblem"] = desiredTreatmentsList.SelectedItem.Text.ToString();
        //desiredTreatmentsList.SelectedItem.Text = Session["SolvingProblem"].ToString();
        state1 = "exapnd";
    }

   

    protected void reviewdate1_TextChanged(object sender, EventArgs e)
    {
        Session["re"] = reviewdate1.Text.ToString();
        state1 = "expand";
    }

    
    protected void A1_Click(object sender, EventArgs e)
    {

        if (string.IsNullOrEmpty(reviewdate1.Text) || Session["SolvingProblem"] == null)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('need to select problem and review date')", true);
            //Response.Write("<script>window.open('FitnessMealPlan.aspx','_blank'); return false; </script>");
        }
        else
        {
            state2 = "expand";
            string redirect = "<script>window.open('MealPlan.aspx','_blank');</script>";
            Response.Write(redirect);


        }
        // Response.Write("<script>alert('hello')</script>");
    }
    protected void A2_Click(object sender, EventArgs e)
    {

        if (string.IsNullOrEmpty(reviewdate1.Text) || Session["SolvingProblem"] == null)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('need to select problem and review date')", true);
            //Response.Write("<script>window.open('FitnessMealPlan.aspx','_blank'); return false; </script>");
        }
        else
        {
            state2 = "expand";
            string redirect = "<script>window.open('PARQ.aspx','_blank');</script>";
            Response.Write(redirect);


        }
        // Response.Write("<script>alert('hello')</script>");
    }


    protected void nxtbtn_Click(object sender, EventArgs e)
    {
        //nxtbtn.Attributes.Add("onclick", "return false;");
        state3 = "expand";
        
    }

    protected void objectivenxtbtn_Click(object sender, EventArgs e)
    {
        state = "expand";
        state3 = "collapse";
    }

    protected void assmntnxtbtn_Click(object sender, EventArgs e)
    {
        state2 = "expand";
        state = "collapse";
    }

    protected void expandallbtn_Click(object sender, EventArgs e)
    {
        state = "expand";
        state1 = "expand";
        state2 = "expand";
        state3 = "expand";
        expandout.Visible = true;
        expandallbtn.Visible = false;
    }

    protected void expandout_Click(object sender, EventArgs e)
    {
        state = "collapse";
        state1 = "collapse";
        state2 = "collapse";
        state3 = "collapse";
        expandallbtn.Visible = true;
        expandout.Visible = false;
    }

    protected void objExam1_Click(object sender, EventArgs e)
    {

        if (string.IsNullOrEmpty(reviewdate1.Text) || Session["SolvingProblem"] == null)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('need to select problem and review date')", true);
            //Response.Write("<script>window.open('FitnessMealPlan.aspx','_blank'); return false; </script>");
        }
        else
        {
            string redirect = "<script>window.open('ObjectiveFindingsExam.aspx','_blank');</script>";
            Response.Write(redirect);
            state3 = "expand";


        }

    }
    
}