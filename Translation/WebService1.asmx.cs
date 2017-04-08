using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Translation.Application;
using Translation.model;

namespace Translation
{
    /// <summary>
    /// WebService1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        [WebMethod]
        public translationInfo Submit(string username, string text, string textId, string time)
        {
            string sqlInsertStr = "insert into translation(textId,username,translatedText,updateTime)";
            string sqlUpdateStr = $"update translation set username='{username}',translatedText='{text}',updateTime='{time}' where textId='{textId}'";
            sqlInsertStr += $"values('{textId}','{username}','{text}','{time}')";
            string sqlSelectStr = $"select count(*) from translation where textId='{textId}'";
            if (username.Trim() == "" || text.Trim() == "" || textId.Trim() == "" || time.Trim() == "")
            {
                return null;
            }
            try
            {
                if (Convert.ToInt16(SQLHelper.GetExecuteScalar(sqlSelectStr)) == 0)
                {
                    SQLHelper.GetExecuteNonQuery(sqlInsertStr);

                }
                else
                {
                    SQLHelper.GetExecuteNonQuery(sqlUpdateStr);
                }
                return new translationInfo() { Username = username, Text = text, TextId = textId, Time = time };

            }
            catch (Exception)
            {

                return null;
            }
        }

    }
}
