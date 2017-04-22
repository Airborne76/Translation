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
    public partial class projectView : System.Web.UI.Page
    {
        public string getUrl(string projectId)
        {
            return $"projectDetail.aspx?projectId={projectId }";

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //加载本页时显示当前用户名
            Master.UserClass = "show";
            Master.loginClass = "hidden";
            Master.UserTxt = Authentication.getUserName();
            if (!IsPostBack)
                Data_Binding();
        }
        //当前分页索引
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
        //数据绑定
        private void Data_Binding()
        {
            PagedDataSource pd = new PagedDataSource();
            if (ViewState["DataSource"] == null)
            {
                string sql = "select projectId,projectname,username,createtime from projectinfo";
                ViewState["DataSource"] = SQLHelper.GetDataTable(sql);
            }
            pd.DataSource = ((DataTable)ViewState["DataSource"]).DefaultView;
            pd.AllowPaging = true;
            pd.PageSize = 3;
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
    }
}