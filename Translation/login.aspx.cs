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
            //注销登录状态，清空cookie
            Authentication.logOut();
        }
        string username;
        string password;
        protected void login_Click(object sender, EventArgs e)
        {
            //获取用户名密码
            username = usernameTxt.Text;
            password = passwordTxt.Text;
            string sqlStr = $"select count(*) from userinfo where username='{username}' and password='{password}'";
            //查询用户名及密码
            if (Convert.ToBoolean(SQLHelper.GetExecuteScalar(sqlStr)))
            {
                string sqlStrRights = $"select rights from userinfo where username='{username}'";
                if (Convert.ToString(SQLHelper.GetExecuteScalar(sqlStrRights)) == "admin")
                {
                    Label1.Text = "admin!";
                    Authentication.logOut();
                    //设置用户信息凭据
                    Authentication.SetCookie(username, password);
                    //跳转至我的项目页
                    Response.Redirect("managerPage.aspx");
                }
                else
                {
                    //先清空cookie
                    Authentication.logOut();
                    //设置用户信息凭据
                    Authentication.SetCookie(username, password);
                    //跳转至我的项目页
                    Response.Redirect("myProject.aspx");
                }

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