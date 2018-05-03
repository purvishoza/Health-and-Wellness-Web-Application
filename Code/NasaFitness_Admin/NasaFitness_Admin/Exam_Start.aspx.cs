using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data;


public partial class Exam_Start : System.Web.UI.Page
{
    String[] myArray = new String[] { "True", "False", "True", "False", "False" };
    protected void Page_Load(object sender, EventArgs e)
    {
        DateTime dt1 = DateTime.Now;
        Session["dt1"] = dt1;
        string id = Decrypt(HttpUtility.UrlDecode(Request.QueryString["name"]));
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        string query = "SELECT * from Weekly_Users where Id='" + id + "'";
        using (SqlConnection con = new SqlConnection(cs))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataSet ds = new DataSet())
                    {
                        sda.Fill(ds);
                        if (ds.Tables[0].Rows.Count != 0)
                        {
                            DataRow dr1 = ds.Tables[0].Rows[0];
                            Session["week-question1"] = dr1["Question1"];
                            Session["week-question2"] = dr1["Question2"];
                            Session["week-question3"] = dr1["Question3"];
                            Session["week-question4"] = dr1["Question4"];
                            Session["week-question5"] = dr1["Question5"];
                            Session["week-Presentation"] = dr1["Presentation"];
                            Session["week-Topic"] = dr1["Topic"];
                            Session["week-Answers"] = dr1["Answers"];

                            head.InnerHtml = (string)dr1["Topic"];
                            tabel1.Rows[0].Cells[0].InnerText = "1." + " " + dr1["Question1"];
                            tabel1.Rows[1].Cells[0].InnerText = "2." + " " + dr1["Question2"];
                            tabel1.Rows[2].Cells[0].InnerText = "3." + " " + dr1["Question3"];
                            tabel1.Rows[3].Cells[0].InnerText = "4." + " " + dr1["Question4"];
                            tabel1.Rows[4].Cells[0].InnerText = "5." + " " + dr1["Question5"];

                        }
                        else
                        {



                        }
                    }

                }
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

    protected void save_Click(object sender, EventArgs e)
    {




        string answer1 = RadioButtonList.SelectedValue;
        string answer2 = RadioButtonList1.SelectedValue;
        string answer3 = RadioButtonList2.SelectedValue;
        string answer4 = RadioButtonList3.SelectedValue;
        string answer5 = RadioButtonList4.SelectedValue;
        if (answer1 == "" || answer2 == "" || answer3 == "" || answer4 == "" || answer5 == "")
        {
            MessageBox("Please Fill all the answers");
        }
        else
        {
            String[] ansArray1 = new String[] { answer1, answer2, answer3, answer4, answer5 };
            Session["ansArray1"] = ansArray1;
            Response.Redirect("Exam_Presentation.aspx");
        }




    }
    private void MessageBox(string Message)
    {
        Label lblMessageBox = new Label();
        lblMessageBox.Text =
            "<script language='javascript'>" + Environment.NewLine +
            "window.alert('" + Message + "')</script>";
        Page.Controls.Add(lblMessageBox);
    }
}