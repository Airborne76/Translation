using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Translation.Application
{
    public class MD5Helper
    {
        //MD5加密 32位
        public static string UseMd5(string str)
        {
            string cl = str;
            string pwd = "";
            MD5 md5 = MD5.Create();
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
            for (int i = 0; i < s.Length; i++)
            {        
                pwd = pwd + s[i].ToString("X");
            }
            return pwd;
        }
    }
}