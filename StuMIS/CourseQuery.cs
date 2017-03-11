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
    public partial class CourseQuery : Form
    {
        public CourseQuery()
        {
            InitializeComponent();
        }

        private void SelectBtn_Click(object sender, EventArgs e)
        {
            if (this.CnoText.Text.Trim() == "")
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
                cmd.CommandText = "select * from Course where Cno='" + this.CnoText.Text.Trim() + "'";
                cmd.Connection = conn;

                //datareader读取数据
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    CnameText.Text = reader.GetString(1);
                    ChourText.Text = Convert.ToString(reader.GetInt16(2));
                    CcreditText.Text = Convert.ToString(reader.GetInt16(3));
                }
                else
                {
                    MessageBox.Show("抱歉！没有找到相关信息！请重新输入", "提示");
                    CnoText.Text = "";
                }
                conn.Close();
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
