using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Web.Services;
using System.IO;

namespace NasaFitness_Admin
{
    public partial class viewVideo : System.Web.UI.Page
    {
        string src = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            src = Request.QueryString["id"];
            //getData();
        }

        public string getData()
        {
            string val = "";
            val="FileCS.ashx?id=" + src;
            return val;
        }
    }
}