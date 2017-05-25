using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Translation.Application;
using Translation.model;

namespace Translation
{
    public partial class projectDetail : System.Web.UI.Page
    {
        
        string projectId;
        public string username;
        protected void Page_Load(object sender, EventArgs e)
        {
            username = Authentication.getUserName();
            Master.UserClass = "show col-md-3";
            Master.loginClass = "hidden";
            Master.UserTxt = Authentication.getUserName();
            projectId = Request.QueryString["projectId"];
            if (!IsPostBack)
                Data_Binding();
        }
        public string hasText(string text)
        {
            if (text!="")
            {
                return "well well-sm show";
            }
            else
            {
                return "well well-sm hidden";
            }
            
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
        private List<member> datatabletolist(DataTable dt)
        {
            List<member> members = new List<member>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    member m = new member();
                    m.username = Convert.ToString(dr["username"]);
                    m.translationnumber = Convert.ToInt16(dr[0]);
                    members.Add(m);
                }
                return members;
            }
            else
            {
                return null;
            }
        }
        public List<member> GetMembers()
        {
            string sql = $"select count(textId),username from translation where textId in(select textId from textinfo where projectId='{projectId}') group by username ";
            return datatabletolist(SQLHelper.GetDataTable(sql));
           
        }
        public DataTable GetCreatorMessage()
        {
            string sql = $"select username,message from projectinfo where projectId='{projectId}'";
            return SQLHelper.GetDataTable(sql);
        }
        private void Data_Binding()
        {
            PagedDataSource pd = new PagedDataSource();
            if (ViewState["DataSource"] == null)
            {
                //查询已翻译的 
                //select [key],text,username,translatedText,updateTime from textinfo　left join　translation on  (translation.textId = textinfo.textId) where projectId='201722421213darkestdungeon' and translatedText is not null;
                //查询所有的
                //select [key],text,username,translatedText,updateTime from textinfo　left join　translation on  (translation.textId=textinfo.textId) where projectId='201722421213darkestdungeon';
                //查询未翻译的
                //select [key],text,username,translatedText,updateTime from textinfo　left join　translation on  (translation.textId=textinfo.textId) where projectId='201722421213darkestdungeon' and translation.textId is null;
                //string sql = $"select [key],text from textinfo where projectId='{projectId}'";
                string sql = $"select[key],textinfo.textId,text,username,translatedText,updateTime from textinfo left join translation on(translation.textId = textinfo.textId) where projectId = '{projectId}'";
                ViewState["DataSource"] = SQLHelper.GetDataTable(sql);
            }
            pd.DataSource = ((DataTable)ViewState["DataSource"]).DefaultView;
            pd.AllowPaging = true;
            pd.PageSize = 20;
            pd.CurrentPageIndex = CurrentPage;
            Label1.Text = $"当前:{ (CurrentPage + 1).ToString()}/{ pd.PageCount.ToString()}";
            ButtonPrevious.Enabled = !pd.IsFirstPage;
            ButtonNext.Enabled = !pd.IsLastPage;
            Repeaterprojects.DataSource = pd;
            Repeaterprojects.DataBind();
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

        protected void Submit(object sender, CommandEventArgs e)
        {
            var i = e.CommandArgument;
            
        }
    }
}