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
        private static SqlDataAdapter da = new SqlDataAdapter();
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
        //查询数据库,返回返回结果(用于select)
        public static object GetExecuteScalar(string sqlStr)
        {
            OpenConnection();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlStr;
            object result = cmd.ExecuteScalar();
            CloseConnection();
            return result;
        }
        //查询数据库,返回返回个数(用于insert,update,delete)
        public static int GetExecuteNonQuery(string sqlStr)
        {
            OpenConnection();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlStr;
            int result = cmd.ExecuteNonQuery();
            CloseConnection();
            return result;
        }
        //返回DataTable
        public static DataTable GetDataTable(string sqlStr)
        {
            OpenConnection();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlStr;
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            CloseConnection();
            return dt;            
        }

    }
}