using System;
using System.Collections.Generic;
using System.Linq;
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

        }
        string usernameTxt;
        string passwordTxt1;
        string passwordTxt2;
        protected void userRegister_Click(object sender, EventArgs e)
        {
            usernameTxt = username.Text;
            passwordTxt1 = password1.Text;
            passwordTxt2 = password2.Text;
            string sqlInsertStr ="insert into userinfo(username,password)";
            sqlInsertStr += $"values('{ usernameTxt }','{ passwordTxt1 }')";
            //试试C#6语法
            string sqlSelectStr = $"select count(*) from userinfo where username='{usernameTxt}' and password='{passwordTxt1}'";

            if (passwordTxt1 == passwordTxt2)
            {
                if (Convert.ToInt16(SQLHelper.GetExecuteScalar(sqlSelectStr)) == 0)
                {
                    SQLHelper.GetExecuteNonQuery(sqlInsertStr);
                    Response.Redirect("myProject.aspx");
                }
                else
                {
                    Label4.Text = "用户名已存在";
                }
            }
        }

    }
}