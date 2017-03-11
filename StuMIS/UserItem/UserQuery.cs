using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StuMIS.UserItem
{
    public partial class UserQuery : Form
    {
        DataSet ds = new DataSet();
        public UserQuery()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Username = comboBox1.Text.Trim();
            string UserRight = comboBox2.Text;
            
            User.UserInfoData data = new User.UserInfoData();

            data.UserName = Username;
            data.UserRight = UserRight;
      

            try
            {
                ds = User.UserInfoOperation.getUserInfo(data);
                this.dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void UserQuery_Load(object sender, EventArgs e)
        {

            User.UserInfoData data = new User.UserInfoData();
            ds = User.UserInfoOperation.getUserInfo(data);
            this.dataGridView1.DataSource = ds.Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index = this.dataGridView1.CurrentRow.Index;
            if (index < 0)
            {
                MessageBox.Show("请选择要删除的记录！", "提示");
                return;
            }
            else
            {
                if (MessageBox.Show("确定要删除吗？", "删除后无法撤回", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string tno = ds.Tables[0].Rows[index]["教师号"].ToString();
                    try
                    {
                        if (Teacher.TeacherInfoOperation.deleteTeacherInfo(tno))
                        {
                            MessageBox.Show("删除成功!", "提示");
                            //binddatagrid
                            string Username = comboBox1.Text.Trim();
                            string UserRight = comboBox2.Text;

                            User.UserInfoData data = new User.UserInfoData();

                            data.UserName = Username;
                            data.UserRight = UserRight;

                            try
                            {
                                ds = User.UserInfoOperation.getUserInfo(data);
                                this.dataGridView1.DataSource = ds.Tables[0];
                            }
                            catch (Exception ex)
                            {
                                ex.ToString();
                            }
                        }
                        else
                        {
                            MessageBox.Show("删除失败", "错误");
                        }
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                        MessageBox.Show("删除失败", "错误");
                    }
                }
            }
        }
    }
}
