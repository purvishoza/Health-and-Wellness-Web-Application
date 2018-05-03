using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Sql;

namespace NasaFitness_Employee
{
    /// <summary>
    /// Summary description for FollowUpDetails
    /// </summary>
    public class FollowUpDetails : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            string id = context.Request.QueryString["id"];
            byte[] bytes;
            string contentType;
            string strConnString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
            string name;
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select Name, Data, ContentType from ExerciseVideos where Name='" + id+"'";
                    //cmd.Parameters.AddWithValue("@Id", id);
                   
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    sdr.Read();
                    bytes = (byte[])sdr["Data"];
                    contentType = sdr["ContentType"].ToString();
                    name = sdr["Name"].ToString();
                    con.Close();
                }
            }
            context.Response.Clear();
            context.Response.Buffer = true;
            context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + name);
            context.Response.ContentType = contentType;
            context.Response.BinaryWrite(bytes);
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}