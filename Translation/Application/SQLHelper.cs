using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Translation.Application
{
    public class SQLHelper
    {
        public SQLHelper()
        {

        }
        private static SqlConnection conn = new SqlConnection();
        private static SqlCommand cmd = new SqlCommand();
        //连接关闭数据库
        public static void OpenConnection()
        {
            if (conn.State == ConnectionState.Closed)
            {
                string connString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
                conn.ConnectionString = connString;
                cmd.Connection = conn;
                conn.Open();
            }
        }
        public static void CloseConnection()
        {
            if(conn.State== ConnectionState.Open)
            {
                conn.Close();
            }
            
        }
        //查询数据库,返回返回结果
        public static object GetExecuteScalar(string sqlStr)
        {
            OpenConnection();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlStr;
            object result = cmd.ExecuteScalar();
            CloseConnection();
            return result;
        }
        //查询数据库,返回返回个数
        public static int GetExecuteNonQuery(string sqlStr)
        {
            OpenConnection();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlStr;
            int result = cmd.ExecuteNonQuery();
            CloseConnection();
            return result;
        }


        //string sqlStr = "Data Source = 2012-20130910SA\\SQLEXPRESS;Initial Catalog = TRDB; Integrated Security = True; Connect Timeout = 15; Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

    }
}