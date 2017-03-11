using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace StuMIS.SC
{
    class StuGradeOperation
    {
        private static DataAccess dataAccess = new DataAccess();
        //插入成绩信息
        public static bool insertStuGrade(SC.StuGradeData stuGrade)
        {
            string sql = "insert into SC(Sno,Cno,SCORE) values (" + stuGrade.Sno + ",'" + stuGrade.Cno + "'," + stuGrade.SCORE + ")";
            return dataAccess.ExecuteSQL(sql);
        }
        //修改成绩信息
        public static bool updateStuGrade(SC.StuGradeData stuGrade)
        {
            string sql = "update SC set SCORE=" + stuGrade.SCORE + " where Sno='" + stuGrade.Sno + "' AND Cno='" + stuGrade.Cno + "'";
            return dataAccess.ExecuteSQL(sql);
        }
        //删除成绩信息
        public static bool deleteStuGrade(string sno, string cno)
        {
            string sql = "delete from SC where Sno='" + sno + "' AND Cno='" + cno + "'";
            return dataAccess.ExecuteSQL(sql);
        }
        //获取查询成绩信息
        public static DataSet getStuGrade(SC.StuGradeData stuGrade)
        {
            string condition = "";
            if (stuGrade.Sno != null && stuGrade.Sno != "")
            {
                condition += "and Sno='" + stuGrade.Sno + "'";
            }
            if (stuGrade.Cno != null && stuGrade.Cno != "")
            {
                condition += "and Cno='" + stuGrade.Cno + "'";
            }
            string sql = "select Sno,Cno, SCORE from SC where 2=2 " + condition;
            return dataAccess.GetDataSet(sql, "SC");
        }

    }
}
