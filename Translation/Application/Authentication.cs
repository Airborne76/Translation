using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Translation.Application
{
    public class Authentication
    {
        public static void SetCookie(string UserName, string PassWord)
        {
            String UserData = UserName + "#" + PassWord;
            if (true)
            {
                //数据放入ticket
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, UserName, DateTime.Now, DateTime.Now.AddMinutes(60), false, UserData);
                //数据加密
                string enyTicket = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, enyTicket);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }
        //是否登录
        public static bool isLogin()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }
        //注销登录
        public static void logOut()
        {
            FormsAuthentication.SignOut();
        }
        //获取用户名
        public static string getUserName()
        {
            if (isLogin())
            {
                string strUserData = ((FormsIdentity)(HttpContext.Current.User.Identity)).Ticket.UserData;
                string[] UserData = strUserData.Split('#');
                if (UserData.Length != 0)
                {
                    return UserData[0].ToString();
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }
    }
}