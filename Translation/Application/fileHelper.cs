using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Translation.Application
{
    public class fileHelper
    {
        public fileHelper()
        {

        }
        //读取文件返回字符
        public static string FileStreamReader(string fileName)
        {
            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string s = "";
                    string fileStr="";
                    while ((s = sr.ReadLine()) != null)
                    {
                        fileStr += s;
                    }
                    return fileStr;
                }
            }
            catch(Exception e)
            {
                return e.Message;
            }

        }

    }
}