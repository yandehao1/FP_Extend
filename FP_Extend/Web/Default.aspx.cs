using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace RURO.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FreezerProUrl();
                //访问页面时做登陆检查
            }
        }
        private void FreezerProUrl()
        {
            string s = System.Configuration.ConfigurationManager.AppSettings["FpUrl"];
            FreezerPro.Attributes.Add("src", s);
        }
    }
}
