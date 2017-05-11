using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Translation.Application;

namespace Translation
{
    public partial class managerPage : System.Web.UI.Page
    {
        string adminname;
        protected void Page_Load(object sender, EventArgs e)
        {
            adminname = Authentication.getUserName();
            if (!IsPostBack)
                Data_Binding();
        }
        public string getadminname()
        {
            return adminname;
        }
        private int CurrentPage
        {
            get
            {
                object currPg = this.ViewState["CurrentPage"];
                if (currPg == null)
                    return 0;
                else
                {
                    return Convert.ToInt32(currPg);
                }

            }
            set
            {
                this.ViewState["CurrentPage"] = value;
            }
        }
        private void Data_Binding()
        {
            PagedDataSource pd = new PagedDataSource();
            if (ViewState["DataSource"] == null)
            {
                string sql = "select username from userinfo where rights is null";
                ViewState["DataSource"] = SQLHelper.GetDataTable(sql);
            }
            pd.DataSource = ((DataTable)ViewState["DataSource"]).DefaultView;
            pd.AllowPaging = true;
            pd.PageSize = 10;
            pd.CurrentPageIndex = CurrentPage;
            Label1.Text = $"当前:{ (CurrentPage + 1).ToString()}/{ pd.PageCount.ToString()}";
            ButtonPrevious.Enabled = !pd.IsFirstPage;
            ButtonNext.Enabled = !pd.IsLastPage;
            Repeaterprojects.DataSource = pd;
            Repeaterprojects.DataBind();
        }
        //翻页按钮
        protected void ButtonPrevious_Click(object sender, EventArgs e)
        {
            CurrentPage -= 1;
            Data_Binding();
        }

        protected void ButtonNext_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            Data_Binding();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Authentication.logOut();
            Response.Redirect("login.aspx");
        }
        string usernameTxt;
        string passwordTxt1;
        string passwordTxt2;
        protected void userRegister_Click(object sender, EventArgs e)
        {
            usernameTxt = username.Text;
            passwordTxt1 = password1.Text;
            passwordTxt2 = password2.Text;
            if (usernameTxt.Trim() != "" && passwordTxt1.Trim() != "" & passwordTxt2.Trim() != "")
            {
                string sqlInsertStr = "insert into userinfo(username,password)";
                sqlInsertStr += $"values('{ usernameTxt }','{ passwordTxt1 }')";
                string sqlSelectStr = $"select count(*) from userinfo where username='{usernameTxt}'";

                if (passwordTxt1 == passwordTxt2)
                {
                    if (Convert.ToInt16(SQLHelper.GetExecuteScalar(sqlSelectStr)) == 0)
                    {
                        SQLHelper.GetExecuteNonQuery(sqlInsertStr);
                        Response.AddHeader("Refresh", "0");
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
            else
            {
                Label4.Text = "用户名或密码不能为空!";
            }
        }
    }
}