using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace StuMIS.User
{
    class getUserInfoAll
    {
        private static DataAccess dataAccess = new DataAccess();
        public static DataSet GetUserInfoAll(UserInfoData data)
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
