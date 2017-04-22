using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Translation.Application;

namespace Translation
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //加载此页时注销用户登录状态
            Authentication.logOut();
        }
        string usernameTxt;
        string passwordTxt1;
        string passwordTxt2;
        protected void userRegister_Click(object sender, EventArgs e)
        {
            //获取用户名密码
            usernameTxt = username.Text;
            passwordTxt1 = password1.Text;
            passwordTxt2 = password2.Text;
            string sqlInsertStr ="insert into userinfo(username,password)";
            sqlInsertStr += $"values('{ usernameTxt }','{ passwordTxt1 }')";
            //C#6语法中的字符串格式化
            string sqlSelectStr = $"select count(*) from userinfo where username='{usernameTxt}'";

            if (passwordTxt1 == passwordTxt2)
            {
                //插入一条用户数据
                if (Convert.ToInt16(SQLHelper.GetExecuteScalar(sqlSelectStr)) == 0)
                {
                    SQLHelper.GetExecuteNonQuery(sqlInsertStr);
                    //跳转至登录页
                    Response.Redirect("login.aspx");
                }
                else
                {
                    Label4.Text = "用户名已存在";
                }
            }
            else
            {
                Label4.Text = "密码输入不一致！";
            }
        }

    }
}