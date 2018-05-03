using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Configuration;

namespace NasaFitness_Employee
{
    public partial class PersonalInformation3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand("SELECT * FROM SecondaryInsurance where EmpID = @empid", con);
                cmd.Parameters.AddWithValue("@empid", Session["empid"].ToString());
                try
                {
                    con.Open();

                    SqlDataReader sqlReader = cmd.ExecuteReader();
                    while (sqlReader.Read())
                    {

                        sinsID.Text = sqlReader["SInsuranceID"].ToString();
                        Ssign.Text = sqlReader["SInsuranceGNum"].ToString();
                        Scompany.Text = sqlReader["SCompany"].ToString();
                        Stype.Text = sqlReader["SInsuranceType"].ToString();
                        Srelation.Text = sqlReader["SRelation"].ToString();
                        SGname.Text = sqlReader["SGName"].ToString();
                        SGaddress.Text = sqlReader["SGAddress"].ToString();
                        SGcity.Text = sqlReader["SGCity"].ToString();
                        SGstate.Text = sqlReader["SGState"].ToString();
                        SGzip.Text = sqlReader["SGZip"].ToString();
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
        }

        protected void save_secondaryIns_info(object sender, EventArgs e)
        {
            SqlConnection constr = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);

            SqlCommand cmd = new SqlCommand("if exists (select * from SecondaryInsurance with (updlock,serializable) where EmpID = @empid)" +
                                            "begin update SecondaryInsurance set EmpID = @empid, SInsuranceID = @sinsID, SInsuranceGNum = @Ssign, SCompany = @Scompany, SInsuranceType = @Stype, SRelation = @Srelation, SGName = @SGname, SGAddress = @SGaddress, SGCity = @SGcity, SGState = @SGstate, SGZip = @SGzip where EmpID = @empid end else begin " +
                                            "insert into SecondaryInsurance(ID, EmpID, SInsuranceID, SInsuranceGNum, SCompany, SInsuranceType, SRelation, SGName, SGAddress, SGCity, SGState, SGZip)" +
                                            "values(@id, @empid, @sinsID, @Ssign, @Scompany, @Stype, @Srelation, @SGname, @SGaddress, @SGcity, @SGstate, @SGzip)" +
                                            "end", constr);


            try
            {
                constr.Open();

                cmd.Parameters.AddWithValue("@id", sinsID.Text.Trim());
                cmd.Parameters.AddWithValue("@sinsID", sinsID.Text.Trim());
                cmd.Parameters.AddWithValue("@Ssign", Ssign.Text.Trim());
                cmd.Parameters.AddWithValue("@Scompany", Scompany.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@Stype", Stype.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@Srelation", Srelation.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@SGname", SGname.Text.Trim());
                cmd.Parameters.AddWithValue("@SGaddress", SGaddress.Text.Trim());
                cmd.Parameters.AddWithValue("@SGcity", SGcity.Text.Trim());
                cmd.Parameters.AddWithValue("@SGstate", SGstate.Text.Trim());
                cmd.Parameters.AddWithValue("@SGzip", SGzip.Text.Trim());

                cmd.Parameters.AddWithValue("@empid", Session["empid"]);
                int a = cmd.ExecuteNonQuery();
                if (a <= 0)
                {

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully Updated.'); ", true);
                }
            }

            catch (Exception ex)
            {
                Response.Write(ex);
                Console.WriteLine(ex);
            }
            finally
            {
                constr.Close();

            }
            Response.Redirect("HIPPA.aspx");
            //Server.Transfer("HIPPA.aspx");
        }

        protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Srelation.SelectedValue == "Self")
            {
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand("SELECT * FROM web_users where Pernr = @empid", con);
                cmd.Parameters.AddWithValue("@empid", Session["empid"].ToString());
                try
                {
                    con.Open();

                    SqlDataReader sqlReader = cmd.ExecuteReader();
                    while (sqlReader.Read())
                    {

                        SGname.Text = sqlReader["FName"].ToString();
                        SGaddress.Text = sqlReader["address"].ToString();
                        SGcity.Text = sqlReader["city"].ToString();
                        SGstate.Text = sqlReader["state"].ToString();
                        SGzip.Text = sqlReader["zipcode"].ToString();

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

        }
    }
}