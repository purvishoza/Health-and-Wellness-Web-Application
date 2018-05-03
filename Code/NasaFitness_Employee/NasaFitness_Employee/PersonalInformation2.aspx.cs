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
    public partial class PersonalInformation2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand("SELECT * FROM PrimaryInsurance where EmpID = @empid", con);
                cmd.Parameters.AddWithValue("@empid", Session["empid"].ToString());
                try
                {
                    con.Open();

                    SqlDataReader sqlReader = cmd.ExecuteReader();
                    while (sqlReader.Read())
                    {

                        pinsID.Text = sqlReader["PInsuranceID"].ToString();
                        pign.Text = sqlReader["PInsuranceGNum"].ToString();
                        company.Text = sqlReader["Company"].ToString();
                        type.Text = sqlReader["InsuranceType"].ToString();
                        relation.Text = sqlReader["Relation"].ToString();
                        Gname.Text = sqlReader["GName"].ToString();
                        Gaddress.Text = sqlReader["GAddress"].ToString();
                        Gcity.Text = sqlReader["GCity"].ToString();
                        Gstate.Text = sqlReader["GState"].ToString();
                        Gzip.Text = sqlReader["GZip"].ToString();
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
        protected void save_primaryIns_info(object sender, EventArgs e)
        {
            SqlConnection constr = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);

            SqlCommand cmd = new SqlCommand("if exists (select * from PrimaryInsurance with (updlock,serializable) where EmpID = @empid)" + 
                                            "begin update PrimaryInsurance set EmpID = @empid, PInsuranceID = @pinsID, PInsuranceGNum = @pign, Company = @company, InsuranceType = @type, Relation = @relation, GName = @Gname, GAddress = @Gaddress, GCity = @Gcity, GState = @Gstate, GZip = @Gzip where EmpID = @empid end else begin " +  
                                            "insert into PrimaryInsurance(ID, EmpID, PInsuranceID, PInsuranceGNum, Company, InsuranceType, Relation, GName, GAddress, GCity, GState, GZip)" +
                                            "values(@id, @empid, @pinsID, @pign, @company, @type, @relation, @Gname, @Gaddress, @Gcity, @Gstate, @Gzip)" +
                                            "end", constr);
           

            try
            {
                constr.Open();

                cmd.Parameters.AddWithValue("@id", pinsID.Text.Trim());
                cmd.Parameters.AddWithValue("@pinsID", pinsID.Text.Trim());
                cmd.Parameters.AddWithValue("@pign", pign.Text.Trim());
                cmd.Parameters.AddWithValue("@company", company.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@type", type.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@relation", relation.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@Gname", Gname.Text.Trim());
                cmd.Parameters.AddWithValue("@Gaddress", Gaddress.Text.Trim());
                cmd.Parameters.AddWithValue("@Gcity", Gcity.Text.Trim());
                cmd.Parameters.AddWithValue("@Gstate", Gstate.Text.Trim());
                cmd.Parameters.AddWithValue("@Gzip", Gzip.Text.Trim());

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
            Response.Redirect("PersonalInformation3.aspx");
            //Server.Transfer("PersonalInformation3.aspx");
        }

        protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (relation.SelectedValue == "Self")
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

                        Gname.Text = sqlReader["FName"].ToString();
                        Gaddress.Text = sqlReader["address"].ToString();
                        Gcity.Text = sqlReader["city"].ToString();
                        Gstate.Text = sqlReader["state"].ToString();
                        Gzip.Text = sqlReader["zipcode"].ToString();
                       
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

        protected void save_primaryIns_info1(object sender, EventArgs e)
        {
            SqlConnection constr = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);

            SqlCommand cmd = new SqlCommand("if exists (select * from PrimaryInsurance with (updlock,serializable) where EmpID = @empid)" +
                                            "begin update PrimaryInsurance set EmpID = @empid, PInsuranceID = @pinsID, PInsuranceGNum = @pign, Company = @company, InsuranceType = @type, Relation = @relation, GName = @Gname, GAddress = @Gaddress, GCity = @Gcity, GState = @Gstate, GZip = @Gzip where EmpID = @empid end else begin " +
                                            "insert into PrimaryInsurance(ID, EmpID, PInsuranceID, PInsuranceGNum, Company, InsuranceType, Relation, GName, GAddress, GCity, GState, GZip)" +
                                            "values(@id, @empid, @pinsID, @pign, @company, @type, @relation, @Gname, @Gaddress, @Gcity, @Gstate, @Gzip)" +
                                            "end", constr);


            try
            {
                constr.Open();

                cmd.Parameters.AddWithValue("@id", pinsID.Text.Trim());
                cmd.Parameters.AddWithValue("@pinsID", pinsID.Text.Trim());
                cmd.Parameters.AddWithValue("@pign", pign.Text.Trim());
                cmd.Parameters.AddWithValue("@company", company.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@type", type.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@relation", relation.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@Gname", Gname.Text.Trim());
                cmd.Parameters.AddWithValue("@Gaddress", Gaddress.Text.Trim());
                cmd.Parameters.AddWithValue("@Gcity", Gcity.Text.Trim());
                cmd.Parameters.AddWithValue("@Gstate", Gstate.Text.Trim());
                cmd.Parameters.AddWithValue("@Gzip", Gzip.Text.Trim());

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
            //Server.Transfer("PersonalInformation3.aspx");
        }

    }
}
    
