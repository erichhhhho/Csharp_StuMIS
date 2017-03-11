using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuMIS.SC
{
    class StuGradeData
    {
        private string sno = "";
        private string cno = "";
        private string score = "";

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

        public string SCORE
        {
            get
            {
                return score;
            }

            set
            {
                score = value;
            }
        }
    }
}
