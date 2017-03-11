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

namespace StuMIS.UserItem
{
    public partial class User_Password_Edit : Form
    {
        public User_Password_Edit()
        {
            InitializeComponent();
            User.UserInfoData data = new User.UserInfoData();
            data.UserName = User.Constants.UserName;
            DataSet ds = new DataSet();
            ds = User.UserInfoOperation.getUserInfoAll(data);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Trim() != textBox4.Text.Trim())
            {
                MessageBox.Show("两次密码输入不一致！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (textBox2.Text.Trim() != User.Constants.UserPassword)
            {
                MessageBox.Show("旧密码错误！！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                User.UserInfoData data = new User.UserInfoData();
                data.UserName = this.textBox1.Text;
                data.UserPwd = this.textBox3.Text;
                data.UserRight = User.Constants.UserRight;
                if (User.UserInfoOperation.updateUserInfo(data))
                {
                    MessageBox.Show("修改成功！", "Succeed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("修改失败！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                MessageBox.Show("修改失败！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void User_Password_Edit_Load(object sender, EventArgs e)
        {
            textBox1.Text = User.Constants.UserName;
        }
    }
}
