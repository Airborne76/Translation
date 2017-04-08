using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Translation
{
    public partial class main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        public void logined(string username)
        {
            login.Visible = false;
            user.Text = username;
        }
        public string loginClass
        {
            set
            {
                login.CssClass = value;
            }
        }
        public string UserClass
        {
            set
            {
                user.CssClass = value;
            }
        }
        public string UserTxt
        {
            set
            {
                user.Text = value;
            }
        }
    }
}