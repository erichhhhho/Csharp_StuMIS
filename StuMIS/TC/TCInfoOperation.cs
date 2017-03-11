using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace StuMIS.TC
{
    class TCInfoOperation
    {
        private static DataAccess dataAccess = new DataAccess();
        //插入教学信息
        public static bool insertTCInfo(TC.TCInfoData TCInfo)
        {
            string sql = "insert into TC(Tno,Cno) VALUES ('" + TCInfo.Tno + "','" + TCInfo.Cno + "')";
            return dataAccess.ExecuteSQL(sql);
        }
        //修改教学信息
        public static bool updateTCInfo(TC.TCInfoData TCInfo)
        {
            string sql = "update TC set Tno='" + TCInfo.New_tno + "', Cno='" + TCInfo.New_cno + "' where Tno='" + TCInfo.Tno + "'And Cno = '" + TCInfo.Cno + "'";
            return dataAccess.ExecuteSQL(sql);
        }
        //删除教学信息
        public static bool deleteTCInfo(string tno, string cno)
        {
            string sql = "delete from TC where Tno='" + tno + "' AND Cno='" + cno + "'";
            return dataAccess.ExecuteSQL(sql);
        }
        //获取查询教学信息
        public static DataSet getTCInfo(TC.TCInfoData TCInfo)
        {
            string condition = "";
            if (TCInfo.Tno != null && TCInfo.Tno != "")
            {
                condition += "and Tno='" + TCInfo.Tno + "'";
            }
            if (TCInfo.Cno != null && TCInfo.Cno != "")
            {
                condition += "and Cno='" + TCInfo.Cno + "'";
            }
            string sql = "select Tno 教师号,Cno 课程号 from TC where 2=2 " + condition;
            return dataAccess.GetDataSet(sql, "TC");
        }

    }
}
