using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;

namespace NasaFitness_Employee
{
    /// <summary>
    /// Summary description for FollowUpPdf
    /// </summary>
    public class FollowUpPdf : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string id = context.Request.QueryString["id"];
            string filepath = HttpContext.Current.Server.MapPath(id);
            WebClient user = new WebClient();
            Byte[] FileBuffer = user.DownloadData(filepath);
            if (FileBuffer != null)
            {
               context.Response.ContentType = "application/pdf";
                context.Response.AddHeader("content-length", FileBuffer.Length.ToString());
                context.Response.BinaryWrite(FileBuffer);
            }

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