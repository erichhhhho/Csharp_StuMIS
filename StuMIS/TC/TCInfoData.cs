using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace StuMIS.TC
{
    class TCInfoData
    {
        private string tno;
        private string cno;
        private string new_tno;
        private string new_cno;

        public string Tno
        {
            get
            {
                return tno;
            }

            set
            {
                tno = value;
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

        public string New_tno
        {
            get
            {
                return new_tno;
            }

            set
            {
                new_tno = value;
            }
        }

        public string New_cno
        {
            get
            {
                return new_cno;
            }

            set
            {
                new_cno = value;
            }
        }
    }
}
