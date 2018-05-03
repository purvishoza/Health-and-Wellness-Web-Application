using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ObjectiveFindingsExam : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
       
            if (!IsPostBack)
            {
                Session["flag"] = "false";
                vitalsigns.Visible = false;
                sitreach.Visible = false;
                rangeofmotion.Visible = false;
                inspection.Visible = false;
                orthopedic.Visible = false;
                neurlogical.Visible = false;
                string empid = Session["id_health"].ToString();
                string problem = Session["SolvingProblem"].ToString();
                DateTime problemstartdate = Convert.ToDateTime(Session["date_health"]);
                DateTime problemreviewdate = DateTime.Now;
            }
       
    }
        private Boolean InsertOrUpdate(SqlCommand cmd)
        {
            String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            try
            {
                con.Open();
               int a = cmd.ExecuteNonQuery();
            if(a == 0)
            {

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('inserted successfully')", true);
            }
                return true;
            }
            catch (Exception ex)
            {
                Response.Write(ex);
                return false;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
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
    protected void paneldropdown_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (paneldropdown.SelectedValue == "1")
        {
            vitalsigns.Visible = true;
            sitreach.Visible = false;
            rangeofmotion.Visible = false;
            inspection.Visible = false;
            orthopedic.Visible = false;
            neurlogical.Visible = false;
        }
        else if (paneldropdown.SelectedValue == "2")
        {
            vitalsigns.Visible = false;
            sitreach.Visible = true;
            rangeofmotion.Visible = false;
            inspection.Visible = false;
            orthopedic.Visible = false;
            neurlogical.Visible = false;
        }
        else if (paneldropdown.SelectedValue == "3")
        {
            vitalsigns.Visible = false;
            sitreach.Visible = false;
            rangeofmotion.Visible = true;
            inspection.Visible = false;
            orthopedic.Visible = false;
            neurlogical.Visible = false;
        }
        else if (paneldropdown.SelectedValue == "4")
        {
            vitalsigns.Visible = false;
            sitreach.Visible = false;
            rangeofmotion.Visible = false;
            inspection.Visible = true;
            orthopedic.Visible = false;
            neurlogical.Visible = false;
        }
        else if (paneldropdown.SelectedValue == "5")
        {
            vitalsigns.Visible = false;
            sitreach.Visible = false;
            rangeofmotion.Visible = false;
            inspection.Visible = false;
            orthopedic.Visible = true;
            neurlogical.Visible = false;
        }
        else if (paneldropdown.SelectedValue == "6")
        {
            vitalsigns.Visible = false;
            sitreach.Visible = false;
            rangeofmotion.Visible = false;
            inspection.Visible = false;
            orthopedic.Visible = false;
            neurlogical.Visible = true;
        }
    }

    protected void close_Click(object sender, EventArgs e)
    {
        string jScript = "<script>window.close();</script>";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "keyClientBlock", jScript);
    }

    protected void save_Click(object sender, EventArgs e)
    {

    }
    protected void vitalsigngsSave_Click(object sender, EventArgs e)
    {
        string empid = Session["id_health"].ToString();
        string problem = Session["SolvingProblem"].ToString();
        DateTime problemstartdate = Convert.ToDateTime(Session["date_fitness"]);
        string vs_bp_sys = bps.Text.ToString();
        string vs_bp_dia = bpd.Text.ToString();
        string vs_bp_hr = bph.Text.ToString();
        string vs_bp_weight = weight.Text.ToString();
        string vs_bp_height = heigth.Text.ToString();
        DateTime problemreviewdate = Convert.ToDateTime(Session["re"].ToString());
        DataTable dt1 = this.GetData("select * from objectiveFindingsExam WHERE empid='" + empid + "' AND problem = '" + problem + "' AND problemstartdate = '" + problemstartdate + "' AND problemreviewdate = '" + problemreviewdate + "'");
        if (dt1.Rows.Count == 0)
        {
            string strQuery = "insert into objectiveFindingsExam(empid,problem,problemstartdate,problemreviewdate,vs_bp_sys, vs_bp_dia, vs_bp_hr,vs_bp_weight,vs_bp_height)" +
              " values (@empid,@problem,@probdate,@probReviewDate,@bps, @bpd, @bph,@bpw,@bphe)";
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.Parameters.Add("@empid", SqlDbType.VarChar).Value = empid;
            cmd.Parameters.Add("@problem", SqlDbType.VarChar).Value = problem;
            cmd.Parameters.Add("@probdate", SqlDbType.DateTime2).Value = problemstartdate;
            cmd.Parameters.Add("@probReviewDate", SqlDbType.DateTime2).Value = problemreviewdate;
            cmd.Parameters.Add("@bps", SqlDbType.VarChar).Value = vs_bp_sys;
            cmd.Parameters.Add("@bpd", SqlDbType.VarChar).Value = vs_bp_dia;
            cmd.Parameters.Add("@bph", SqlDbType.VarChar).Value = vs_bp_hr;
            cmd.Parameters.Add("@bpw", SqlDbType.VarChar).Value = vs_bp_weight;
            cmd.Parameters.Add("@bphe", SqlDbType.VarChar).Value = vs_bp_height;
            InsertOrUpdate(cmd);
        }
        else
        {
            string strQuery = "UPDATE objectiveFindingsExam SET vs_bp_sys = @bps1, vs_bp_dia = @bpd1, vs_bp_hr = @bph1, vs_bp_weight = @bpw1, vs_bp_height = @bphe1 WHERE empid='" + empid + "' AND problem = '" + problem + "' AND problemstartdate = '" + problemstartdate + "' AND problemreviewdate = '" + problemreviewdate + "'";
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.Parameters.Add("@bps1", SqlDbType.VarChar).Value = vs_bp_sys;
            cmd.Parameters.Add("@bpd1", SqlDbType.VarChar).Value = vs_bp_dia;
            cmd.Parameters.Add("@bph1", SqlDbType.VarChar).Value = vs_bp_hr;
            cmd.Parameters.Add("@bpw1", SqlDbType.VarChar).Value = vs_bp_weight;
            cmd.Parameters.Add("@bphe1", SqlDbType.VarChar).Value = vs_bp_height;
            InsertOrUpdate(cmd);
        }
    }

    protected void sitandreachSave_Click(object sender, EventArgs e)
    {
        string empid = Session["id_health"].ToString();
        string problem = Session["SolvingProblem"].ToString();
        DateTime problemstartdate = Convert.ToDateTime(Session["date_fitness"]);
        DateTime problemreviewdate = Convert.ToDateTime(Session["re"].ToString());
        string sitreachandgrip_flex1 = "";
        string sitreachandgrip_flex2 = "";
        string sitreachandgrip_flex3 = "";
        string sitreachandgrip_grip_l1 = "";
        string sitreachandgrip_grip_l2 = "";
        string sitreachandgrip_grip_l3 = "";
        string sitandreachgrip_grip_r1 = "";
        string sitandreachgrip_grip_r2 = "";
        string sitandreachgrip_grip_r3 = "";

        
        //string sitreachandgrip_flex1 = oneone.Text.ToString();
        //string sitreachandgrip_flex2 = onetwo.Text.ToString();
        //string sitreachandgrip_flex3 = onethree.Text.ToString();
        //string sitreachandgrip_grip_l1 = twoone.Text.ToString();
        //string sitreachandgrip_grip_l2 = twotwo.Text.ToString();
        //string sitreachandgrip_grip_l3 = twothree.Text.ToString();
        //string sitandreachgrip_grip_r1 = threeone.Text.ToString();
        //string sitandreachgrip_grip_r2 = threetwo.Text.ToString();
        //string sitandreachgrip_grip_r3 = threethree.Text.ToString();
        DataTable dt1 = this.GetData("select * from objectiveFindingsExam WHERE empid='" + empid + "' AND problem = '" + problem + "' AND problemstartdate = '" + problemstartdate + "' AND problemreviewdate = '" + problemreviewdate + "'");
        if (dt1.Rows.Count == 0)
        {
            string strQuery = "insert into objectiveFindingsExam(empid,problem,problemstartdate,problemreviewdate,sitreachandgrip_flex1, sitreachandgrip_flex2, sitreachandgrip_flex3,sitreachandgrip_grip_l1,sitreachandgrip_grip_l2,sitreachandgrip_grip_l3,sitandreachgrip_grip_r1,sitandreachgrip_grip_r2,sitandreachgrip_grip_r3)" +
              "values (@empid,@problem,@probdate,@probReviewDate,@flex1, @flex2, @flex3,@gripl1,@gripl2,@gripl3,@gripr1,@gripr2,@gripr3)";


            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.Parameters.Add("@empid", SqlDbType.VarChar).Value = empid;
            cmd.Parameters.Add("@problem", SqlDbType.VarChar).Value = problem;
            cmd.Parameters.Add("@probdate", SqlDbType.DateTime2).Value = problemstartdate;
            cmd.Parameters.Add("@probReviewDate", SqlDbType.DateTime2).Value = problemreviewdate;
            cmd.Parameters.Add("@flex1", SqlDbType.VarChar).Value = sitreachandgrip_flex1;
            cmd.Parameters.Add("@flex2", SqlDbType.VarChar).Value = sitreachandgrip_flex2;
            cmd.Parameters.Add("@flex3", SqlDbType.VarChar).Value = sitreachandgrip_flex3;
            cmd.Parameters.Add("@gripl1", SqlDbType.VarChar).Value = sitreachandgrip_grip_l1;
            cmd.Parameters.Add("@gripl2", SqlDbType.VarChar).Value = sitreachandgrip_grip_l2;
            cmd.Parameters.Add("@gripl3", SqlDbType.VarChar).Value = sitreachandgrip_grip_l3;
            cmd.Parameters.Add("@gripr1", SqlDbType.VarChar).Value = sitandreachgrip_grip_r1;
            cmd.Parameters.Add("@gripr2", SqlDbType.VarChar).Value = sitandreachgrip_grip_r2;
            cmd.Parameters.Add("@gripr3", SqlDbType.VarChar).Value = sitandreachgrip_grip_r3;
            InsertOrUpdate(cmd);
        }
        else
        {
            string strQuery = "UPDATE objectiveFindingsExam SET sitreachandgrip_flex1 = @flex1, sitreachandgrip_flex2 = @flex2, sitreachandgrip_flex3 = @flex3, sitreachandgrip_grip_l1 = @gripl1, sitreachandgrip_grip_l2 = @gripl2, sitreachandgrip_grip_l3 = @gripl3, sitreachandgrip_grip_r1 = @gripr1, sitreachandgrip_grip_r2 = @gripr2, sitreachandgrip_grip_r3 = @gripr3 WHERE empid='" + empid + "' AND problem = '" + problem + "' AND problemstartdate = '" + problemstartdate + "' AND problemreviewdate = '" + problemreviewdate + "'";
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.Parameters.Add("@flex1", SqlDbType.VarChar).Value = sitreachandgrip_flex1;
            cmd.Parameters.Add("@flex2", SqlDbType.VarChar).Value = sitreachandgrip_flex2;
            cmd.Parameters.Add("@flex3", SqlDbType.VarChar).Value = sitreachandgrip_flex3;
            cmd.Parameters.Add("@gripl1", SqlDbType.VarChar).Value = sitreachandgrip_grip_l1;
            cmd.Parameters.Add("@gripl2", SqlDbType.VarChar).Value = sitreachandgrip_grip_l2;
            cmd.Parameters.Add("@gripl3", SqlDbType.VarChar).Value = sitreachandgrip_grip_l3;
            cmd.Parameters.Add("@gripr1", SqlDbType.VarChar).Value = sitandreachgrip_grip_r1;
            cmd.Parameters.Add("@gripr2", SqlDbType.VarChar).Value = sitandreachgrip_grip_r2;
            cmd.Parameters.Add("@gripr3", SqlDbType.VarChar).Value = sitandreachgrip_grip_r3;
            InsertOrUpdate(cmd);
        }
    }

    protected void rofSave_Click(object sender, EventArgs e)
    {
        string empid = Session["id_health"].ToString();
        string problem = Session["SolvingProblem"].ToString();
        DateTime problemstartdate = Convert.ToDateTime(Session["date_fitness"]);
        DateTime problemreviewdate = Convert.ToDateTime(Session["re"].ToString());
        //++++++++++++++++++++++
        string rom_cs_fle = cf1.Text.ToString();
        string rom_cs_fle_p1 = cfp1.Text.ToString();
        string rom_cs_ext = ce2.Text.ToString();
        string rom_cs_ext_p1 = cep2.Text.ToString();
        string rom_cs_lr = clr3.Text.ToString();
        string rom_cs_lr_p1 = clrp3.Text.ToString();
        string rom_cs_rr = crr4.Text.ToString();
        string rom_cs_rr_p1 = crrp3.Text.ToString();
        string rom_cs_llf = cll5.Text.ToString();
        string rom_cs_llf_p1 = cllp5.Text.ToString();
        string rom_cs_rlf = crl6.Text.ToString();
        string rom_cs_rlf_p1 = crlp6.Text.ToString();
        string rom_tho_fla = tf1.Text.ToString();
        string rom_tho_fla_p1 = tfp1.Text.ToString();
        string rom_tho_ext = te2.Text.ToString();
        string rom_tho_ext_p1 = tep2.Text.ToString();
        string rom_tho_lr = tlr3.Text.ToString();
        string rom_tho_lr_p1 = tlrp3.Text.ToString();
        string rom_tho_rr = trr4.Text.ToString();
        string rom_tho_rr_p1 = trrp4.Text.ToString();
        string rom_tho_llr = tll5.Text.ToString();
        string rom_tho_llr_p1 = tllp5.Text.ToString();
        string rom_tho_rlr = trl6.Text.ToString();
        string rom_tho_rlr_p1 = trlp6.Text.ToString();
        //++++++++++++++++++++++
        DataTable dt1 = this.GetData("select * from objectiveFindingsExam WHERE empid='" + empid + "' AND problem = '" + problem + "' AND problemstartdate = '" + problemstartdate + "' AND problemreviewdate = '" + problemreviewdate + "'");
        if (dt1.Rows.Count == 0)
        {
            //insert
            string strQuery = "insert into objectiveFindingsExam(empid,problem,problemstartdate,problemreviewdate, rom_cs_fle, rom_cs_fle_p1,  rom_cs_ext, rom_cs_ext_p1, rom_cs_lr,  rom_cs_lr_p1,  rom_cs_rr, rom_cs_rr_p1,  rom_cs_llf, rom_cs_llf_p1, rom_cs_rlf,  rom_cs_rlf_p1,  rom_tho_fla,  rom_tho_fla_p1, rom_tho_ext, rom_tho_ext_p1, rom_tho_lr, rom_tho_lr_p1,  rom_tho_rr, rom_tho_rr_p1,  rom_tho_llr, rom_tho_llr_p1, rom_tho_rlr, rom_tho_rlr_p1)" +
                "values (@empid,@problem,@probdate,@probReviewDate, @rom_cs_fle, @rom_cs_fle_p1, @rom_cs_ext, @rom_cs_ext_p1, @rom_cs_lr, @rom_cs_lr_p1, @rom_cs_rr, @rom_cs_rr_p1, @rom_cs_llf, @rom_cs_llf_p1, @rom_cs_rlf, @rom_cs_rlf_p1, @rom_tho_fla, @rom_tho_fla_p1,  @rom_tho_ext ,@rom_tho_ext_p1, @rom_tho_lr, @rom_tho_lr_p1, @rom_tho_rr, @rom_tho_rr_p1, @rom_tho_llr, @rom_tho_llr_p1, @rom_tho_rlr, @rom_tho_rlr_p1)";

            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.Parameters.Add("@empid", SqlDbType.VarChar).Value = empid;
            cmd.Parameters.Add("@problem", SqlDbType.VarChar).Value = problem;
            cmd.Parameters.Add("@probdate", SqlDbType.DateTime2).Value = problemstartdate;
            cmd.Parameters.Add("@probReviewDate", SqlDbType.DateTime2).Value = problemreviewdate;
            //++++++++++++++++++++++++
            cmd.Parameters.Add("@rom_cs_fle", SqlDbType.VarChar).Value = rom_cs_fle;
            cmd.Parameters.Add("@rom_cs_fle_p1", SqlDbType.VarChar).Value = rom_cs_fle_p1;
            cmd.Parameters.Add("@rom_cs_ext", SqlDbType.VarChar).Value = rom_cs_ext;
            cmd.Parameters.Add("@rom_cs_ext_p1", SqlDbType.VarChar).Value = rom_cs_ext_p1;
            cmd.Parameters.Add("@rom_cs_lr", SqlDbType.VarChar).Value = rom_cs_lr;
            cmd.Parameters.Add("@rom_cs_lr_p1", SqlDbType.VarChar).Value = rom_cs_lr_p1;
            cmd.Parameters.Add("@rom_cs_rr", SqlDbType.VarChar).Value = rom_cs_rr;
            cmd.Parameters.Add("@rom_cs_rr_p1", SqlDbType.VarChar).Value = rom_cs_rr_p1;
            cmd.Parameters.Add("@rom_cs_llf", SqlDbType.VarChar).Value = rom_cs_llf;
            cmd.Parameters.Add("@rom_cs_llf_p1", SqlDbType.VarChar).Value = rom_cs_llf_p1;
            cmd.Parameters.Add("@rom_cs_rlf", SqlDbType.VarChar).Value = rom_cs_rlf;
            cmd.Parameters.Add("@rom_cs_rlf_p1", SqlDbType.VarChar).Value = rom_cs_rlf_p1;
            cmd.Parameters.Add("@rom_tho_fla", SqlDbType.VarChar).Value = rom_tho_fla;
            cmd.Parameters.Add("@rom_tho_fla_p1", SqlDbType.VarChar).Value = rom_tho_fla_p1;
            cmd.Parameters.Add("@rom_tho_ext", SqlDbType.VarChar).Value = rom_tho_ext;
            cmd.Parameters.Add("@rom_tho_ext_p1", SqlDbType.VarChar).Value = rom_tho_ext_p1;
            cmd.Parameters.Add("@rom_tho_lr", SqlDbType.VarChar).Value = rom_tho_lr;
            cmd.Parameters.Add("@rom_tho_lr_p1", SqlDbType.VarChar).Value = rom_tho_lr_p1;
            cmd.Parameters.Add("@rom_tho_rr", SqlDbType.VarChar).Value = rom_tho_rr;
            cmd.Parameters.Add("@rom_tho_rr_p1", SqlDbType.VarChar).Value = rom_tho_rr_p1;
            cmd.Parameters.Add("@rom_tho_llr", SqlDbType.VarChar).Value = rom_tho_llr;
            cmd.Parameters.Add("@rom_tho_llr_p1", SqlDbType.VarChar).Value = rom_tho_llr_p1;
            cmd.Parameters.Add("@rom_tho_rlr", SqlDbType.VarChar).Value = rom_tho_rlr;
            cmd.Parameters.Add("@rom_tho_rlr_p1", SqlDbType.VarChar).Value = rom_tho_rlr_p1;
            //++++++++++++++++++++++++
            InsertOrUpdate(cmd);
        }
        else
        {
            //update
            string strQuery = "UPDATE objectiveFindingsExam SET rom_cs_fle = @rom_cs_fle, rom_cs_fle_p1 = @rom_cs_fle_p1, rom_cs_ext = @rom_cs_ext, rom_cs_ext_p1 = @rom_cs_ext_p1,  rom_cs_lr = @rom_cs_lr, rom_cs_lr_p1 = @rom_cs_lr_p1, rom_cs_rr = @rom_cs_rr, rom_cs_rr_p1 = @rom_cs_rr_p1, rom_cs_llf = @rom_cs_llf, rom_cs_llf_p1 = @rom_cs_llf_p1, rom_cs_rlf = @rom_cs_rlf, rom_cs_rlf_p1 = @rom_cs_rlf_p1, rom_tho_fla = @rom_tho_fla, rom_tho_fla_p1 = @rom_tho_fla_p1, rom_tho_ext = @rom_tho_ext, rom_tho_ext_p1 = @rom_tho_ext_p1, rom_tho_lr = @rom_tho_lr, rom_tho_lr_p1 = @rom_tho_lr_p1, rom_tho_rr = @rom_tho_rr, rom_tho_rr_p1 = @rom_tho_rr_p1, rom_tho_llr = @rom_tho_llr, rom_tho_llr_p1 = @rom_tho_llr_p1, rom_tho_rlr = @rom_tho_rlr, rom_tho_rlr_p1 = @rom_tho_rlr_p1 WHERE empid='" + empid + "' AND problem = '" + problem + "' AND problemstartdate = '" + problemstartdate + "' AND problemreviewdate = '" + problemreviewdate + "'";
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.Parameters.Add("@rom_cs_fle", SqlDbType.VarChar).Value = rom_cs_fle;
            cmd.Parameters.Add("@rom_cs_fle_p1", SqlDbType.VarChar).Value = rom_cs_fle_p1;
            cmd.Parameters.Add("@rom_cs_ext", SqlDbType.VarChar).Value = rom_cs_ext;
            cmd.Parameters.Add("@rom_cs_ext_p1", SqlDbType.VarChar).Value = rom_cs_ext_p1;
            cmd.Parameters.Add("@rom_cs_lr", SqlDbType.VarChar).Value = rom_cs_lr;
            cmd.Parameters.Add("@rom_cs_lr_p1", SqlDbType.VarChar).Value = rom_cs_lr_p1;
            cmd.Parameters.Add("@rom_cs_rr", SqlDbType.VarChar).Value = rom_cs_rr;
            cmd.Parameters.Add("@rom_cs_rr_p1", SqlDbType.VarChar).Value = rom_cs_rr_p1;
            cmd.Parameters.Add("@rom_cs_llf", SqlDbType.VarChar).Value = rom_cs_llf;
            cmd.Parameters.Add("@rom_cs_llf_p1", SqlDbType.VarChar).Value = rom_cs_llf_p1;
            cmd.Parameters.Add("@rom_cs_rlf", SqlDbType.VarChar).Value = rom_cs_rlf;
            cmd.Parameters.Add("@rom_cs_rlf_p1", SqlDbType.VarChar).Value = rom_cs_rlf_p1;
            cmd.Parameters.Add("@rom_tho_fla", SqlDbType.VarChar).Value = rom_tho_fla;
            cmd.Parameters.Add("@rom_tho_fla_p1", SqlDbType.VarChar).Value = rom_tho_fla_p1;
            cmd.Parameters.Add("@rom_tho_ext", SqlDbType.VarChar).Value = rom_tho_ext;
            cmd.Parameters.Add("@rom_tho_ext_p1", SqlDbType.VarChar).Value = rom_tho_ext_p1;
            cmd.Parameters.Add("@rom_tho_lr", SqlDbType.VarChar).Value = rom_tho_lr;
            cmd.Parameters.Add("@rom_tho_lr_p1", SqlDbType.VarChar).Value = rom_tho_lr_p1;
            cmd.Parameters.Add("@rom_tho_rr", SqlDbType.VarChar).Value = rom_tho_rr;
            cmd.Parameters.Add("@rom_tho_rr_p1", SqlDbType.VarChar).Value = rom_tho_rr_p1;
            cmd.Parameters.Add("@rom_tho_llr", SqlDbType.VarChar).Value = rom_tho_llr;
            cmd.Parameters.Add("@rom_tho_llr_p1", SqlDbType.VarChar).Value = rom_tho_llr_p1;
            cmd.Parameters.Add("@rom_tho_rlr", SqlDbType.VarChar).Value = rom_tho_rlr;
            cmd.Parameters.Add("@rom_tho_rlr_p1", SqlDbType.VarChar).Value = rom_tho_rlr_p1;
            InsertOrUpdate(cmd);
        }

    }

    protected void orthSave_Click(object sender, EventArgs e)
    {
        string ort_cer = null;
        string ort_cervi = null;
        string ort_soto_hall = null;
        string ort_nrc_fora_com_l = null;
        string ort_nrc_fora_com_r = null;
        string ort_nrc_cer_dis = null;
        string ort_nrc_max_cer_com = null;
        string ort_nrc_shou_dep_l = null;
        string ort_nrc_shou_dep_r = null;
        string ort_ivd_deje_triad = null;
        string ort_ivd_swa = null;
        string ort_nvc_vba_l = null;
        string ort_nvc_vba_r = null;
        string ort_nvc_ad_l = null;
        string ort_nvc_ad_r = null;
        string ort_nvc_shou_com_l = null;
        string ort_nvc_shou_com_r = null;
        string ort_nvc_wri_hyp_l = null;
        string ort_nvc_wri_hyp_r = null;
        string ort_thora = null;
        string ort_lam = null;
        string ort_ner_bec_l = null;
        string ort_ner_bec_r = null;
        string ort_ner_kem_l = null;
        string ort_ner_kem_r = null;
        string ort_ner_slr_l = null;
        string ort_ner_slr_r = null;
        string ort_ner_ely_l = null;
        string ort_ner_ely_r = null;
        string ort_ner_vel_l = null;
        string ort_ner_vle_r = null;
        string ort_sij_gae_l = null;
        string ort_sij_gae_r = null;
        string ort_sij_yeo_l = null;
        string ort_sij_yeo_r = null;
        string ort_sij_hoo_l = null;
        string ort_sij_dlr = null;
        string ort_ner_ll = null;
        string ort_ner_cm_mar_l = null;


        ort_cer = o1.Checked.ToString();
        ort_cervi = o2.Checked.ToString();


        if (!string.IsNullOrEmpty(Request.Form["Soto-Hall"]))
        {
            ort_soto_hall = Request.Form["Soto-Hall"];

            //  Response.Write(ort_soto_hall);
        }
        if (!string.IsNullOrEmpty(Request.Form["fcl"]))
        {
            ort_nrc_fora_com_l = Request.Form["fcl"].ToString();

            // Response.Write(ort_nrc_fora_com_l);
        }
        if (!string.IsNullOrEmpty(Request.Form["fcr"]))
        {
            ort_nrc_fora_com_r = Request.Form["fcr"];

            // Response.Write(ort_nrc_fora_com_r);
        }
        if (!string.IsNullOrEmpty(Request.Form["cd"]))
        {
            ort_nrc_cer_dis = Request.Form["cd"];

            // Response.Write(test);
        }
        if (!string.IsNullOrEmpty(Request.Form["cm"]))
        {
            ort_nrc_max_cer_com = Request.Form["cm"];

            // Response.Write(test);
        }
        if (!string.IsNullOrEmpty(Request.Form["sdl"]))
        {
            ort_nrc_shou_dep_l = Request.Form["sdl"];

            // Response.Write(test);
        }
        if (!string.IsNullOrEmpty(Request.Form["sdr"]))
        {
            ort_nrc_shou_dep_r = Request.Form["sdr"];

            // Response.Write(test);
        }
        if (!string.IsNullOrEmpty(Request.Form["dt"]))
        {
            ort_ivd_deje_triad = Request.Form["dt"].ToString();

            // Response.Write(test);
        }
        if (!string.IsNullOrEmpty(Request.Form["s"]))
        {
            ort_ivd_swa = Request.Form["s"].ToString();

            // Response.Write(test);
        }
        if (!string.IsNullOrEmpty(Request.Form["vl"]))
        {
            ort_nvc_vba_l = Request.Form["vl"].ToString();

            // Response.Write(test);
        }
        if (!string.IsNullOrEmpty(Request.Form["vr"]))
        {
            ort_nvc_vba_r = Request.Form["vr"].ToString();

            // Response.Write(test);
        }
        if (!string.IsNullOrEmpty(Request.Form["al"]))
        {
            ort_nvc_ad_l = Request.Form["al"].ToString();

            // Response.Write(test);
        }
        if (!string.IsNullOrEmpty(Request.Form["ar"]))
        {
            ort_nvc_ad_r = Request.Form["ar"].ToString();

            // Response.Write(test);
        }
        if (!string.IsNullOrEmpty(Request.Form["scl"]))
        {
            ort_nvc_shou_com_l = Request.Form["scl"].ToString();

            // Response.Write(test);
        }
        if (!string.IsNullOrEmpty(Request.Form["scr"]))
        {
            ort_nvc_shou_com_r = Request.Form["scr"].ToString();

            // Response.Write(test);
        }
        if (!string.IsNullOrEmpty(Request.Form["whl"]))
        {
            ort_nvc_wri_hyp_l = Request.Form["whl"].ToString();

            // Response.Write(test);
        }
        if (!string.IsNullOrEmpty(Request.Form["whr"]))
        {
            ort_nvc_wri_hyp_r = Request.Form["whr"].ToString();

            // Response.Write(test);
        }
        //if (ot1.Checked)
        //{
        //    ort_thora = "checked";
        //}
        //if (ol2.Checked)
        //{
        //    ort_lam = "checked";
        //}
        ort_thora = ot1.Checked.ToString();
        ort_lam = ol2.Checked.ToString();
        if (!string.IsNullOrEmpty(Request.Form["bl"]))
        {
            ort_ner_bec_l = Request.Form["bl"].ToString();

            // Response.Write(test);
        }
        if (!string.IsNullOrEmpty(Request.Form["br"]))
        {
            ort_ner_bec_r = Request.Form["br"].ToString();

            // Response.Write(test);
        }
        if (!string.IsNullOrEmpty(Request.Form["kl"]))
        {
            ort_ner_kem_l = Request.Form["kl"].ToString();

            // Response.Write(test);
        }
        if (!string.IsNullOrEmpty(Request.Form["kr"]))
        {
            ort_ner_kem_r = Request.Form["kr"].ToString();

            // Response.Write(test);
        }
        if (!string.IsNullOrEmpty(Request.Form["slrl"]))
        {
            ort_ner_slr_l = Request.Form["slrl"].ToString();

            // Response.Write(test);
        }
        if (!string.IsNullOrEmpty(Request.Form["slrr"]))
        {
            ort_ner_slr_r = Request.Form["slrr"].ToString();

            // Response.Write(test);
        }
        if (!string.IsNullOrEmpty(Request.Form["elyl"]))
        {
            ort_ner_ely_l = Request.Form["elyl"].ToString();

            // Response.Write(test);
        }
        if (!string.IsNullOrEmpty(Request.Form["elyr"]))
        {
            ort_ner_ely_r = Request.Form["elyr"].ToString();

            // Response.Write(test);
        }
        if (!string.IsNullOrEmpty(Request.Form["tvl"]))
        {
            ort_ner_vel_l = Request.Form["tvl"].ToString();

            // Response.Write(test);
        }
        if (!string.IsNullOrEmpty(Request.Form["tvr"]))
        {
            ort_ner_vle_r = Request.Form["tvr"].ToString();

            // Response.Write(test);
        }
        if (!string.IsNullOrEmpty(Request.Form["gl"]))
        {
            ort_sij_gae_l = Request.Form["gl"].ToString();

            // Response.Write(test);
        }
        if (!string.IsNullOrEmpty(Request.Form["gr"]))
        {
            ort_sij_gae_r = Request.Form["gr"].ToString();

            // Response.Write(test);
        }
        if (!string.IsNullOrEmpty(Request.Form["yl"]))
        {
            ort_sij_yeo_l = Request.Form["yl"].ToString();

            // Response.Write(test);
        }
        if (!string.IsNullOrEmpty(Request.Form["yr"]))
        {
            ort_sij_yeo_r = Request.Form["yr"].ToString();

            // Response.Write(test);
        }
        if (!string.IsNullOrEmpty(Request.Form["hl"]))
        {
            ort_sij_hoo_l = Request.Form["hl"].ToString();

            // Response.Write(test);
        }
        if (!string.IsNullOrEmpty(Request.Form["dlr"]))
        {
            ort_sij_dlr = Request.Form["dlr"].ToString();

            // Response.Write(test);
        }
        ort_ner_ll = leglen.Text.ToString();
        if (!string.IsNullOrEmpty(Request.Form["ml"]))
        {
            ort_ner_cm_mar_l = Request.Form["ml"].ToString();

            // Response.Write(test);
        }
        // Response.Write(test);
        string empid = Session["id_health"].ToString();
        string problem = Session["SolvingProblem"].ToString();
        DateTime problemstartdate = Convert.ToDateTime(Session["date_fitness"]);
        DateTime problemreviewdate = DateTime.Now;
        DataTable dt1 = this.GetData("select * from objectiveFindingsExam WHERE empid='" + empid + "' AND problem = '" + problem + "' AND problemstartdate = '" + problemstartdate + "' AND problemreviewdate = '" + problemreviewdate + "'");
        if (dt1.Rows.Count == 0)
        {
            string strQuery = "insert into objectiveFindingsExam(empid,problem,problemstartdate,problemreviewdate,ort_cer,ort_cervi,ort_soto_hall,ort_nrc_fora_com_l,ort_nrc_fora_com_r,ort_nrc_cer_dis ,ort_nrc_max_cer_com,ort_nrc_shou_dep_l,ort_nrc_shou_dep_r ,ort_ivd_deje_triad,ort_ivd_swa ,ort_nvc_vba_l,ort_nvc_vba_r,ort_nvc_ad_l,ort_nvc_ad_r,ort_nvc_shou_com_l,ort_nvc_shou_com_r,ort_nvc_wri_hyp_l,ort_nvc_wri_hyp_r,ort_thora,ort_lam              ,ort_ner_bec_l,ort_ner_bec_r,ort_ner_kem_l,ort_ner_kem_r,ort_ner_slr_l ,ort_ner_slr_r,ort_ner_ely_l,ort_ner_ely_r,ort_ner_vel_l,ort_ner_vle_r,ort_sij_gae_l,ort_sij_gae_r,ort_sij_yeo_l ,ort_sij_hoo_l ,ort_sij_dlr,ort_ner_ll        ,ort_ner_cm_mar_l      )" + " values (@empid,@problem,@probdate,@probReviewDate,@ort_cer,@ort_cervi,@ort_soto_hall,@ort_nrc_fora_com_l,@ort_nrc_fora_com_r ,@ort_nrc_cer_dis,@ort_nrc_max_cer_com,@ort_nrc_shou_dep_l,@ort_nrc_shou_dep_r ,@ort_ivd_deje_triad ,@ort_ivd_swa ,@ort_nvc_vba_l,@ort_nvc_vba_r,@ort_nvc_ad_l ,@ort_nvc_ad_r,@ort_nvc_shou_com_l,@ort_nvc_shou_com_r,@ort_nvc_wri_hyp_l,@ort_nvc_wri_hyp_r,@ort_thora,@ort_lam ,@ort_ner_bec_l  ,@ort_ner_bec_r,@ort_ner_kem_l ,@ort_ner_kem_r,@ort_ner_slr_l ,@ort_ner_slr_r,@ort_ner_ely_l ,@ort_ner_ely_r ,@ort_ner_vel_l,@ort_ner_vle_r ,@ort_sij_gae_l    ,@ort_sij_gae_r     ,@ort_sij_yeo_l    ,@ort_sij_hoo_l,@ort_sij_dlr ,@ort_ner_ll,@ort_ner_cm_mar_l       )";
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.Parameters.Add("@empid", SqlDbType.VarChar).Value = empid;

            cmd.Parameters.Add("@problem", SqlDbType.VarChar).Value = problem;
            cmd.Parameters.Add("@probdate", SqlDbType.DateTime2).Value = problemstartdate;
            cmd.Parameters.Add("@probReviewDate", SqlDbType.DateTime2).Value = problemreviewdate;
            cmd.Parameters.Add("@ort_cer", SqlDbType.VarChar).Value = ort_cer;
            cmd.Parameters.Add("@ort_cervi", SqlDbType.VarChar).Value = ort_cervi;
            cmd.Parameters.Add("@ort_soto_hall", SqlDbType.VarChar).Value = ort_soto_hall;
            cmd.Parameters.Add("@ort_nrc_fora_com_l", SqlDbType.VarChar).Value = ort_nrc_fora_com_l;
            cmd.Parameters.Add("@ort_nrc_fora_com_r", SqlDbType.VarChar).Value = ort_nrc_fora_com_r;
            cmd.Parameters.Add("@ort_nrc_cer_dis", SqlDbType.VarChar).Value = ort_nrc_cer_dis;
            cmd.Parameters.Add("@ort_nrc_max_cer_com", SqlDbType.VarChar).Value = ort_nrc_max_cer_com;
            cmd.Parameters.Add("@ort_nrc_shou_dep_l", SqlDbType.VarChar).Value = ort_nrc_shou_dep_l;
            cmd.Parameters.Add("@ort_nrc_shou_dep_r", SqlDbType.VarChar).Value = ort_nrc_shou_dep_r;
            cmd.Parameters.Add("@ort_ivd_deje_triad", SqlDbType.VarChar).Value = ort_ivd_deje_triad;
            cmd.Parameters.Add("@ort_ivd_swa", SqlDbType.VarChar).Value = ort_ivd_swa;
            cmd.Parameters.Add("@ort_nvc_vba_l", SqlDbType.VarChar).Value = ort_nvc_vba_l;
            cmd.Parameters.Add("@ort_nvc_vba_r", SqlDbType.VarChar).Value = ort_nvc_vba_r;
            cmd.Parameters.Add("@ort_nvc_ad_l", SqlDbType.VarChar).Value = ort_nvc_ad_l;
            cmd.Parameters.Add("@ort_nvc_ad_r", SqlDbType.VarChar).Value = ort_nvc_ad_r;
            cmd.Parameters.Add("@ort_nvc_shou_com_l", SqlDbType.VarChar).Value = ort_nvc_shou_com_l;
            cmd.Parameters.Add("@ort_nvc_shou_com_r", SqlDbType.VarChar).Value = ort_nvc_shou_com_r;
            cmd.Parameters.Add("@ort_nvc_wri_hyp_l", SqlDbType.VarChar).Value = ort_nvc_wri_hyp_l;
            cmd.Parameters.Add("@ort_nvc_wri_hyp_r", SqlDbType.VarChar).Value = ort_nvc_wri_hyp_r;
            cmd.Parameters.Add("@ort_thora", SqlDbType.VarChar).Value = ort_thora;
            cmd.Parameters.Add("@ort_lam", SqlDbType.VarChar).Value = ort_lam;
            cmd.Parameters.Add("@ort_ner_bec_l", SqlDbType.VarChar).Value = ort_ner_bec_l;
            cmd.Parameters.Add("@ort_ner_bec_r", SqlDbType.VarChar).Value = ort_ner_bec_r;
            cmd.Parameters.Add("@ort_ner_kem_l", SqlDbType.VarChar).Value = ort_ner_kem_l;
            cmd.Parameters.Add("@ort_ner_kem_r", SqlDbType.VarChar).Value = ort_ner_kem_r;
            cmd.Parameters.Add("@ort_ner_slr_l", SqlDbType.VarChar).Value = ort_ner_slr_l;
            cmd.Parameters.Add("@ort_ner_slr_r", SqlDbType.VarChar).Value = ort_ner_slr_r;
            cmd.Parameters.Add("@ort_ner_ely_l", SqlDbType.VarChar).Value = ort_ner_ely_l;
            cmd.Parameters.Add("@ort_ner_ely_r", SqlDbType.VarChar).Value = ort_ner_ely_r;
            cmd.Parameters.Add("@ort_ner_vel_l", SqlDbType.VarChar).Value = ort_ner_vel_l;
            cmd.Parameters.Add("@ort_ner_vle_r", SqlDbType.VarChar).Value = ort_ner_vle_r;
            cmd.Parameters.Add("@ort_sij_gae_l", SqlDbType.VarChar).Value = ort_sij_gae_l;
            cmd.Parameters.Add("@ort_sij_gae_r", SqlDbType.VarChar).Value = ort_sij_gae_r;
            cmd.Parameters.Add("@ort_sij_yeo_l", SqlDbType.VarChar).Value = ort_sij_yeo_l;
            cmd.Parameters.Add("@ort_sij_yeo_r", SqlDbType.VarChar).Value = ort_sij_yeo_r;
            cmd.Parameters.Add("@ort_sij_hoo_l", SqlDbType.VarChar).Value = ort_sij_hoo_l;
            cmd.Parameters.Add("@ort_sij_dlr", SqlDbType.VarChar).Value = ort_sij_dlr;
            cmd.Parameters.Add("@ort_ner_ll", SqlDbType.VarChar).Value = ort_ner_ll;
            cmd.Parameters.Add("@ort_ner_cm_mar_l", SqlDbType.VarChar).Value = ort_ner_cm_mar_l;
            InsertOrUpdate(cmd);
        }
        else
        {

            string strQuery = "update objectiveFindingsExam set ort_cer =@ort_cer ,ort_cervi =@ort_cervi ,ort_soto_hall =@ort_soto_hall ,ort_nrc_fora_com_l =@ort_nrc_fora_com_l ,ort_nrc_fora_com_r =@ort_nrc_fora_com_r ,ort_nrc_cer_dis =ort_nrc_cer_dis ,ort_nrc_max_cer_com =@ort_nrc_max_cer_com ,ort_nrc_shou_dep_l =@ort_nrc_shou_dep_l ,ort_nrc_shou_dep_r =@ort_nrc_shou_dep_r ,ort_ivd_deje_triad =@ort_ivd_deje_triad ,ort_ivd_swa =@ort_ivd_swa ,ort_nvc_vba_l =@ort_nvc_vba_l ,ort_nvc_vba_r =@ort_nvc_vba_r ,ort_nvc_ad_l =@ort_nvc_ad_l ,ort_nvc_shou_com_l=@ort_nvc_shou_com_l ,ort_nvc_shou_com_r =@ort_nvc_shou_com_r ,ort_nvc_wri_hyp_l =@ort_nvc_wri_hyp_l ,ort_nvc_wri_hyp_r =@ort_nvc_wri_hyp_r ,ort_thora =@ort_thora ,ort_lam =@ort_lam ,ort_ner_bec_l=@ort_ner_bec_l, ort_ner_bec_r=@ort_ner_bec_r, ort_ner_kem_l=@ort_ner_kem_l, ort_ner_kem_r=@ort_ner_kem_r, ort_ner_slr_l=@ort_ner_slr_l, ort_ner_slr_r=@ort_ner_slr_r, ort_ner_ely_l=@ort_ner_ely_l, ort_ner_ely_r=@ort_ner_ely_r, ort_ner_vel_l=@ort_ner_vel_l, ort_ner_vel_l=@ort_ner_vel_l, ort_ner_vle_r=@ort_ner_vle_r, ort_sij_gae_l=@ort_sij_gae_l, ort_sij_gae_r=@ort_sij_gae_r, ort_sij_yeo_l=@ort_sij_yeo_l, ort_sij_yeo_r=@ort_sij_yeo_r, ort_sij_hoo_l=@ort_sij_hoo_l, ort_sij_dlr=@ort_sij_dlr, ort_ner_ll=@ort_ner_ll, ort_ner_cm_mar_l=@ort_ner_cm_mar_l where empid='" + empid + "' AND problem = '" + problem + "' AND problemstartdate = '" + problemstartdate + "' AND problemreviewdate = '" + problemreviewdate + "'";
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.Parameters.Add("@empid", SqlDbType.VarChar).Value = empid;
            cmd.Parameters.Add("@problem", SqlDbType.VarChar).Value = problem;
            cmd.Parameters.Add("@probdate", SqlDbType.DateTime2).Value = problemstartdate;
            cmd.Parameters.Add("@probReviewDate", SqlDbType.DateTime2).Value = problemreviewdate;
            cmd.Parameters.Add("@ort_cer", SqlDbType.VarChar).Value = ort_cer;
            cmd.Parameters.Add("@ort_cervi", SqlDbType.VarChar).Value = ort_cervi;
            cmd.Parameters.Add("@ort_soto_hall", SqlDbType.VarChar).Value = ort_soto_hall;
            cmd.Parameters.Add("@ort_nrc_fora_com_l", SqlDbType.VarChar).Value = ort_nrc_fora_com_l;
            cmd.Parameters.Add("@ort_nrc_fora_com_r", SqlDbType.VarChar).Value = ort_nrc_fora_com_r;
            cmd.Parameters.Add("@ort_nrc_cer_dis", SqlDbType.VarChar).Value = ort_nrc_cer_dis;
            cmd.Parameters.Add("@ort_nrc_max_cer_com", SqlDbType.VarChar).Value = ort_nrc_max_cer_com;
            cmd.Parameters.Add("@ort_nrc_shou_dep_l", SqlDbType.VarChar).Value = ort_nrc_shou_dep_l;
            cmd.Parameters.Add("@ort_nrc_shou_dep_r", SqlDbType.VarChar).Value = ort_nrc_shou_dep_r;
            cmd.Parameters.Add("@ort_ivd_deje_triad", SqlDbType.VarChar).Value = ort_ivd_deje_triad;
            cmd.Parameters.Add("@ort_ivd_swa", SqlDbType.VarChar).Value = ort_ivd_swa;
            cmd.Parameters.Add("@ort_nvc_vba_l", SqlDbType.VarChar).Value = ort_nvc_vba_l;
            cmd.Parameters.Add("@ort_nvc_vba_r", SqlDbType.VarChar).Value = ort_nvc_vba_r;
            cmd.Parameters.Add("@ort_nvc_ad_l", SqlDbType.VarChar).Value = ort_nvc_ad_l;
            cmd.Parameters.Add("@ort_nvc_ad_r", SqlDbType.VarChar).Value = ort_nvc_ad_r;
            cmd.Parameters.Add("@ort_nvc_shou_com_l", SqlDbType.VarChar).Value = ort_nvc_shou_com_l;
            cmd.Parameters.Add("@ort_nvc_shou_com_r", SqlDbType.VarChar).Value = ort_nvc_shou_com_r;
            cmd.Parameters.Add("@ort_nvc_wri_hyp_l", SqlDbType.VarChar).Value = ort_nvc_wri_hyp_l;
            cmd.Parameters.Add("@ort_nvc_wri_hyp_r", SqlDbType.VarChar).Value = ort_nvc_wri_hyp_r;
            cmd.Parameters.Add("@ort_thora", SqlDbType.VarChar).Value = ort_thora;
            cmd.Parameters.Add("@ort_lam", SqlDbType.VarChar).Value = ort_lam;
            cmd.Parameters.Add("@ort_ner_bec_l", SqlDbType.VarChar).Value = ort_ner_bec_l;
            cmd.Parameters.Add("@ort_ner_bec_r", SqlDbType.VarChar).Value = ort_ner_bec_r;
            cmd.Parameters.Add("@ort_ner_kem_l", SqlDbType.VarChar).Value = ort_ner_kem_l;
            cmd.Parameters.Add("@ort_ner_kem_r", SqlDbType.VarChar).Value = ort_ner_kem_r;
            cmd.Parameters.Add("@ort_ner_slr_l", SqlDbType.VarChar).Value = ort_ner_slr_l;
            cmd.Parameters.Add("@ort_ner_slr_r", SqlDbType.VarChar).Value = ort_ner_slr_r;
            cmd.Parameters.Add("@ort_ner_ely_l", SqlDbType.VarChar).Value = ort_ner_ely_l;
            cmd.Parameters.Add("@ort_ner_ely_r", SqlDbType.VarChar).Value = ort_ner_ely_r;
            cmd.Parameters.Add("@ort_ner_vel_l", SqlDbType.VarChar).Value = ort_ner_vel_l;
            cmd.Parameters.Add("@ort_ner_vle_r", SqlDbType.VarChar).Value = ort_ner_vle_r;
            cmd.Parameters.Add("@ort_sij_gae_l", SqlDbType.VarChar).Value = ort_sij_gae_l;
            cmd.Parameters.Add("@ort_sij_gae_r", SqlDbType.VarChar).Value = ort_sij_gae_r;
            cmd.Parameters.Add("@ort_sij_yeo_l", SqlDbType.VarChar).Value = ort_sij_yeo_l;
            cmd.Parameters.Add("@ort_sij_yeo_r", SqlDbType.VarChar).Value = ort_sij_yeo_r;
            cmd.Parameters.Add("@ort_sij_hoo_l", SqlDbType.VarChar).Value = ort_sij_hoo_l;
            cmd.Parameters.Add("@ort_sij_dlr", SqlDbType.VarChar).Value = ort_sij_dlr;
            cmd.Parameters.Add("@ort_ner_ll", SqlDbType.VarChar).Value = ort_ner_ll;
            cmd.Parameters.Add("@ort_ner_cm_mar_l", SqlDbType.VarChar).Value = ort_ner_cm_mar_l;
            InsertOrUpdate(cmd);



        }
    }

    protected void nuerologicalSave_Click(object sender, EventArgs e)
    {
        string empid = Session["id_health"].ToString();
        string problem = Session["SolvingProblem"].ToString();
        DateTime problemstartdate = Convert.ToDateTime(Session["date_fitness"]);
        DateTime problemreviewdate = Convert.ToDateTime(Session["re"].ToString());
        string neu_cer_bic_l = bl1.Text.ToString();
        string neu_cer_bic_r = br2.Text.ToString();
        string neu_cer_est_c = ec3.Text.ToString();
        string neu_cer_bra_l = bl.Text.ToString();
        string neu_cer_bra_r = br.Text.ToString();
        string neu_cer_tri_l = tl1.Text.ToString();
        string neu_cer_tri_r = tr2.Text.ToString();
        string neu_cer_mus_str = ms.Text.ToString();
        string neu_lum_pate_l = pl1.Text.ToString();
        string neu_lum_pate_r = pr2.Text.ToString();
        string neu_lum_est_l = el.Text.ToString();
        string neu_lum_ach_l = TextBox1.Text.ToString();
        string neu_lum_ach_r = TextBox2.Text.ToString();
        string neu_lum_mus_str = TextBox3.Text.ToString();
        string neu_lum_heelwalk_l = HeelWalk_L.Text.ToString();
        string neu_lum_heelwalk_r = HeelWalk_R.Text.ToString();
        string neu_lum_toewalk_l = ToeWalk_L.Text.ToString();
        string neu_lum_toewalk_r = ToeWalk_R.Text.ToString();
        string neu_lum_path = lasttb.Text.ToString();
        string neu_lum_all_neg = check.Checked.ToString();
        DataTable dt1 = this.GetData("select * from objectiveFindingsExam WHERE empid='" + empid + "' AND problem = '" + problem + "' AND problemstartdate = '" + problemstartdate + "' AND problemreviewdate = '" + problemreviewdate + "'");
        if (dt1.Rows.Count == 0)
        {
            string strQuery = "insert into objectiveFindingsExam(empid,problem,problemstartdate,problemreviewdate,neu_cer_bic_l, neu_cer_bic_r, neu_cer_est_c,neu_cer_bra_l,neu_cer_bra_r,neu_cer_tri_l,neu_cer_tri_r,neu_cer_mus_str,neu_lum_pate_l,neu_lum_pate_r,neu_lum_est_l,neu_lum_ach_l,neu_lum_ach_r,neu_lum_mus_str,neu_lum_heelwalk_l,neu_lum_heelwalk_r,neu_lum_toewalk_l,neu_lum_toewalk_r,neu_lum_path,neu_lum_all_neg)" +
              " values (@empid,@problem,@probdate,@probReviewDate,@ncbl, @ncbr, @ncec,@ncbrl,@ncbrr,@nctl,@nctr,@ncms,@nlpl,@nlpr,@nlel,@nlal,@nlar,@nlms,@nlhl,@nlhr,@nltl,@nltr,@nlp,@nlap)";
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.Parameters.Add("@empid", SqlDbType.VarChar).Value = empid;
            cmd.Parameters.Add("@problem", SqlDbType.VarChar).Value = problem;
            cmd.Parameters.Add("@probdate", SqlDbType.DateTime2).Value = problemstartdate;
            cmd.Parameters.Add("@probReviewDate", SqlDbType.DateTime2).Value = problemreviewdate;
            cmd.Parameters.Add("@ncbl", SqlDbType.VarChar).Value = neu_cer_bic_l;
            cmd.Parameters.Add("@ncbr", SqlDbType.VarChar).Value = neu_cer_bic_r;
            cmd.Parameters.Add("@ncec", SqlDbType.VarChar).Value = neu_cer_est_c;
            cmd.Parameters.Add("@ncbrl", SqlDbType.VarChar).Value = neu_cer_bra_l;
            cmd.Parameters.Add("@ncbrr", SqlDbType.VarChar).Value = neu_cer_bra_r;
            cmd.Parameters.Add("@nctl", SqlDbType.VarChar).Value = neu_cer_tri_l;
            cmd.Parameters.Add("@nctr", SqlDbType.VarChar).Value = neu_cer_tri_r;
            cmd.Parameters.Add("@ncms", SqlDbType.VarChar).Value = neu_cer_mus_str;
            cmd.Parameters.Add("@nlpl", SqlDbType.VarChar).Value = neu_lum_pate_l;
            cmd.Parameters.Add("@nlpr", SqlDbType.VarChar).Value = neu_lum_pate_r;
            cmd.Parameters.Add("@nlel", SqlDbType.VarChar).Value = neu_lum_est_l;
            cmd.Parameters.Add("@nlal", SqlDbType.VarChar).Value = neu_lum_ach_l;
            cmd.Parameters.Add("@nlar", SqlDbType.VarChar).Value = neu_lum_ach_r;
            cmd.Parameters.Add("@nlms", SqlDbType.VarChar).Value = neu_lum_mus_str;
            cmd.Parameters.Add("@nlhl", SqlDbType.VarChar).Value = neu_lum_heelwalk_l;
            cmd.Parameters.Add("@nlhr", SqlDbType.VarChar).Value = neu_lum_heelwalk_r;
            cmd.Parameters.Add("@nltl", SqlDbType.VarChar).Value = neu_lum_toewalk_l;
            cmd.Parameters.Add("@nltr", SqlDbType.VarChar).Value = neu_lum_toewalk_r;
            cmd.Parameters.Add("@nlp", SqlDbType.VarChar).Value = neu_lum_path;
            cmd.Parameters.Add("@nlap", SqlDbType.VarChar).Value = neu_lum_all_neg;
            InsertOrUpdate(cmd);
        }
        else
        {
            string strQuery = "UPDATE objectiveFindingsExam SET empid=@empid,problem = @problem,problemstartdate=@probdate,problemreviewdate=@probReviewDate,neu_cer_bic_l=@ncbl, neu_cer_bic_r=@ncbr, neu_cer_est_c=@ncec,neu_cer_bra_l=@ncbl1,neu_cer_bra_r=@ncbr1,neu_cer_tri_l=@nctl,neu_cer_tri_r=@nctr,neu_cer_mus_str=@ncms,neu_lum_pate_l=@nlpl,neu_lum_pate_r=@nlpr,neu_lum_est_l=@nlel,neu_lum_ach_l=@nlal,neu_lum_ach_r=@nlar,neu_lum_mus_str=@nlms,neu_lum_heelwalk_l=@nlhl,neu_lum_heelwalk_r=@nlhr,neu_lum_toewalk_l=@nltl,neu_lum_toewalk_r=@nltr,neu_lum_path=@nlp,neu_lum_all_neg=@nlap  WHERE empid='" + empid + "' AND problem = '" + problem + "' AND problemstartdate = '" + problemstartdate + "' AND problemreviewdate = '" + problemreviewdate + "'";

            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.Parameters.Add("@empid", SqlDbType.VarChar).Value = empid;
            cmd.Parameters.Add("@problem", SqlDbType.VarChar).Value = problem;
            cmd.Parameters.Add("@probdate", SqlDbType.DateTime2).Value = problemstartdate;
            cmd.Parameters.Add("@probReviewDate", SqlDbType.DateTime2).Value = problemreviewdate;
            cmd.Parameters.Add("@ncbl", SqlDbType.VarChar).Value = neu_cer_bic_l;
            cmd.Parameters.Add("@ncbr", SqlDbType.VarChar).Value = neu_cer_bic_r;
            cmd.Parameters.Add("@ncec", SqlDbType.VarChar).Value = neu_cer_est_c;
            cmd.Parameters.Add("@ncbl1", SqlDbType.VarChar).Value = neu_cer_bra_l;
            cmd.Parameters.Add("@ncbr1", SqlDbType.VarChar).Value = neu_cer_bra_r;
            cmd.Parameters.Add("@nctl", SqlDbType.VarChar).Value = neu_cer_tri_l;
            cmd.Parameters.Add("@nctr", SqlDbType.VarChar).Value = neu_cer_tri_r;
            cmd.Parameters.Add("@ncms", SqlDbType.VarChar).Value = neu_cer_mus_str;
            cmd.Parameters.Add("@nlpl", SqlDbType.VarChar).Value = neu_lum_pate_l;
            cmd.Parameters.Add("@nlpr", SqlDbType.VarChar).Value = neu_lum_pate_r;
            cmd.Parameters.Add("@nlel", SqlDbType.VarChar).Value = neu_lum_est_l;
            cmd.Parameters.Add("@nlal", SqlDbType.VarChar).Value = neu_lum_ach_l;
            cmd.Parameters.Add("@nlar", SqlDbType.VarChar).Value = neu_lum_ach_r;
            cmd.Parameters.Add("@nlms", SqlDbType.VarChar).Value = neu_lum_mus_str;
            cmd.Parameters.Add("@nlhl", SqlDbType.VarChar).Value = neu_lum_heelwalk_l;
            cmd.Parameters.Add("@nlhr", SqlDbType.VarChar).Value = neu_lum_heelwalk_r;
            cmd.Parameters.Add("@nltl", SqlDbType.VarChar).Value = neu_lum_toewalk_l;
            cmd.Parameters.Add("@nltr", SqlDbType.VarChar).Value = neu_lum_toewalk_r;
            cmd.Parameters.Add("@nlp", SqlDbType.VarChar).Value = neu_lum_path;
            cmd.Parameters.Add("@nlap", SqlDbType.VarChar).Value = neu_lum_all_neg;
            InsertOrUpdate(cmd);
        }


    }

    protected void inspectionSave_Click(object sender, EventArgs e)
    {
        //declaration
        string ins_spline_obs = null;
        string ins_sub_mus_l = null;
        string ins_sub_mus_r = null;
        string ins_scm_mus_l = null;
        string ins_scm_mus_r = null;
        string ins_para_mus_ct_l = null;
        string ins_para_mus_ct_r = null;
        string ins_ls_spine_obs = null;
        string ins_tra_mus_ut_l = null;
        string ins_tra_mus_ut_r = null;
        string ins_tra_mus_mt_l = null;
        string ins_tra_mus_mt_r = null;
        string ins_tra_mus_lt_l = null;
        string ins_tra_mus_lt_r = null;
        string ins_para_mus_tl_l = null;
        string ins_para_mus_tl_r = null;
        string ins_piri_mus_l = null;
        string ins_piri_mus_r = null;
        string ins_glu_mus_l = null;
        string ins_glu_mus_r = null;
        //
        ins_spline_obs = ct.Text.ToString();
        ins_ls_spine_obs = ls.Text.ToString();

        if (!string.IsNullOrEmpty(Request.Form["sml"]))
        {
            ins_sub_mus_l = Request.Form["sml"];

        }

        if (!string.IsNullOrEmpty(Request.Form["smr"]))
        {
            ins_sub_mus_r = Request.Form["smr"];

        }

        if (!string.IsNullOrEmpty(Request.Form["scm"]))
        {
            ins_scm_mus_l = Request.Form["scm"];

        }

        if (!string.IsNullOrEmpty(Request.Form["scmr"]))
        {
            ins_scm_mus_r = Request.Form["scmr"];

        }

        if (!string.IsNullOrEmpty(Request.Form["pml"]))
        {
            ins_para_mus_ct_l = Request.Form["pml"];

        }

        if (!string.IsNullOrEmpty(Request.Form["pmr"]))
        {
            ins_para_mus_ct_r = Request.Form["pmr"];

        }

        if (!string.IsNullOrEmpty(Request.Form["tml"]))
        {
            ins_tra_mus_ut_l = Request.Form["tml"];

        }

        if (!string.IsNullOrEmpty(Request.Form["tmr"]))
        {
            ins_tra_mus_ut_r = Request.Form["tmr"];

        }

        if (!string.IsNullOrEmpty(Request.Form["mtl"]))
        {
            ins_tra_mus_mt_l = Request.Form["mtl"];

        }

        if (!string.IsNullOrEmpty(Request.Form["mtr"]))
        {
            ins_tra_mus_mt_r = Request.Form["mtr"];

        }

        if (!string.IsNullOrEmpty(Request.Form["ltl"]))
        {
            ins_tra_mus_lt_l = Request.Form["ltl"];

        }

        if (!string.IsNullOrEmpty(Request.Form["ltr"]))
        {
            ins_tra_mus_lt_r = Request.Form["ltr"];

        }

        if (!string.IsNullOrEmpty(Request.Form["tll"]))
        {
            ins_para_mus_tl_l = Request.Form["tll"];

        }

        if (!string.IsNullOrEmpty(Request.Form["tlr"]))
        {
            ins_para_mus_tl_r = Request.Form["tlr"];

        }

        if (!string.IsNullOrEmpty(Request.Form["lsl"]))
        {
            ins_piri_mus_l = Request.Form["lsl"];

        }

        if (!string.IsNullOrEmpty(Request.Form["lsr"]))
        {
            ins_piri_mus_r = Request.Form["lsr"];

        }

        if (!string.IsNullOrEmpty(Request.Form["gml"]))
        {
            ins_glu_mus_l = Request.Form["gml"];

        }

        if (!string.IsNullOrEmpty(Request.Form["gmr"]))
        {
            ins_glu_mus_r = Request.Form["gmr"];

        }

        //
        string empid = Session["id_health"].ToString();
        string problem = Session["SolvingProblem"].ToString();
        DateTime problemstartdate = Convert.ToDateTime(Session["date_fitness"]);
        DateTime problemreviewdate = Convert.ToDateTime(Session["re"].ToString());
        DataTable dt1 = this.GetData("select * from objectiveFindingsExam WHERE empid='" + empid + "' AND problem = '" + problem + "' AND problemstartdate = '" + problemstartdate + "' AND problemreviewdate = '" + problemreviewdate + "'");
        if (dt1.Rows.Count == 0)
        {
            //insert
            string strQuery = "insert into objectiveFindingsExam(empid,problem,problemstartdate,problemreviewdate, ins_spline_obs, ins_sub_mus_l, ins_sub_mus_r, ins_scm_mus_l, ins_scm_mus_r, ins_para_mus_ct_l, ins_para_mus_ct_r, ins_ls_spine_obs, ins_tra_mus_ut_l, ins_tra_mus_ut_r, ins_tra_mus_mt_l, ins_tra_mus_mt_r, ins_tra_mus_lt_l, ins_tra_mus_lt_r, ins_para_mus_tl_l, ins_para_mus_tl_r, ins_piri_mus_l, ins_piri_mus_r, ins_glu_mus_l, ins_glu_mus_r)" +
            "values (@empid,@problem,@probdate,@probReviewDate,@ins_spline_obs,@ins_sub_mus_l,@ins_sub_mus_r, @ins_scm_mus_l, @ins_scm_mus_r, @ins_para_mus_ct_l, @ins_para_mus_ct_r, @ins_ls_spine_obs,@ins_tra_mus_ut_l, @ins_tra_mus_ut_r, @ins_tra_mus_mt_l, @ins_tra_mus_mt_r, @ins_tra_mus_lt_l, @ins_tra_mus_lt_r, @ins_para_mus_tl_l, @ins_para_mus_tl_r, @ins_piri_mus_l, @ins_piri_mus_r, @ins_glu_mus_l, @ins_glu_mus_r )";

            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.Parameters.Add("@empid", SqlDbType.VarChar).Value = empid;
            cmd.Parameters.Add("@problem", SqlDbType.VarChar).Value = problem;
            cmd.Parameters.Add("@probdate", SqlDbType.DateTime2).Value = problemstartdate;
            cmd.Parameters.Add("@probReviewDate", SqlDbType.DateTime2).Value = problemreviewdate;
            //++++++++++++++++++++++++
            /*cmd.Parameters.Add("@", SqlDbType.VarChar).Value = ;*/
            cmd.Parameters.Add("@ins_spline_obs", SqlDbType.VarChar).Value = ins_spline_obs;
            cmd.Parameters.Add("@ins_sub_mus_l", SqlDbType.VarChar).Value = ins_sub_mus_l;
            cmd.Parameters.Add("@ins_sub_mus_r", SqlDbType.VarChar).Value = ins_sub_mus_r;
            cmd.Parameters.Add("@ins_scm_mus_l", SqlDbType.VarChar).Value = ins_scm_mus_l;
            cmd.Parameters.Add("@ins_scm_mus_r", SqlDbType.VarChar).Value = ins_scm_mus_r;
            cmd.Parameters.Add("@ins_para_mus_ct_l", SqlDbType.VarChar).Value = ins_para_mus_ct_l;
            cmd.Parameters.Add("@ins_para_mus_ct_r", SqlDbType.VarChar).Value = ins_para_mus_ct_r;
            cmd.Parameters.Add("@ins_ls_spine_obs", SqlDbType.VarChar).Value = ins_ls_spine_obs;
            cmd.Parameters.Add("@ins_tra_mus_ut_l", SqlDbType.VarChar).Value = ins_tra_mus_ut_l;
            cmd.Parameters.Add("@ins_tra_mus_ut_r", SqlDbType.VarChar).Value = ins_tra_mus_ut_r;
            cmd.Parameters.Add("@ins_tra_mus_mt_l", SqlDbType.VarChar).Value = ins_tra_mus_mt_l;
            cmd.Parameters.Add("@ins_tra_mus_mt_r", SqlDbType.VarChar).Value = ins_tra_mus_mt_r;
            cmd.Parameters.Add("@ins_tra_mus_lt_l", SqlDbType.VarChar).Value = ins_tra_mus_lt_l;
            cmd.Parameters.Add("@ins_tra_mus_lt_r", SqlDbType.VarChar).Value = ins_tra_mus_lt_r;
            cmd.Parameters.Add("@ins_para_mus_tl_l", SqlDbType.VarChar).Value = ins_para_mus_tl_l;
            cmd.Parameters.Add("@ins_para_mus_tl_r", SqlDbType.VarChar).Value = ins_para_mus_tl_r;
            cmd.Parameters.Add("@ins_piri_mus_l", SqlDbType.VarChar).Value = ins_piri_mus_l;
            cmd.Parameters.Add("@ins_piri_mus_r", SqlDbType.VarChar).Value = ins_piri_mus_r;
            cmd.Parameters.Add("@ins_glu_mus_l", SqlDbType.VarChar).Value = ins_glu_mus_l;
            cmd.Parameters.Add("@ins_glu_mus_r", SqlDbType.VarChar).Value = ins_glu_mus_r;
            InsertOrUpdate(cmd);
        }
        else
        {
            //update
            string strQuery = "UPDATE objectiveFindingsExam SET ins_spline_obs=@ins_spline_obs, ins_sub_mus_l=@ins_sub_mus_l, ins_sub_mus_r=@ins_sub_mus_r, ins_scm_mus_l=@ins_scm_mus_l, ins_scm_mus_r=@ins_scm_mus_r, ins_para_mus_ct_l=@ins_para_mus_ct_l, ins_para_mus_ct_r=@ins_para_mus_ct_r, ins_ls_spine_obs=@ins_ls_spine_obs, ins_tra_mus_ut_l=@ins_tra_mus_ut_l, ins_tra_mus_ut_r=@ins_tra_mus_ut_r, ins_tra_mus_mt_l=@ins_tra_mus_mt_l, ins_tra_mus_mt_r=@ins_tra_mus_mt_r, ins_tra_mus_lt_l=@ins_tra_mus_lt_l, ins_tra_mus_lt_r=@ins_tra_mus_lt_r, ins_para_mus_tl_l=@ins_para_mus_tl_l, ins_para_mus_tl_r=@ins_para_mus_tl_r, ins_piri_mus_l=@ins_piri_mus_l, ins_piri_mus_r=@ins_piri_mus_r, ins_glu_mus_l=@ins_glu_mus_l, ins_glu_mus_r=@ins_glu_mus_r WHERE empid='" + empid + "' AND problem = '" + problem + "' AND problemstartdate = '" + problemstartdate + "' AND problemreviewdate = '" + problemreviewdate + "'";
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.Parameters.Add("@empid", SqlDbType.VarChar).Value = empid;
            cmd.Parameters.Add("@problem", SqlDbType.VarChar).Value = problem;
            cmd.Parameters.Add("@probdate", SqlDbType.DateTime2).Value = problemstartdate;
            cmd.Parameters.Add("@probReviewDate", SqlDbType.DateTime2).Value = problemreviewdate;
            //++++++++++++++++++++++++
            /*cmd.Parameters.Add("@", SqlDbType.VarChar).Value = ;*/
            cmd.Parameters.Add("@ins_spline_obs", SqlDbType.VarChar).Value = ins_spline_obs;
            cmd.Parameters.Add("@ins_sub_mus_l", SqlDbType.VarChar).Value = ins_sub_mus_l;
            cmd.Parameters.Add("@ins_sub_mus_r", SqlDbType.VarChar).Value = ins_sub_mus_r;
            cmd.Parameters.Add("@ins_scm_mus_l", SqlDbType.VarChar).Value = ins_scm_mus_l;
            cmd.Parameters.Add("@ins_scm_mus_r", SqlDbType.VarChar).Value = ins_scm_mus_r;
            cmd.Parameters.Add("@ins_para_mus_ct_l", SqlDbType.VarChar).Value = ins_para_mus_ct_l;
            cmd.Parameters.Add("@ins_para_mus_ct_r", SqlDbType.VarChar).Value = ins_para_mus_ct_r;
            cmd.Parameters.Add("@ins_ls_spine_obs", SqlDbType.VarChar).Value = ins_ls_spine_obs;
            cmd.Parameters.Add("@ins_tra_mus_ut_l", SqlDbType.VarChar).Value = ins_tra_mus_ut_l;
            cmd.Parameters.Add("@ins_tra_mus_ut_r", SqlDbType.VarChar).Value = ins_tra_mus_ut_r;
            cmd.Parameters.Add("@ins_tra_mus_mt_l", SqlDbType.VarChar).Value = ins_tra_mus_mt_l;
            cmd.Parameters.Add("@ins_tra_mus_mt_r", SqlDbType.VarChar).Value = ins_tra_mus_mt_r;
            cmd.Parameters.Add("@ins_tra_mus_lt_l", SqlDbType.VarChar).Value = ins_tra_mus_lt_l;
            cmd.Parameters.Add("@ins_tra_mus_lt_r", SqlDbType.VarChar).Value = ins_tra_mus_lt_r;
            cmd.Parameters.Add("@ins_para_mus_tl_l", SqlDbType.VarChar).Value = ins_para_mus_tl_l;
            cmd.Parameters.Add("@ins_para_mus_tl_r", SqlDbType.VarChar).Value = ins_para_mus_tl_r;
            cmd.Parameters.Add("@ins_piri_mus_l", SqlDbType.VarChar).Value = ins_piri_mus_l;
            cmd.Parameters.Add("@ins_piri_mus_r", SqlDbType.VarChar).Value = ins_piri_mus_r;
            cmd.Parameters.Add("@ins_glu_mus_l", SqlDbType.VarChar).Value = ins_glu_mus_l;
            cmd.Parameters.Add("@ins_glu_mus_r", SqlDbType.VarChar).Value = ins_glu_mus_r;
            InsertOrUpdate(cmd);
        }
    }
}