using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

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
            JArray ja = (JArray)JsonConvert.DeserializeObject(JSONString);
            return ja;

        }
    }
}