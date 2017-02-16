using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Translation.Application;

namespace Translation
{
    public partial class LoginIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void login_Click(object sender, EventArgs e)
        {
            string sqlStr=$"select count(*) from userinfo where username='{username.Text }' and password='{password.Text}'";
            string i = Convert.ToString(SQLHelper.GetExecuteScalar(sqlStr));
            Label1.Text = i;
        }
    }
}