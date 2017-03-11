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
    public partial class User_Right_Edit : Form
    {
        SqlConnection conn;

        SqlCommand cmd;

        SqlDataAdapter sda;

        public User_Right_Edit()
        {
            InitializeComponent();
        }
        private void GetInfo()
        {
            SqlDataReader sdr;
            conn.Open();
            sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            comboBox1.Items.Clear();
            while (sdr.Read())
            {
                comboBox1.Items.Add(sdr.GetValue(1));
            }
            comboBox2.Items.Add("超级管理员");
            comboBox2.Items.Add("教师");
            comboBox2.Items.Add("学生");
            sdr.Close();
            //comboBox1.SelectedIndex = 0;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Trim() == "" || comboBox2.Text.Trim() == "")
            {
                MessageBox.Show("修改内容不能为空", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                User.UserInfoData data = new User.UserInfoData();
                data.UserName = this.comboBox1.Text.Trim();
                data.UserRight = this.comboBox2.Text.Trim();
                data.UserPwd = User.Constants.UserPassword;
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

        private void User_Right_Edit_Load(object sender, EventArgs e)
        {
            string connString = "server=.;database=jiaoxuedb;uid=sa;pwd=960109";
            conn = new SqlConnection(connString);

            cmd = new SqlCommand();
            cmd.CommandText = "select * from User_Login";
            cmd.Connection = conn;
            sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds, "User_Login");

            GetInfo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
