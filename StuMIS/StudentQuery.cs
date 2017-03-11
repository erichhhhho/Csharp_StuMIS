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
    public partial class StudentQuery : Form
    {
        public StudentQuery()
        {
            InitializeComponent();
        }

        private void SelectBtn_Click(object sender, EventArgs e)
        {
            if (this.SnoText.Text.Trim() == "")
            {
                MessageBox.Show("请输入要查询的课程编号！", "提示");
            }
            else
            {
                //connection连接数据库
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "server=.;database=jiaoxuedb;uid=sa;pwd=960109";
                conn.Open();

                //command访问数据库
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from Student where Sno='" + this.SnoText.Text.Trim() + "'";
                cmd.Connection = conn;

                //datareader读取数据
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    SnameText.Text = reader.GetString(1);
                    GradeText.Text = Convert.ToString(reader.GetInt32(3));
                    DeptText.Text = reader.GetString(4);
                    if (reader.GetString(2) == "男")
                        radioButton1.Checked = true;
                    else
                        radioButton2.Checked = true;
                }
                else
                {
                    MessageBox.Show("抱歉！没有找到相关信息！请重新输入", "提示");
                    SnoText.Text = "";

                }
                conn.Close();
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SnoText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
