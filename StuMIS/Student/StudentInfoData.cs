using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuMIS.Student
{
    class StudentInfoData
    {
        private string sno = "";
        private string sname = "";
        private string sex = "";
        private string grade = "";
        private string dept = "";

        public string Sno
        {
            get
            {
                return sno;
            }

            set
            {
                sno = value;
            }
        }

        public string Sname
        {
            get
            {
                return sname;
            }

            set
            {
                sname = value;
            }
        }

        public string Sex
        {
            get
            {
                return sex;
            }

            set
            {
                sex = value;
            }
        }

        public string Grade
        {
            get
            {
                return grade;
            }

            set
            {
                grade = value;
            }
        }

        public string Dept
        {
            get
            {
                return dept;
            }

            set
            {
                dept = value;
            }
        }
    }
}
