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
                string filePath = Server.MapPath("File/") + DateTime.Now.Year+ DateTime.Now.Month+ DateTime.Now.Day+ DateTime.Now.Hour+ DateTime.Now.Minute+ DateTime.Now.Second + FileUpload1.FileName;
                FileUpload1.SaveAs(filePath);
                string JSONString = fileHelper.FileStreamReader(filePath);
                JArray ja = JSONHelper.DeserializeJSON(JSONString);
                string s="";
               for(int i = 0; i < ja.Count; i++)
                {
                    JObject o = (JObject)ja[i];
                    s += "KEY:" +o["key"].ToString();
                    s += "TEXT:" + o["text"].ToString();
                }
                Label1.Text = s;

            }
        }
    }
}