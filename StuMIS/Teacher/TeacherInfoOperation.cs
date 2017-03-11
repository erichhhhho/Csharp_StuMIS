using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace StuMIS.Teacher
{
    class TeacherInfoOperation
    {
        private static DataAccess dataAccess = new DataAccess();
        //插入教师记录
        public static bool insertTeacherInfo(Teacher.TeacherInfoData data)
        {
            string sql = "insert into Teacher(Tno,Tname,Sex,Age,Prof,Sal,Comm,Dept) values('" + data.Tno + "','" + data.Tname + "','" + data.Sex + "'," + data.Age + ",'" + data.Prof + "'," + data.Sal + "," + data.Comm + ",'" + data.Dept + "')";
            return dataAccess.ExecuteSQL(sql);
        }
        //修改教师信息
        public static bool updateTeacherInfo(Teacher.TeacherInfoData data)
        {
            string sql = "update Teacher set Tname='" + data.Tname + "',Sex='" + data.Sex + "',Age=" + data.Age + ",Prof='" + data.Prof + "',Sal=" + data.Sal + ",Comm=" + data.Comm + ",Dept='" + data.Dept + "' where Tno='" + data.Tno + "'";
            return dataAccess.ExecuteSQL(sql);
        }
        //删除教师信息
        public static bool deleteTeacherInfo(string tno)
        {
            string sql = "delete from Teacher where Tno='" + tno + "'";
            return dataAccess.ExecuteSQL(sql);
        }
        //获取查询教师信息
        public static DataSet getTeacherInfo(Teacher.TeacherInfoData data)
        {
            string condition = "";
            if (data.Tno != null && data.Tno != "")
            {
                condition += "and Tno='" + data.Tno + "'";
            }
            if (data.Tname != null && data.Tname != "")
            {
                condition += "and Tname='" + data.Tname + "'";
            }
            if (data.Sex != null && data.Sex != "")
            {
                condition += "and Sex='" + data.Sex + "'";
            }
            if (data.Age != null && data.Age != "")
            {
                condition += "and Age='" + data.Age + "'";
            }
            if (data.Prof != null && data.Prof != "")
            {
                condition += "and Prof='" + data.Prof + "'";
            }
            if (data.Sal != null && data.Sal != "")
            {
                condition += "and Sal='" + data.Sal + "'";
            }
            if (data.Comm != null && data.Comm != "")
            {
                condition += "and Comm='" + data.Comm + "'";
            }
            if (data.Dept != null && data.Dept != "")
            {
                condition += "and Dept='" + data.Dept + "'";
            }
            string sql = "select Tno 教师号,Tname 教师名, Sex 性别,Age 年龄,Prof 职称,Sal 薪水,Comm 津贴,Dept 所教专业 from Teacher where 2=2 " + condition;
            return dataAccess.GetDataSet(sql, "Teacher");
        }
    }
}
