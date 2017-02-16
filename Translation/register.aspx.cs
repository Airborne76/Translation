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

        protected void userRegister_Click(object sender, EventArgs e)
        {
            string sqlInsertStr ="insert into userinfo(username,password)";
            sqlInsertStr += $"values('{ username.Text }','{ password1.Text }')";
            //试试C#6语法
            string sqlSelectStr = $"select count(*) from userinfo where username='{username.Text}' and password='{password1.Text}'";

            if (password1.Text == password2.Text)
            {
                if (Convert.ToInt16(SQLHelper.GetExecuteScalar(sqlSelectStr)) == 0)
                {
                    string i = Convert.ToString(SQLHelper.GetExecuteNonQuery(sqlInsertStr));
                    Label4.Text = i;
                }
                else
                {
                    Label4.Text = "用户名已存在";
                }
            }
        }

    }
}