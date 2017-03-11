using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace StuMIS
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = Username.Text.Trim();
            string password = Password.Text.Trim();
            if (username != "" && password != "")
            {
                DataAccess data = new DataAccess();
                if (data.CheckAdmin(username, password))
                {
                    User.Constants.UserName = username;
                    User.Constants.UserPassword = password;
                    main fmain = new main();
                    this.Hide();
                    fmain.Show();
                }
                else
                {
                    MessageBox.Show("You Prabably mistype your Password or UserName", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Password.Text = "";
                    Username.Text = "";
                    Username.Focus();
                }
            }
            else
            {
                MessageBox.Show("Please Type your Password and UserName", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Password.Text = "";
                Username.Focus();
            }
            //SqlDataReader sqlread = boperate.getread("select UserName,UserPwd from User_Login where UserName='" + Username.Text.Trim() + "' and UserPwd='" + Password.Text.Trim() + "'");
            //sqlread.Read();
            //if (sqlread.HasRows)
            //{
            //    M_str_name = Username.Text;
            //    M_str_pwd = Password.Text.Trim();
            //    main fmain = new main();
            //    this.Hide();
            //    fmain.Show();
            //}
            //else
            //{
            //    MessageBox.Show("用户名或密码错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    Password.Text = "";
            //    Username.Focus();
            //}
            //sqlread.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "||Current Time: " + System.DateTime.Now.ToString();
        }
    }
}
