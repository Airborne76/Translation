using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Translation.Application;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Translation
{
    public partial class myProject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["username"]== null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                Label1.Text = Request.Cookies["username"].Value;
            }
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
                sqlInsert = $"insert into projectinfo(projectId,projectname,username,createtime) values('{datetime + ProjectName.Text}','{ProjectName.Text}','{Request.Cookies["username"].Value}','{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}')";
                SQLHelper.GetExecuteNonQuery(sqlInsert);
                for (int i = 0; i < ja.Count; i++)
                {
                    JObject o = (JObject)ja[i];
                    //textId以时间+key+顺序i
                    sqlInsert = $"insert into textinfo(textId,[key],text,projectId) values('{datetime+ o["key"].ToString() + i}','{o["key"].ToString()}','{ o["text"].ToString()}','{datetime+ProjectName.Text}')";
                    SQLHelper.GetExecuteNonQuery(sqlInsert);
                    s += "KEY:" + o["key"].ToString();
                    s += "TEXT:" + o["text"].ToString();
                }

                Label1.Text = s;

            }
        }
    }
}