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

using DocuSign.eSign.Api;
using DocuSign.eSign.Model;
using DocuSign.eSign.Client;
using System.IO;

namespace NasaFitness_Employee
{
    public partial class HIPPA2 : System.Web.UI.Page
    {
        static string username = "viral.thakkar25@gmail.com";
        static string password = "Wclhost.123";
        static string integratorKey = "30ad44c6-5adc-4646-add5-65376e17cd20";
        static string templateId = "62c73088-656a-4f05-a562-548793469284";
        static string roleName = "***";

        protected void Page_Load(object sender, EventArgs r)
        {
            if (!Page.IsPostBack)
            {
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand("SELECT IRead, FName, LName FROM web_users where Pernr = @empid", con);
                cmd.Parameters.AddWithValue("@empid", Session["empid"].ToString());
                try
                {
                    con.Open();

                    SqlDataReader sqlReader = cmd.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        PatientName.Text = sqlReader["FName"].ToString() + " " + sqlReader["LName"].ToString();
                        //IRead.Checked = (bool)sqlReader["IRead"];
                        CurrentDate.Text = DateTime.Now.ToString();
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

        protected void save_consent(object sender, EventArgs e)
        {
            SqlConnection constr = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Update web_users set IRead=  @IRead where Pernr = @empid", constr);
            try
            {
                constr.Open();
                cmd.Parameters.AddWithValue("@IRead", IRead.Checked);
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
            Response.Redirect("DashboardEmp.aspx");
        }

        protected void SendDocforsign(object sender, EventArgs e)
        {
            string username = "viral.thakkar25@gmail.com";
            string password = "Wclhost.123";
            string integratorKey = "30ad44c6-5adc-4646-add5-65376e17cd20";

            // initialize client for desired environment (for production change to www)
            ApiClient apiClient = new ApiClient("https://demo.docusign.net/restapi");
            DocuSign.eSign.Client.Configuration.Default.ApiClient = apiClient;

            // configure 'X-DocuSign-Authentication' header
            string authHeader = "{\"Username\":\"" + username + "\", \"Password\":\"" + password + "\", \"IntegratorKey\":\"" + integratorKey + "\"}";
            DocuSign.eSign.Client.Configuration.Default.AddDefaultHeader("X-DocuSign-Authentication", authHeader);

            // we will retrieve this from the login API call
            string accountId = null;

            /////////////////////////////////////////////////////////////////
            // STEP 1: LOGIN API        
            /////////////////////////////////////////////////////////////////

            // login call is available in the authentication api 
            AuthenticationApi authApi = new AuthenticationApi();
            LoginInformation loginInfo = authApi.Login();

            // parse the first account ID that is returned (user might belong to multiple accounts)
            accountId = loginInfo.LoginAccounts[0].AccountId;

            // Update ApiClient with the new base url from login call
            string[] separatingStrings = { "/v2" };
            apiClient = new ApiClient(loginInfo.LoginAccounts[0].BaseUrl.Split(separatingStrings, StringSplitOptions.RemoveEmptyEntries)[0]);

            Console.WriteLine("LoginInformation: {0}", loginInfo.ToJson());

            /////////////////////////////////////////////////////////////////
            // STEP 2: CREATE ENVELOPE API        
            /////////////////////////////////////////////////////////////////				

            string SignTest1File = "C:\\Users\\thakkarv\\Documents\\sign-doc.docx";
            byte[] fileBytes = File.ReadAllBytes(SignTest1File);



            // create a new envelope which we will use to send the signature request
            EnvelopeDefinition envDef = new EnvelopeDefinition();
            envDef.EmailSubject = "[DocuSign C# SDK] - Sample Signature Request";

            // Add a document to the envelope
            Document doc = new Document();
            doc.DocumentBase64 = System.Convert.ToBase64String(fileBytes);
            doc.Name = "TestFile.pdf";
            doc.DocumentId = "1";

            envDef.Documents = new List<Document>();
            envDef.Documents.Add(doc);

            // Add a recipient to sign the documeent
            Signer signer = new Signer();
            signer.Email = "viral.thakkar25@gmail.com";
            signer.Name = "Viral Thakkar";
            signer.RecipientId = "1";

            // must set |clientUserId| to embed the recipient
            signer.ClientUserId = "1234";

            // Create a |SignHere| tab somewhere on the document for the recipient to sign
            signer.Tabs = new Tabs();
            signer.Tabs.SignHereTabs = new List<SignHere>();
            SignHere signHere = new SignHere();
            signHere.DocumentId = "1";
            signHere.PageNumber = "1";
            signHere.RecipientId = "1";
            signHere.XPosition = "100";
            signHere.YPosition = "150";
            signer.Tabs.SignHereTabs.Add(signHere);

            envDef.Recipients = new Recipients();
            envDef.Recipients.Signers = new List<Signer>();
            envDef.Recipients.Signers.Add(signer);

            // provide a valid template ID from a template in your account
            //envDef.TemplateId = "6f3e52e8-dd3b-44c0-93eb-186d77a4917a";

            // assign recipient to template role by setting name, email, and role name.  Note that the
            // template role name must match the placeholder role name saved in your account template.  
            TemplateRole tRole = new TemplateRole();
            /*tRole.Email = "viral.thakkar25@gmail.com";
            tRole.Name = "Viral";
            tRole.RoleName = "Test"; */

            // add the roles list with the our single role to the envelope
            List<TemplateRole> rolesList = new List<TemplateRole>() { tRole };
            envDef.TemplateRoles = rolesList;

            // set envelope status to "sent" to immediately send the signature request
            envDef.Status = "sent";

            // |EnvelopesApi| contains methods related to creating and sending Envelopes (aka signature requests)
            EnvelopesApi envelopesApi = new EnvelopesApi();
            EnvelopeSummary envelopeSummary = envelopesApi.CreateEnvelope(accountId, envDef);
        } // end main()
    }
}
