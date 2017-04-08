using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Translation.Application;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data;

namespace Translation
{
    public partial class myProject : System.Web.UI.Page
    {
        string username;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Request.Cookies["username"] == null)
            //{
            //    Response.Redirect("login.aspx");
            //}
            //else if (!IsPostBack)
            //{
            //    username = Request.Cookies["username"].Value;
            //    usermsg.Text = username;
            //    Data_Binding();
            //}
            username = User.Identity.Name;
            Data_Binding();
            usermsg.Text = username;
        }
        //显示进度
        public string showRate(string projectId)
        {
            string sqlAllStr = $"select count([key])from textinfo left join translation on (translation.textId = textinfo.textId) where projectId = '{projectId}' ";
            string sqlTranslatedStr = $"select count([key]) from textinfo left join translation on (translation.textId = textinfo.textId) where projectId = '{projectId}' and translatedText is not null";
            string rate = ((double)result(sqlTranslatedStr) / result(sqlAllStr)).ToString("0.00%");
            return rate;
        }
        int result(string str)
        {
            return Convert.ToInt16(SQLHelper.GetExecuteScalar(str));
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
        public string hasProject(string element)
        {
            string sqlcount = $"select count(*) from projectinfo where username='{username}'";
            int i = Convert.ToInt16(SQLHelper.GetExecuteScalar(sqlcount));            
            if (element=="bind")
            {
                if (i == 0)
                {
                    return "hidden";
                }
                else
                {
                    return "show";
                }
            }
            if (element == "tip")
            {
                if (i == 0)
                {
                    return "show";
                }
                else
                {
                    return "hidden";
                }
            }
            return null;

        }

        //数据绑定
        private void Data_Binding()
        {
            PagedDataSource pd = new PagedDataSource();
            if (ViewState["DataSource"] == null)
            {
                string sql = $"select projectname,createtime,projectId from projectinfo where username='{username}'";
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
        protected void upload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string datetime = "" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;
                string filePath = Server.MapPath("File/") + datetime + FileUpload1.FileName;
                FileUpload1.SaveAs(filePath);
                string JSONString = fileHelper.FileStreamReader(filePath);
                string sqlInsert;
                //JSON反序列化
                JArray ja = JSONHelper.DeserializeJSON(JSONString);
                //测试用
                string s = "";
                //预留username
                //projectId以时间+项目名
                sqlInsert = $"insert into projectinfo(projectId,projectname,username,createtime) values('{datetime + ProjectName.Text}','{ProjectName.Text}','{username}','{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}')";
                SQLHelper.GetExecuteNonQuery(sqlInsert);
                for (int i = 0; i < ja.Count; i++)
                {
                    JObject o = (JObject)ja[i];
                    //textId以时间+key+顺序i
                    sqlInsert = $"insert into textinfo(textId,[key],text,projectId) values('{datetime + o["key"].ToString() + i}','{o["key"].ToString()}','{ o["text"].ToString()}','{datetime + ProjectName.Text}')";
                    SQLHelper.GetExecuteNonQuery(sqlInsert);
                    s += "KEY:" + o["key"].ToString();
                    s += "TEXT:" + o["text"].ToString();
                }

                usermsg.Text = s;

            }
        }
    }
}