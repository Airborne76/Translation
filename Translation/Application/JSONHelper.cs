using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using Translation.model;

namespace Translation.Application
{
    public class JSONHelper
    {
        //public static string JSONToObject(string JSONString)
        //{
        //    List<JSONData> textInfo= JsonConvert.DeserializeObject

        //}
        //JSON反序列化
        public static JArray DeserializeJSON(string JSONString)
        {
            try
            {
                JArray ja = (JArray)JsonConvert.DeserializeObject(JSONString);
                return ja;
            }
            catch (System.Exception)
            {

                return null;
            }               
        }
        public static string SerializeJSON(List<translatedTextInfo> translatedTextInfolist)
        {
            return JsonConvert.SerializeObject(translatedTextInfolist);
        }
    }
}