using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuMIS.User
{
    class UserInfoData
    {
        private string userid = "";
        private string username = "";
        private string userpwd = "";
        private string userright = "";
        public string UserID
        {
            get { return userid; }
            set { userid = value; }
        }

        public string UserName
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public string UserPwd
        {
            get
            {
                return userpwd;
            }

            set
            {
                userpwd = value;
            }
        }

        public string UserRight
        {
            get
            {
                return userright;
            }

            set
            {
                userright = value;
            }
        }
    }
}
