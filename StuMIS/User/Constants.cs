using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuMIS.User
{
    class Constants
    {
        private static string username = "";
        private static string userright = "";
        private static string userpassword = "";
        public static string UserName
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

        public static string UserRight
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

        public static string UserPassword
        {
            get
            {
                return userpassword;
            }

            set
            {
                userpassword = value;
            }
        }
    }
}
