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
            string sqlStr = "insert into userinfo(username,password)";
            sqlStr += "values('"+username.Text+"','"+password1.Text+"')";
            if (password1.Text == password2.Text)
            {
                string i=Convert.ToString(SQLHelper.GetExecuteNonQuery(sqlStr));
                Label4.Text = i;
            }
        }

    }
}