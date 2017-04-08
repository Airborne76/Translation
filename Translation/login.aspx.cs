using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
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
        string username;
        protected void login_Click(object sender, EventArgs e)
        {
            username = usernameTxt.Text;
            string sqlStr=$"select count(*) from userinfo where username='{username}' and password='{password.Text}'";
            if (Convert.ToBoolean(SQLHelper.GetExecuteScalar(sqlStr)))
            {
                FormsAuthentication.SetAuthCookie(username, false);
                Label1.Text = $"用户{User.Identity.Name}登录!";
                Master.UserClass = "show";
                Master.loginClass = "hidden";
                Master.UserTxt = User.Identity.Name;
            }
            else
            {
                Label1.Text = "用户名不存在或密码错误!";
            }

            //FormsAuthentication.RedirectFromLoginPage(username.Text, false);
            //Response.Cookies["username"].Value = username.Text;
            //Response.Cookies["username"].Expires = DateTime.Now.AddDays(1);
        }
    }
}