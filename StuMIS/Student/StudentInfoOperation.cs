using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace StuMIS.Student
{
    class StudentInfoOperation
    {
        private static DataAccess dataAccess = new DataAccess();
        //插入学生记录
        public static bool insertStudentInfo(Student.StudentInfoData data)
        {
            string sql = "insert into Student(Sno,Sname,Sex,Grade,Dept) values('" + data.Sno + "','" + data.Sname + "','" + data.Sex + "'," + data.Grade + ",'" + data.Dept + "')";
            return dataAccess.ExecuteSQL(sql);
        }
        //修改学生信息
        public static bool updateStudentInfo(Student.StudentInfoData data)
        {
            string sql = "update Student set Sname='" + data.Sname + "',Sex='" + data.Sex + "',Grade=" + data.Grade + ",Dept='" + data.Dept + "' where Sno='" + data.Sno + "'";
            return dataAccess.ExecuteSQL(sql);
        }
        //删除学生信息
        public static bool deleteStudentInfo(string Sno)
        {
            string sql = "delete from Student where Sno='" + Sno + "'";
            return dataAccess.ExecuteSQL(sql);
        }
        //获取查询学生信息
        public static DataSet getStudentInfo(Student.StudentInfoData data)
        {
            string condition = "";
            if (data.Sno != null && data.Sno != "")
            {
                condition += "and Sno='" + data.Sno + "'";
            }
            if (data.Sname != null && data.Sname != "")
            {
                condition += "and Sname='" + data.Sname + "'";
            }
            if (data.Sex != null && data.Sex != "")
            {
                condition += "and Sex='" + data.Sex + "'";
            }
            if (data.Grade != null && data.Grade != "")
            {
                condition += "and Grade='" + data.Grade + "'";
            }
            if (data.Dept != null && data.Dept != "")
            {
                condition += "and Dept='" + data.Dept + "'";
            }
            string sql = "select Sno StudentNumber,Sname StudentName, Sex,Grade,Dept Department from Student where 2=2 " + condition;
            return dataAccess.GetDataSet(sql, "Student");
        }
    }
}
