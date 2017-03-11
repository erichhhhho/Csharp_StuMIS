using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuMIS.Course
{
    class CourseInfoData
    {
        private string cno;
        private string cname;
        private string chour;
        private string ccredit;
        public string Cno
        {
            get
            {
                return cno;
            }

            set
            {
                cno = value;
            }
        }

        public string Cname
        {
            get
            {
                return cname;
            }

            set
            {
                cname = value;
            }
        }

        public string Chour
        {
            get
            {
                return chour;
            }

            set
            {
                chour = value;
            }
        }

        public string Ccredit
        {
            get
            {
                return ccredit;
            }

            set
            {
                ccredit = value;
            }
        }
    }
}
