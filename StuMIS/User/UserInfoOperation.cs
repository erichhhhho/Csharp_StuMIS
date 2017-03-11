using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace StuMIS.User
{
    class UserInfoOperation
    {
        private static DataAccess dataAccess = new DataAccess();
        //数据插入
        public static bool insertUserInfo(UserInfoData data)
        {
            string sql = "insert into User_Login(UserID,UserName,UserPwd,UserRight) VALUE('" +
                data.UserID + "','" + data.UserName + "','" + data.UserPwd + "','" + "'" + data.UserRight + "')";
            return dataAccess.ExecuteSQL(sql);
        }
        //数据更新
        public static bool updateUserInfo(UserInfoData data)
        {
            string sql = "update User_Login set UserPwd='" + data.UserPwd + "',UserRight='" + data.UserRight + "' where UserName='" + data.UserName + "'";
            return dataAccess.ExecuteSQL(sql);
        }
        //数据删除
        public static bool deleteUserInfo(String userName)
        {
            string sql = "delete from User_Login where UserName='" + userName + "'";
            return dataAccess.ExecuteSQL(sql);
        }

        public static DataSet getUserInfo(UserInfoData data)
        {
            string sql = "";
            if (data.UserName != null && data.UserName != "")
            {
                sql += "and UserName='" + data.UserName + "'";
            }
            if (data.UserRight != null && data.UserRight != "")
            {
                sql += "and UserRight='" + data.UserRight + "'";
            }
            string sql1 = "select UserName 用户名,UserRight 用户权限 from User_Login where 2=2 " + sql;
            return dataAccess.GetDataSet(sql1, "User_Login");
        }

        public static DataSet getUserInfoAll(UserInfoData data)
        {
            string sql = "";
            if (data.UserName != null && data.UserName != "")
            {
                sql += "UserName='" + data.UserName + "'";
            }
            if (data.UserRight != null && data.UserRight != "")
            {
                sql += "and UserRight='" + data.UserRight + "'";
            }
            string sql1 = "select UserName 用户名,UserPwd 用户密码,UserRight 用户权限 from User_Login where " + sql;
            return dataAccess.GetDataSet(sql1, "User_Login");
        }
    }
}
