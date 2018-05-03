using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HealthFitnessTesting : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        empnamehealthPage.Text = Session["EmployeeName"].ToString();
        //empnamehealthPage.Text = "JSC001 JSC001";
    }

    public string GetData(int option)
    {
        string htmlStr = "";
        string employee_id = Convert.ToString(Session["id_health"]);
        //Session["id_health"] = "jsc001";
        //string employee_id = "jsc001";
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM [FitnessTesting] WHERE ([employee_id] = @employee_id) ORDER BY [date] DESC";
                cmd.Parameters.AddWithValue("@employee_id", employee_id);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                if (option == 1)
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            htmlStr += "<tr><td>"
                                                      + dt.Rows[i]["date"].ToString() + "</td><td>"
                                                      + dt.Rows[i]["blood_pressure"].ToString() + "/" + dt.Rows[i]["blood_pressure2"].ToString() + "</td><td>"
                                                      + dt.Rows[i]["heart_rate"].ToString() + "</td><td>"
                                                      + dt.Rows[i]["weight"].ToString() + "</td><td>"
                                                      + dt.Rows[i]["skin_fold1"].ToString() + "/" + dt.Rows[i]["skin_fold2"].ToString() + "/" + dt.Rows[i]["skin_fold3"].ToString() + "</td><td>"
                                                      + dt.Rows[i]["bmi"].ToString() + "</td><td>"
                                                               + dt.Rows[i]["body_fat1"].ToString() + "</td><td>"
                                                               + dt.Rows[i]["sit_reach1"].ToString() + "/" + dt.Rows[i]["sit_reach2"].ToString() + "/" + dt.Rows[i]["sit_reach3"].ToString() + "</td></tr>";
                        }
                    }
                }
                else
                {
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            htmlStr += "<tr><td>"
                                                      + dt.Rows[i]["date"].ToString() + "</td><td>"
                                                               + dt.Rows[i]["hip_flexion"].ToString() + "</td><td>"
                                                               + dt.Rows[i]["hip_extension"].ToString() + "</td><td>"
                                                               + dt.Rows[i]["l_side_bridge"].ToString() + " / "
                                                               + dt.Rows[i]["r_side_bridge"].ToString() + "</td><td>"
                                                              + dt.Rows[i]["grip_right"].ToString() + " / " + dt.Rows[i]["grip_left"].ToString() + "</td><td>"
                                                               + dt.Rows[i]["push_up"].ToString() + "</td><td>"
                                                               + dt.Rows[i]["curl_ups"].ToString() + "</td><td>"
                                                               + dt.Rows[i]["knee_bend"].ToString() + "</td><td>"
                                                               + dt.Rows[i]["arm_raise"].ToString() + "</td></tr>";
                        }
                    }
                }

            }
        }
        return htmlStr;
    }
}