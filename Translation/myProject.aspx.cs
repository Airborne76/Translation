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
using System.Resources;

namespace Translation
{
    public partial class myProject : System.Web.UI.Page
    {
        string username;
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.UserClass = "show col-md-3";
            Master.loginClass = "hidden";
            Master.UserTxt = Authentication.getUserName();
            username = Authentication.getUserName();
            Data_Binding();
            //usermsg.Text = username;
        }
        public string getUsername()
        {
            return username;
        }

        //显示进度
        public string showRate(string projectId)
        {
            //所有文本
            string sqlAllStr = $"select count([key])from textinfo left join translation on (translation.textId = textinfo.textId) where projectId = '{projectId}' ";
            //已翻译文本
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
            if (element == "bind")
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
        //前后翻页按钮
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
            var message = TextArea1.InnerText;
            if (ProjectName.Text.Trim() != "")
            {
                if (message.Length < 500)
                {
                    if (FileUpload1.HasFile)
                    {
                        try
                        {
                            string datetime = "" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;
                            string filePath = Server.MapPath("UploadFile/") + datetime + FileUpload1.FileName;
                            FileUpload1.SaveAs(filePath);
                            string JSONString = fileHelper.FileStreamReader(filePath);
                            string sqlInsert;
                            //JSON反序列化
                            JArray ja = JSONHelper.DeserializeJSON(JSONString);
                            if (ja != null)
                            {
                                //string s = "";
                                //以时间+项目名作为projectId
                                sqlInsert = $"insert into projectinfo(projectId,projectname,username,createtime,message) values('{datetime + ProjectName.Text}','{ProjectName.Text}','{username}','{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day} {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}','{message}')";
                                SQLHelper.GetExecuteNonQuery(sqlInsert);
                                for (int i = 0; i < ja.Count; i++)
                                {
                                    JObject o = (JObject)ja[i];
                                    //以时间+key+顺序i作为textId
                                    sqlInsert = $"insert into textinfo(textId,[key],text,projectId) values('{datetime + o["key"].ToString() + i}','{o["key"].ToString()}','{ o["text"].ToString()}','{datetime + ProjectName.Text}')";
                                    SQLHelper.GetExecuteNonQuery(sqlInsert);
                                    // s += "KEY:" + o["key"].ToString();
                                    //s += "TEXT:" + o["text"].ToString();
                                }
                                // usermsg.Text = s;
                                Response.AddHeader("Refresh", "0");
                            }
                            else
                            {
                                usermsg.Text = "文件格式错误，请检查上传的文件";
                            }
                        }
                        catch (Exception)
                        {
                            usermsg.Text = "文件格式错误，请检查上传的文件";
                        }
                    }
                    else
                    {
                        usermsg.Text = "请选择要上传的文件";
                    }
                }
                else
                {
                    usermsg.Text = "项目介绍应小于500字";
                }
            }
            else
            {
                usermsg.Text = "请输入项目名";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Authentication.logOut();
            Response.Redirect("login.aspx");
        }
    }
}