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
                JArray ja = JSONHelper.DeserializeJSON(JSONString);
                //测试用
                //坑了我一晚上
                string s = "";
                for (int i = 0; i < ja.Count; i++)
                {
                    JObject o = (JObject)ja[i];
                    sqlInsert = $"insert into textinfo(Id,[key],text,projectname) values('{datetime+i}','{o["key"].ToString()}','{ o["text"].ToString()}','{ProjectName.Text}')";
                    SQLHelper.GetExecuteNonQuery(sqlInsert);
                    s += "KEY:" + o["key"].ToString();
                    s += "TEXT:" + o["text"].ToString();
                }
                Label1.Text = s;

            }
        }
    }
}