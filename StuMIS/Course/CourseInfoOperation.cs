using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace StuMIS.Course
{
    class CourseInfoOperation
    {

        private static DataAccess dataAccess = new DataAccess();
        //插入课程记录
        public static bool insertCourseInfo(Course.CourseInfoData data)
        {
            string sql = "insert into Course(Cno,Cname,Chour,Ccredit) values('" + data.Cno + "','" + data.Cname + "'," + data.Chour + "," + data.Ccredit + ")";
            return dataAccess.ExecuteSQL(sql);
        }
        //修改课程信息
        public static bool updateCourseInfo(Course.CourseInfoData data)
        {
            string sql = "update Course set Cname='" + data.Cname + "',Chour=" + data.Chour + ",Ccredit=" + data.Ccredit + " where Cno='" + data.Cno + "'";
            return dataAccess.ExecuteSQL(sql);
        }
        //删除课程信息
        public static bool deleteCourseInfo(string cno)
        {
            string sql = "delete from Course where Cno='" + cno + "'";
            return dataAccess.ExecuteSQL(sql);
        }
        //获取查询课程信息
        public static DataSet getCourseInfo(Course.CourseInfoData data)
        {
            string condition = "";
            if (data.Cno != null && data.Cno != "")
            {
                condition += "and Cno='" + data.Cno + "'";
            }
            if (data.Cname != null && data.Cname != "")
            {
                condition += "and Cname='" + data.Cname + "'";
            }
            if (data.Chour != null && data.Chour != "")
            {
                condition += "and Chour='" + data.Chour + "'";
            }
            if (data.Ccredit != null && data.Ccredit != "")
            {
                condition += "and Ccredit='" + data.Ccredit + "'";
            }
            string sql = "select Cno 课程号,Cname 课程名, Chour 课时,Ccredit 学分 from Course where 2=2 " + condition;
            return dataAccess.GetDataSet(sql, "Course");
        }


    }
}
