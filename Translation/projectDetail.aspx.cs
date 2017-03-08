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
    public partial class projectDetail : System.Web.UI.Page
    {
        string projectId;
        protected void Page_Load(object sender, EventArgs e)
        {
            projectId = Request.QueryString["projectId"];
            if (!IsPostBack)
                Data_Binding();
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
                string sql = $"select [key],text from textinfo where projectId='{projectId}'";
                ViewState["DataSource"] = SQLHelper.GetDataTable(sql);
            }
            pd.DataSource = ((DataTable)ViewState["DataSource"]).DefaultView;
            pd.AllowPaging = true;
            pd.PageSize = 3;
            pd.CurrentPageIndex = CurrentPage;
            this.Label1.Text = $"当前:{ (CurrentPage + 1).ToString()}/{ pd.PageCount.ToString()}";
            this.ButtonPrevious.Enabled = !pd.IsFirstPage;
            this.ButtonNext.Enabled = !pd.IsLastPage;
            this.Repeaterprojects.DataSource = pd;
            this.Repeaterprojects.DataBind();
        }

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